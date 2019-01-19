using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Negocio;

public partial class MantenimientoClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void LimpioFormulario()
    {
        txtCedula.Text = "";
        txtNombre.Text = "";
        txtTarjeta.Text = "";
        txtTelefono.Text = "";
        txtDireccion.Text = "";
        clnFechaNacimiento.Value = "";
    }

    private void DesactivoBotones()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            negCliente negCliente = new negCliente();
            Cliente cliente = negCliente.Buscar(txtCedula.Text, true);

            txtNombre.Text = cliente.NombreCompleto;
            txtTarjeta.Text = cliente.TarjetaCredito;
            txtTelefono.Text = cliente.Telefono;
            txtDireccion.Text = cliente.Direccion;
            clnFechaNacimiento.Value = (cliente.FechaNacimiento).ToString();

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = false;
        }
        catch (Exception ex)
        {
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Cliente cliente = new Cliente(txtCedula.Text, txtNombre.Text, txtTarjeta.Text, txtTelefono.Text, txtDireccion.Text, Convert.ToDateTime(clnFechaNacimiento.Value));
            negCliente negCliente = new negCliente();
            negCliente.Agregar(cliente);
            lblError.Text = "Se agregó el cliente con éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string cedula = txtCedula.Text;
            negCliente negCliente = new negCliente();
            Cliente cliente = negCliente.Buscar(cedula, true);

            cliente.NombreCompleto = txtNombre.Text;
            cliente.TarjetaCredito = txtTarjeta.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.FechaNacimiento = Convert.ToDateTime(clnFechaNacimiento.Value);

            negCliente.Modificar(cliente);
            lblError.Text = "Se ha realizado la modificación con éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally
        {
            LimpioFormulario();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            negCliente negCliente = new negCliente();
            string cedula = txtCedula.Text;
            negCliente.Eliminar(cedula);
            lblError.Text = "Se eliminó el cliente con éxito.";

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        finally
        {
            LimpioFormulario();
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
        this.DesactivoBotones();
    }
}