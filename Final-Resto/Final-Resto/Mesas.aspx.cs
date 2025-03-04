using System;
using System.Web.UI;
using Negocio;
using Dominio;
using System.Collections.Generic;

namespace Final_Resto
{
    public partial class Mesas : Page
    {
        MesaNegocio negocio = new MesaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMesas();
            }
        }

        private void CargarMesas()
        {
            gvMesa.DataSource = negocio.listarMesa();
            gvMesa.DataBind();
        }

        protected void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMesa.Text))
            {
                Mesa nuevaMesa = new Mesa
                {
                    NumeroMesa = int.Parse(txtMesa.Text),
                    CapacidadMesa = 4, // Capacidad por defecto
                    Disponible = 1 // Disponible al crearse
                };

                negocio.AgregarMesa(nuevaMesa);
                txtMesa.Text = "";
                CargarMesas();
            }
        }

        protected void btnModificarMesa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdMesa.Text))
            {
                modificar.Visible = true; // Mostrar el formulario de modificación
            }
        }

        protected void btnAceptarModificacion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdMesa.Text) && !string.IsNullOrWhiteSpace(txtNuevoNombre.Text))
            {
                Mesa mesaModificada = new Mesa
                {
                    IdMesa = int.Parse(txtIdMesa.Text),
                    NumeroMesa = int.Parse(txtNuevoNombre.Text),
                    Disponible = 1, // Supongamos que al modificar sigue disponible
                    CapacidadMesa = 4 // Se mantiene la capacidad
                };

                negocio.ModificarMesa(mesaModificada);
                txtIdMesa.Text = "";
                txtNuevoNombre.Text = "";
                modificar.Visible = false;
                CargarMesas();
            }
        }

        protected void btnEliminarMesa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdMesa.Text))
            {
                negocio.EliminarMesa(int.Parse(txtIdMesa.Text));
                txtIdMesa.Text = "";
                CargarMesas();
            }
        }
    }
}
