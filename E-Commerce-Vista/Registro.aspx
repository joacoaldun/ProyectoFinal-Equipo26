<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="E_Commerce_Vista.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:UpdatePanel runat="server" ID="updatePanelCliente" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">

                <div class="col-4">



                    <div class="mb-3 mt-3">

                        <label for="txtNombre" class="form-label">Ingrese su Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" />
                        <div id="errorNombre" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3 mt-3">
                        <label for="txtApellido" class="form-label">Ingrese su Apellido</label>
                        <asp:TextBox ID="txtApellido" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtApellido_TextChanged" />
                        <div id="errorApellido" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>


                    <div class="mb-3 mt-3">
                        <label for="txtUserName" class="form-label">Ingrese su Username</label>
                        <asp:TextBox ID="txtUserName" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtUserName_TextChanged" />
                        <div id="errorUsername" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>

                    <div class="mb-3 mt-3">
                        <label for="txtEmail" class="form-label">Ingrese su Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" TextMode="Email" />
                        <div id="errorEmail" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>
                    
                  
                    <div class="mb-3 mt-3">
                        <label for="txtPass" class="form-label">Ingrese una Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" TextMode="Password" OnTextChanged="txtPass_TextChanged"/>
                        <div id="errorPass" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>


                     <%if (txtPass.Text != null && txtPass.CssClass == "form-control is-valid")
                         {   %>
                     <div class="mb-3 mt-3">
                        <label for="txtPass" class="form-label">Confirme Contraseña</label>
                        <asp:TextBox ID="txtConfirmarPass" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" TextMode="Password" OnTextChanged="ConfirmarPass_TextChanged" />
                        <div id="errorConfirmarPass" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>
                    <%} %>
                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" OnClientClick="return validarFormulario();" />
                        <a href="Default.aspx" class="btn btn-primary">Cancelar</a>



                    </div>
                </div>



                <div class="col-4">

                    <div class="mb-3 mt-3">
                        <label for="txtDni" class="form-label">Ingrese su Dni</label>

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
