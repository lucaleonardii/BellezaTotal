using BellezaTotal_BE.Familias;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MPP
{
    public class PermisosMPP
    {
        // Devuelve lo que tiene asignado el usuario: familias (con su árbol armado) y patentes directas
        public List<Permiso> ArmarPermisosAsignados(
            DataTable tablaPatentes,
            DataTable tablaFamilias,
            DataTable tablaFamiliaPatente,
            DataTable tablaFamiliaFamilia,
            DataTable tablaFamiliasDelUsuario,
            DataTable tablaPatentesDelUsuario)
        {
            
            Dictionary<int, Patente> patentePorId = new Dictionary<int, Patente>();
            foreach (DataRow filaPatente in tablaPatentes.Rows)
            {
                int patenteId = (int)filaPatente["PatenteId"];
                patentePorId[patenteId] = new Patente
                {
                    PermisoId = patenteId,
                    Nombre = (string)filaPatente["Nombre"]
                };
            }

            Dictionary<int, Familia> familiaPorId = new Dictionary<int, Familia>();
            foreach (DataRow filaFamilia in tablaFamilias.Rows)
            {
                int familiaId = (int)filaFamilia["FamiliaId"];
                familiaPorId[familiaId] = new Familia
                {
                    PermisoId = familiaId,
                    Nombre = (string)filaFamilia["Nombre"]
                };
            }

            
            foreach (DataRow filaRelacion in tablaFamiliaPatente.Rows)
            {
                Familia familia = familiaPorId[(int)filaRelacion["FamiliaId"]];
                Patente patente = patentePorId[(int)filaRelacion["PatenteId"]];
                familia.Agregar(patente);
            }

            // 3) Qué familias contiene cada familia
            foreach (DataRow filaRelacion in tablaFamiliaFamilia.Rows)
            {
                Familia familiaPadre = familiaPorId[(int)filaRelacion["FamiliaPadreId"]];
                Familia familiaHija = familiaPorId[(int)filaRelacion["FamiliaHijaId"]];
                familiaPadre.Agregar(familiaHija);
            }

            // 4) Lo que tiene asignado este usuario
            List<Permiso> permisosAsignados = new List<Permiso>();

            foreach (DataRow filaUsuarioFamilia in tablaFamiliasDelUsuario.Rows)
            {
                permisosAsignados.Add(familiaPorId[(int)filaUsuarioFamilia["FamiliaId"]]);
            }

            foreach (DataRow filaUsuarioPatente in tablaPatentesDelUsuario.Rows)
            {
                permisosAsignados.Add(patentePorId[(int)filaUsuarioPatente["PatenteId"]]);
            }

            return permisosAsignados;
        }
    }
}