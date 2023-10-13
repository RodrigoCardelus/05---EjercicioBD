<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="controles" namespace="controles" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 27%;
        }
        .auto-style2 {
            width: 182px;
        }
        .auto-style3 {
            width: 117px;
        }
        .auto-style4 {
            width: 82px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table border="1" class="auto-style1">
            <tr>
                <td class="auto-style2">Ingresar al Sistema</td>
            </tr>
            <tr>
                <td>
                    <cc1:Logueo ID="Logueo1" runat="server" OnLoguearse="Logueo1_Loguearse" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblError" runat="server" ForeColor="#F00000"></asp:Label>
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
