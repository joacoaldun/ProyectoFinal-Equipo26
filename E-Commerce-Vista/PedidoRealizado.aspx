<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PedidoRealizado.aspx.cs" Inherits="E_Commerce_Vista.FinalizarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pedido-enviado">
        <h1>Pedido recibido!</h1>
        <p></p>
        <p>En breve nos comunicaremos con vos para continuar con la gestión de tu pedido. </p>
        <div class="nroPedido text-center">
            <asp:Label Text="" ID="lblNroPedido" runat="server" />
        </div>
        <a href="Listado.aspx" class="btn btn-dark">Volver al listado</a>
    </div>



    <style>
        .pedido-enviado {
            text-align: center;
            margin-top: 50px;
        }

        .pedido-enviado h1 {
            font-size: 24px;
        }


        .pedido-enviado .btn {
            margin-top: 20px;
            padding: 10px 20px;
            text-decoration: none;
           
        }
        .nroPedido{
            width:200px;
            padding:5px;
            background-color:black;
            color:white;
            margin: 0 auto;
        }
    </style>


</asp:Content>
