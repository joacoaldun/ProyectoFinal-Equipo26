<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="E_Commerce_Vista.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- CON VALIDACION REQUIRED Y JS --%>

    <asp:UpdatePanel runat="server" ID="updatePanelArticulo" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">

                <div class="col-4">

                    <%if (verId)
                        {%>
                    <div class="mb-3 mt-3">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                    </div>
                    <% }%>




                    <div class="mb-3 mt-3">
                        <label for="txtNombre" class="form-label">Nombre Articulo</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" />
                        <div id="errorNombre" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3 mt-3">
                        <label for="txtCodigoArticulo" class="form-label">Codigo Articulo</label>
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
                        <div id="errorPrecio" class="invalid-feedback ">Campo obligatorio.</div>

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
                        <%-- <%if (modificando)
                            {%>
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click"
                            CssClass="btn btn-danger" runat="server" />
                        <%} %>



                        <%if (confirmarEliminar)
                            {%>

                        <div class="mb-3 mt-3">
                            <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />

                        </div>


                        <%}%>
                    </div>
                
                        --%>
                    </div>
                    </div>
                    <div class="col-4">   
                   
                        <div class="mb-3">
                            <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                            <asp:TextBox ID="txtImagenUrl" CssClass="form-control is-invalid"  runat="server" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"/>
                            <%--<div id="errorImagen" class="invalid-feedback">Url imagen es obligatorio.</div>--%>
                        </div>
                        <div class="mt-3">
                            <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png"
                                runat="server" ID="imgArticulo" Width="100%" />
                            
                            <%if (Session["Imagenes"] != null)
                                {
                                    %>
                            <asp:Button Text="Agregar otra imagen" ID="btnAgregarImagen" CssClass="btn btn-success" OnClick="btnAgregarImagen_Click" runat="server" UseSubmitBehavior="false"/>
                        <%} %>
                        
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
</style>

</asp:Content>




