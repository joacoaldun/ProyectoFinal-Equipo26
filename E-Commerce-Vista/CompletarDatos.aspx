<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CompletarDatos.aspx.cs" Inherits="E_Commerce_Vista.CompletarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="updateDatos">
        <ContentTemplate>


            <div class="row completarDatos">
                <div class="col-4">

                    <div class="mb-3 mt-3 login">
                        <asp:Label Text="Medio de pago" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlMedioPago" OnSelectedIndexChanged="ddlMedioPago_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control is-valid">
                        </asp:DropDownList>
                    </div>


                    <div class="mb-3 mt-3 login">
                        <asp:Label Text="Provincia" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlProvincia" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"  AutoPostBack="true" CssClass="form-control is-valid">
                        </asp:DropDownList>
                    
                    </div>

                    <div class="mb-3 mt-3 login">
                        <asp:Label Text="Localidad" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlLocalidad" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control is-valid">
                        </asp:DropDownList>
                       
                    </div>

                    <div class="mb-3 mt-3 login">
                        <asp:Label Text="Tipo de vivienda" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlVivienda" OnSelectedIndexChanged="ddlVivienda_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control is-valid">
                            <asp:ListItem>Casa</asp:ListItem>
                            <asp:ListItem>Departamento</asp:ListItem>
                        </asp:DropDownList>
                       
                    </div>


                    <div class="mb-3 mt-3 login">
                        <asp:Label Text="Direccion" runat="server" />
                        <asp:TextBox runat="server" ID="txtDireccion" AutoPostBack="true" OnTextChanged="txtDireccion_TextChanged" CssClass="form-control is-invalid" />
                        <div id="errorDireccion" runat="server" class ="invalid-feedback">Campo obligatorio.</div>
                    </div>
                     
                    <div class="mb-3 mt-3 login">
                        <asp:Label Text="Codigo postal" runat="server" />
                        <asp:TextBox runat="server" ID="txtCodigoPostal" OnTextChanged="txtCodigoPostal_TextChanged" AutoPostBack="true" CssClass="form-control is-invalid" />
                        <div id="errorCodigoPostal" runat="server"  class="invalid-feedback">Campo obligatorio.</div>
                    </div>

                    <%-- Si es departamento... --%>
                    <%if (ddlVivienda.SelectedValue == "Departamento")
                        {%>
                    <div class="mb-3 mt-3 login">
                        <asp:Label Text="Departamento" runat="server" />
                        <asp:TextBox runat="server" ID="txtDepartamento" OnTextChanged="txtDepartamento_TextChanged" AutoPostBack="true" CssClass="form-control is-invalid" />
                        <div id="errorDepartamento"  runat="server" class="invalid-feedback">Campo obligatorio.</div>
                    </div>
                    <%} %>


                    <asp:Button Text="Realizar pedido" CssClass="btn btn-success" runat="server" Id="btnRealizarPedido" OnClick="btnRealizarPedido_Click"/>
                </div>

                <div class="col-1">

                </div>

                <div class="col-6 ">
                    <div class="containerArticulos">

                    <asp:Repeater ID="repCarrito" runat="server" OnItemDataBound="repCarrito_ItemDataBound">
                        <ItemTemplate>

                            <div class="card mb-3 mt-3 text-bg-dark p-3" ">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <asp:Image ID="ImagenCarrito" CssClass="img-fluid rounded-start img-left" runat="server" />
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h4 class="card-title"><%# Eval("Nombre") %></h4>
                                            <h6 class="card-title">$<%# Eval("Precio") %></h6>


                                            <div class="botonesYcantidad">
                                             Cantidad:
                                            <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>
                </div>

                            <div class="card mb-3 text-bg-dark p-3">

                                  <h4>Total: $<asp:Label ID="lblPrecioTotal" runat="server" Text=""></asp:Label></h4>

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

        /*ESTILO*/
        .login{
            color:white;
        }
        
    </style>

</asp:Content>
