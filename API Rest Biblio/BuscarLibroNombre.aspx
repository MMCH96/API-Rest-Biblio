<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarLibroNombre.aspx.cs" Inherits="API_Rest_Biblio.BuscarLibroNombre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 137px;
        }
        #Res {
            height: 79px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;<br />
            Buscar Libro por Titulo<br />
            <br />
            <asp:TextBox ID="txtBuscarLibroTitulo" runat="server" Width="272px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
            <br />
            <br />
            <br />
            <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtautor" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
