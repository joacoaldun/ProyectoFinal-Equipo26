<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="E_Commerce_Vista.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center titulo">CONTACTATE CON NOSOTROS</h1>
    <div class="row store " >
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
            <div class="mb-3 mt-4">
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
                <asp:Button Text="ENVIAR" id="btnEnviar" runat="server" CssClass="btn btn-dark " OnClientClick="enviarCorreo(); return false;" onclick="btnEnviar_Click"/>
            </div>

            

        </div>
         <div  id="loader" style="display:none;" >
                
                <div class="loader"></div>
                <p>Cargando...</p>
            </div>
    </div>

    



    <div class="container-fluid banner-envio ">
        <div class="row item-banner">
            <div class="col-md-12 text-center banner">
                <iconify-icon icon="ic:baseline-local-shipping" width="80" height="80" class="itemBanner"></iconify-icon>
                <h2 class="banner bannerh2">ENVÍOS</h2>
                <h4 class="bannerh4">A TODO EL PAIS</h4>
            </div>
        </div>


        <div class="row item-banner">
            <div class="col-md-12 text-center banner">
                <iconify-icon icon="ion:card-sharp" width="80" height="80" class="itemBanner"></iconify-icon>
                <h2 class="banner bannerh2">MEDIOS DE PAGO</h2>
                <h4 class="bannerh4">TARJETAS O TRANSFERENCIA BANCARIA</h4>

            </div>
        </div>


        <div class="row item-banner">
            <div class="col-md-12 text-center banner">
                <iconify-icon icon="charm:padlock" width="80" height="80" class="itemBanner"></iconify-icon>
                <h2 class="banner bannerh2">SITIO SEGURO</h2>
                <h4 class="bannerh4">PROTEGEMOS TUS DATOS</h4>
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
            
            color:white;
            /*margin-bottom:4vh;*/
        }

        .titulo{
            margin-bottom:4vh;
        }
        
        .banner {
            font-size: large;
            /*color:white;*/
            color: black;
        }

        p {
            font-size: medium;
        }

        .contacto, h2 {
            font-size: large;
            /*font-weight: bold;*/
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
            font-size: large;
            /*color:white;*/
            color: black;
        }

        h3 {
            font-size: large;
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

        /*ESTILO VISUAL*/
        h2,h4,.banner{
            color:white;
        }
        .itemBanner{
            color:white;
        }

        .bannerh2{
            font-size:xx-large;
        }
        .bannerh4{
            font-size:large;
        }
    </style>

    <script>
        function enviarCorreo() {

            
            mostrarCarga();
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
        function mostrarCarga() {
            document.getElementById("loader").style.display = "block";
            setTimeout(function () {
                document.getElementById("loader").style.display = "none";
            }, 5000); 
        }


    </script>

    <style>
        
        .loader {
            
            border: 4px solid rgba(0, 0, 0, 0.1);
            border-left: 4px solid purple;
            border-radius: 50%;
            width: 40px;
            height: 40px;
            animation: spin 1s linear infinite;
            margin: 0 auto;
        }

        
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }


    </style>

</asp:Content>

