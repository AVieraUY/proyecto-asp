using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Auto: Vehiculo
    { 
        //Atributo
        private string _tipoAnclaje;

        //Propiedades
        public string TipoAnclaje
        {
            get 
            {
                return _tipoAnclaje;
            }
            set 
            {
                if (value.ToLower() == "latch" || value.ToLower() == "isofix" || value.ToLower() == "cinturón")
                {
                    _tipoAnclaje = value;
                }
                else 
                {
                    throw new Exception("Error: Tipo de anclaje");
                }
                
            }
        }

        //Constructor
        public Auto(string pMatricula, string pMarca, string pModelo, int pAño, int pCantPuerta, decimal pCostoAlquiler, string pTipoAnclaje)
            :base(pMatricula, pMarca, pModelo, pAño, pCantPuerta, pCostoAlquiler)
        {
            TipoAnclaje = pTipoAnclaje;
        }

        public override string ToString()
        {
            return (base.ToString() + " | Tipo de silla: " + TipoAnclaje);
        }
    }

}
