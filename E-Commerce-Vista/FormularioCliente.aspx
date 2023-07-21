<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="E_Commerce_Vista.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="updatePanelCliente" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row login">

                <div class="col-4">

                    <%if (verId)
                        {%>
                    <div class="mb-3 mt-3">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                    </div>
                    <% }%>



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
                        <asp:TextBox ID="txtEmail" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" TextMode="Email" />
                        <div id="errorEmail" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>
                    
                    <%if (Request.QueryString["id"] == null)
                        { %>
                    <div class="mb-3 mt-3">
                        <label for="txtPass" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtPass_TextChanged"/>
                        <div id="errorPass" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>
                    <%} %>


                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" OnClientClick="return validarFormulario();" />
                        <a href="GestionUsuarios.aspx?id=1" class="btn btn-primary">Cancelar</a>



                    </div>
                </div>



                <div class="col-4">

                    <div class="mb-3 mt-3">
                        <label for="txtDni" class="form-label">Dni</label>

                        <asp:TextBox ID="txtDni" CssClass="form-control is-invalid" AutoPostBack="true" OnTextChanged="txtDni_TextChanged" runat="server" />
                        <div id="errorDni" class="invalid-feedback " runat="server">Campo obligatorio</div>

                    </div>


                   



                        <div class="mb-3 mt-3">
                            <label for ="txtMostrarFecha" class="form-label">Fecha de Nacimiento</label>
                            <asp:TextBox ID="txtMostrarFecha" runat="server" CssClass="form-control is-invalid" AutoPostBack="true" OnTextChanged="txtMostrarFecha_TextChanged" ReadOnly="true" />
                            <div id="errorFecha" class="invalid-feedback " runat="server">Campo obligatorio.</div>
                            </br>

                             <label for ="txtFechaNacimiento" class="form-label">Seleccione Fecha de Nacimiento</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFechaNacimiento_TextChanged" onkeydown="return false" TextMode="Date" />
                           <span style="font-size: 12px;">Por favor, haz clic en el calendario para seleccionar una fecha.</span>
                        </div>



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
        .login{
            color:white
        }
    </style>


    



</asp:Content>
