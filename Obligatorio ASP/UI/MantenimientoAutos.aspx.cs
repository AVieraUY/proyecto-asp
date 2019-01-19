using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Negocio;

public partial class MantenimientoAutos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void LimpioFormulario()
    {
        txtMatricula.Text = "";
        txtMarca.Text = "";
        txtModelo.Text = "";
        txtAnio.Text = "";
        txtCantidadPuertas.Text = "";
        txtCostoDiario.Text = "";
        txtTipoAnclaje.Text = "";
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
            negAuto negAuto = new negAuto();
            Auto auto = negAuto.Buscar(txtMatricula.Text, true);

            txtMarca.Text = auto.Marca;
            txtModelo.Text = auto.Modelo;
            txtAnio.Text = (auto.Año).ToString();
            txtCantidadPuertas.Text = (auto.CantidadPuertas).ToString();
            txtCostoDiario.Text = (auto.CostoAlquiler).ToString();
            txtTipoAnclaje.Text = auto.TipoAnclaje;

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
            Auto auto = new Auto(txtMatricula.Text, txtMarca.Text, txtModelo.Text, Convert.ToInt32(txtAnio.Text), Convert.ToInt32(txtCantidadPuertas.Text), Convert.ToDecimal(txtCostoDiario.Text), txtTipoAnclaje.Text);
            negAuto negAuto = new negAuto();
            negAuto.Agregar(auto);
            lblError.Text = "Se agregó el auto con éxito.";
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
            string matricula = txtMatricula.Text;
            negAuto negAuto = new negAuto();
            Auto auto = negAuto.Buscar(matricula, true);

            auto.Modelo = txtModelo.Text;
            auto.Marca = txtMarca.Text;
            auto.Año = Convert.ToInt32(txtAnio.Text);
            auto.CantidadPuertas = Convert.ToInt32(txtCantidadPuertas.Text);
            auto.CostoAlquiler = Convert.ToDecimal(txtCostoDiario.Text);
            auto.TipoAnclaje = txtTipoAnclaje.Text;

            negAuto.Modificar(auto);
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
            negVehiculo negVehiculo = new negVehiculo();
            string matricula = txtMatricula.Text;
            negVehiculo.Eliminar(matricula);
            lblError.Text = "Se eliminó el vehículo con éxito.";

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