<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="E_Commerce_Vista.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%if (Session["error"] != null)
            {%>
    <h1 >Hubo un problema...</h1>
          <% } 

     else{%>
     <h1 >Oops!</h1>
    <%}%>
    
    <asp:Label Text="text" Id="lblMensaje" runat="server" />

</asp:Content>
