<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Final_Resto.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mt-5">Gestión del Menú</h2>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>


        <div class="row mb-3">
            <div class="col text-center">
                <asp:Button ID="btnMostrarForm" runat="server" Text="Agregar Producto" CssClass="btn btn-success mx-2" OnClick="btnMostrarForm_Click" />
                
                <asp:TextBox ID="txtIdProducto" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 150px;" Placeholder="Ingresar ID Producto"></asp:TextBox>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning mx-2" OnClick="btnModificar_Click" />
            </div>
        </div>

        <div id="formProducto" runat="server" visible="false" class="mt-4">
            <h4 class="text-center">Formulario de Producto</h4>

            <asp:HiddenField ID="hfIdProducto" runat="server" />
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control mb-2" Placeholder="Nombre del Producto"></asp:TextBox>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control mb-2" Placeholder="Descripción"></asp:TextBox>
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control mb-2" Placeholder="Categoría"></asp:TextBox>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control mb-2" Placeholder="Precio" TextMode="Number"></asp:TextBox>
                    <asp:TextBox ID="txtStockActual" runat="server" CssClass="form-control mb-2" Placeholder="Stock Actual" TextMode="Number"></asp:TextBox>
                    <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control mb-2" Placeholder="Stock Mínimo" TextMode="Number"></asp:TextBox>


                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Producto" CssClass="btn btn-primary mb-2" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary mb-2" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>


         <div id="formModificacion" runat="server" visible="false" class="mt-4">
            <h4 class="text-center">Formulario de Modificación de Producto</h4>

            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control mb-2" Placeholder="Nombre del Producto"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control mb-2" Placeholder="Descripción"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control mb-2" Placeholder="Categoría"></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control mb-2" Placeholder="Precio" TextMode="Number"></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control mb-2" Placeholder="Stock Actual" TextMode="Number"></asp:TextBox>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control mb-2" Placeholder="Stock Mínimo" TextMode="Number"></asp:TextBox>


                    <asp:Button ID="BtnModificarFormulario" runat="server" Text="Guardar Modificación" CssClass="btn btn-primary mb-2" OnClick="btnGuardarModificacion_Click" />
                    <asp:Button ID="BtnCancelarModificar" runat="server" Text="Cancelar" CssClass="btn btn-secondary mb-2" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>





         <div class="row mt-4">
             <div class="col">
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                         <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
                        <asp:BoundField DataField="StockMinimo" HeaderText="Stock Minimo" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>


    </div>
</asp:Content>
