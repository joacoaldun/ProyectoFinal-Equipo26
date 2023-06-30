<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="E_Commerce_Vista.MisFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de favoritos</h1>

     <style>
        h1 {
            /*color: aliceblue;*/
            color: black;
            margin-bottom: 60px;
            margin-top: 30px;
            text-align: center
        }

    </style>

     <%@ Import Namespace="Dominio" %>

    <%-- Titulos --%>





    <div class="card mb-3" style="background-color: black;">
        <div class="row g-0">
            <div class="col-md-12" style="color: white; font-weight: bold;">
                <div class="card-body d-flex">
                    <%--<div class="col-md-2 col-sm-2"></div>--%>
                    <!-- Columna vacía sin título -->
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsFavorito"></p>
                    </div>

                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsFavorito">Nombre</p>
                    </div>
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsFavorito">Marca</p>
                    </div>
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsFavorito">Categoria</p>
                    </div>
                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsFavorito">Precio</p>
                    </div>

                    <div class="col-md-2 col-sm-2" style="width: 16.66%;">
                        <p class="card-title itemsFavorito"></p>
                    </div>
                   
                </div>
            </div>
        </div>
    </div>
    <%--<asp:ScriptManager ID="script3" runat="server"></asp:ScriptManager>--%>




    <asp:UpdatePanel ID="updatePanelFavorito" runat="server" UpdateMode="Conditional"  >
        <ContentTemplate>


            <asp:Repeater ID="repFavoritos" runat="server" OnItemDataBound="repFavoritos_ItemDataBound">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="row g-0">

                            <div class="col-md-12">
                                <div class="card-body d-flex">
                                    <div class="col-md-2">
                                        <asp:HyperLink ID="hlImagen" runat="server" NavigateUrl='<%# "DetalleArticulo.aspx?id=" + Eval("Id") %>'>
                                            <asp:Image ID="imgImagen" runat="server" CssClass="img-fluid rounded-start" Style="max-height: 15vh; width: 100%;" />
                                        </asp:HyperLink>
                                    </div>
                                    <div class="col-md-2 itemsFavorito">
                                        <p class="card-text"><%# Eval("Nombre") %></p>
                                    </div>
                                    <div class="col-md-2 itemsFavorito">
                                        <p class="card-text"><%# Eval("Marcas.NombreMarca") %></p>
                                    </div>
                                    <div class="col-md-2 itemsFavorito">
                                        <p class="card-text"><%# Eval("Categorias.NombreCategoria") %></p>
                                    </div>
                                    <div class="col-md-2 itemsFavorito">
                                        <p class="card-text">$ <%# Eval("Precio") %></p>
                                    </div>
                                   
                                    <div class="col-md-2 itemsFavorito">
                                     <asp:Button ID="btnEliminarFav" Text="Eliminar" runat="server" CssClass="btn btn-dark" CommandArgument='<%#Eval("Id")%>' OnClick="btnEliminarFav_Click" />
                                       </div>
                                   
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            
        </ContentTemplate>
    </asp:UpdatePanel>


    <style>
         
        .itemsFavorito {
            margin: auto;
            text-align: center;
        }
        .btn-dark{
            height:50%;
            margin:auto;
           
        }
        .btn-dark:hover{
             background-color:purple;
            border-color:purple;
        }
        

    </style>

</asp:Content>
