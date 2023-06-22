using System;
using System.Collections;
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
        public List<Marca> ListaMarca { get; set; }
        public List<Categoria> ListaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {      
             

            if (!IsPostBack)
            { 
                ArticuloNegocio negocio = new ArticuloNegocio();

                Session.Add("ListaArticulo", negocio.listarConSP());
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];


                MarcaNegocio marcaNegocio=new MarcaNegocio();
                Session.Add("ListaMarca", marcaNegocio.listar());
                ListaMarca = (List<Marca>)Session["ListaMarca"];
                //rptMarcas.DataSource = ListaMarca; 
              //  rptMarcas.DataBind();

                CategoriaNegocio categoriaNegocio=new CategoriaNegocio();
                Session.Add("ListaCategoria", categoriaNegocio.listar());
                ListaCategoria = (List<Categoria>)Session["ListaCategoria"];


            }



        }

       

    }
}