<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoVehiculosDisponibles.aspx.cs"
    Inherits="ListadoVehiculosDisponibles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
    <title>Listar vehículos disponibles</title>
    <style type="text/css">
        .style1
        {
            height: 21px;
            width: 170px;
        }
        .style2
        {
            height: 21px;
            width: 218px;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type='text/javascript' src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type='text/javascript' src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type='text/javascript'>
        $(function () {
            $("#clnFechaUno").datepicker({
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                firstDay: 1,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type='text/javascript' src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type='text/javascript' src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type='text/javascript'>
        $(function () {
            $("#clnFechaDos").datepicker({
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                firstDay: 1,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <b>Listar vehículos disponibles<br />
            <br />
        </b>
        <table>
            <tr>
                <td class="style1">
                    <p>
                        Fecha uno:</p>
                </td>
                <td>
                    <p>
                        <input type="text" id="clnFechaUno" runat="server" /></p>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <p>
                        Fecha dos:</p>
                </td>
                <td>
                    <p>
                        <input type="text" id="clnFechaDos" runat="server" /></p>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnConsultar" runat="server" CssClass="Estilo" Font-Bold="True" OnClick="btnConsultar_Click"
                        Text="Consultar" />
                </td>
                <td align="center" colspan="1">
                    <asp:Button ID="btnLimpiar" runat="server" CssClass="Estilo" Font-Bold="True" OnClick="btnLimpiar_Click"
                        Text="Limpiar" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblError" runat="server" CssClass="Estilo"></asp:Label>&nbsp;<br />
        <br />
        <asp:ListBox ID="lstVehiculosDisponibles" runat="server" Height="200px" Width="1200px"></asp:ListBox><br />
        <asp:LinkButton ID="lbtnVolver" runat="server" CssClass="Estilo" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>
