using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Negocio;

public partial class RealizarAlquiler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                negVehiculo negVehiculo = new negVehiculo(); // Fuente de datos para el Drop Down List
                cboVehiculos.DataSource = negVehiculo.Listar();
                cboVehiculos.DataValueField = "Matricula"; //Le marco que la matrícula es la PK para quedarme con el dato que selecciona el cliente
                cboVehiculos.DataTextField = "Modelo"; //Le marco que es lo que tiene que mostrar en el combo
                cboVehiculos.DataBind(); // Enlace, por defecto mostrará el ToString(), pero lo cambié arriba con los DataValue y DataText
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private void LimpioFormulario()
    {
        txtCedula.Text = "";
        cboVehiculos.Text = null;
        clnFechaInicio.Value = "";
        clnFechaFin.Value = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            negCliente negCliente = new negCliente();
            negVehiculo negVehiculo = new negVehiculo();
            Cliente cliente = negCliente.Buscar(txtCedula.Text, true);
            Vehiculo vehiculo = negVehiculo.Buscar((cboVehiculos.SelectedValue).ToString());
            Alquiler alquiler = new Alquiler(cliente, vehiculo, Convert.ToDateTime(clnFechaInicio.Value), Convert.ToDateTime(clnFechaFin.Value));
            negAlquiler negAlquiler = new negAlquiler();
            negAlquiler.Agregar(alquiler);
            lblError.Text = "Se agregó el alquiler con éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        try
        {
            negAlquiler negAlquiler = new negAlquiler();
            lblError.Text = "Costo total U$S " + (negAlquiler.CalcularCostoAlquiler((cboVehiculos.SelectedValue).ToString(), Convert.ToDateTime(clnFechaInicio.Value), Convert.ToDateTime(clnFechaFin.Value))).ToString();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}