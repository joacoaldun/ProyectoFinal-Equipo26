<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Commerce_Vista.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel Id="panelLogin" runat="server">
        <ContentTemplate>


            <div class="row justify-content-center">
                <div class="col-4">
                    <div class="mb-3">
                        <h1>Iniciar sesión</h1>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Usuario</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUser" />
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Password</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
                    </div>

                    <div clas="mb-3">
                        <p>¿No tiene una cuenta?
                            <a href="Registro.aspx">Cree una.</a>
                        </p> 
                    </div>

                    <div class="mb-3">
                        <a href="RecuperarCuenta.aspx">¿Olvidó su contraseña?</a>
                    </div>

                    <asp:Button Text="Login" runat="server" CssClass="btn btn-success" ID="btnIngresar" OnClick="btnIngresar_Click" />
                    <a href="Default.aspx" Class="btn btn-danger">Cancelar</a>



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
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
