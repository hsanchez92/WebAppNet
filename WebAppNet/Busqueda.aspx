<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Busqueda.aspx.cs" Inherits="WebAppNet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
    <div class="ui-search">
        <div class="col-sm-16 divBusqueda">
            <%=_ContenidoBusqueda %>
        </div>
    </div>
</div>




</asp:Content>
