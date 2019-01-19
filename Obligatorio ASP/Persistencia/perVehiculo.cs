using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perVehiculo
    {
        public List<Vehiculo> Buscar(string matricula)
        {
            List<Vehiculo> lista = new List<Vehiculo>();

            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("BuscarAuto", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("matricula", matricula));

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Auto objAuto = new Auto(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), dr["tipo_anclaje"].ToString());
                lista.Add(objAuto);
            }

            Conexion.Desconectar();
            Conexion.Conectar();

            cmd = new SqlCommand("BuscarUtilitario", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("matricula", matricula));

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Utilitario objUtilitario = new Utilitario(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), Convert.ToInt32(dr["capacidad_carga"].ToString()), dr["tipo"].ToString());
                lista.Add(objUtilitario);
            }

            Conexion.Desconectar();

            return lista;
        }

        public int Eliminar(string matricula)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("EliminarVehiculo", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", matricula));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }

        public List<Vehiculo> Listar()
        {
            List<Vehiculo> lista = new List<Vehiculo>();

            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("ListarAutos", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Auto objAuto = new Auto(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), dr["tipo_anclaje"].ToString());
                lista.Add(objAuto);
            }

            Conexion.Desconectar();
            Conexion.Conectar();

            cmd = new SqlCommand("ListarUtilitarios", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Utilitario objUtilitario = new Utilitario(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), Convert.ToInt32(dr["capacidad_carga"].ToString()), dr["tipo"].ToString());
                lista.Add(objUtilitario);
            }

            Conexion.Desconectar();

            return lista;
        }

        public List<Vehiculo> ListarVehiculosDisponibles(DateTime fechauno, DateTime fechados)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("ListarVehiculosDisponibles", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("FechaUno", fechauno));
            cmd.Parameters.Add(new SqlParameter("FechaDos", fechados));

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Vehiculo vehiculo = null;

                if (dr["Tipo"] is DBNull)
                    vehiculo = new Auto(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), dr["tipo_anclaje"].ToString());
                else
                    vehiculo = new Utilitario(dr["matricula"].ToString(), dr["marca"].ToString(), dr["modelo"].ToString(), Convert.ToInt32(dr["anio"].ToString()), Convert.ToInt32(dr["cantidad_puertas"].ToString()), Convert.ToDecimal(dr["costo_diario"].ToString()), Convert.ToInt32(dr["capacidad_carga"].ToString()), dr["tipo"].ToString());

                vehiculos.Add(vehiculo);
            }

            Conexion.Desconectar();
            return vehiculos;
        }
    }
}
