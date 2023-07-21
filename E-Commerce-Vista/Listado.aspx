<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="E_Commerce_Vista.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .filtros {
            float: left;
            width: 15%;
            position: fixed;
            z-index: 2;
            top: 20px;
            left: 0;
            height: 100%;
            background-color: black;
        }

        .estiloFiltros {
            margin-top: 10vh;
        }

        /*Filtro buscar rapido*/
        .filtrosAv {
            color: white;
        }

        .filtros .form-control {
            width: 50%;
            margin: 0 auto;
        }
        
    </style>



    <div class="containerTotal">
        <%-- FILTROS --%>

        <div class="filtros" id="filtros" runat="server" style="display:none;">
            <div class="estiloFiltros text-center">


                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <%-- Buscador --%>
                        <div class="row filtroRapido">
                            <div class="col-12 filtrosAv">
                                <div class="mb-3">
                                    <asp:Label Text="Buscar" runat="server" />
                                    <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <%-- Filtros desplegables --%>
                        <div class="row">
                            <div class="col-12 filtrosAv">
                                <div class="mb-3">
                                    <asp:Label Text="Campo" ID="ddlCampo1" runat="server" />
                                    <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control">
                                        <asp:ListItem Text="Precio" />
                                        <asp:ListItem Text="Nombre" />
                                        <asp:ListItem Text="Marcas" />
                                        <asp:ListItem Text="Categorías" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <%-- Criterio --%>

                        <div class="row">
                            <div class="col-12 filtrosAv">
                                <div class="mb-3">
                                    <asp:Label Text="Criterio" runat="server" />
                                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <%-- Filtros --%>
                        <div class="row">
                            <div class="col-12 filtrosAv">
                                <div class="mb-3">
                                    <asp:Label Text="Filtro" runat="server" />
                                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                                </div>
                            </div>
                        </div>


                        <%-- Boton buscar, borrar y ordenar filtros--%>
                        <div class="row">
                            <div class="col-12 filtrosAv">
                                <div class="mb-3 botonFILTRO">
                                    <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-outline-light form-control" OnClick="btnBuscar_Click" style="width:100px"/>
                                </div>
                                <div class="mb-3 botonFILTRO">
                                    <asp:Button Text="Limpiar" runat="server" ID="btnQuitarFiltros" CssClass="btn btn-outline-light form-control" OnClick="btnQuitarFiltros_Click" style="width:100px"/>
                                </div>


                                <div class="dropdown mb-3 botonFILTRO">
                                    <button class="btn btn-outline-light dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false" width:"80px";>
                                        Ordenar
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option1_Click">A-Z</a></li>
                                        <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option2_Click">Z-A</a></li>
                                        <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option3_Click">Mayor a menor</a></li>
                                        <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option4_Click">Menor a mayor</a></li>
                                    </ul>
                                </div>

                            </div>
                        </div>


                         <asp:UpdatePanel ID="updatePanelMensajeError" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>


                            <div class="alert" style="display: flex; flex-direction: column; align-items: center; text-align: center; margin-top: 2vh;">
                                <% if (lblMensajeError.Visible){ %>
                                <i class="fa-solid fa-circle-exclamation fa-xl" style="color: #ff8040; margin-top: 2vh;" ></i>
                                <% } %>
                                

                                <asp:Label ID="lblMensajeError" runat="server" Visible="false" CssClass="alert d-flex align-items-center" Style="margin-top: 1vh; color: orange;"></asp:Label>
                                <asp:Timer ID="timerMensajeError" runat="server" Interval="5000" OnTick="timerMensajeError_Tick" Enabled="false"></asp:Timer>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>


                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <%-- TERMINA ESTILO FILTROS --%>
        </div>
        <%-- TERMINA FILTROS --%>


      







        <%-- CARDS --%>
        <asp:UpdatePanel ID="panel1" runat="server" OnLoad="panel1_Load">
            <ContentTemplate>
                <div class="cards-container">
                    <div class="row row-cols-1 row-cols-md-3 g-4">

                        <%-- Repeater --%>
                        <asp:Repeater ID="repRepetidor" runat="server" OnItemDataBound="repRepetidor_ItemDataBound">
                            <ItemTemplate>
                                <div class="col col-12  col-md-6 col-lg-4 text-center">
                                    <div class="card">
                                        <asp:Image ID="imgImagen" class="card-img-top" runat="server" CssClass="card-img-top" />
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Nombre") %> </h5>
                                            <p class="card-text"><%# Eval("CodigoArticulo")%></p>
                                            <p class="card-text">$<%# Eval("Precio")%></p>
                                            <asp:Button Text="Ver Detalle" ID="btnDetalle" CssClass="btn btn-dark " runat="server" OnClick="btnDetalle_Click" CommandArgument='<%#Eval("Id")%>' />

                                            <asp:Button Text="Agregar al carrito" ID="btnEjemplo" CssClass="btn btn-success btnAgregar btn-pg-1" runat="server" OnClick="btnAgregarCarrito_Click" CommandArgument='<%# Eval("Id") %>' OnClientClick="mostrarMensaje();" />

                                            <asp:Button Text="♥" CssClass="btn btnFav" ID="btnFavorito" OnClick="btnFavorito_Click" CommandArgument='<%#Eval ("Id") %>' runat="server" />

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>


        <div class="containerDerecha">
        </div>


    </div>
    <%-- TERMINA CONTAINER TOTAL  --%>



    <style>
        .cards-container {
            margin-top: 5vh;
        }

        .card-img-top {
            height: 300px;
            width: auto;
        }

        .btnFav {
            color: black;
            border: none;
            font-size: xx-large;
        }

        .btn-favorito-activo {
            color: purple;
        }
        
    </style>


    <%-- volvemos a asignar los eventos al click del carrito-master --%>
    <script>


        function mostrarMensaje() {
            var mensajeCarrito = document.getElementById("mensajeCarritoo");
            mensajeCarrito.innerText = "Artículo agregado al carrito";
            mensajeCarrito.style.display = "block";

            setTimeout(function () {
                mensajeCarrito.style.display = "none";
            }, 4000);
        }

        function toggleFiltros() {
            var filtros = document.getElementById('filtros');
            filtros.style.display = (filtros.style.display === 'none') ? 'block' : 'none';
            return false;
        }


        function asignarEventos() {
            var btnAgregarCesta = document.querySelectorAll(".btn.btn-success");
            btnAgregarCesta.forEach(function (button) {
                button.addEventListener("click", sumarAlCarrito);
            });
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            asignarEventos();
        });


        function redirectToListado() {
            window.location.href = "ListadoCarrito.aspx";
        }
        //actualizamos btn fav
        function btnFavoritoClick(btnId) {
            __doPostBack(btnId, '');
        }



    </script>


</asp:Content>
