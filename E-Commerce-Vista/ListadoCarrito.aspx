<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoCarrito.aspx.cs" Inherits="E_Commerce_Vista.ListadoCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1 class="h1">Carrito de compras</h1>
    <%-- Grilla --%>

    <style>
        .h1 {
            /*color: aliceblue;*/
            color: white;
            margin-bottom: 60px;
            margin-top: 30px;
            text-align: center
        }

        .gridview-white-background {
            background-color: white;
        }
    </style>


    <%@ Import Namespace="Dominio" %>

    <%-- Titulos --%>





    <div class="card mb-3" style="background-color: black;">
        <div class="row g-0">
            <div class="col-md-12" style="color: white; ">
                <div class="card-body d-flex">
                    <%--<div class="col-md-2 col-sm-2"></div>--%>
                    <!-- Columna vacía sin título -->
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsCarrito"></p>
                    </div>

                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsCarrito">Nombre</p>
                    </div>
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsCarrito">Marca</p>
                    </div>
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsCarrito">Precio</p>
                    </div>
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsCarrito">Cantidad</p>
                    </div>
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsCarrito">Total</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<asp:ScriptManager ID="script3" runat="server"></asp:ScriptManager>--%>




    <asp:UpdatePanel ID="updatePanelCarrito" runat="server" UpdateMode="Conditional">
        <ContentTemplate>


            <asp:Repeater ID="repCarrito" runat="server" OnItemDataBound="repCarrito_ItemDataBound">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="row g-0">

                            <div class="col-md-12">
                                <div class="card-body d-flex">
                                    <div class="col-md-2">
                                        <asp:HyperLink ID="hlImagen" runat="server" NavigateUrl='<%# "DetalleArticulo.aspx?id=" + Eval("Id") %>'>
                                            <asp:Image ID="imgImagen" runat="server" CssClass="img-fluid rounded-start" Style="max-height: 15vh; width: 100%;" />
                                        </asp:HyperLink>
                                    </div>
                                    <div class="col-md-2 itemsCarrito">
                                        <p class="card-text"><%# Eval("Nombre") %></p>
                                    </div>
                                    <div class="col-md-2 itemsCarrito">
                                        <p class="card-text"><%# Eval("Marcas.NombreMarca") %></p>
                                    </div>
                                    <div class="col-md-2 itemsCarrito">
                                        <p class="card-text">$ <%# Convert.ToDecimal(Eval("Precio")).ToString("#,##0.00", System.Globalization.CultureInfo.InvariantCulture) %></p>
                                    </div>
                                    <div class="col-md-2 itemsCarrito d-flex justify-content-evenly align-items-center ">

                                        <asp:Button ID="btnRestar" Text="<" runat="server" CssClass="btn btn-sm   btn-dark" CommandArgument='<%#Eval("Id")%>' OnClick="btnRestar_Click" />
                                        <%--<p class="card-text"><%# carrito.ObtenerCantidadArticulo(((Articulo)Container.DataItem).Id) %></p>--%>
                                        <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                                        <asp:Button ID="btnSumar" Text=">" runat="server" CssClass="btn btn-sm   btn-dark" CommandArgument='<%#Eval("Id")%>' OnClick="btnSumar_Click" />

                                    </div>
                                    <div class="col-md-2 itemsCarrito">
                                        <asp:Label ID="lblTotalCantXart" runat="server"></asp:Label>

                                        <%--<p class="card-text">$ <%# ((decimal)Eval("Precio")) * carrito.ObtenerCantidadArticulo(((Articulo)Container.DataItem).Id) %></p>--%>
                                    </div>
                                    <%--<div class="col-md-2">
                                <a href="Detalle.aspx" class="btn btn-primary">Ver Detalle</a>
                            </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div style="display: flex; justify-content: flex-end;">
                <h4 style="color: white;">TOTAL: $<asp:Label ID="lblPrecioTotal" runat="server" Text=""></asp:Label></h4>

                <%--<h4 style="color: white;">TOTAL COMPRA: $<%: carrito.PrecioTotal %></h4>--%>
            </div>

            <div>

             <%--   <%if (Session["Carrito"] != null)
                    {%>--%>

                <asp:Button Text="Realizar pedido" ID="btnPedido" CssClass="btn btn-success" OnClick="btnPedido_Click" runat="server" />
                <asp:UpdatePanel ID="updatePanelMensajeError" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>


                            <div class="alert" style="display: flex; flex-direction: column; align-items: center; text-align: center; margin-top: 2vh;">
                                <% if (lblMensajeError.Visible){ %>
                                <i class="fa-solid fa-circle-exclamation fa-xl" style="color: #ff8040; margin-top: 2vh;" ></i>
                                <% } %>


                                <asp:Label ID="lblMensajeError" runat="server" Visible="false" CssClass="alert d-flex align-items-center mensajeError" Style="margin-top: 1vh; color: orange;"></asp:Label>
                                <asp:Timer ID="timerMensajeError" runat="server"  OnTick="timerMensajeError_Tick" Enabled="false"></asp:Timer>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
               <%-- <% }

                   else
                    {%>
                <asp:Label Text="Carrito vacio" runat="server" />
                <a href="Listado.aspx" class="btn btn-success">Ver productos</a>
                <%} %>--%>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>




    <style>
        .itemsCarrito {
            margin: auto;
            text-align: center;
        }
        .mensajeError{
            font-size:x-large;
        }
    </style>





</asp:Content>

