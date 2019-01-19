using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Negocio;

public partial class MantenimientoUtilitarios : System.Web.UI.Page
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
        txtCapacidadCarga.Text = "";
        txtTipoUtilitario.Text = "";
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
            negUtilitario negUtilitario = new negUtilitario();
            Utilitario utilitario = negUtilitario.Buscar(txtMatricula.Text, true);

            txtMarca.Text = utilitario.Marca;
            txtModelo.Text = utilitario.Modelo;
            txtAnio.Text = (utilitario.Año).ToString();
            txtCantidadPuertas.Text = (utilitario.CantidadPuertas).ToString();
            txtCostoDiario.Text = (utilitario.CostoAlquiler).ToString();
            txtCapacidadCarga.Text = (utilitario.CapacidadCarga).ToString();
            txtTipoUtilitario.Text = utilitario.TipoUtilitario;

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
            Utilitario utilitario = new Utilitario(txtMatricula.Text, txtMarca.Text, txtModelo.Text, Convert.ToInt32(txtAnio.Text), Convert.ToInt32(txtCantidadPuertas.Text), Convert.ToDecimal(txtCostoDiario.Text), Convert.ToInt32(txtCapacidadCarga.Text), txtTipoUtilitario.Text);
            negUtilitario negUtilitario = new negUtilitario();
            negUtilitario.Agregar(utilitario);
            lblError.Text = "Se agregó el utilitario con éxito.";
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
            negUtilitario negUtilitario = new negUtilitario();
            Utilitario utilitario = negUtilitario.Buscar(matricula, true);

            utilitario.Modelo = txtModelo.Text;
            utilitario.Marca = txtMarca.Text;
            utilitario.Año = Convert.ToInt32(txtAnio.Text);
            utilitario.CantidadPuertas = Convert.ToInt32(txtCantidadPuertas.Text);
            utilitario.CostoAlquiler = Convert.ToDecimal(txtCostoDiario.Text);
            utilitario.CapacidadCarga = Convert.ToInt32(txtCapacidadCarga.Text);
            utilitario.TipoUtilitario = txtTipoUtilitario.Text;

            negUtilitario.Modificar(utilitario);
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