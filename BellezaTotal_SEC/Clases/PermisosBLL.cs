using BellezaTotal_BE.Familias;
using BellezaTotal_DAL.Clases;
using System;
using System.Collections.Generic;

namespace BellezaTotal_SEC.Clases
{
    public class PermisosBLL
    {
        public List<Permiso> ObtenerPermisosEfectivos(int usuarioId)
        {
            PermisosDAL accesoDatos = new PermisosDAL();
            List<Permiso> permisosAsignados = accesoDatos.ObtenerPermisosAsignados(usuarioId);

            return AplanarSinRepetidos(permisosAsignados);
        }


        private List<Permiso> AplanarSinRepetidos(List<Permiso> permisosAsignados)
        {
            List<Permiso> patentesResultado = new List<Permiso>();
            HashSet<string> nombresYaAgregados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (Permiso permisoAsignado in permisosAsignados)
            {
                foreach (Patente patente in permisoAsignado.ObtenerPatentes())
                {
                    bool esPrimeraVez = nombresYaAgregados.Add(patente.Nombre);

                    if (esPrimeraVez)
                        patentesResultado.Add(patente);
                }
            }

            return patentesResultado;
        }
    }
}