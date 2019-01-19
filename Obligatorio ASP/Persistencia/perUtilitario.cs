using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perUtilitario
    {
        public int Agregar(Utilitario utilitario)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("AgregarUtilitario", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", utilitario.Matricula));
            cmd.Parameters.Add(new SqlParameter("Modelo", utilitario.Modelo));
            cmd.Parameters.Add(new SqlParameter("Marca", utilitario.Marca));
            cmd.Parameters.Add(new SqlParameter("Anio", utilitario.Año));
            cmd.Parameters.Add(new SqlParameter("CantidadPuertas", utilitario.CantidadPuertas));
            cmd.Parameters.Add(new SqlParameter("CostoDiario", utilitario.CostoAlquiler));
            cmd.Parameters.Add(new SqlParameter("CapacidadCarga", utilitario.CapacidadCarga));
            cmd.Parameters.Add(new SqlParameter("Tipo", utilitario.TipoUtilitario));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }

        public Utilitario Buscar(string matricula)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("BuscarUtilitario", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", matricula));

            SqlDataReader dr = cmd.ExecuteReader();

            Utilitario utilitario = null;

            while (dr.Read())
            {
                utilitario = new Utilitario(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), Convert.ToInt32(dr["capacidad_carga"].ToString()), dr["tipo"].ToString());
            }

            Conexion.Desconectar();

            return utilitario;
        }

        public int Modificar(Utilitario utilitario)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("ModificarUtilitario", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", utilitario.Matricula));
            cmd.Parameters.Add(new SqlParameter("Modelo", utilitario.Modelo));
            cmd.Parameters.Add(new SqlParameter("Marca", utilitario.Marca));
            cmd.Parameters.Add(new SqlParameter("Anio", utilitario.Año));
            cmd.Parameters.Add(new SqlParameter("CantidadPuertas", utilitario.CantidadPuertas));
            cmd.Parameters.Add(new SqlParameter("CostoDiario", utilitario.CostoAlquiler));
            cmd.Parameters.Add(new SqlParameter("CapacidadCarga", utilitario.CapacidadCarga));
            cmd.Parameters.Add(new SqlParameter("Tipo", utilitario.TipoUtilitario));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }
    }
}
