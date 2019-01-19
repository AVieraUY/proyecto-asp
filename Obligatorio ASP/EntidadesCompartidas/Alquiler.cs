using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Alquiler
    {
        //Atributos
        private int _id;
        private Cliente _cliente;
        private Vehiculo _vehiculo;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;

        //Propiedades
        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                _cliente = value;
            }
        }

        public Vehiculo Vehiculo
        {
            get
            {
                return _vehiculo;
            }
            set
            {
                _vehiculo = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return _fechaInicio;
            }
            set
            {
                if (true)//value.Date >= DateTime.Now.Date
                {
                    _fechaInicio = value;
                }
                else
                {
                    throw new Exception("Error: Fecha de inicio");
                }
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return _fechaFin;
            }
            set
            {
                TimeSpan dif = value.Subtract(FechaInicio);

                if (dif.TotalDays > 0)
                {
                    _fechaFin = value;
                }
                else
                {
                    throw new Exception("Debe haber una diferencia de 1 día como mínimo.");
                }
            }
        }

        public decimal Costo
        {
            get
            {
                int cantDias = (_fechaFin.Subtract(_fechaInicio)).Days;
                return (this._vehiculo.CostoAlquiler * cantDias);
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value >= 0)
                    _id = value;
                else
                    throw new Exception("Error: Id de Alquiler");
            }
        }


        //Constructor
        public Alquiler(Cliente pCliente, Vehiculo pVehiculo, DateTime pFechainicio, DateTime pFechafin)
        {
            Cliente = pCliente;
            Vehiculo = pVehiculo;
            FechaInicio = pFechainicio;
            FechaFin = pFechafin;
        }

        public override string ToString()
        {
            return "Matrícula: " + Vehiculo.Matricula + " | Cédula de cliente: " + Cliente.Cedula + " | Fecha de inicio: " + FechaInicio.ToShortDateString() + " | Fecha fin: " + FechaFin.ToShortDateString() + " | Costo total: " + Costo;
        }

    }
}
