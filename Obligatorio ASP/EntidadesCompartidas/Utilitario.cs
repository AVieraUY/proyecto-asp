using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Utilitario:Vehiculo
    {
        //Atributos
        private int _capacidadCarga;
        private string _tipoUtilitario;

        //Propiedades
        public int CapacidadCarga
        {
            get 
            {
                return _capacidadCarga;
            }
            set 
            {
                if (value > 0)
                {
                    _capacidadCarga = value;
                }
                else
                {
                    throw new Exception("Error: Capacidad de carga");
                }
            }
        }

        public string TipoUtilitario
        {
            get 
            {
                return _tipoUtilitario;
            }
            set 
            {
                if (value.ToLower() == "furgoneta" || value.ToLower() == "pickup")
                {
                    _tipoUtilitario = value;
                }
                else 
                {
                    throw new Exception("Error: Tipo de utilitario");
                }
                
            }
        }

        //Constructor
        public Utilitario(string pMatricula, string pMarca, string pModelo, int pAño, int pCantPuerta, decimal pCostoAlquiler, int pCapCarga, string pTipoUti)
            :base (pMatricula, pMarca, pModelo, pAño, pCantPuerta, pCostoAlquiler)
        {
            CapacidadCarga = pCapCarga;
            TipoUtilitario = pTipoUti; 
        }

        public override string ToString()
        {
            return (base.ToString() + " | Capacidad de carga: " + CapacidadCarga + " | \nTipo de utilitario: " + TipoUtilitario);
        }

    }
}
