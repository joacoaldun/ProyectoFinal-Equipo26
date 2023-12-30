<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPedido.aspx.cs" Inherits="E_Commerce_Vista.FormularioPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <asp:UpdatePanel runat="server" ID="updatePedido" >
        <ContentTemplate>


            <div class="row login">
                <%--Titulo --%>
                 <div class="col-12 text-center tituloGeneral"> 
                    <asp:Label Text="" ID="lblNroPedido" CssClass="nroPedido login " runat="server" />
                 </div>

                 <%-- Listado cliente, domicilio, estadopedido y btones --%>
                <div class="col-4 datosPedido">
                    <div class="datos">
                        <h2>DATOS DEL CLIENTE</h2>
                        <table>
                            <tr>
                                <td class="tituloHeader">Apellido:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblApellido" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">Nombre:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblNombre" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">DNI:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblDni" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">Email:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblEmail" runat="server" /></td>
                            </tr>
                        </table>
                    </div>

                    <div class="datos">
                        <%-- <h2>DIRECCION DE ENTREGA</h2>*/ --%>
                        <table>
                            <tr>
                                <td class="tituloHeader">Provincia:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblProvincia" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">Localidad:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblLocalidad" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">Código Postal:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblCodigoPostal" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">Dirección:</td>
                                <td class="contenido">
                                    <asp:Label Text="" ID="lblDireccion" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">Número Departamento:</td>
                                <td class="contenido" >
                                    <asp:Label Text="" ID="lblNumeroDepartamento" runat="server" /></td>
                            </tr>
                        </table>
                    </div>

                    
                   
                </div>


                <%-- Listado arts... --%>



                <div class="col-4 datosArticulos">
                     <h2>ARTICULOS SOLICITADOS</h2>
                    <div class="containerArticulos">

                        <asp:Repeater ID="repListadoArticulos" runat="server" OnItemDataBound="repListadoArticulos_ItemDataBound">
                            <ItemTemplate>

                                <div class="mb-3 mt-2">

                                    <div class="row g-0">
                                        <div class="col-md-6">
                                            <asp:Image ID="ImagenArticulo" CssClass="img-fluid rounded-start img-left" runat="server" />
                                        </div>
                                        <div class="col-md-6 ">
                                            <div class="card-body">
                                                <p class="card-title botonesYcantidad"><%# Eval("Nombre") %></p>
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
                               
                            </ItemTemplate>
                        </asp:Repeater>

                         <h4 class="login "  >TOTAL: <asp:Label ID="lblPrecioTotal"  runat="server" Text="" ></asp:Label></h4>
                    </div>


                   
                </div>

                <div class="col-4 ">
                        <h2>ESTADO DEL PEDIDO</h2>
                        <table>
                            <tr>
                                <td class="tituloHeader">Medio de pago <td>
                                <asp:TextBox ID="txtMedioPago" runat="server" CssClass="form-control" Enabled="false" style="background-color:grey;color:white;"></asp:TextBox>
                            </tr>

                            <tr>
                                <td class="tituloHeader">Estado del pago </td>
                                <td class=" ddlContenido">

                                <asp:DropDownList runat="server" Id="ddlPagado" CssClass="form-select" AutoPostBack="true" OnTextChanged="ddlPagado_TextChanged">
                                    <asp:ListItem Text="Abonado" />
                                    <asp:ListItem Text="No abonado" />
                                </asp:DropDownList>

                            </tr>

                            <tr id="divPago" runat="server">
                                <td class="tituloHeader">Codigo de pago </td>
                                <td><asp:TextBox ID="txtCodigoPago" runat="server" CssClass="form-control place" placeholder="Ingrese codigo"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td class="tituloHeader">Estado del Pedido </td>
                                <td class=" ddlContenido">
                                    <asp:DropDownList runat="server" Id="ddlEstadoPedido" AutoPostBack="true"  CssClass="form-select" OnTextChanged="ddlEstadoPedido_TextChanged" >
                                    </asp:DropDownList>
                            </tr>

                       <div id="divEnvio" runat="server">
                            <tr>
                                <td class="tituloHeader" >Medio de envio</td> 
                                   <td>
                                     <asp:DropDownList runat="server" Id="ddlMedioEnvio" AutoPostBack="true"  CssClass="form-select" >
                                    </asp:DropDownList>
                                   </td>
                            </tr>
                            <tr>
                                <td class="tituloHeader">Codigo de envio </td>
                                <td>
                                <asp:TextBox ID="txtCodigoEnvio" runat="server" CssClass="form-control place" placeholder="Ingrese codigo"></asp:TextBox></td>
                            </tr>
                        </div>          
                      </div>
                        </table>

                    <div class="botones mt-2">


                      <asp:button text="Guardar cambios" CssClass="btn btn-dark btnGuardar"  AutoPostBack="true" runat="server" Id="btnGuardarCambios" Onclick="btnGuardarCambios_Click"  Visible="false" />
                     

                    </div>
                    <div class="botones  mt-2">
                     <a href="GestionPedidos.aspx" class="btn btn-success btnVolver">Volver</a>
                    </div>
                    </div>
                
                    

                    <asp:UpdatePanel ID="updatePanelMensajeError" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>


                            <div class="alert" style="display: flex; flex-direction: column; align-items: center; text-align: center; ">
                                <% if (lblMensajeError.Visible){%>
                                <i class="fa-solid fa-circle-exclamation fa-xl" style="color: #ff8040; " ></i>
                                 
                                <% } %>
                                <asp:Label ID="lblMensajeError" runat="server" Visible="false" CssClass="alert d-flex align-items-center" Style=" color: orange; font-size:xx-large;"></asp:Label>
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
            width: 80%;
        }
        img{
            margin-right:2vh;
        }
         /*.datos table td {
             width: 30%;
         }*/

         h2{
             font-size:xx-large;
             /*font-weight:bold;*/
         }

         .datos{
             margin-bottom:0px;
         }

         .btn{
           
             width:160px;
         }

         .botones{
            text-align:center;
         }
         
         .btnVolver{
             background-color:purple;
             border:none;
         }
         .login{
             color:white;
         }
        .nroPedido{
            /*font-size:xx-large;*/
            font-size:50px;
        }

        .tituloHeader{
            font-size:large;
            font-weight:normal;
            width:30%;
        }
        .contenido{
            font-size:large;
            width:70%;
        }
        
        .botonesYcantidad{
            margin-left:40px;
            display:flex;
            justify-content:start;
        }
        .form-select, .form-control {
            width:200px;
        }
       .tituloGeneral{
           margin-bottom:6vh;
       }
       .alert{
           margin-top:0;
       }
       .place::placeholder{
           color:orange;
       }

      
    </style>



</asp:Content>
