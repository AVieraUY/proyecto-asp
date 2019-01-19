using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perAuto
    {
        public int Agregar(Auto auto)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("AgregarAuto", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", auto.Matricula));
            cmd.Parameters.Add(new SqlParameter("Modelo", auto.Modelo));
            cmd.Parameters.Add(new SqlParameter("Marca", auto.Marca));
            cmd.Parameters.Add(new SqlParameter("Anio", auto.Año));
            cmd.Parameters.Add(new SqlParameter("CantidadPuertas", auto.CantidadPuertas));
            cmd.Parameters.Add(new SqlParameter("CostoDiario", auto.CostoAlquiler));
            cmd.Parameters.Add(new SqlParameter("TipoAnclaje", auto.TipoAnclaje));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }

        public Auto Buscar(string matricula)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("BuscarAuto", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", matricula));

            SqlDataReader dr = cmd.ExecuteReader();

            Auto auto = null;

            while (dr.Read())
            {
                auto = new Auto(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), dr["tipo_anclaje"].ToString());
            }

            Conexion.Desconectar();

            return auto;
        }

        public int Modificar(Auto auto)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("ModificarAuto", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", auto.Matricula));
            cmd.Parameters.Add(new SqlParameter("Modelo", auto.Modelo));
            cmd.Parameters.Add(new SqlParameter("Marca", auto.Marca));
            cmd.Parameters.Add(new SqlParameter("Anio", auto.Año));
            cmd.Parameters.Add(new SqlParameter("CantidadPuertas", auto.CantidadPuertas));
            cmd.Parameters.Add(new SqlParameter("CostoDiario", auto.CostoAlquiler));
            cmd.Parameters.Add(new SqlParameter("TipoAnclaje", auto.TipoAnclaje));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }
    }
}
