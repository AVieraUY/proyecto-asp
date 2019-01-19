using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class perCliente
    {
        public int Agregar(Cliente cliente)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("AgregarCliente", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Cedula", cliente.Cedula));
            cmd.Parameters.Add(new SqlParameter("TarjetaCredito", cliente.TarjetaCredito));
            cmd.Parameters.Add(new SqlParameter("NombreCompleto", cliente.NombreCompleto));
            cmd.Parameters.Add(new SqlParameter("FechaNacimiento", cliente.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("Telefono", cliente.Telefono));
            cmd.Parameters.Add(new SqlParameter("Direccion", cliente.Direccion));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }

        public Cliente Buscar(string cedula)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("BuscarCliente", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Cedula", cedula));

            SqlDataReader dr = cmd.ExecuteReader();

            Cliente cliente = null;

            while (dr.Read())
            {
                cliente = new Cliente(dr["cedula"].ToString(), dr["nombre_completo"].ToString(), dr["tarjeta_credito"].ToString(), dr["telefono"].ToString(), dr["direccion"].ToString(), Convert.ToDateTime(dr["fecha_nacimiento"].ToString()));
            }

            Conexion.Desconectar();

            return cliente;
        }

        public int Modificar(Cliente cliente)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("ModificarCliente", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Cedula", cliente.Cedula));
            cmd.Parameters.Add(new SqlParameter("TarjetaCredito", cliente.TarjetaCredito));
            cmd.Parameters.Add(new SqlParameter("NombreCompleto", cliente.NombreCompleto));
            cmd.Parameters.Add(new SqlParameter("FechaNacimiento", cliente.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("Telefono", cliente.Telefono));
            cmd.Parameters.Add(new SqlParameter("Direccion", cliente.Direccion));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }

        public int Eliminar(string cedula)
        {
            Conexion.Conectar();

            SqlCommand cmd = new SqlCommand("EliminarCliente", Conexion.cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Cedula", cedula));

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            Conexion.Desconectar();

            return Convert.ToInt32(r.Value);
        }
    }
}
