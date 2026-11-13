using BellezaTotal_BE.Auditoria;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Personas;
using BellezaTotal_DAL.Clases;
using BellezaTotal_SEC.Clases;
using BellezaTotal_MAPPER.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BellezaTotal_BLL.Clases.xml
{
    public class ClientesXmlBLL
    {
        private readonly ClientesBLL clientesBll = new ClientesBLL();
        private readonly ClientesDAL clientesDal = new ClientesDAL();
        private readonly BitacoraBLL bitacora = new BitacoraBLL();

        // Exporta todos los clientes activos a un archivo XML. Devuelve la cantidad exportada.
        public int Exportar(string ruta)
        {
            List<Cliente> clientes = clientesBll.Listar();

            if (clientes.Count == 0)
                throw new ExcepcionNegocio("EXP_SinClientesParaExportar");
          
            XMLHelper<List<Cliente>>.Serializar(clientes, ruta);

            bitacora.Registrar(
                AccionesBitacora.ExportacionClientes,
                SeveridadBitacora.Info,
                clientes.Count + " clientes exportados");

            return clientes.Count;
        }

        public ResultadoImportacion Importar(string ruta)
        {
            List<Cliente> clientes = XMLHelper<List<Cliente>>.Deserializar(ruta);

            if (clientes == null || clientes.Count == 0)
                throw new ExcepcionNegocio("EXP_XmlSinClientes");

            
            HashSet<int> dnis = clientesDal.ObtenerDnisRegistrados();

            ResultadoImportacion resultado = new ResultadoImportacion();

            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente cliente = clientes[i];

                try
                {
                    if (cliente == null)
                        throw new ExcepcionNegocio("EXP_ClienteXmlVacio");

                    Normalizar(cliente);

                    if (cliente.DNI < 1 || cliente.DNI > 99999999)
                        throw new ExcepcionNegocio("EXP_DNIInvalido");

                    if (dnis.Contains(cliente.DNI))
                        throw new ExcepcionNegocio("EXP_ClienteDuplicadoDNI");

                    clientesBll.Alta(cliente);

                    dnis.Add(cliente.DNI);
                    resultado.Importados++;
                }
                catch (ExcepcionNegocio ex)
                {
                    resultado.Errores.Add(NuevoError(i + 1, cliente, ex.Codigo));
                }
                catch (Exception ex)
                {
                    resultado.Errores.Add(NuevoError(i + 1, cliente, ex.Message));
                }
            }

            bitacora.Registrar(
                AccionesBitacora.ImportacionClientes,
                resultado.Errores.Count == 0 ? SeveridadBitacora.Info : SeveridadBitacora.Warning,
                resultado.Importados + " importados, " + resultado.Errores.Count + " omitidos");

            return resultado;
        }

        
        private void Normalizar(Cliente cliente)
        {
            cliente.ClienteId = 0;
            cliente.Activo = true;
            cliente.Nombre = cliente.Nombre == null ? null : cliente.Nombre.Trim();
            cliente.Apellido = cliente.Apellido == null ? null : cliente.Apellido.Trim();
            cliente.Email = cliente.Email == null ? null : cliente.Email.Trim();
            cliente.Telefono = cliente.Telefono == null ? null : cliente.Telefono.Trim();

            if (cliente.FichaTecnicaAlergias == null) cliente.FichaTecnicaAlergias = new BindingList<string>();
            if (cliente.FichaTecnicaAfecciones == null) cliente.FichaTecnicaAfecciones = new BindingList<string>();
            if (cliente.FichaTecnicaContraindicaciones == null) cliente.FichaTecnicaContraindicaciones = new BindingList<string>();
        }

        private ErrorImportacion NuevoError(int posicion, Cliente cliente, string motivo)
        {
            return new ErrorImportacion
            {
                Posicion = posicion,
                DNI = cliente == null ? 0 : cliente.DNI,
                Motivo = motivo
            };
        }
    }
}
