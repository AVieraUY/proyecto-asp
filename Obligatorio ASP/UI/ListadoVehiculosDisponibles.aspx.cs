using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Negocio;

public partial class ListadoVehiculosDisponibles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Listar()
    {
        negVehiculo negVehiculo = new negVehiculo();
        lstVehiculosDisponibles.DataSource = negVehiculo.ListarVehiculosDisponibles(Convert.ToDateTime(clnFechaUno.Value), Convert.ToDateTime(clnFechaDos.Value));
        lstVehiculosDisponibles.DataBind();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            Listar();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private void LimpioFormulario()
    {
        clnFechaUno.Value = "";
        clnFechaDos.Value = "";
        lstVehiculosDisponibles = null;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}