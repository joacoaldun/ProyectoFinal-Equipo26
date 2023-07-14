using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace E_Commerce_Vista
{
    public partial class FormularioMarca : System.Web.UI.Page
    {
        string imgReemplazo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
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
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                confirmarEliminar = false;
                verId = false;

                if (id!="" && !IsPostBack)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    List<Marca> temporal = negocio.listar();
                    Marca seleccionada = temporal.Find(x => x.Id == int.Parse(id));

                    txtId.Text = seleccionada.Id.ToString();
                    txtId.ReadOnly = true;
                    txtNombreMarca.Text = seleccionada.NombreMarca;
                    txtImagenUrl.Text = seleccionada.ImagenMarca;
                    imgMarca.ImageUrl = txtImagenUrl.Text;
                    txtNombreMarca.CssClass = "form-control is-valid";
                    txtImagenUrl.CssClass = "form-control is-valid";
                    modificando = true;
                    updatePanelMarca.Update();

                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }


        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {   
            imgMarca.ImageUrl = txtImagenUrl.Text;

            if (string.IsNullOrEmpty(txtImagenUrl.Text.Trim()))
            {
                imgMarca.ImageUrl = imgReemplazo;
                txtImagenUrl.CssClass = "form-control is-invalid";
            }
            else
            {
                txtImagenUrl.CssClass = "form-control is-valid";
            }

            updatePanelMarca.Update();
        }

        public bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombreMarca.Text.Trim()))
            {
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(txtImagenUrl.Text.Trim()))
                {
                    return false;
                }
                else
                {
                    
                    return true;
                }
            }
            
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {


                if (validarFormulario())
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca nuevaMarca = new Marca();

                    nuevaMarca.NombreMarca = txtNombreMarca.Text;
                    nuevaMarca.ImagenMarca = txtImagenUrl.Text;

                    if (Request.QueryString["id"] != null)
                    {
                        nuevaMarca.Id = int.Parse(txtId.Text);
                        negocio.modificar(nuevaMarca);
                    }
                    else
                    {
                        negocio.agregar(nuevaMarca);
                    }
                    


                }
                else
                {
                    return;
                }

                Response.Redirect("GestionMarcas.aspx", false);

                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void txtNombreMarca_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreMarca.Text.Trim()))
            {   
                txtNombreMarca.CssClass = "form-control is-invalid";
            }
            else
            {
                txtNombreMarca.CssClass = "form-control is-valid";
            }
            updatePanelMarca.Update();
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
                    MarcaNegocio negocio = new MarcaNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("GestionMarcas.aspx");
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