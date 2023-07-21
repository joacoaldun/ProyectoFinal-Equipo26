<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Commerce_Vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /*Articulos*/
        .container {
            width: 70%;
        }

        .cardArticulo {
            width: 100%;
            height: 50vh;
        }

        h1 {
            margin-top: 8vh;
            text-align: center;
        }
        /*Marcas*/
        .cardMarca {
            width: 100%;
            height: 20vh;
        }
    </style>



    <%--Home--%>
    <div class="containerHome mt-0">
        <div id="carouselExample" class="carousel slide ">
            <div class="carousel-inner">
                <a href="Listado.aspx">

                    <%-- Primera imagen --%>
                    <div class="carousel-item active">
                        <img src="imagenes/1.jpg" class="d-block w-100" alt="Imagen 1">
                    </div>

                    <%-- Segunda imagen --%>
                    <div class="carousel-item">
                        <img src="imagenes/2.jpg" class="d-block w-100" alt="Imagen 2">
                    </div>
                </a>
            </div>

            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>

    </div>


    <%-- Articulos --%>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>ARTÍCULOS</h1>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-md-12">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <% for (int i = 0; i < ListaArticulo.Count; i++)
                            {
                                string activeClass = (i == 0) ? "active" : "";
                        %>
                        <div class="carousel-item <%= activeClass %>">
                            <div class="card">
                               <a href="DetalleArticulo.aspx?id=<%= ListaArticulo[i].Id %>" class="image-link">
                                <img src="<%=ListaArticulo[i].Imagenes[0].UrlImagen %>" class="card-img-top cardArticulo" alt="<%= ListaArticulo[i].Nombre%>">
                              </a>
                                    <div class="card-body">
                                    <h5 class="card-title"><%= ListaArticulo[i].Nombre %></h5>
                                    <%--  <p class="card-text"><%= ListaArticulo[i].Descripcion %></p>--%>
                                    <p class="card-text">Precio: $ <%= ListaArticulo[i].Precio %></p>
                                </div>
                            </div>
                        </div>
                        <% } %>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </a>
                </div>
            </div>
        </div>
    </div>

    <%-- BANNER --%>

    <div class="container-fluid banner-envio ">
        <div class="row item-banner">
            <div class="col-md-12 text-center">
                <iconify-icon icon="ic:baseline-local-shipping" width="100" height="100"></iconify-icon>
                <h2>ENVÍOS</h2>
                <h3>A TODO EL PAIS</h3>
            </div>
        </div>


        <div class="row item-banner">
            <div class="col-md-12 text-center">
                <iconify-icon icon="ion:card-sharp" width="100" height="100"></iconify-icon>
                <h2>MEDIOS DE PAGO</h2>
                <h3>TARJETAS O TRANSFERENCIA BANCARIA</h3>

            </div>
        </div>


        <div class="row item-banner">
            <div class="col-md-12 text-center">
                <iconify-icon icon="charm:padlock" width="100" height="100"></iconify-icon>
                <h2>SITIO SEGURO</h2>
                <h3>PROTEGEMOS TUS DATOS</h3>
            </div>
        </div>


    </div>



    <%-- Marcas --%>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>MARCAS</h1>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-md-12">

                <div id="carouselExampleIndicatorsMarca" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <% for (int i = 0; i < ListaMarca.Count; i += 3)//muestra de a 3
                            {
                                int endIndex = Math.Min(i + 3, ListaMarca.Count);//muestra de a 3
                                string activeClass = (i == 0) ? "active" : "";
                        %>
                        <div class="carousel-item <%= activeClass %>">
                            <div class="row">
                                <% for (int j = i; j < endIndex; j++)
                                    {

                                %>
                                <div class="col-md-4">
                                    <div class="card">
                                        <a href="Listado.aspx?id=M_<%= ListaMarca[j].Id %>" class="image-link">
                                            <img src="<%= ListaMarca[j].ImagenMarca %>" class="card-img-top cardMarca" alt="<%= ListaMarca[j].NombreMarca %>" data-id="<%= ListaMarca[j].Id %>">
                                        </a>

                                    </div>
                                </div>
                                <% } %>
                            </div>
                        </div>
                        <% } %>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicatorsMarca" role="button" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicatorsMarca" role="button" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </a>
                </div>


            </div>
        </div>
    </div>



    <%-- Categorias --%>
    <div class="container">
        <h1>CATEGORIAS</h1>
        <div class="categoria-list-container">
            <% foreach (var categoria in ListaCategoria)
                { %>
            <div class="categoria-item" style="background-color: black; color: white;">
                <a href="Listado.aspx?id=C_<%= categoria.Id %>" class="image-link" style="background-color: black; color: white; text-decoration:none">
                <%= categoria.NombreCategoria %>
                </a>
            </div>
            <% } %>
        </div>
    </div>

    <style>
        .categoria-list-container {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-bottom: 10vh;
            margin-top: 6vh;
        }

        .categoria-item {
            background-color: black;
            color: white;
            width: 32%;
            height: 10vh;
            margin: 1vh;
            text-align: center;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        @media (max-width: 768px) {
            .categoria-list-container {
                flex-direction: column;
            }

            .categoria-item {
                width: 100%;
            }
        }

        .banner-envio {
            margin-top: 100px;
            /*background-color: rebeccapurple;*/
            background-color: black;
            color: white;
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

        h2 {
            font-size: large;
            color: white;
        }

        h3 {
            font-size: small;
            color: white;
        }

        /* .container{
            width:85%;
        }*/

        .containerHome {
            position: relative;
            width: 100vw;
            left: 50%;
            right: 50%;
            margin-left: -50vw;
            margin-right: -50vw;
            padding-top: 0px;
            margin-top: 0;
        }

        .containerAsp {
            margin-top: 40px !important;
        }
        



    </style>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var carousel = document.querySelector("#carouselExample");
            var cambiar = new bootstrap.Carousel(carousel, {
                interval: 2000 // Cambia la imagen cada 2 segundos
            });

            setInterval(function () {
                cambiar.next();
            }, 3000);
        });
    </script>



</asp:Content>
