using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;
using Persistencia;

namespace Negocio
{
    public class negUtilitario
    {
        public void Agregar(Utilitario utilitario)
        {
            perUtilitario pu = new perUtilitario();

            int r = pu.Agregar(utilitario);

            switch (r)
            {
                case -1:
                    {
                        throw new Exception("Ya existe el utilitario.");
                    }
                case 0:
                    {
                        break;
                    }
                default:
                    {
                        throw new Exception("Error desconocido.");
                    }
            }
        }

        public Utilitario Buscar(string matricula, bool chequearNull)
        {
            perUtilitario pu = new perUtilitario();

            Utilitario utilitario = pu.Buscar(matricula);

            if (utilitario == null)
            {
                negAuto negAuto = new negAuto();
                Auto auto = negAuto.Buscar(matricula, false);
                if (auto != null)
                    throw new Exception("La matrícula ingresada pertenece a un auto.");
                else if (chequearNull && utilitario == null && auto == null)
                    throw new Exception("No existe el utilitario.");
            }

            return utilitario;
        }

        public void Modificar(Utilitario utilitario)
        {
            perUtilitario pu = new perUtilitario();

            int r = pu.Modificar(utilitario);

            switch (r)
            {
                case -1:
                    {
                        throw new Exception("No existe el utilitario.");
                    }
                case 0:
                    {
                        break;
                    }
                default:
                    {
                        throw new Exception("Error desconocido.");
                    }
            }
        }
    }
}
