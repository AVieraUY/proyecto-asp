using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        //Atributos
        private string _cedula;
        private string _nombreCompleto;
        private string _tarjetaCredito;
        private string _telefono;
        private string _direccion;
        private DateTime _fechaNacimiento;


        //Propiedades
        public string Cedula
        {
            get { return _cedula; }
            set
            {
                int entero = 0;
                bool isNum = int.TryParse(value, out entero);
                if (!isNum)
                    throw new Exception("Debe ingresar solo números.");

                if (value.Length < 7)
                    throw new Exception("Debe ingresar un documento válido.");

                _cedula = value;
            }
        }

        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set
            {
                if (value == String.Empty || value.Length < 3)
                    throw new Exception("Debe indicar nombre completo.");

                _nombreCompleto = value.ToUpper();
            }
        }
        public string TarjetaCredito
        {
            get { return _tarjetaCredito; }
            set
            {
                long entero = 0;
                bool isNum = long.TryParse(value, out entero);
                if (!isNum)
                    throw new Exception("Debe ingresar solo números.");

                if (value.Length != 16)
                    throw new Exception("Debe ingresar una tarjeta de crédito válida.");

                _tarjetaCredito = value;
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                int entero = 0;
                bool isNum = int.TryParse(value, out entero);
                if (!isNum)
                    throw new Exception("Debe ingresar solo números.");

                if (value.Length < 8 || value.Length > 9)
                    throw new Exception("Debe ingresar un teléfono válido.");

                _telefono = value;
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set
            {
                if (value == String.Empty || value.Length < 6)
                    throw new Exception("Debe indicar una dirección válida.");

                _direccion = value.ToUpper();
            }
        }

        public DateTime FechaNacimiento        
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                TimeSpan edad = DateTime.Now.Subtract(value);

                if ((edad.Days / 365.25) >= 25)
                {
                    _fechaNacimiento = value;
                }
                else 
                {
                    throw new Exception ("Debe tener al menos 25 años.");
                }
            }
        }

        //Constructores
        public Cliente(string pCedula, string pNombreCompleto, string pTarjetaCredito, string pTelefono, string pDireccion, DateTime pFechaNacimiento) 
        {
            NombreCompleto = pNombreCompleto;
            Cedula = pCedula;
            TarjetaCredito = pTarjetaCredito;
            Telefono = pTelefono;
            Direccion = pDireccion;
            FechaNacimiento = pFechaNacimiento;
        }

        public override string ToString()
        {
            return ("Nombre: " + NombreCompleto + " Cedula: " + Cedula + " Fecha de nacimiento: " + FechaNacimiento + " Telefono: " + Telefono + " Direccion: " + Direccion + " Tarjeta de credito: " + TarjetaCredito);
        }
    }
}
