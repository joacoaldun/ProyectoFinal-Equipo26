<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionArticulos.aspx.cs" Inherits="E_Commerce_Vista.GestiónArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de articulos a gestionar...</h1>
    

    <asp:GridView ID="dgvArticulos" runat="server" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="12" OnPageIndexChanging ="dgvArticulos_PageIndexChanging">  

        <Columns>
            <asp:BoundField  HeaderText="Articulo" DataField="Nombre"/> 
            <asp:BoundField  HeaderText="Codigo" DataField="CodigoArticulo"/> 
            <asp:BoundField  HeaderText="Marca" DataField="Marcas.NombreMarca"/> 
            <asp:BoundField  HeaderText="Categoria" DataField="Categorias.NombreCategoria"/> 
            <asp:BoundField  HeaderText="Precio" DataField="Precio"/> 
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

        </Columns>

    </asp:GridView>

    <a href="FormularioArticulo.aspx" class="btn btn-success" >Agregar</a>
    <a href="PanelGestion.aspx" class="btn btn-danger" >Volver</a>
</asp:Content>
