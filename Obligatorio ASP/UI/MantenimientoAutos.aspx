<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoAutos.aspx.cs" Inherits="MantenimientoAutos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
    <title>Mantenimiento de Autos</title>
    <style type="text/css">
        .style1
        {
            height: 21px;
            width: 200px;
        }
        .style2
        {
            height: 21px;
            width: 225px;
        }
        .style4
        {
            width: 229px;
        }
        .style5
        {
            height: 21px;
            width: 229px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <b>Mantenimiento de Autos<br />
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
                <td align="center" class="style5">
                    <asp:RequiredFieldValidator ID="rfMatricula" runat="server" 
                        ControlToValidate="txtMatricula" ErrorMessage="La matrícula es requerida"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 21px" align="center">
                    <asp:Button ID="btnBuscar" runat="server" CssClass="Estilo" Width="150px" Text="Buscar"
                        OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Marca:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
                <td align="center" class="style5">
                    &nbsp;</td>
                <td style="width: 100px; height: 21px" align="center">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Modelo:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtModelo" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
                <td align="center" class="style4">
                    &nbsp;</td>
                <td style="width: 100px" align="center">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Año:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtAnio" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
                <td align="center" class="style4">
                    <asp:RegularExpressionValidator ID="regExAnio" runat="server" 
                        ControlToValidate="txtAnio" ErrorMessage="Ingrese solo números." 
                        ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                </td>
                <td style="width: 100px" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Cantidad de puertas:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtCantidadPuertas" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
                <td align="center" class="style4">
                    <asp:RegularExpressionValidator ID="regExCantPuertas" runat="server" 
                        ControlToValidate="txtCantidadPuertas" ErrorMessage="Ingrese solo números." 
                        ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                </td>
                <td style="width: 100px" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                        Costo de alquiler p/día:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtCostoDiario" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
                <td align="center" class="style4">
                    <asp:RegularExpressionValidator ID="regExCosto" runat="server" 
                        ControlToValidate="txtCostoDiario" ErrorMessage="Ingrese solo números." 
                        ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                </td>
                <td style="width: 100px" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Tipo de anclaje:
                </td>
                <td align="center" class="style2">
                    <asp:TextBox ID="txtTipoAnclaje" runat="server" CssClass="Estilo" Width="150px"></asp:TextBox>
                </td>
                <td align="center" class="style4">
                    &nbsp;</td>
                <td style="width: 100px" align="center">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="Estilo" Font-Bold="True" OnClick="btnAgregar_Click"
                        Text="Agregar" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="Estilo" Font-Bold="True" Text="Modificar"
                        OnClick="btnModificar_Click" Enabled="False" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="Estilo" Font-Bold="True" Text="Eliminar"
                        OnClick="btnEliminar_Click" Enabled="False" />
                </td>
                <td align="center" class="style4">
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
