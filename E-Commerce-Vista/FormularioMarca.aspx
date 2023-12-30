<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioMarca.aspx.cs" Inherits="E_Commerce_Vista.FormularioMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <%-- CON VALIDACION REQUIRED Y JS --%>
     <style>
        h1{
            color:white;
        }
    </style>
   
    <h1 class="text-center">Gestionando marca</h1>
    <asp:UpdatePanel runat="server" ID="updatePanelMarca" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row login">

                <div class="col-6 container mt-4">

                    <%if (verId)
                        {%>
                    <div class="mb-3 mt-3">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                    </div>
                    <% } %>




                    <div class="mb-3 mt-3 ">
                        <label for="txtNombreMarca" class="form-label">Nombre Marca</label>
                        <asp:TextBox ID="txtNombreMarca" CssClass="form-control is-invalid " runat="server" AutoPostBack="true" OnTextChanged="txtNombreMarca_TextChanged" />
                        <div id="errorNombreMarca" class="invalid-feedback ">Campo obligatorio.</div>

                    </div>


                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label" >Url Imagen</label>
                        <asp:TextBox ID="txtImagenUrl" CssClass="form-control is-invalid" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" runat="server" />
                        <div id="errorImagen" class="invalid-feedback">Url imagen es obligatorio.</div>
                    </div>




                    <div class="mb-3 mt-2">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" OnClientClick="return validarFormulario();" />
                        <a href="GestionMarcas.aspx" class="btn btn-primary">Cancelar</a>
                        <%if (modificando)
                            {%>
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click"
                            CssClass="btn btn-danger" runat="server" />
                        <%} %>



                        <%if (confirmarEliminar)
                            {%>

                        <div class="mb-3 mt-3">
                            <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion"  class="texto" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-danger" runat="server" />

                        </div>


                        <%}%>
                    </div>


                </div>


                <div class="col-6 mt-4">

                    <div class="mt-3 ">
                        <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png"
                            runat="server" ID="imgMarca" Style="width: 40vh; height: 40vh;" />

                    </div>
                </div>



            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


    <%--<div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    

                    <%if (confirmarEliminar)
                        {%>

                    <div class="mb-3 mt-3">
                        <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />

                    </div>


                    <%}%>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>--%>

    <style>
        .login{
            color:white;
        }
        .form-control{
            width:30vh;
        }
        .container{
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
        }
        .form-label,.texto{
            font-size:x-large;
        }
        .invalid-feedback{
            color:orange;
        }
    </style>
</asp:Content>
