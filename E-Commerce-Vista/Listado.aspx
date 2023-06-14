<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="E_Commerce_Vista.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <%-- CARDS --%>
     <div class="cards-container">
                    <div class="row row-cols-1 row-cols-md-3 g-4">
                        
                        <%-- Repeater --%>
                            <asp:Repeater ID="repRepetidor" runat="server" OnItemDataBound="repRepetidor_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col col-12  col-md-6 col-lg-4 text-center" >
                                        <div class="card">
                                            <asp:Image ID="imgImagen" class="card-img-top" runat="server" CssClass="card-img-top"  />
                                            <div class="card-body">
                                                <h5 class="card-title"><%# Eval("Nombre") %> </h5>
                                                <p class="card-text"><%# Eval("CodigoArticulo")%></p>
                                                <p class="card-text">$<%# Eval("Precio")%></p>
                                                <asp:Button Text="Ver Detalle" ID="btnDetalle" CssClass="btn btn-dark " runat="server" OnClick="btnDetalle_Click" CommandArgument='<%#Eval("Id")%>' />
                                                <asp:Button Text="Agregar al carrito" ID="btnEjemplo" CssClass="btn btn-success btnAgregar btn-pg-1" runat="server"    />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                    </div>
                </div>



     <style>
       .cards-container{
           margin-top:10vh;
           
       }
       .card-img-top{
           height: 300px;
           width: auto;
       }
       

   </style>

</asp:Content>
