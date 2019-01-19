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
    public class negAuto
    {
        public void Agregar(Auto auto)
        {
            perAuto pa = new perAuto();

            int r = pa.Agregar(auto);

            switch (r)
            {
                case -1:
                    {
                        throw new Exception("Ya existe el auto.");
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

        public Auto Buscar(string matricula, bool chequearNull)
        {
            perAuto pa = new perAuto();

            Auto auto = pa.Buscar(matricula);

            if (chequearNull && auto == null)
            {
                /*negUtilitario negUtilitario = new negUtilitario();
                Utilitario utilitario = negUtilitario.Buscar(matricula, false);
                if (utilitario != null)
                    throw new Exception("La matrícula ingresada pertenece a un utilitario.");
                else if (chequearNull && utilitario == null && auto == null)*/
                    throw new Exception("No existe el auto.");
            }


            return auto;
        }

        public void Modificar(Auto auto)
        {
            perAuto pa = new perAuto();

            int r = pa.Modificar(auto);

            switch (r)
            {
                case -1:
                    {
                        throw new Exception("No existe el auto.");
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
