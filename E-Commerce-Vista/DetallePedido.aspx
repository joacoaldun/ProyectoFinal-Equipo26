<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="E_Commerce_Vista.DetallePedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body{
            color:white;
        }
        .nroPedido{
           
            font-size:50px;
        }
        .tituloGeneral{
           margin-bottom:6vh;
            
       }

        
    </style>
    <div class="col-12 text-center tituloGeneral"> 
        <asp:Label Text="" ID="lblNroPedido" CssClass="nroPedido" runat="server" />
     </div>
    <asp:UpdatePanel runat="server" ID="updatePedido" >
        <ContentTemplate>


            <div class="row">

                <%-- Listado arts... --%>

                <div class="col-6 datosArticulos">
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
                                                <h5 class="card-title botonesYcantidad"><%# Eval("Nombre") %></h5>
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

                        <h4 style="color: white;">TOTAL: <asp:Label ID="lblPrecioTotal" runat="server" Text=""></asp:Label></h4>
                    </div>
                    
                </div>

                <%-- Listado cliente, domicilio, estadopedido y btones --%>
                <div class="col-6 datosPedido">
                    <div class="datos">

                    <div class="datos">
                        <h3>DIRECCION DE ENTREGA</h3>
                        <table>
                            <tr>
                                <td>Provincia:</td>
                                <td>
                                    <asp:Label Text="" ID="lblProvincia" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Localidad:</td>
                                <td>
                                    <asp:Label Text="" ID="lblLocalidad" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Código Postal:</td>
                                <td>
                                    <asp:Label Text="" ID="lblCodigoPostal" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Dirección:</td>
                                <td>
                                    <asp:Label Text="" ID="lblDireccion" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Número Departamento:</td>
                                <td>
                                    <asp:Label Text="" ID="lblNumeroDepartamento" runat="server" /></td>
                            </tr>
                        </table>
                    </div>

                    <div class="datos">
                        <h3>ESTADO DEL PEDIDO</h3>
                        <table>
                            <tr>
                                <td>Medio de pago:</td>
                                <td><asp:Label Text="" ID="txtMedioPago" runat="server" /></td>

                            </tr>

                            <tr>
                                <td>Estado del pago:</td>
                                <td>

                                    <asp:Label Text="" ID="lblPagado" runat="server" /></td>


                            </tr>
                             <tr id="divPago" runat="server">		
                                <td class="tituloHeader">Codigo de pago </td>		
                                <td><asp:Label ID="txtCodigoPago" runat="server" ></asp:Label></td>		
                            </tr>		

                            <tr>
                                <td>Estado del Pedido:</td>
                                <td>

                                     <asp:Label Text="" ID="lblEstado" runat="server" /></td>
                                    
                            </tr>

                             <div id="divEnvio" runat="server">			
                                <tr>			
                                    <td class="tituloHeader" >Medio de envio</td> 			
                                       <td>
                                            <asp:Label Text="" ID="txtMedioEnvio"  runat="server" />
                                        		
                                       </td>			
                                </tr>			
                                <tr>			
                                    <td class="tituloHeader">Codigo de envio </td>			
                                    <td>			
                                    <asp:Label ID="txtCodigoEnvio" runat="server"  ></asp:Label></td>			
                                </tr>			
                            </div>  			



                        </table>
                    </div>
                    <div class="botones ">
                      <a href="MisPedidos.aspx" class="btn btn-success btnVolver">Volver</a>
                    </div>

                </div>
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

         h2{
             font-size:medium;
             font-weight:bold;
         }

         .datos{
             margin-bottom:30px;
         }

         .btnVolver{
           
             width:160px;
         }

         .botones{
            display: flex;
            justify-content:start;

         }
         
         .btnVolver{
             background-color:purple;
             border:none;
         }

        .botonesYcantidad{
            margin-left:40px;
            display:flex;
            justify-content:start;
        }
    </style>






</asp:Content>
