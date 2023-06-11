<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelGestion.aspx.cs" Inherits="E_Commerce_Vista.Administración" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="containerPrincipal">
        <div class="row">

            <div >
                <a href="GestionArticulos.aspx">Gestionar artículos</a>
            </div>

            <div>
                <a href="GestionMarcas.aspx">Gestionar marcas</a>
            </div>

            <div>
                <a href="GestionCategorias.aspx">Gestionar categorías</a>
            </div>

            <div>
                <a href="GestionPedidos.aspx">Gestionar pedidos</a>
            </div>

            </div>
    </div>

    <%-- HTML --%>
    <style>
        .containerPrincipal{
            margin-top:10vh;
        }
    </style>

</asp:Content>
