<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionCategorias.aspx.cs" Inherits="E_Commerce_Vista.GestiónCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Lista de categorias a gestionar...</h1>

    <asp:GridView ID="dgvCategorias" runat="server" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged" >  
        <Columns>
            <asp:BoundField HeaderText="Categoria" DataField="NombreCategoria" />
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>
    </asp:GridView>
    <a href="FormularioCategoria.aspx" class="btn btn-success">Agregar</a>
    <a href="PanelGestion.aspx" class="btn btn-danger"  >Volver</a>
</asp:Content>
