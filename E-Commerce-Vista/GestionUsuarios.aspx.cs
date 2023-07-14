using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce_Vista
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) {
                Response.Redirect("Default.aspx",false);
            
            }


            UsuarioNegocio negocio = new UsuarioNegocio();

            if (!IsPostBack)
            {
                if (int.Parse(Request.QueryString["id"]) == 1)
                {
                    Session.Add("listaClientes", negocio.listarClientesConSp());

                    dgvClientes.DataSource = Session["listaClientes"];
                    dgvClientes.DataBind();
                }


                else if (int.Parse(Request.QueryString["id"]) == 2)
                {

                    Session.Add("listaAdmin", negocio.listarAdminsConSp());

                    dgvAdmins.DataSource = Session["listaAdmin"];
                    dgvAdmins.DataBind();
                }

            }


        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            var id = dgvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCliente.aspx?id=" + id);

        }

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientes.PageIndex = e.NewPageIndex;
            dgvClientes.DataBind();


        }

        protected void dgvAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvAdmins.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioAdmin.aspx?id=" + id);


        }

        protected void dgvAdmins_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvAdmins.PageIndex = e.NewPageIndex;
            dgvAdmins.DataBind();


        }

        protected void FiltroApellido_TextChanged(object sender, EventArgs e)
        {

            if (txtFiltroApellido.Text != "" || txtFiltrarPorApellidoAdmin.Text != "")
            {
                if (int.Parse(Request.QueryString["id"]) == 1)
                {
                    List<Cliente> listaApellido = (List<Cliente>)Session["listaClientes"];
                    List<Cliente> listaFiltrada = listaApellido.FindAll(x => x.Apellido.ToUpper().Contains(txtFiltroApellido.Text.ToUpper()));
                    dgvClientes.DataSource = listaFiltrada;
                    dgvClientes.DataBind();
                }
                else
                {

                    List<Admin> listaApellido = (List<Admin>)Session["listaAdmin"];
                    List<Admin> listaFiltrada = listaApellido.FindAll(x => x.Email.ToUpper().Contains(txtFiltrarPorApellidoAdmin.Text.ToUpper()));
                    dgvAdmins.DataSource = listaFiltrada;
                    dgvAdmins.DataBind();


                }
            }
        }

        protected void Dni_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroDni.Text != "")
            {
                if (soloNumeros(txtFiltroDni.Text))
                {
                    List<Cliente> listaDni = (List<Cliente>)Session["listaClientes"];
                    List<Cliente> listaFiltrada = listaDni.FindAll(x => x.Dni.Contains(txtFiltroDni.Text));
                    dgvClientes.DataSource = listaFiltrada;
                    dgvClientes.DataBind();
                    txtFiltroDni.CssClass = "form-control";
                    errorDni.InnerText = "";
                }
                else
                {

                    txtFiltroDni.CssClass = "form-control is-invalid";
                    errorDni.InnerText = "Este Campo solo Acepta numeros";

                }
            }

        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if ((char.IsNumber(caracter)))
                    return true;
            }
            return false;
        }

        protected void txtFiltrarMail_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltrarMail.Text != "" || txtFiltrarPorMailAdmin.Text != "")
            {
                if (int.Parse(Request.QueryString["id"]) == 1)
                {
                    List<Cliente> listaMail = (List<Cliente>)Session["listaClientes"];
                    List<Cliente> listaFiltrada = listaMail.FindAll(x => x.Email.ToUpper().Contains(txtFiltrarMail.Text.ToUpper()));
                    dgvClientes.DataSource = listaFiltrada;
                    dgvClientes.DataBind();
                }
                else
                {

                    List<Admin> listaMail = (List<Admin>)Session["listaAdmin"];
                    List<Admin> listaFiltrada = listaMail.FindAll(x => x.Email.ToUpper().Contains(txtFiltrarPorMailAdmin.Text.ToUpper()));
                    dgvAdmins.DataSource = listaFiltrada;
                    dgvAdmins.DataBind();


                }
            }
        }
    }



}