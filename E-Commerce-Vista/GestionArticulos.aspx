<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionArticulos.aspx.cs" Inherits="E_Commerce_Vista.GestiónArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="login text-center">Lista de articulos a gestionar</h1>
    
    <asp:UpdatePanel runat="server" Id="panelFiltros" >
        <ContentTemplate>   

            <div class="row login text-center d-flex justify-content-center align-items-center">
                     

                <div class="col-2 ">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Buscar por nombre" runat="server" />
                        <asp:TextBox runat="server" ID="txtNombre" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtNombre_TextChanged" />
                    </div>
                </div>


                 <div class="col-2 ">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Buscar por código" runat="server" />
                        <asp:TextBox runat="server" ID="txtCodigo"  AutoPostBack="true" CssClass="form-control" OnTextChanged="txtCodigo_TextChanged" />
                    </div>
                </div>  

                <div class="col-2 mb-3 mt-3">
                    <asp:Label Text="Buscar por precio" runat="server" />
                    <div class=" d-flex">
                        
                        
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control ">
                            <asp:ListItem Text="Igual a" />
                            <asp:ListItem Text="Mayor a" />
                            <asp:ListItem Text="Menor a" />
                        </asp:DropDownList>
                      
                        <asp:TextBox runat="server"  ID="txtPrecio"  AutoPostBack="true" OnTextChanged="txtPrecio_TextChanged" CssClass="form-control" />
                    </div>
                </div>

                <div class="col-2">
                    <div class="mb-3 mt-3">
                       <asp:Label Text="Marcas" runat="server" />
                         <asp:DropDownList runat="server" ID="ddlMarcas" AutoPostBack="true" CssClass="form-control" OnTextChanged="ddlMarcas_TextChanged">
                         </asp:DropDownList>
                    </div>
                </div>

                <div class="col-2">
                     <div class="mb-3 mt-3">
                         <asp:Label Text="Categorias" runat="server" />
                         <asp:DropDownList runat="server" ID="ddlCategorias" AutoPostBack="true" CssClass="form-control" OnTextChanged="ddlCategorias_TextChanged" >
                         </asp:DropDownList>
                     </div>
                </div>

         <div class="col-2">
             <div class="mb-3 mt-3 dropdown">
                       <button class="btn btn-dark dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false" width:"80px";>
                           Ordenar
                       </button>
                       <ul class="dropdown-menu">
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option1_Click">A-Z</a></li>
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option2_Click">Z-A</a></li>
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option3_Click">Mayor a menor</a></li>
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option4_Click">Menor a mayor</a></li>
                       </ul>
              </div>
             <div class="mb-3 botonFILTRO">
                    <asp:Button Text="Limpiar" runat="server" ID="btnQuitarFiltros" CssClass="btn btn-dark form-control" OnClick="btnQuitarFiltros_Click" style="width:100px"/>
              </div>
         </div>
    </div>




    <asp:GridView ID="dgvArticulos" runat="server" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="12" OnPageIndexChanging ="dgvArticulos_PageIndexChanging">  
         <HeaderStyle CssClass="thead-dark" />
        <Columns>
            <asp:BoundField  HeaderText="Articulo" DataField="Nombre"/> 
            <asp:BoundField  HeaderText="Codigo" DataField="CodigoArticulo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Marca" DataField="Marcas.NombreMarca" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Categoria" DataField="Categorias.NombreCategoria" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Precio" DataField="Precio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Stock" DataField="StockArticulo.Cantidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:BoundField  HeaderText="Publicado" DataField="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> 
            <asp:CommandField ShowSelectButton="true" SelectText="	&#x270D; " HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

        </Columns>

    </asp:GridView>


             </ContentTemplate>
    </asp:UpdatePanel>

    <a href="FormularioArticulo.aspx" class="btn btn-success" >Agregar</a>
    <a href="PanelGestion.aspx" class="btn btn-danger" >Volver</a>

    <style>
        .login{
            color:white;
        }
        .thead-dark th {
            background-color: black; 
            color: white; 
            font-weight:normal;
        }

    </style>
</asp:Content>
