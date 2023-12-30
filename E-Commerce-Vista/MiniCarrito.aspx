﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiniCarrito.aspx.cs" Inherits="E_Commerce_Vista.MiniCarrito" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .titulo {
            margin-left: 12vh;
        }

        .containerPrincipal {
            margin-top: 2vh;
            margin-left: 1vh;
        }

        #barNav{
            display:none;
        }

    </style>

    <div class="containerPrincipal">
        <div class="containerCarrito">
            <h2 class="titulo">Mi Carrito</h2>
            <button class="btn btn-outline-light" id="btnCerrar">X </button>
        </div>

        <%-- LLAMO AL UPDATE Y CREO EL REPETIDOR PARA QUE MUESTRA TODO LO QUE HAY EN CARRITO--%>
    
        <asp:UpdatePanel ID="updatePanelCarrito" runat="server" UpdateMode="Conditional"  >

            <ContentTemplate>

                <div class="containerArticulos">
                    <asp:Repeater ID="repCarrito" runat="server" OnItemDataBound="repCarrito_ItemDataBound">
                        <ItemTemplate>

                            <div class="card mb-3 text-bg-dark p-3" style="max-width: 360px;">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <asp:Image ID="ImagenCarrito" CssClass="img-fluid rounded-start img-left" runat="server" />
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h4 class="card-title"><%# Eval("Nombre") %></h4>
                                            <h5 class="card-title"><%# Eval("Marcas.NombreMarca") %></h5>
                                            <h6 class="card-title">$<%# Convert.ToDecimal(Eval("Precio")).ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture) %></h6>



                                            <div class="botonesYcantidad">

                                                <%-- PASAMOS LOS ID COMO ARGUMENTO A LOS BOTONES PARA QUE ENCUENTRE LOS ARTICULOS QUE TIENE Q RESTAR O SUMAR --%>
                                                <asp:Button ID="btnRestar" Text="-"  runat="server" CssClass="btn btn-light" OnClick="restarArticulo_Click" CommandArgument='<%#Eval("Id")%>'  />
                                                <p>
                                                    CANTIDAD:
                                            <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                                                </p>
                                                <asp:Button ID="btnSumar" Text="+"  runat="server" CssClass="btn btn-light btnSumar" OnClick="sumarArticulo_Click" CommandArgument='<%#Eval("Id")%>' />
                                            </div>



                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>

                </div>
                <div class="card mb-3 text-bg-dark p-3" style="max-width: 360px;">

                    <h4 class="text-center">Total: $<asp:Label ID="lblPrecioTotal" runat="server" Text=""></asp:Label></h4>

                    <asp:Button Text="Completar pedido" style="font-size:x-large;" CssClass="btn btn-light" runat="server" OnClientClick="return redirectToPage('ListadoCarrito.aspx');" />
                </div>



            </ContentTemplate>
        </asp:UpdatePanel>




    </div>






    <%-- css --%>


    <style>
        #form1, html {
            background-color: black;
            color: white;
        }

        .containerCarrito {
            display: flex;
        }


        #btnCerrar {
            margin-left: 5vh;
        }

        .containerArticulos {
            margin-top: 3vh;
            height: 70vh;
            overflow-y: auto;
        }


        .card.mb-3 {
            display: flex;
        }

            .card.mb-3 .col-md-4 {
                flex-basis: 30%;
                max-width: 30%;
            }

            .card.mb-3 .col-md-8 {
                flex-basis: 70%;
                max-width: 70%;
            }

        .img-left {
            width: 100%;
            height: 100%;
            object-fit: fill;
        }

        .botonesYcantidad {
            display: flex;
            align-items: center;
        }

            .botonesYcantidad p {
                margin: 0 10px;
            }

        #footer {
            display:none;
        } 
    </style>

    <script>

        //redireccion a listado
        function redirectToPage(url) {
            parent.location.href = url;
            return false;
        }




        //este agrego para que no tener que recargar la pagina para el evento abrir y cerrar
        window.addEventListener('DOMContentLoaded', function () {
            var hideButton = document.getElementById('btnCerrar');

            hideButton.addEventListener('click', function () {
                parent.postMessage('cerrarMiniCartContainer', '*');
            });

            parent.postMessage('actualizarUpdatePanel', '*');
        });


        function asignarEventos() {
            var btnAgregarCesta = document.querySelectorAll(".btn.btn-success");
            btnAgregarCesta.forEach(function (button) {
                button.addEventListener("click", sumarAlCarrito);
            });
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            asignarEventos();
        });



    </script>




</asp:Content>
