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
            text-align:center;
        }
        /*Marcas*/
        .cardMarca {
            width: 100%;
            height: 20vh;
        }
    </style>


    <%-- Articulos --%>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Artículos</h1>
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
                                <img src="<%=ListaArticulo[i].Imagenes[0].UrlImagen %>" class="card-img-top cardArticulo" alt="<%= ListaArticulo[i].Nombre%>">
                                <div class="card-body">
                                    <h5 class="card-title"><%= ListaArticulo[i].Nombre %></h5>
                                    <p class="card-text"><%= ListaArticulo[i].Descripcion %></p>
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





    <%-- Marcas --%>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Marcas</h1>
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
                                        <img src="<%= ListaMarca[j].ImagenMarca %>" class="card-img-top cardMarca" alt="<%= ListaMarca[j].NombreMarca %>">
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
        <h1>Categorias</h1>
        <div class="categoria-list-container">
            <% foreach (var categoria in ListaCategoria)
                { %>
            <div class="categoria-item" style="background-color: black; color: white;">
                <%= categoria.NombreCategoria %>
            </div>
            <% } %>
        </div>
    </div>

    <style>
        .categoria-list-container {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-bottom:10vh;
            margin-top:6vh;
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
            .categoria-list-container{
                flex-direction:column;
            }
            .categoria-item {
                
                width: 100%;
            }
        }
    </style>

</asp:Content>
