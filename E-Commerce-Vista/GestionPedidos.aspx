<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionPedidos.aspx.cs" Inherits="E_Commerce_Vista.GestiónPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Lista de pedidos a gestionar...</h1>

     <asp:GridView ID="dgvPedidos" runat="server" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging ="dgvPedidos_PageIndexChanging">  

        <Columns>
            <asp:BoundField  HeaderText="Numero" DataField="Id"  /> 
            <asp:BoundField  HeaderText="Apellido" DataField="Cliente.Apellido"  /> 
            <asp:BoundField  HeaderText="Nombre" DataField="Cliente.Nombre"  /> 
            <asp:BoundField  HeaderText="Email" DataField="Cliente.Email"  /> 
             <asp:BoundField  HeaderText="Fecha"   DataFormatString="{0:dd/MM/yyyy}"  DataField="FechaPedido"  /> 
             <asp:BoundField  HeaderText="Estado de envio" DataField="EstadoEnvio"/> 
             <asp:BoundField  HeaderText="Medio de pago" DataField="MedioDePago.NombrePago"  /> 
             <asp:BoundField  HeaderText="Pagado" DataField="EstadoPago"  /> 
             <asp:BoundField  HeaderText="Importe" DataField="ImporteTotal"  /> 
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>

    </asp:GridView>



    <a href="PanelGestion.aspx">Volver</a>
</asp:Content>
