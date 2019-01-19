using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perAlquiler
    {
        public int Agregar(Alquiler alquiler)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("AgregarAlquiler", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", alquiler.Vehiculo.Matricula));
            cmd.Parameters.Add(new SqlParameter("Cedula", alquiler.Cliente.Cedula));
            cmd.Parameters.Add(new SqlParameter("FechaInicio", alquiler.FechaInicio));
            cmd.Parameters.Add(new SqlParameter("FechaFin", alquiler.FechaFin));

            SqlParameter r = new SqlParameter();
            r.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }

        public decimal CalcularCostoAlquiler(string matricula, DateTime fechainicio, DateTime fechafin)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("CalcularCostoAlquiler", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", matricula));
            cmd.Parameters.Add(new SqlParameter("FechaInicio", fechainicio));
            cmd.Parameters.Add(new SqlParameter("FechaFin", fechafin));

            SqlParameter r = new SqlParameter();
            r.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToDecimal(r.Value);
        }

        public List<Alquiler> ListarAlquileres(string matricula)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("ListadoAlquileres", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", matricula));

            SqlDataReader dr = cmd.ExecuteReader();

            List<Alquiler> lista = new List<Alquiler>();

            while (dr.Read())
            {
                Cliente cliente = new Cliente(dr["cedula"].ToString(), dr["nombre_completo"].ToString(), dr["tarjeta_credito"].ToString(), dr["telefono"].ToString(), dr["direccion"].ToString(), Convert.ToDateTime(dr["fecha_nacimiento"].ToString()));
                Alquiler alquiler = new Alquiler(cliente, null, Convert.ToDateTime(dr["fecha_inicio"]), Convert.ToDateTime(dr["fecha_fin"]));
                lista.Add(alquiler);
            }

            Conexion.Desconectar();

            return lista;
        }

        public decimal TotalRecaudado(string matricula)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("TotalRecaudado", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Matricula", matricula));

            SqlParameter r = new SqlParameter();
            r.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToDecimal(r.Value);
        }
    }
}
