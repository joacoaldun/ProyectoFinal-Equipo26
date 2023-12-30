﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="E_Commerce_Vista.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card {
            margin-top: 5vh;
        }

        .carousel-image {
            /*width:50%;*/
            height: 380px;
            object-fit: fill;
        }
    </style>


    <%
        if (articulo.Id != 0)
        {
    %>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8">
                        <h1 class="card-title titulo"><%: articulo.Nombre %></h1>
                        <div class="card">
                            <div id="carouselExample" class="carousel slide">
                                <div class="carousel-inner">
                                    <% for (int i = 0; i < articulo.Imagenes.Count; i++)
                                        { %>
                                     
                                    <div class="carousel-item <%= i == 0 ? "active" : "" %>">
                                        <img src="<%= articulo.Imagenes[i].UrlImagen %>" class="d-block w-100 carousel-image" alt="Imagen <%= i %>" onerror="this.src='https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png';">
                                    </div>
                                    <% } %>
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

                           

                            <div class="card-body">
                                
                                <div class="details">
                                    <p><span class="label">Código del articulo:</span> <%: articulo.CodigoArticulo %></p>
                                </div>
                                <div class="details">
                                    <p><span class="label">Marca:</span> <%: articulo.Marcas.NombreMarca %></p>
                                </div>
                                <div class="details">
                                    <p><span class="label">Categoría:</span> <%:articulo.Categorias.NombreCategoria %></p>
                                </div>

                                <div class="details">
                                    <p><span class="label">Descripcion:</span> <%:articulo.Descripcion %></p>
                                </div>

                                <div class="details">
                                    <p><span class="label">Precio:</span> <%:"$" + Convert.ToDecimal(articulo.Precio).ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture) %></p>
                                </div>
                                <div class="add-to-cart">
                                    <% if (articulo.StockArticulo.Cantidad > 0)
                                        {

                                    %>
                                   
                                    <% if(Session["ClienteLogueado"] == null || Session["ClienteLogueado"] == null) { %>
                                            <asp:Button Text="En stock" ID="btnEjemplo" CssClass="btn btn-success btnAgregar btn-pg-1 " runat="server"  CommandArgument='<%# Eval("Id") %>' OnClientClick="mostrarMensaje();" Enabled="false" />
                                        <% } else { %>
                                            <asp:Button Text="Agregar al carrito" ID="btnAgregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" OnClientClick="mostrarMensaje();" />

                                    
                                    <% } %>  


                                    <%}
                                        else
                                        {%>
                                      <asp:Button Text="Sin stock" ID="Button1" CssClass="btn btn-danger btn-pg-1" runat="server" style="background-color:purple; border:none;" enabled="false" />

                                        <%}%>
                                    <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-dark green-text" Text="Volver atras" OnClick="btnVolver_Click" />
                                    
                                     <%if(Session["Admin"] == null && Session["ClienteLogueado"] != null) {  %>
                                    <asp:Button Text="♥" Cssclass="btn btnFav" ID="btnFavorito"  OnClick="btnFavorito_Click" runat="server" CommandArgument='<%#Eval ("Id") %>' />
                                     <%} %>
                                

                                           
                                           
                                           
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            

        </ContentTemplate>
    </asp:UpdatePanel>
    <%  }
    %>

    <%else
        {
    %>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <asp:Image ID="Image1" class="card-img-top" runat="server" CssClass="card-img-top" />
                    <div class="card-body">
                        <h5 class="card-title">No hay articulo seleccionado</h5>
                        <div class="details">
                            <p><span class="label">Código del articulo:</span> </p>
                        </div>
                        <div class="details">
                            <p><span class="label">Marca:</span> ></p>
                        </div>
                        <div class="details">
                            <p><span class="label">Categoría:</span> ></p>
                        </div>
                        <div class="details">
                            <p><span class="label">Precio:</span></p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <%  } %>


  <style>
       .btnFav{
           color: black;
            border:none;
            font-size:xx-large;
        }

        .btn-favorito-activo {
            color: purple;
        }
        .titulo{
           
            color:white;
            margin-bottom:auto;
            text-align:center;
        }
        p{
            font-size:x-large;
        }
        

  </style>

    <script>
        function mostrarMensaje() {
            var mensajeCarrito = document.getElementById("mensajeCarritoo");
            mensajeCarrito.innerText = "Artículo agregado al carrito";
            mensajeCarrito.style.display = "block";

            setTimeout(function () {
                mensajeCarrito.style.display = "none";
            }, 4000);
        }

        //actualizamos btn fav
        function btnFavoritoClick(btnId) {
            __doPostBack(btnId, '');
        }
    </script>

</asp:Content>
