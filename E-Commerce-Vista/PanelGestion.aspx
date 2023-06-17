<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelGestion.aspx.cs" Inherits="E_Commerce_Vista.Administración" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Panel de gestión...</h1>
    <div class="containerPrincipal">
        <div class="row">

            <div class="mt-1 mb-1 ">
                <a href="GestionArticulos.aspx" class="btn btn-dark">Gestionar artículos</a>
            </div>

            <div class="mt-1 mb-1 ">
                <a href="GestionMarcas.aspx" class="btn btn-dark">Gestionar marcas</a>
            </div>

            <div class="mt-1 mb-1 ">
                <a href="GestionCategorias.aspx" class="btn btn-dark">Gestionar categorías</a>
            </div>

            <div class="mt-1 mb-1 ">
                <a href="GestionPedidos.aspx" class="btn btn-dark">Gestionar pedidos</a>
            </div>

       </div>
    </div>

    <%-- HTML --%>
    <style>
        .containerPrincipal{
            margin-top:5vh;
            
        }
        .btn{
            width:20vh;
        }
    </style>

</asp:Content>
