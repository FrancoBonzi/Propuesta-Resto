<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedidos.aspx.cs" Inherits="Final_Resto.DetallePedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Agregar Productos al Pedido</h2>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>

        <div class="row mt-4">
            <div class="col-md-6">
                <asp:HiddenField ID="hfIdPedido" runat="server" />
                <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control mb-2" Placeholder="Cantidad" TextMode="Number"></asp:TextBox>
                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar al Pedido" CssClass="btn btn-primary" OnClick="btnAgregarProducto_Click" />
                <asp:Button ID="btnMisMesas" runat="server" Text="Volver a Mis Mesas" CssClass="btn btn-primary" OnClick="btnMisMesas_Click" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col">
                <asp:GridView ID="gvDetallePedido" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdDetalle" HeaderText="ID Detalle" />
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Pedido" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
