<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="E_Commerce_Vista.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de usuarios a gestionar...</h1>


     <h3>Lista de Clientes</h3>
     <asp:GridView ID="dgvClientes" runat="server" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="12" OnPageIndexChanging ="dgvClientes_PageIndexChanging">  

        <Columns>
            <asp:BoundField  HeaderText="Nombre" DataField="Nombre"/> 
            <asp:BoundField  HeaderText="Apellido" DataField="Apellido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Username" DataField="Username" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Email" DataField="Email" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            
           
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

        </Columns>

    </asp:GridView>


</asp:Content>

