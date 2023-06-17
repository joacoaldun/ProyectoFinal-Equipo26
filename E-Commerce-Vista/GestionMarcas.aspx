<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionMarcas.aspx.cs" Inherits="E_Commerce_Vista.GestiónMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Lista de marcas a gestionar...</h1>

    <asp:GridView ID="dgvMarcas" runat="server" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging ="dgvMarcas_PageIndexChanging">  

        <Columns>
            <asp:BoundField  HeaderText="Marca" DataField="NombreMarca"  /> 
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>

    </asp:GridView>

    <a href="FormularioMarca.aspx" class="btn btn-success" >Agregar</a>
    <a href="PanelGestion.aspx" class="btn btn-danger" >Volver</a>

</asp:Content>
