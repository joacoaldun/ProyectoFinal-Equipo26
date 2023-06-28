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
            dgvClientes.DataSource = negocio.listarClientesConSp();
            dgvClientes.DataBind();
           
            
            
            
            
            



        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e) { 
        
        
        
        }

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientes.PageIndex = e.NewPageIndex;
            dgvClientes.DataBind();


        }
    }
}