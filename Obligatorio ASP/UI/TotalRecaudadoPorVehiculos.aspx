<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TotalRecaudadoPorVehiculos.aspx.cs" Inherits="TotalRecaudadoPorVehiculos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
    <title>Total recaudado por vehículo</title>
    <style type="text/css">
        .style1
        {
            height: 21px;
            width: 200px;
        }
        .style2
        {
            height: 21px;
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <b>Total recaudado por vehículo<br />
            <br />
        </b>
        <table>
            <tr>
                <td class="style1">
                    Matrícula:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Alquileres:
                </td>
                <td align="center" class="style2">
                    <asp:ListBox ID="lstAlquileres" runat="server" Height="200px" Width="900px"></asp:ListBox><br />
                </td>
                <td style="width: 100px; height: 21px" align="center">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Total recaudado:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="Estilo" Width="150px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td style="width: 100px" align="center">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnConsultar" runat="server" CssClass="Estilo" Font-Bold="True" OnClick="btnConsultar_Click"
                        Text="Consultar" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblError" runat="server" CssClass="Estilo"></asp:Label>&nbsp;<br />
        <br />
        <asp:LinkButton ID="lbtnVolver" runat="server" CssClass="Estilo" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>
