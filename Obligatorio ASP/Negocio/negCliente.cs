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
    public class negCliente
    {
        public void Agregar(Cliente cliente)
        {
            perCliente pc = new perCliente();

            int r = pc.Agregar(cliente);

            switch (r)
            {
                case -1:
                    {
                        throw new Exception("Ya existe el cliente.");
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

        public Cliente Buscar(string cedula, bool chequearNull)
        {
            perCliente pc = new perCliente();

            Cliente cliente = pc.Buscar(cedula);

            if (chequearNull && cliente == null)
                throw new Exception("No existe el cliente.");

            return cliente;
        }

        public void Modificar(Cliente cliente)
        {
            perCliente pc = new perCliente();

            int r = pc.Modificar(cliente);

            switch (r)
            {
                case -1:
                    {
                        throw new Exception("No existe el cliente.");
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

        public void Eliminar(string cedula)
        {
            perCliente pc = new perCliente();
            int r = pc.Eliminar(cedula);

            if (r == 0)
                throw new Exception("No existe el cliente.");
            else if (r == -1)
                throw new Exception("El cliente posee alquileres.");
        }
    }
}
