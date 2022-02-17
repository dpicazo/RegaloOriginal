<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RegaloOriginal.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="regalo-input">
            <div class="input-row">
                <div class="input-title">Nombre de producto</div>
                <div class="input-obj"><asp:TextBox ID="inpNombre" runat="server"></asp:TextBox></div>
            </div>
            <div class="input-row">
                <div class="input-title">Precio unitario</div>
                <div class="input-obj"><asp:TextBox ID="inpPrecio" runat="server" Text="0"></asp:TextBox></div>
            </div>
            <div class="input-row">
                <div class="input-title">Cantidad</div>
                <div class="input-obj"><asp:TextBox ID="inpCantidad" runat="server" Text="1"></asp:TextBox></div>
            </div>
            <div class="input-row">
                <div class="input-title">Lista</div>
                <div class="input-obj"><asp:DropDownList ID="inpLista" runat="server"></asp:DropDownList></div>                
            </div>
            <div class="input-row">
                <div class="input-submit">
                    <asp:Button ID="btnSubmit" runat="server" Text="Agregar" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
        <hr />
        <div>
            <div class="table-title">Favoritos</div>
            <asp:Table ID="TablaFavoritos" CssClass="datatable" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Nombre Producto</asp:TableHeaderCell>                    
                    <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="4">Sin datos</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div>
            <div class="table-title">Carrito</div>
            <asp:Table ID="TablaCarrito" CssClass="datatable" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>                    
                    <asp:TableHeaderCell>Nombre Producto</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Subtotal</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="4">Sin datos</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
    <style type="text/css">
        body { font-family: Verdana; font-size: 10pt; }
        .datatable { width: 100%; max-width:600px; margin: 10px 0 20px 0;  }
        .datatable tr:first-of-type { background-color:#f1f1f1; }
        .input-row { display: inline-flex; width:100%;  }
        .input-title { width: 200px; }
        .input-submit { text-align:center; width:100%; max-width:400px; margin-top:20px; }
        .table-title { font-weight:bold; margin-top:30px; }
    </style>
</body>
</html>
