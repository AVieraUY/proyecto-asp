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
    public class negAlquiler
    {
        public void Agregar(Alquiler alquiler)
        {
            perAlquiler pa = new perAlquiler();
            int r = pa.Agregar(alquiler);

            switch (r)
            {
                case -1:
                    throw new Exception("No existe el cliente.");
                case -2:
                    throw new Exception("No existe el vehículo.");
                case -3:
                    throw new Exception("El vehículo se encuentra alquilado durante esa fecha.");
                case -4:
                    throw new Exception("Debe realizar un alquiler de por lo menos 1 día.");
                case -5:
                    throw new Exception("Error desconocido.");
                default:
                    break;

            }
        }

        public decimal CalcularCostoAlquiler(string matricula, DateTime fechainicio, DateTime fechafin)
        {
            perAlquiler pa = new perAlquiler();
            decimal r = pa.CalcularCostoAlquiler(matricula, fechainicio, fechafin);
            return r;
        }

        public List<Alquiler> ListarAlquileres(string matricula)
        {
            negVehiculo nv = new negVehiculo();
            Vehiculo vehiculo = nv.Buscar(matricula);

            perAlquiler pa = new perAlquiler();

            List<Alquiler> lista = pa.ListarAlquileres(matricula);
            foreach (Alquiler alquiler in lista)
            {
                alquiler.Vehiculo = vehiculo;
            }

            return lista;
        }

        public decimal TotalRecaudado(string matricula)
        {
            perAlquiler pa = new perAlquiler();
            decimal r = pa.TotalRecaudado(matricula);
            return r;
        }
    }
}
