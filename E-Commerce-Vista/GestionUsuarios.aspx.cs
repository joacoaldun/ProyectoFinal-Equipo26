using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace E_Commerce_Vista
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 

                
            UsuarioNegocio negocio = new UsuarioNegocio();

            if (!IsPostBack)
            {
                if (int.Parse(Request.QueryString["id"]) == 1)
                {
                    dgvClientes.DataSource = negocio.listarClientesConSp();
                    dgvClientes.DataBind();
                }

                else if (int.Parse(Request.QueryString["id"]) == 2)
                {
                    dgvAdmins.DataSource = negocio.listarAdminsConSp();
                    dgvAdmins.DataBind();
                }

            }


        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e) {

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





    }



}