<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="Presentacion.PaginaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
&nbsp;&nbsp;
        </div>

        <div>
            <table>
                <tr>
                    <td>Ingrese su Nombre:</td><td></td><td><asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td><td>
                        <asp:Button ID="BtnGrabar" runat="server" Text="Button" OnClick="BtnGrabar_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
