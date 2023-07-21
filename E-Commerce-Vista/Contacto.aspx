<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="E_Commerce_Vista.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row store">
        <div class="col-4 d-flex flex-column align-items-center justify-content-center" style="background-color:black;">
            <div class="mb-3 mt-3 text-center">
                <img src="imagenes/logo.png" alt="Logo" width="100" height="100" class="logo">
            </div>
            <div class="mb-3 mt-3 text-center contacto2">
                <h1 class="contacto">DATOS DE CONTACTO</h1>
                <p>+54 11 1111-1111</p>
            </div>
            <div class="mb-3 mt-3 text-center contacto2">
                <h1 class="contacto">REDES SOCIALES</h1>
                <p>Instagram</p>
            </div>
        </div>

        <div class="col-4 contacto">
            <div class="mb-3 mt-3">
                <label for="txtNombre" class="form-label">NOMBRE</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3 mt-3">
                <label for="txtEmail" class="form-label">EMAIL</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3 mt-3">
                <label for="txtMensaje" class="form-label">MENSAJE</label>
                <asp:TextBox runat="server" ID="txtMensaje" TextMode="MultiLine" CssClass="form-control" />
            </div>


            <div class="text-end">
                <asp:Button Text="ENVIAR" ID="btnEnviar" runat="server" CssClass="btn btn-dark " OnClientClick="enviarCorreo(); return false;" />
            </div>

        </div>
    </div>

    <div class="container-fluid banner-envio ">
        <div class="row item-banner">
            <div class="col-md-12 text-center">
                <iconify-icon icon="ic:baseline-local-shipping" width="80" height="80"></iconify-icon>
                <h2 class="banner">ENVÍOS</h2>
                <h4>A TODO EL PAIS</h4>
            </div>
        </div>


        <div class="row item-banner">
            <div class="col-md-12 text-center">
                <iconify-icon icon="ion:card-sharp" width="80" height="80"></iconify-icon>
                <h2 class="banner">MEDIOS DE PAGO</h2>
                <h4>TARJETAS O TRANSFERENCIA BANCARIA</h4>

            </div>
        </div>


        <div class="row item-banner">
            <div class="col-md-12 text-center">
                <iconify-icon icon="charm:padlock" width="80" height="80"></iconify-icon>
                <h2 class="banner">SITIO SEGURO</h2>
                <h4>PROTEGEMOS TUS DATOS</h4>
            </div>
        </div>


    </div>


    <style>
        .store {
            /*display:flex;  */
            justify-content: space-around;
            background-color:black;
        }
        .btn-dark{
            background-color:purple;
        }
        h1 {
            font-size: medium;
        }

        .banner {
            font-size: large;
            /*color:white;*/
            color: black;
        }

        p {
            font-size: small;
        }

        .contacto, h2 {
            font-size: medium;
            font-weight: bold;
             color:white;
        }

        .banner-envio {
            margin-top: 100px;
            /*background-color: rebeccapurple;*/
            /*background-color:black;*/
            /*color: white;*/
            color: black;
            padding: 40px;
            display: flex;
            position: relative;
            width: 100vw;
            left: 50%;
            right: 50%;
            margin-left: -50vw;
            margin-right: -50vw;
            justify-content: space-around;
        }

        .item-banner {
            width: 33.33%;
            color: blueviolet;
        }

        h4 {
            font-size: small;
            /*color:white;*/
            color: black;
        }

        h3 {
            font-size: medium;
            margin-bottom: 20px;
        }

        .footer {
            color: white;
        }
        .contacto2{
            color:white;
        }
        .logo{
            width:200px;
            height:150px;
        }
    </style>

    <script>
        function enviarCorreo() {
            var nombre = document.getElementById('<%= txtNombre.ClientID %>').value;
            var email = document.getElementById('<%= txtEmail.ClientID %>').value;
            var mensaje = document.getElementById('<%= txtMensaje.ClientID %>').value;

            var templateParams = {
                from_name: nombre,
                from_email: email,
                message: mensaje
            };

            emailjs.send('service_1udlfc4', 'template_uif8uoh', templateParams)
                .then(function (response) {

                    // REdireccionamos
                    window.location.href = 'Exito.aspx';
                })
        }

    </script>


</asp:Content>

