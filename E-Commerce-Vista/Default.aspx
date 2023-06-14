<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Commerce_Vista.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
   
</style>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Carrusel de Artículos</h1>
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
                                <img src="<%=ListaArticulo[i].Imagenes[0].UrlImagen %>" class="card-img-top" alt="<%= ListaArticulo[i].Nombre%>">
                                <div class="card-body">
                                    <h5 class="card-title"><%= ListaArticulo[i].Nombre %></h5>
                                    <p class="card-text"><%= ListaArticulo[i].Descripcion %></p>
                                    <p class="card-text">Precio:  <%= ListaArticulo[i].Precio %></p>
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





</asp:Content>
