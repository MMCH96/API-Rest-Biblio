<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="API_Rest_Biblio.Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-weight: bold">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BIBLIOTECA<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LISTA DE LIBROS<br />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="835px" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" PageSize="8">
                <Columns>
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo"></asp:BoundField>
                    <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor"></asp:BoundField>
                    <asp:BoundField DataField="Año Lanzamiento" HeaderText="Año Lanzamiento" SortExpression="Año Lanzamiento"></asp:BoundField>
                    <asp:BoundField DataField="Editorial" HeaderText="Editorial" SortExpression="Editorial"></asp:BoundField>
                    <asp:BoundField DataField="Idioma" HeaderText="Idioma" SortExpression="Idioma"></asp:BoundField>
                    <asp:BoundField DataField="Paginas" HeaderText="Paginas" SortExpression="Paginas"></asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#CCCC00" BorderColor="Black" BorderStyle="Solid" />
                <HeaderStyle BackColor="#CCCC00" />
                <PagerStyle BackColor="#CCCC00" />
            </asp:GridView>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bibliotecaConnectionString %>" SelectCommand="SELECT * FROM [VistaGeneral]"></asp:SqlDataSource>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
