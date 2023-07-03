<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionMarcas.aspx.cs" Inherits="E_Commerce_Vista.GestiónMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Lista de marcas a gestionar...</h1>

      <asp:UpdatePanel runat="server" Id="panelFiltros" >
        <ContentTemplate>   
        
        <div class="row">
                <div class="col-2">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Buscar por nombre" runat="server" />
                        <asp:TextBox runat="server" ID="txtNombre" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtNombre_TextChanged" />
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
                       </ul>
              </div>
                 <div class="mb-3 botonFILTRO">
                    <asp:Button Text="Limpiar" runat="server" ID="btnQuitarFiltros" CssClass="btn btn-dark form-control" OnClick="btnQuitarFiltros_Click" style="width:100px"/>
                 </div>
             </div>
        </div>

     


    <asp:GridView ID="dgvMarcas" runat="server" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging ="dgvMarcas_PageIndexChanging">  

        <Columns>
            <asp:BoundField  HeaderText="Marca" DataField="NombreMarca"  /> 
            <asp:CommandField ShowSelectButton="true" SelectText="♦" HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>

    </asp:GridView>

    <a href="FormularioMarca.aspx" class="btn btn-success" >Agregar</a>
    <a href="PanelGestion.aspx" class="btn btn-danger" >Volver</a>


            </ContentTemplate>
          </asp:UpdatePanel>
</asp:Content>
