<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="E_Commerce_Vista.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="updatePanelCliente" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">

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
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" />
                        <div id="errorNombre" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3 mt-3">
                        <label for="txtApellido" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellido" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtApellido_TextChanged" />
                        <div id="errorApellido" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>


                    <div class="mb-3 mt-3">
                        <label for="txtUserName" class="form-label">Username</label>
                        <asp:TextBox ID="txtUserName" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtUserName_TextChanged" />
                        <div id="errorUserName" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3 mt-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" />
                        <div id="errorEmail" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>




                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" OnClientClick="return validarFormulario();" />
                        <a href="GestionUsuarios.aspx?id=1" class="btn btn-primary">Cancelar</a>



                    </div>
                </div>



                <div class="col-4">

                    <div class="mb-3 mt-3">
                        <label for="txtDni" class="form-label">Dni</label>

                        <asp:TextBox ID="txtDni" CssClass="form-control " AutoPostBack="true" OnTextChanged="txtDni_TextChanged" runat="server" />
                        <div id="errorDni" class="invalid-feedback " runat="server"></div>

                    </div>


                    <div class="col-4">



                        <div class="mb-3 mt-3">
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" AutoPostBack="true" />
                        </div>
                       <%-- <asp:RegularExpressionValidator ID="revFechaNacimiento" runat="server"
                            ControlToValidate="txtFechaNacimiento"
                            ValidationExpression="(0[1-9]|1[0-2])/(0[1-9]|1\d|2\d|3[01])/(19|20)\d{2}"
                            ErrorMessage="Ingrese una fecha válida en formato MM/DD/YYYY"></asp:RegularExpressionValidator>--%>


                        <div class="mb-3 mt-3">
                            <%--                        <label for="txtPublicar" class="form-label">Articulo publicado</label>--%>
                            <%--                        <asp:TextBox ID="txtPublicar" CssClass="form-control" runat="server"></asp:TextBox>--%>

                            <label for="ddlBajaLogica" class="form-label">Estado de Cliente</label>
                            <asp:DropDownList ID="ddlBajaLogica" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>






                    </div>

                </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <style>
        .row {
            display: flex;
        }

        .col-4 {
            flex-basis: 50%; /* O cualquier otro ancho deseado */
        }
    </style>





</asp:Content>
