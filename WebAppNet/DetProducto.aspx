<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetProducto.aspx.cs" Inherits="WebAppNet.DetProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <%=_ContenidoDetalle %>

 <div id="mensajeId" class="seccion-mensaje">
  <!-- Modal content -->
  <div class="mensajecontenido">
    <div class="mensajecabecero">
      <span class="cerrar">&times;</span>
      <h2>Modal Header</h2>
    </div>
    <div class="mensajecuerpo">
      <p>Some text in the Modal Body</p>
    </div>
  </div>

</div>

     

</asp:Content>
