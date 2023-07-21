<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionCategorias.aspx.cs" Inherits="E_Commerce_Vista.GestiónCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="login">Lista de categorias a gestionar...</h1>

     <asp:UpdatePanel runat="server" Id="panelFiltros" >
        <ContentTemplate>   

       <div class="row login">
                <div class="col-2">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Buscar por nombre" runat="server" />
                        <asp:TextBox runat="server" ID="txtNombre" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtNombre_TextChanged" />
                    </div>
                </div>

            <div class="col-2">
             <div class="mb-3 mt-3 dropdown">
                       <button class="btn btn-dark dropdown-toggle same-width-button" type="button" data-bs-toggle="dropdown" aria-expanded="false" width:"100px";>
                           Ordenar
                       </button>
                       <ul class="dropdown-menu">
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option1_Click">A-Z</a></li>
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option2_Click">Z-A</a></li>
                       </ul>
              </div>

                 <div class="mb-3 mt-3">
                    <asp:Button Text="Limpiar" runat="server" ID="btnQuitarFiltros" CssClass="btn btn-dark form-control same-width-button" OnClick="btnQuitarFiltros_Click" style="width:100px"/>
              </div>
             </div>

        </div>

           




    <asp:GridView ID="dgvCategorias" runat="server" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged" >  
        <Columns>
            <asp:BoundField HeaderText="Categoria" DataField="NombreCategoria" />
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>
    </asp:GridView>
    <a href="FormularioCategoria.aspx" class="btn btn-success">Agregar</a>
    <a href="PanelGestion.aspx" class="btn btn-danger"  >Volver</a>



                </ContentTemplate>
         </asp:UpdatePanel>

    <style>
        .login{
            color:white;
        }
    </style>

</asp:Content>
