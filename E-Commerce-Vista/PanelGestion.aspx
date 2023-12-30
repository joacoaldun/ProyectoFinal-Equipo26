﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelGestion.aspx.cs" Inherits="E_Commerce_Vista.Administración" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <div class="containerPrincipal text-center">
        <h1>Panel de gestión</h1>

        <div class="row">
            <div class="col-md-6 mt-1 mb-1">
                <a href="GestionArticulos.aspx" class="btn btn-dark btnGestion">
                    Gestionar artículos
                    <img src="imagenes/articulos.png" alt="Imagen artículos" class="img-btn">
                </a>
            </div>

            <div class="col-md-6 mt-1 mb-1 ">
                <a href="GestionMarcas.aspx" class="btn btn-dark btnGestion">
                    Gestionar marcas
                    <img src="imagenes/marca.png" alt="Imagen marcas" class="img-btn">
                </a>
            </div>

            <div class="col-md-6 mt-1 mb-1">
                <a href="GestionCategorias.aspx" class="btn btn-dark btnGestion">
                    Gestionar categorías
                    <img src="imagenes/categorias.png" alt="Imagen categorías" class="img-btn">
                </a>
            </div>

            <div class="col-md-6 mt-1 mb-1">
                <a href="GestionPedidos.aspx" class="btn btn-dark btnGestion">
                    Gestionar pedidos
                    <img src="imagenes/pedidos.png" alt="Imagen pedidos" class="img-btn">
                </a>
            </div>

            <div class="col-md-6 mt-1 mb-1">
                <a href="GestionUsuarios.aspx?id=1" class="btn btn-dark btnGestion">
                    Gestionar Clientes
                    <img src="imagenes/usuarios.png" alt="Imagen clientes" class="img-btn">
                </a>
            </div>

            <div class="col-md-6 mt-1 mb-1">
                <a href="GestionUsuarios.aspx?id=2" class="btn btn-dark btnGestion">
                    Gestionar Admins
                    <img src="imagenes/admin.png" alt="Imagen admins" class="img-btn">
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
        .btnGestion {
        width: 100%; /* Reducir el ancho para dejar espacio para los márgenes */
        max-width: 600px; /* Máximo ancho del botón */
        margin: 5px; /* Agregar márgenes */
        padding: 10px;
        font-size: x-large;
        }
        img {
            width: 100px;
            margin-left: 50px;
        }
        h1 {
            margin-bottom: 30px;
            color: white;
        }
    </style>

</asp:Content>
