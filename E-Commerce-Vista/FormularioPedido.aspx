<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPedido.aspx.cs" Inherits="E_Commerce_Vista.FormularioPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Label Text="" ID="lblNroPedido" CssClass="nroPedido login" runat="server" />

    <asp:UpdatePanel runat="server" ID="updatePedido" >
        <ContentTemplate>


            <div class="row login">

                <%-- Listado arts... --%>

                <div class="col-4 datosArticulos">
                    <div class="containerArticulos">

                        <asp:Repeater ID="repListadoArticulos" runat="server" OnItemDataBound="repListadoArticulos_ItemDataBound">
                            <ItemTemplate>

                                <div class="mb-3 mt-3">

                                    <div class="row g-0">
                                        <div class="col-md-4">
                                            <asp:Image ID="ImagenArticulo" CssClass="img-fluid rounded-start img-left" runat="server" />
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <h4 class="card-title"><%# Eval("Nombre") %></h4>
                                                <div class="botonesYcantidad">
                                                    Cantidad:
                                                     <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                                                   

                                                </div>
                                                
                                                <div class="botonesYcantidad">
                                                     Precio U.:
                                                     <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                        </div>
                                    </div>


                                </div>
                                <%--   <div class="mb-3 mt-3">
                                    <h6 class="card-title">$<%# Eval("PrecioTotal") %></h6>
                                     
                                </div>--%>
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>

                    <h4 class="login" >TOTAL: $<asp:Label ID="lblPrecioTotal"  runat="server" Text=""></asp:Label></h4>
                </div>

                <%-- Listado cliente, domicilio, estadopedido y btones --%>
                <div class="col-8 datosPedido">
                    <div class="datos">
                        <h2>DATOS DEL CLIENTE</h2>
                        <table>
                            <tr>
                                <td><strong>Apellido:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblApellido" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Nombre:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblNombre" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>DNI:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblDni" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Email:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblEmail" runat="server" /></td>
                            </tr>
                        </table>
                    </div>

                    <div class="datos">
                        <h2>DIRECCION DE ENTREGA</h2>
                        <table>
                            <tr>
                                <td><strong>Provincia:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblProvincia" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Localidad:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblLocalidad" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Código Postal:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblCodigoPostal" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Dirección:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblDireccion" runat="server" /></td>
                            </tr>
                            <tr>
                                <td><strong>Número Departamento:</strong></td>
                                <td>
                                    <asp:Label Text="" ID="lblNumeroDepartamento" runat="server" /></td>
                            </tr>
                        </table>
                    </div>

                    <div class="datos">
                        <h2>ESTADO DEL PEDIDO</h2>
                        <table>
                            <tr>
                                <td><strong>Estado del pago:</strong></td>
                                <td>

                                <asp:DropDownList runat="server" Id="ddlPagado" CssClass="form-select" AutoPostBack="true" OnTextChanged="ddlPagado_TextChanged">
                                    <asp:ListItem Text="Abonado" />
                                    <asp:ListItem Text="No abonado" />
                                </asp:DropDownList>

                            </tr>
                            <tr>
                                <td><strong>Estado del Pedido:</strong></td>
                                <td>
                                    <asp:DropDownList runat="server" Id="ddlEstadoPedido" AutoPostBack="true"  CssClass="form-select" OnTextChanged="ddlEstadoPedido_TextChanged" >
                                    </asp:DropDownList>
                            </tr>
                        </table>
                    </div>
                    <div class="botones">
                      <asp:button text="Guardar cambios" CssClass="btn btn-dark btnGuardar"  AutoPostBack="true" runat="server" Id="btnGuardarCambios" Onclick="btnGuardarCambios_Click" />
                      <a href="GestionPedidos.aspx" class="btn btn-success btnVolver">Volver</a>
                    </div>


                    <asp:UpdatePanel ID="updatePanelMensajeError" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>


                            <div class="alert" style="display: flex; flex-direction: column; align-items: center; text-align: center; margin-top: 2vh;">
                                <% if (lblMensajeError.Visible){ %>
                                <i class="fa-solid fa-circle-exclamation fa-xl" style="color: #ff8040; margin-top: 2vh;" ></i>
                                <% } %>


                                <asp:Label ID="lblMensajeError" runat="server" Visible="false" CssClass="alert d-flex align-items-center" Style="margin-top: 1vh; color: orange;"></asp:Label>
                                <asp:Timer ID="timerMensajeError" runat="server"  OnTick="timerMensajeError_Tick" Enabled="false"></asp:Timer>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>




                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>




    <style>
        .containerArticulos {
            height: calc(550px - 50px);
            overflow-y: auto;
        }

        .datos table {
            width: 100%;
        }

         .datos table td {
             width: 50%;
         }

         h2, .nroPedido{
             font-size:medium;
             font-weight:bold;
         }

         .datos{
             margin-bottom:30px;
         }

         .btn{
           
             width:160px;
         }

         .botones{
            text-align:right;
         }
         
         .btnVolver{
             background-color:purple;
             border:none;
         }
         .login{
             color:white;
         }
        
    </style>



</asp:Content>
