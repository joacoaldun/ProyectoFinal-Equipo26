<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="E_Commerce_Vista.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        h1{
            color:white;
        }
        .form-label{
            font-size:x-large;
        }
    </style>
    <%-- FORM CON VALIDACIONES --%>

    <h1 class="text-center">Gestionando articulo</h1>
    <asp:UpdatePanel runat="server" ID="updatePanelArticulo" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row login">

                <div class="col-4">

                    <%if (verId)
                        {%>
                    <div class="mb-3 mt-3">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                    </div>
                    <% }
                        %>



                    <div class="mb-3 mt-3">
                        <label for="txtNombre" class="form-label">Codigo Articulo</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" />
                        <div id="errorNombre" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3 mt-3">
                        <label for="txtCodigoArticulo" class="form-label">Nombre Articulo</label>
                        <asp:TextBox ID="txtCodigoArticulo" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoArticulo_TextChanged" />
                        <div id="errorCodigoArticulo" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>


                    <div class="mb-3 mt-3">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control is-invalid" runat="server" TextMode="MultiLine" AutoPostBack="true" OnTextChanged="txtDescripcion_TextChanged" />
                        <div id="errorDescripcion" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3 mt-3">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtPrecio_TextChanged" />
                        <div id="errorPrecio" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca: </label>
                        <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoria</label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>



                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" OnClientClick="return validarFormulario();" />
                        <a href="GestionArticulos.aspx" class="btn btn-primary">Cancelar</a>
                      
                        <%if (modificando)
                            {%>
                        <asp:Button Text="Eliminar" ID="btnEliminarArticulo" OnClick="btnEliminarArticulo_Click"
                            CssClass="btn btn-danger" runat="server" />
                        <%} %>



                        <%if (confirmarEliminar)
                            {
                                %>

                        <div class="mb-3 mt-3">
                            <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion" runat="server" class="confirmarTexto" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-danger" runat="server" />

                        </div>


                        <%}%>


                       
                    </div>
                </div>

                <%-- IMAGENES! --%>

                <div class="col-4">

                    <div class="mb-3 mt-3">
                        <label for="txtStock" class="form-label">Stock articulo</label>

                        <asp:TextBox ID="txtStock" CssClass="form-control " AutoPostBack="true" OnTextChanged="txtStock_TextChanged" runat="server" />
                        <div id="errorStock" class="invalid-feedback " runat="server"></div>
                       
                    </div>


                    <div class="mb-3 mt-3">
<%--                        <label for="txtPublicar" class="form-label">Articulo publicado</label>--%>
<%--                        <asp:TextBox ID="txtPublicar" CssClass="form-control" runat="server"></asp:TextBox>--%>

                        <label for="ddlPublicar" class="form-label">Publicar articulo</label>
                         <asp:DropDownList ID="ddlPublicar" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>



                    <div class="mb-3 mt-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtImagenUrl" CssClass="form-control is-invalid" runat="server" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>

                    <div class="mt-3 ">


                        <div id="carouselExampleControls" class="carousel slide">
                            <div class="carousel-inner carousel-container">


                                <asp:Image ID="imgCarrusel" runat="server" CssClass="d-block w-100" Style="width: 40vh; height: 40vh;" />
                                <%List<string> urls_imagenes = (List<string>)Session["Imagenes"];

                                    if (Session["Imagenes"] != null && urls_imagenes.Count > 1)
                                    {%>
                                <asp:Button Text="<" ID="btnAnterior" OnClick="btnAnterior_Click" CssClass="btn carousel-control-prev btnCarrusel" runat="server" UseSubmitBehavior="false" />
                                <asp:Button Text=">" ID="btnSiguiente" OnClick="btnSiguiente_Click" CssClass="btn carousel-control-next btnCarrusel" runat="server" UseSubmitBehavior="false" />

                                <%}
                        %>
                            </div>
                        </div>
                        <%if (Session["Imagenes"] != null)
                            {%>
                        <asp:Button Text="Agregar otra imagen" ID="btnAgregarOtraImagen" CssClass="btn btn-success" OnClick="btnAgregarImagen_Click" runat="server" UseSubmitBehavior="false" />
                        <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificarImagen_Click" CssClass="btn btn-primary" runat="server" UseSubmitBehavior="false" />
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" UseSubmitBehavior="false" />



                        <%}

                            else
                            { %>
                        <asp:Button Text="Agregar imagen" ID="AgregarImagen" CssClass="btn btn-success" OnClick="btnAgregarImagen_Click" runat="server" UseSubmitBehavior="false" />

                        <%}%>
                    </div>

                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <%--<div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    

                    <%if (confirmarEliminar)
                        {%>

                    <div class="mb-3 mt-3">
                        <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />

                    </div>


                    <%}%>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>--%>

    <style>
        .row {
            display: flex;
        }

        .col-4 {
            flex-basis: 50%; /* O cualquier otro ancho deseado */
        }

        .carousel-container {
            position: relative;
            display: inline-block;
        }

        .btnCarrusel {
            position: absolute;
            top: 45%;
            background-color: black;
            color: white;
            border-radius: 50%;
            width: 40px;
            height: 40px;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .btnAnterior {
            left: 0;
        }

        .btnSiguiente {
            right: 0;
        }
        .login{
            color:white;
        }
        .confirmarTexto{
            font-size:x-large;
        }
        .invalid-feedback{
            color:orange;
        }
    </style>



</asp:Content>




