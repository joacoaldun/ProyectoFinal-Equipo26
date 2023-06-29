<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="E_Commerce_Vista.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="mensaje-enviado">
        <h1>Mensaje enviado con éxito.</h1>
        <p>Gracias por contactarnos. Le contestaremos a la brevedad.</p>
        <a href="Listado.aspx" class="btn btn-dark">Volver al listado</a>
    </div>

    <style>
    .mensaje-enviado {
        text-align: center;
        margin-top: 50px;
    }

    .mensaje-enviado h1 {
        font-size: 24px;
    
    }

  

    .mensaje-enviado .btn {
        margin-top: 20px;
        padding: 10px 20px;
        text-decoration: none;
    
    }

</style>

</asp:Content>

