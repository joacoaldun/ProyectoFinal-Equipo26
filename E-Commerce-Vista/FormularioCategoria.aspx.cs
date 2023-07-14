using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        public bool confirmarEliminar { get; set; }
        public bool modificando { get; set; }
        public bool verId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Default.aspx", false);

            }
            txtId.Enabled = false;
            try
            {
                modificando = false;
                confirmarEliminar = false;
                verId = false;
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if(id!="" && !IsPostBack)
                {
                    CategoriaNegocio negocio=new CategoriaNegocio();
                    List<Categoria> temporal = negocio.listar();
                    Categoria seleccionada = temporal.Find(x => x.Id == int.Parse(id));

                    txtId.Text = seleccionada.Id.ToString();
                    txtNombreCategoria.Text = seleccionada.NombreCategoria;
                    txtNombreCategoria.CssClass = "form-control is-valid";
                    modificando = true;
                    updatePanelCategoria.Update();

                }
               


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreCategoria.Text.Trim()))
            {
                txtNombreCategoria.CssClass = "form-control is-invalid";
            }
            else
            {
                txtNombreCategoria.CssClass = "form-control is-valid";
            }

            updatePanelCategoria.Update();
        }

        public bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombreCategoria.Text.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (validarFormulario())
                {
                    CategoriaNegocio negocio=new CategoriaNegocio();
                    Categoria nuevaCategoria=new Categoria();

                    nuevaCategoria.NombreCategoria = txtNombreCategoria.Text;
                    if (Request.QueryString["id"] != null)
                    {
                        nuevaCategoria.Id = int.Parse(txtId.Text);
                        negocio.modificar(nuevaCategoria);
                    }
                    else
                    {
                        negocio.agregar(nuevaCategoria);
                    }
                }
                else
                {
                    return;
                }

                Response.Redirect("GestionCategorias.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminar = true;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    CategoriaNegocio negocio=new CategoriaNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("GestionCategorias.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

       
    }
}