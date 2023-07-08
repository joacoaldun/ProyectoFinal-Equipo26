<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CompletarDatos.aspx.cs" Inherits="E_Commerce_Vista.CompletarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="updateDatos">
        <ContentTemplate>


            <div class="row">
                <div class="col-4">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Provincia" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlProvincia" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"  AutoPostBack="true" CssClass="form-control is-valid">
                        </asp:DropDownList>
                    
                    </div>

                    <div class="mb-3 mt-3">
                        <asp:Label Text="Localidad" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlLocalidad" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control is-valid">
                        </asp:DropDownList>
                       
                    </div>

                    <div class="mb-3 mt-3">
                        <asp:Label Text="Tipo de vivienda" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlVivienda" OnSelectedIndexChanged="ddlVivienda_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control is-valid">
                            <asp:ListItem>Casa</asp:ListItem>
                            <asp:ListItem>Departamento</asp:ListItem>
                        </asp:DropDownList>
                       
                    </div>


                    <div class="mb-3 mt-3">
                        <asp:Label Text="Direccion" runat="server" />
                        <asp:TextBox runat="server" ID="txtDireccion" AutoPostBack="true" OnTextChanged="txtDireccion_TextChanged" CssClass="form-control is-invalid" />
                        <div id="errorDireccion" runat="server" class ="invalid-feedback">Campo obligatorio.</div>
                    </div>

                    <div class="mb-3 mt-3">
                        <asp:Label Text="Codigo postal" runat="server" />
                        <asp:TextBox runat="server" ID="txtCodigoPostal" OnTextChanged="txtCodigoPostal_TextChanged" AutoPostBack="true" CssClass="form-control is-invalid" />
                        <div id="errorCodigoPostal" runat="server"  class="invalid-feedback">Campo obligatorio.</div>
                    </div>

                    <%-- Si es departamento... --%>
                    <%if (ddlVivienda.SelectedValue == "Departamento")
                        {%>
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Departamento" runat="server" />
                        <asp:TextBox runat="server" ID="txtDepartamento" OnTextChanged="txtDepartamento_TextChanged" AutoPostBack="true" CssClass="form-control is-invalid" />
                        <div id="errorDepartamento"  runat="server" class="invalid-feedback">Campo obligatorio.</div>
                    </div>
                    <%} %>
                </div>

            </div>

                <asp:Button Text="Realizar pedido" CssClass="btn btn-success" runat="server" Id="btnRealizarPedido" OnClick="btnRealizarPedido_Click"/>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
