<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
    <title>RentACar</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span>
            <strong><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/logo.png" /></strong><br />
            <br />
            <asp:LinkButton ID="lbtnClientes" runat="server" CssClass="Estilo" PostBackUrl="~/MantenimientoClientes.aspx">Mantenimiento de Clientes</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="lbtnAutos" runat="server" CssClass="Estilo" PostBackUrl="~/MantenimientoAutos.aspx">Mantenimiento de Autos</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="lbtnUtilitarios" runat="server" CssClass="Estilo" PostBackUrl="~/MantenimientoUtilitarios.aspx">Mantenimiento de Utilitarios</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="lbtnAlquiler" runat="server" CssClass="Estilo" PostBackUrl="~/RealizarAlquiler.aspx">Realizar Alquiler</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="lbtnListado" runat="server" CssClass="Estilo" PostBackUrl="~/ListadoVehiculosDisponibles.aspx">Listar vehículos disponibles</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="lbtnTotal" runat="server" CssClass="Estilo" PostBackUrl="~/TotalRecaudadoPorVehiculos.aspx">Total recaudado por vehículo</asp:LinkButton>
        </span>
    </div>
    </form>
</body>
</html>
