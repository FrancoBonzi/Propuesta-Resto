<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Final_Resto.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Gestión del Menú</h2>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>


        <div class="row mt-4">
            <div class="col-md-6">
                <asp:HiddenField ID="hfIdProducto" runat="server" />
                
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control mb-2" Placeholder="Nombre del Producto"></asp:TextBox>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control mb-2" Placeholder="Descripción"></asp:TextBox>
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control mb-2" Placeholder="Categoría"></asp:TextBox>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control mb-2" Placeholder="Precio" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control mb-2" Placeholder="Stock Mínimo" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="txtStockActual" runat="server" CssClass="form-control mb-2" Placeholder="Stock Actual" TextMode="Number"></asp:TextBox>

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" CssClass="btn btn-success mb-2" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar Producto" CssClass="btn btn-warning mb-2" OnClick="btnModificar_Click" Visible="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary mb-2" OnClick="btnCancelar_Click" Visible="false" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col">
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
                        <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
