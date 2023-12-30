<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ValidarCuenta.aspx.cs" Inherits="E_Commerce_Vista.ValidarCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
    <div class="col-4">
        <div class="mb-3 mt-4">
            <h1 class="text-center">Validar cuenta</h1>
        </div>
        <div class="mb-3 mt-4">
            <label for="txtCodigo" class="form-label">Ingrese el código de validación enviado a su email.</label>
            <asp:textbox type="text" class="form-control" id="txtCodigoValidacion" runat="server"></asp:textbox>
        </div>
        <asp:Button Text="Validar" ID="btnValidar" CssClass="btn btn-success" Onclick="btnValidar_Click" runat="server" />
    </div>
</div>

    <style>
        h1, .form-label{
            color:white;
        }
        .form-label{
            font-size:x-large;
        }
    </style>


</asp:Content>

