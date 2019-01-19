using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public abstract class Vehiculo
    {

        //Atributos
        private string _matricula;
        private string _marca;
        private string _modelo;
        private int _año;
        private int _cantidadPuertas;
        private decimal _costoAlquiler;

        //Propiedades
        public string Matricula
        {
            get{ return _matricula; }
            
            set 
            {               
                if (value.Length == 7)
                {
                    for (int i = 0; i < value.Length; i++) 
                    {
                        if (i < 3) 
                        {
                            //Comprueba los tres primeros lugares, verifica que sean letras
                            if (!Char.IsLetter(Convert.ToChar(value.Substring(i, 1))))
                            {
                                throw new Exception("Error en el formato de la matrícula");
                            }
                        }
                        else 
                        {
                            //Ultimos cuatro lugares, comprueba si son numeros
                            if (!Char.IsDigit(Convert.ToChar(value.Substring(i, 1)))) 
                            {
                                throw new Exception("Error en el formato de la matrícula");
                            }
                        }
                    }

                    _matricula = value;

                }
                else 
                {
                    throw new Exception("Error: La matrícula posee una longitud incorrecta (Deben ser 7 dígitos, por ejemplo: ABC1234)");
                }
            }
        }

        public string Marca
        {
            get
            {
                return _marca;
            }
            set 
            {
                if (value.Length > 0)
                {
                    _marca = value;
                }
                else 
                {
                    throw new Exception("Error: Marca");
                }
                
            }
        }

        public string Modelo 
        {
            get 
            {
                return _modelo;
            }
            set 
            {
                if (value.Length > 0)
                {
                    _modelo = value;
                }
                else
                {
                    throw new Exception("Error: Modelo");
                }                
            }

        }

        public int Año        
        {
            get 
            {
                return _año;
            }
            set 
            {
                if (value > 1980)
                {
                    _año = value;
                }
                else
                {
                    throw new Exception("Error: Año");
                }
            }
        }

        public int CantidadPuertas 
        {
            get 
            {
                return _cantidadPuertas;
            }
            set 
            {
                if (value > 0 && value <= 5)
                {
                    _cantidadPuertas = value;
                }
                else
                {
                    throw new Exception("Error: Cantidad de puertas");
                }
            }
        }

        public decimal CostoAlquiler
        {
            get 
            {
                return _costoAlquiler;
            }
            set 
            {
                if (value > 0)
                {
                    _costoAlquiler = value;
                }
                else
                {
                    throw new Exception("Error: Costo de alquiler");

                }
            }
        }

        //Constructor
        public Vehiculo(string pMatricula, string pMarca, string pModelo, int pAño, int pCantPuerta, decimal pCostoAlquiler)
        {
            Matricula = pMatricula;
            Marca = pMarca;
            Modelo = pModelo;
            Año = pAño;
            CantidadPuertas = pCantPuerta;
            CostoAlquiler = pCostoAlquiler; 
        }

        public override string ToString()
        {
            return ("Matricula: " + Matricula.ToUpper() + " \nMarca: " + Marca + " | Modelo: " + Modelo + " | Año: " + Año + " \nCantidad de puertas: " + CantidadPuertas + " | Costo de alquiler: " + CostoAlquiler);
        }
    }
}
