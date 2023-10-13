<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acciones.aspx.cs" Inherits="Acciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 62%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 117px;
        }
        .auto-style4 {
            width: 165px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <table border="1" class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="3">Crear Usuario de Acceso en Sql server</td>
            </tr>
            <tr>
                <td class="auto-style3">Nombre:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TxTNombre" runat="server" Width="192px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Password</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TxtPass" runat="server" Width="192px" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Agregar Manejo Usuarios" />
                &nbsp;<br />
                    <asp:Button ID="BtnAltaComun" runat="server" OnClick="BtnAltaComun_Click" Text="Agegar Usuario Comun" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">Probar ejecutar SP de alta:</td>
                <td>
                    <asp:Button ID="BtnPruebo" runat="server" Text="Pruebo" OnClick="BtnPruebo_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="LblError" runat="server" ForeColor="#F00000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
        <asp:Button ID="BtnDeslogueo" runat="server" OnClick="BtnDeslogueo_Click" Text="Deslogueo" Height="23px" />
    
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
