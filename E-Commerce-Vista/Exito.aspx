<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="E_Commerce_Vista.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="mensaje-enviado">
         <i class="fas fa-paper-plane fa-5x"></i>
        <h1 class="text-center titulo">Mensaje enviado con éxito.</h1>
         
        <p>Gracias por contactarnos. Le contestaremos a la brevedad.</p>
         
        <a href="Listado.aspx" class="btn btn-dark">Volver al listado</a>
    </div>

    <style>
    .mensaje-enviado {
        text-align: center;
        margin-top: 50px;
    }

    .mensaje-enviado {
        font-size: x-large;
    
    }
    .titulo{
        margin-top:4vh;
    }
    body{
        color:white;
    }

  

    .mensaje-enviado .btn {
       
        padding: 10px 20px;
        text-decoration: none;
    
    }

</style>

</asp:Content>

