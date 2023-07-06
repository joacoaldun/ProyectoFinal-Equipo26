<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RecuperarCuenta.aspx.cs" Inherits="E_Commerce_Vista.RecuperarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
            <div class="row justify-content-center">

                <div class="col-4">
                    <div class="mb-3">
                        <h1>Restablecer contraseña</h1>
                    </div>

                    <%-- Si todavía no recuperó contraseña --%>
                    <%if (!codigoEnviado && !codigoValidado)
                        {%>
                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Correo electrónico</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                    </div>
                    <asp:Button Text="Restablecer contraseña" CssClass="btn btn-success" runat="server" ID="btnRestablecer" OnClick="btnRestablecer_Click" />


                    <%}
                        else if (codigoEnviado && !codigoValidado)
                        {%>
                    <%-- Si ya apretó en "reestablecer" --%>

                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Ingrese el código de validación enviado a su email.</label>
                        <asp:TextBox type="text" class="form-control" ID="txtCodigoValidacion" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button Text="Validar" ID="btnValidar" CssClass="btn btn-success" OnClick="btnValidar_Click" runat="server" />
                    <%}
                        else if(codigoValidado)
                        {%>
                    <%-- Si ya validó el codigo, reestablecer pass --%>


                    <asp:UpdatePanel runat="server" ID="panelPass" UpdateMode="Conditional" >
                        <ContentTemplate>   

                            <div class="mb-3 mt-3">
                        <label for="txtPass" class="form-label">Ingrese una Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" TextMode="Password" OnTextChanged="txtPass_TextChanged" />
                        <div id="errorPass" class="invalid-feedback " runat="server">Campo obligatorio.</div>
                    </div>

                                      
                   
                    <div class="mb-3 mt-3">
                        <label for="txtPass" class="form-label">Confirme Contraseña</label>
                        <asp:TextBox ID="txtConfirmarPass" CssClass="form-control is-invalid" runat="server" AutoPostBack="true" TextMode="Password" OnTextChanged="txtConfirmarPass_TextChanged" />
                        <div id="errorConfirmarPass" class="invalid-feedback " runat="server">Campo obligatorio.</div>

                    </div>
                   
                    <div class="mb-3">
                        <asp:Button Text="Cambiar contraseña" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" OnClientClick="return validarFormulario();" />
                        <a href="Default.aspx" class="btn btn-primary">Cancelar</a>

                    </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <% }%>
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


            </div>


</asp:Content>

