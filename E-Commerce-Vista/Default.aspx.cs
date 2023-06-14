using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace E_Commerce_Vista
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {      
             

            if (!IsPostBack)
            { 
                ArticuloNegocio negocio = new ArticuloNegocio();

                Session.Add("ListaArticulo", negocio.listarConSP());
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
               
            }



        }

       

    }
}