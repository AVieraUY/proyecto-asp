using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Negocio;

public partial class TotalRecaudadoPorVehiculos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Consultar()
    {
        negAlquiler negAlquiler = new negAlquiler();
        lstAlquileres.DataSource = negAlquiler.ListarAlquileres(txtMatricula.Text);
        lstAlquileres.DataBind();
        txtTotal.Text = (negAlquiler.TotalRecaudado(txtMatricula.Text)).ToString();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            Consultar();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}