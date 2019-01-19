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
    public class negVehiculo
    {
        public Vehiculo Buscar(string matricula)
        {
            Vehiculo v = null;

            negAuto na = new negAuto();
            v = na.Buscar(matricula, false);

            if (v == null)
            {
                negUtilitario nu = new negUtilitario();
                v = nu.Buscar(matricula, false);

                if (v == null)
                    throw new Exception("No existe el vehículo.");
            }

            return v;
        }
        
        public void Eliminar(string matricula)
        {
            perVehiculo pv = new perVehiculo();
            int r = pv.Eliminar(matricula);

            if (r == 0)
                throw new Exception("No existe el vehículo.");
            else if (r == -1)
                throw new Exception("El vehículo posee alquileres asociados.");
            else if (r < 0)
                throw new Exception("Error desconocido.");
        }

        public List<Vehiculo> Listar()
        {
            perVehiculo pv = new perVehiculo();
            return pv.Listar();
        }

        public List<Vehiculo> ListarVehiculosDisponibles(DateTime fechauno, DateTime fechados)
        {
            perVehiculo pv = new perVehiculo();
            return pv.ListarVehiculosDisponibles(fechauno, fechados);
        }
    }
}
