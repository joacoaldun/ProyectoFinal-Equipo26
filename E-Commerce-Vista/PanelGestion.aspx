<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelGestion.aspx.cs" Inherits="E_Commerce_Vista.Administración" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <div class="containerPrincipal text-center">
         <h1>Panel de gestión</h1>
        <div class="row">

            <div class="mt-1 mb-1 ">
                <a href="GestionArticulos.aspx" class="btn btn-dark btnGestion">Gestionar artículos
                    <img src="imagenes/articulos.png" alt="Imagen marcas" class="img-btn"> 
                </a>
                
            </div>

            <div class="mt-1 mb-1 ">
                <a href="GestionMarcas.aspx" class="btn btn-dark btnGestion">Gestionar marcas
                    <img src="imagenes/marca.png" alt="Imagen marcas" class="img-btn"> 
                </a>
                
            </div>

            <div class="mt-1 mb-1 ">
                <a href="GestionCategorias.aspx" class="btn btn-dark btnGestion">Gestionar categorías
                     <img src="imagenes/categorias.png" alt="Imagen marcas" class="img-btn"> 
                </a>
            </div>

            <div class="mt-1 mb-1 ">
                <a href="GestionPedidos.aspx" class="btn btn-dark btnGestion">Gestionar pedidos
                     <img src="imagenes/pedidos.png" alt="Imagen marcas" class="img-btn"> 
                </a>
            </div>

            <div class="mt-1 mb-1 ">
                <a href="GestionUsuarios.aspx" class="btn btn-dark btnGestion"> Gestionar usuarios
                     <img src="imagenes/usuarios.png" alt="Imagen marcas" class="img-btn"> 
                </a>
            </div>

       </div>
    </div>

    <%-- HTML --%>
    <style>
        .containerPrincipal{
           margin-top:5vh;
           justify-content:center;
            
        }
        .btnGestion{
            width:500px;
            padding:10px;
        }
        img{
            width:100px;
            margin-left:50px;
            
        }
        h1{
            margin-bottom:30px;
        }
    </style>

</asp:Content>
