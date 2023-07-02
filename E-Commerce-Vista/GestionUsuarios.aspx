<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="E_Commerce_Vista.GestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%if (int.Parse(Request.QueryString["id"]) == 1)
        {
    %>
    <asp:UpdatePanel runat="server" ID="updatePanelCliente" UpdateMode="Conditional">
        <ContentTemplate>
            <h3>Lista de Clientes a gestionar</h3>


            <div class="row">

                <div class="col-2">



                    <div class="mb-3 mt-3">
                        <asp:Label Text="Filtrar por Apellido" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroApellido" AutoPostBack="true" OnTextChanged="FiltroApellido_TextChanged" CssClass="form-control" />
                    </div>

                </div>
                <div class="col-2">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Filtrar por Dni" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroDni" AutoPostBack="true" OnTextChanged="Dni_TextChanged" CssClass="form-control" />
                        <div id="errorDni" class="invalid-feedback " runat="server"></div>
                    </div>
                </div>

                <div class="col-2">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Filtrar por Email" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltrarMail" AutoPostBack="true" OnTextChanged="txtFiltrarMail_TextChanged" CssClass="form-control" />

                    </div>
                </div>
            </div>

            <asp:GridView ID="dgvClientes" runat="server" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" CssClass="table table-striped"
                DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="12" OnPageIndexChanging="dgvClientes_PageIndexChanging">

                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField HeaderText="Username" DataField="Username" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField HeaderText="Email" DataField="Email" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField HeaderText="Dni" DataField="Dni" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField HeaderText="Fecha de nacimiento" DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />


                    <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                </Columns>

            </asp:GridView>
            <a href="FormularioCliente.aspx" class="btn btn-success">Agregar</a>
            <a href="PanelGestion.aspx" class="btn btn-danger">Volver</a>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%} %>

    <%else if (int.Parse(Request.QueryString["id"]) == 2)
        {
    %>
    <asp:UpdatePanel runat="server" ID="updatePanelAdmin" UpdateMode="Conditional">
        <ContentTemplate>
            <h3>Lista de Admins a gestionar</h3>


            <div class="row">

                <div class="col-2">



                    <div class="mb-3 mt-3">
                        <asp:Label Text="Filtrar por Apellido" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltrarPorApellidoAdmin" AutoPostBack="true" OnTextChanged="FiltroApellido_TextChanged" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-2">
                    <
            <div class="mb-3 mt-3">
                <asp:Label Text="Filtrar por Email" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltrarPorMailAdmin" AutoPostBack="true" OnTextChanged="txtFiltrarMail_TextChanged" CssClass="form-control" />

            </div>
                </div>
            </div>


            <asp:GridView ID="dgvAdmins" runat="server" OnSelectedIndexChanged="dgvAdmins_SelectedIndexChanged" CssClass="table table-striped"
                DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="12" OnPageIndexChanging="dgvAdmins_PageIndexChanging">

                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField HeaderText="Username" DataField="Username" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField HeaderText="Email" DataField="Email" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />


                    <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                </Columns>

            </asp:GridView>

            <a href="FormularioAdmin.aspx" class="btn btn-success">Agregar</a>
            <a href="PanelGestion.aspx" class="btn btn-danger">Volver</a>

        </ContentTemplate>
    </asp:UpdatePanel>
    <%} %>
</asp:Content>

