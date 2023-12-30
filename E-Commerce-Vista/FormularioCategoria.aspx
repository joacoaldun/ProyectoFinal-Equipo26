<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="E_Commerce_Vista.FormularioCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        h1{
            color:white;
        }
    </style>
   
    <h1 class="text-center">Gestionando categoria</h1>

    <asp:UpdatePanel runat="server" ID="updatePanelCategoria" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row login d-flex justify-content-center align-items-center mt-4">
                <div class="col-6">
                    <%if (verId)
                        {%>
                    <div class="mb-3 mt-3">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                    </div>
                    <% } %>


                    <div class="mb-3 mt-3">
                        <label for="txtNombreCategoria" class="form-label">Categoria</label>
                        <asp:TextBox runat="server" ID="txtNombreCategoria" CssClass="form-control is-invalid" AutoPostBack="true" OnTextChanged="txtNombreCategoria_TextChanged" />
                        <div id="errorNombreCategoria" class="invalid-feedback">Campo obligatorio.</div>
                    </div>

                    <div class="mb-3 mt-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" />
                        <a href="GestionCategorias.aspx" class="btn btn-primary">Cancelar</a>

                        <%if (modificando)
                            {%>
                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />

                        <% }%>
                    </div>

                    <%if (confirmarEliminar)
                        {%>
                    <div class="mb-3 mt-3">
                        <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <%} %>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <style>
    .login{
        color:white;
    }
    .form-label{
        font-size:x-large;
    }
    </style>

</asp:Content>
