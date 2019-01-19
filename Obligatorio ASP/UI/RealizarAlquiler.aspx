<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RealizarAlquiler.aspx.cs"
    Inherits="RealizarAlquiler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
    <title>Realizar Alquiler</title>
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
            $("#clnFechaInicio").datepicker({
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
            $("#clnFechaFin").datepicker({
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
        <b>Realizar Alquiler<br />
            <br />
        </b>
        <table>
            <tr>
                <td class="style1">
                    Matrícula:
                </td>
                <td style="width: 151px">
                    <asp:DropDownList ID="cboVehiculos" runat="server" Width="176px"></asp:DropDownList>
                </td>
                <td style="width: 151px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Cédula:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtCedula" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
                <td align="center" class="style2">
                    <asp:RegularExpressionValidator ID="regExCedula" runat="server" 
                        ControlToValidate="txtCedula" ErrorMessage="Ingrese solo números." 
                        ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                </td>
                <td style="width: 100px; height: 21px" align="center">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <p>
                        Fecha de inicio:</p>
                </td>
                <td>
                    <p>
                        <input type="text" id="clnFechaInicio" runat="server" /></p>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <p>
                        Fecha de finalización:</p>
                </td>
                <td>
                    <p>
                        <input type="text" id="clnFechaFin" runat="server" /></p>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="Estilo" Font-Bold="True" OnClick="btnAgregar_Click"
                        Text="Agregar" />
                    <asp:Button ID="btnCalcular" runat="server" CssClass="Estilo" Font-Bold="True" Text="Calcular"
                        OnClick="btnCalcular_Click" />
                </td>
                <td align="center">
                    &nbsp;</td>
                <td align="center" colspan="1">
                    <asp:Button ID="btnLimpiar" runat="server" CssClass="Estilo" Font-Bold="True" OnClick="btnLimpiar_Click"
                        Text="Limpiar" />
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
