<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="E_Commerce_Vista.MisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Lista de pedidos</h1>

     <asp:GridView ID="dgvPedidos" runat="server" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" CssClass="table table-striped "
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging ="dgvPedidos_PageIndexChanging"> 
          <HeaderStyle CssClass="thead-dark" />
        <Columns>
            <asp:BoundField  HeaderText="Numero" DataField="Id"  /> 
             <asp:BoundField  HeaderText="Fecha"   DataFormatString="{0:dd/MM/yyyy}"  DataField="FechaPedido"  /> 
             <asp:BoundField  HeaderText="Estado de envio" DataField="EstadoEnvio"/> 
             <asp:BoundField  HeaderText="Medio de pago" DataField="MedioDePago.NombrePago"  /> 
             <asp:BoundField  HeaderText="Pagado" DataField="EstadoPago"  /> 
             <asp:BoundField  HeaderText="Importe" DataField="ImporteTotal" DataFormatString="${0:N2}" /> 
            <asp:CommandField ShowSelectButton="true" SelectText="<i class='icono fas fa-info-circle'></i>" HeaderText="Ver detalle" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>

    </asp:GridView>



    <a href="Listado.aspx" Class="btn btn-dark">Volver</a>

    <style>
        h1{
            color:white;
            margin-bottom:4vh;
        }
        /* Estilo para el encabezado de la tabla */
        .thead-dark th {
            background-color: black; 
            color: white; 
            font-weight:normal;
        }
        .icono{
            font-size:x-large;
            color:slateblue;
        }


    </style>
</asp:Content>
