using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Servicios;
using BellezaTotal_DAL.Interfaces;
using BellezaTotal_MAPPER.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BellezaTotal_DAL.Clases
{
    public class TurnosDAL : IABMC<Turno>
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public void Alta(Turno turno)
        {
            string consulta =
                "INSERT INTO Negocio.Turnos " +
                "(ClienteId, ProfesionalId, CabinaId, ServicioId, FechaHoraInicio, " +
                "DuracionMinutos, Estado, MotivoModificacion) " +
                "OUTPUT INSERTED.TurnoId " +
                "VALUES (@clienteId, @profesionalId, @cabinaId, @servicioId, @fecha, " +
                "@duracion, @estado, @motivo)";

            object[] valores = new TurnoMPP().ObtenerValores(turno);

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    AgregarParametros(comando, valores);
                    turno.TurnoId = Convert.ToInt32(comando.ExecuteScalar());
                }
            });
        }

        // Baja lógica: el turno queda en estado Cancelado con su motivo
        public void Baja(Turno turno)
        {
            string consulta =
                "UPDATE Negocio.Turnos " +
                "SET Estado = @estado, MotivoModificacion = @motivo " +
                "WHERE TurnoId = @turnoId AND Estado IN (@programado, @enSala)";

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    comando.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = EstadoTurno.Cancelado.ToString();
                    comando.Parameters.Add("@motivo", SqlDbType.NVarChar, 200).Value = (object)turno.MotivoModificacion ?? DBNull.Value;
                    comando.Parameters.Add("@turnoId", SqlDbType.Int).Value = turno.TurnoId;
                    comando.Parameters.Add("@programado", SqlDbType.NVarChar, 20).Value = EstadoTurno.Programado.ToString();
                    comando.Parameters.Add("@enSala", SqlDbType.NVarChar, 20).Value = EstadoTurno.EnSala.ToString();

                    if (comando.ExecuteNonQuery() == 0)
                        throw new ExcepcionNegocio("EXP_TurnoEstadoInvalido");
                }
            });
        }

        // Reprogramación: solo se pueden modificar turnos en estado Programado
        public void Modificacion(Turno turno, int id)
        {
            string consulta =
                "UPDATE Negocio.Turnos " +
                "SET ClienteId = @clienteId, ProfesionalId = @profesionalId, CabinaId = @cabinaId, " +
                "ServicioId = @servicioId, FechaHoraInicio = @fecha, DuracionMinutos = @duracion, " +
                "MotivoModificacion = @motivo " +
                "WHERE TurnoId = @turnoId AND Estado = @programado";

            object[] valores = new TurnoMPP().ObtenerValores(turno);

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    AgregarParametros(comando, valores, false);
                    comando.Parameters.Add("@turnoId", SqlDbType.Int).Value = id;
                    comando.Parameters.Add("@programado", SqlDbType.NVarChar, 20).Value = EstadoTurno.Programado.ToString();

                    if (comando.ExecuteNonQuery() == 0)
                        throw new ExcepcionNegocio("EXP_TurnoEstadoInvalido");
                }
            });
        }

        public void CambiarEstado(int turnoId, EstadoTurno nuevoEstado)
        {
            string consulta =
                "UPDATE Negocio.Turnos SET Estado = @estado " +
                "WHERE TurnoId = @turnoId AND Estado NOT IN (@cancelado, @atendido)";

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    comando.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = nuevoEstado.ToString();
                    comando.Parameters.Add("@turnoId", SqlDbType.Int).Value = turnoId;
                    comando.Parameters.Add("@cancelado", SqlDbType.NVarChar, 20).Value = EstadoTurno.Cancelado.ToString();
                    comando.Parameters.Add("@atendido", SqlDbType.NVarChar, 20).Value = EstadoTurno.Atendido.ToString();

                    if (comando.ExecuteNonQuery() == 0)
                        throw new ExcepcionNegocio("EXP_TurnoEstadoInvalido");
                }
            });
        }

        public List<Turno> Listar()
        {
            string consulta =
                "SELECT t.TurnoId, t.FechaHoraInicio, t.DuracionMinutos, t.Estado, t.MotivoModificacion, " +
                "t.ServicioId, " +
                "c.ClienteId, c.Nombre AS ClienteNombre, c.Apellido AS ClienteApellido, c.DNI AS ClienteDNI, " +
                "p.ProfesionalId, p.UsuarioId AS ProfesionalUsuarioId, p.Nombre AS ProfesionalNombre, " +
                "p.Apellido AS ProfesionalApellido, p.EspecialidadId AS ProfesionalEspecialidadId, " +
                "e.Nombre AS EspecialidadNombre, " +
                "cab.CabinaId, cab.NumeroCabina, cab.Estado AS CabinaEstado " +
                "FROM Negocio.Turnos t " +
                "INNER JOIN Negocio.Clientes c ON c.ClienteId = t.ClienteId " +
                "INNER JOIN Negocio.Profesionales p ON p.ProfesionalId = t.ProfesionalId " +
                "LEFT JOIN Negocio.Especialidad e ON e.EspecialidadId = p.EspecialidadId " +
                "INNER JOIN Negocio.Cabinas cab ON cab.CabinaId = t.CabinaId " +
                "ORDER BY t.FechaHoraInicio";

            Dictionary<int, Servicio> catalogo = new ServiciosDAL()
                .ListarTodos()
                .ToDictionary(s => s.IdServicio);

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return new TurnoMPP().MapearLista(tabla, catalogo);
            }
        }

        private void AgregarParametros(SqlCommand comando, object[] valores, bool incluirEstado = true)
        {
            comando.Parameters.Add("@clienteId", SqlDbType.Int).Value = valores[1];
            comando.Parameters.Add("@profesionalId", SqlDbType.Int).Value = valores[2];
            comando.Parameters.Add("@cabinaId", SqlDbType.Int).Value = valores[3];
            comando.Parameters.Add("@servicioId", SqlDbType.Int).Value = valores[4];
            comando.Parameters.Add("@fecha", SqlDbType.DateTime2).Value = valores[5];
            comando.Parameters.Add("@duracion", SqlDbType.Int).Value = valores[6];

            if (incluirEstado)
                comando.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = valores[7];

            comando.Parameters.Add("@motivo", SqlDbType.NVarChar, 200).Value = valores[8] ?? DBNull.Value;
        }

        // Toda escritura se ejecuta en una transacción explícita con ROLLBACK ante cualquier fallo
        private void EjecutarEnTransaccion(Action<SqlConnection, SqlTransaction> accion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        accion(conexion, transaccion);
                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
