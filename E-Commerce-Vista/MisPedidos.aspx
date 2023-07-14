<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="E_Commerce_Vista.MisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de pedidos...</h1>

     <asp:GridView ID="dgvPedidos" runat="server" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging ="dgvPedidos_PageIndexChanging">  
        <Columns>
            <asp:BoundField  HeaderText="Numero" DataField="Id"  /> 
             <asp:BoundField  HeaderText="Fecha"   DataFormatString="{0:dd/MM/yyyy}"  DataField="FechaPedido"  /> 
             <asp:BoundField  HeaderText="Estado de envio" DataField="EstadoEnvio"/> 
             <asp:BoundField  HeaderText="Medio de pago" DataField="MedioDePago.NombrePago"  /> 
             <asp:BoundField  HeaderText="Pagado" DataField="EstadoPago"  /> 
             <asp:BoundField  HeaderText="Importe" DataField="ImporteTotal"  /> 
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Ver detalle" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>

    </asp:GridView>



    <a href="Listado.aspx" Class="btn btn-dark">Volver</a>


</asp:Content>
