<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="E_Commerce_Vista.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <%if (int.Parse(Request.QueryString["id"]) == 1)
        {
       %>
     <h3>Lista de Clientes a gestionar</h3>
     <asp:GridView ID="dgvClientes" runat="server" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="12" OnPageIndexChanging ="dgvClientes_PageIndexChanging">  

        <Columns>
            <asp:BoundField  HeaderText="Nombre" DataField="Nombre"/> 
            <asp:BoundField  HeaderText="Apellido" DataField="Apellido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Username" DataField="Username" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Email" DataField="Email" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>     
            <asp:BoundField  HeaderText="Dni" DataField="Dni" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>     
            <asp:BoundField  HeaderText="Fecha de nacimiento" DataField="FechaNacimiento"  DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>     
            
           
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

        </Columns>

    </asp:GridView>

    <%} %>

    <%else if (int.Parse(Request.QueryString["id"]) == 2)
        {
            %>
    <h3>Lista de Admins a gestionar</h3>
     <asp:GridView ID="dgvAdmins" runat="server" OnSelectedIndexChanged="dgvAdmins_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="12" OnPageIndexChanging ="dgvAdmins_PageIndexChanging">  

        <Columns>
            <asp:BoundField  HeaderText="Nombre" DataField="Nombre"/> 
            <asp:BoundField  HeaderText="Apellido" DataField="Apellido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Username" DataField="Username" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Email" DataField="Email" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            
           
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

        </Columns>

    </asp:GridView>
    <%} %>

</asp:Content>

