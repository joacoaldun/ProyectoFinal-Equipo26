﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Commerce_Vista.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel Id="panelLogin" runat="server">
        <ContentTemplate>


            <div class="row justify-content-center">
                <div class="col-4">
                    <div class="mb-3 mt-4 login">
                        <h1 class="text-center">Iniciar sesión</h1>
                    </div>
                    <div class="mb-3 login mt-4">
                        <label class="form-label">Usuario</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUser" />
                    </div>

                    <div class="mb-3 login">
                        <label class="form-label">Password</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
                    </div>

    <div class="text-center">
                    <div clas="mb-3 login">
                        <p>¿No tiene una cuenta?
                            <a href="Registro.aspx">Cree una.</a>
                        </p> 
                    </div>

                    <div class="mb-3 login">
                        <a href="RecuperarCuenta.aspx">¿Olvidó su contraseña?</a>
                    </div>

                    <asp:Button Text="Login" runat="server" CssClass="btn btn-dark btnLogin" ID="btnIngresar" OnClick="btnIngresar_Click" />
                    <a href="Default.aspx" Class="btn btn-dark btnCancelar">Cancelar</a>
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
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

    <style>
         .btnCancelar{
            background-color:black;
            color:white;
            width:130px;
        }
        
        .btnLogin{
            background-color:purple;
            color:white;
            width:130px;
        }
        /*ESTILO VISUAL*/
        .login,p{
            color:white;
            font-size:x-large;
        }
        
        a{  

            
            color:lightblue;
            /*font-weight:bold;*/
        }
        
       
    </style>

</asp:Content>
