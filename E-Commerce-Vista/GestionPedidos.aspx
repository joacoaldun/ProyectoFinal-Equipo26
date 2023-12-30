<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionPedidos.aspx.cs" Inherits="E_Commerce_Vista.GestiónPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="login text-center">Lista de pedidos a gestionar</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>   


     <div class="row login text-center d-flex justify-content-center align-items-center">

                <div class="col-2">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Buscar por numero" runat="server" />
                        <asp:TextBox runat="server" ID="txtNumero" AutoPostBack="true"  CssClass="form-control" OnTextChanged="txtNumero_TextChanged" />
                    </div>
                </div>


                 <div class="col-2">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Buscar por apellido" runat="server" />
                        <asp:TextBox runat="server" ID="txtApellido"  AutoPostBack="true" CssClass="form-control" OnTextChanged="txtApellido_TextChanged"/>
                    </div>
                </div>  

       

           <div class="col-2">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Buscar por estado" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control"  AutoPostBack="true" OnTextChanged="ddlEstado_TextChanged" >
                        </asp:DropDownList>
                    </div>
           </div>

         
           <div class="col-1 "  >
                    <div class="mb-3 mt-3 ">
                        <asp:Label Text="Medio de pago" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlMedioPago" CssClass="form-control" AutoPostBack="true" OnTextChanged="ddlMedioPago_TextChanged">
                        </asp:DropDownList>
                    </div>
           </div>

          <div class="col-1 ">
                    <div class="mb-3 mt-3">
                        <asp:Label Text="Pagado" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlPagado" CssClass="form-control formChico" AutoPostBack="true" OnTextChanged="ddlPagado_TextChanged" >
                            <asp:ListItem Text="Si" />
                            <asp:ListItem Text="No" />
                        </asp:DropDownList>
                    </div>
           </div>



                <div class="col-2 mb-3 mt-3">
                     <asp:Label Text="Precio" runat="server" />
                    <div class="d-flex ">
                       
                        
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control formChico">
                            <asp:ListItem Text="Igual a" />
                            <asp:ListItem Text="Mayor a" />
                            <asp:ListItem Text="Menor a" />
                        </asp:DropDownList>
                      
                        <asp:TextBox runat="server"  ID="txtPrecio"  AutoPostBack="true" OnTextChanged="txtPrecio_TextChanged" CssClass="form-control formChico" />
                    </div>
                </div>

               

         <div class="col-2 ">
             <div class="mb-3 mt-3 dropdown">
                       <button class="btn btn-dark dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false" width:"80px";>
                           Ordenar
                       </button>
                       <ul class="dropdown-menu">
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option1_Click">A-Z</a></li>
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option2_Click">Z-A</a></li>
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option3_Click">Mayor a menor $</a></li>
                           <li><a class="dropdown-item" href="#" runat="server" onserverclick="Option4_Click">Menor a mayor $</a></li>
                       </ul>
              </div>
             <div class="mb-3 botonFILTRO">
                    <asp:Button Text="Limpiar" runat="server" ID="btnQuitarFiltros" CssClass="btn btn-dark form-control" OnClick="btnQuitarFiltros_Click" style="width:100px"/>
              </div>
         </div>
    </div>







     <asp:GridView ID="dgvPedidos" runat="server" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" CssClass="table table-striped"
        DataKeyNames="Id" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging ="dgvPedidos_PageIndexChanging">  
         <HeaderStyle CssClass="thead-dark" />
        <Columns>
            <asp:BoundField  HeaderText="Numero" DataField="Id"  /> 
            <asp:BoundField  HeaderText="Apellido" DataField="Cliente.Apellido"  /> 
            <asp:BoundField  HeaderText="Nombre" DataField="Cliente.Nombre"  /> 
            <asp:BoundField  HeaderText="Email" DataField="Cliente.Email"  /> 
             <asp:BoundField  HeaderText="Fecha"   DataFormatString="{0:dd/MM/yyyy}"  DataField="FechaPedido"  /> 
             <asp:BoundField  HeaderText="Estado de envio" DataField="EstadoEnvio"/> 
             <asp:BoundField  HeaderText="Medio de pago" DataField="MedioDePago.NombrePago"  /> 
             <asp:BoundField  HeaderText="Pagado" DataField="EstadoPago"  /> 
             <asp:BoundField  HeaderText="Importe" DataField="ImporteTotal"  DataFormatString="${0:N2}"/> 
            <asp:CommandField ShowSelectButton="true" SelectText="	&#x270D; " HeaderText="Gestionar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
        </Columns>

    </asp:GridView>



        </ContentTemplate>
    </asp:UpdatePanel>


    <a href="PanelGestion.aspx" class="btn btn-danger">Volver</a>

    <style>
        h1,.login{
            color:white;
        }
        .thead-dark th {
            background-color: black; 
            color: white; 
            font-weight:normal;
        }
        .form-control{
            width:20vh;
        }
        .formChico{
            width:10vh;
        }
    </style>

</asp:Content>