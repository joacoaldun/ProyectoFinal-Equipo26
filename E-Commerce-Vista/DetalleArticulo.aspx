<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="E_Commerce_Vista.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card {
            margin-top: 10vh;
        }

        .carousel-image {
            height: 500px;
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
                                <h5 class="card-title"><%: articulo.Nombre %></h5>
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
                                    <p><span class="label">Precio:</span> <%:"$" + articulo.Precio %></p>
                                </div>
                                <div class="add-to-cart">
                                    <% if (articulo.StockArticulo.Cantidad > 0)
                                        {

                                    %>
                                    <asp:Button Text="Agregar al carrito" ID="btnAgregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" OnClientClick="mostrarMensaje();" />

                                    <%}
                                        else
                                        {%>
                                      <asp:Button Text="Sin stock" ID="Button1" CssClass="btn btn-danger btn-pg-1" runat="server"  enabled="false" />

                                        <%}%>
                                    <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-dark green-text" Text="Volver atras" OnClick="btnVolver_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            --%>

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



    <script>
        function mostrarMensaje() {
            var mensajeCarrito = document.getElementById("mensajeCarritoo");
            mensajeCarrito.innerText = "Artículo agregado al carrito";
            mensajeCarrito.style.display = "block";

            setTimeout(function () {
                mensajeCarrito.style.display = "none";
            }, 4000);
        }
    </script>

</asp:Content>
