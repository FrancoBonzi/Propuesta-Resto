<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs"  Inherits="Final_Resto.Mesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mt-4">Gestión de Mesas</h2>

        <div class="row">
            <div class="col text-center">
                <asp:TextBox ID="txtIdMesa" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Ingresar ID Mesa"></asp:TextBox>
                <asp:Button ID="btnEliminarMesa" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminarMesa_Click" />
                <asp:Button ID="btnAgregarMesa" runat="server" Text="Agregar Mesa" CssClass="btn btn-success mx-2" OnClick="btnAgregarMesa_Click" />
            </div>
        </div>

         <div id="formMesa" runat="server" visible="false" class="mt-4">
            <h4 class="text-center">Formulario de Producto</h4>

            <asp:HiddenField ID="hfIdProducto" runat="server" />
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <asp:TextBox ID="txtNumeroMesa" runat="server" CssClass="form-control mb-2" Placeholder="Numero de Mesa"></asp:TextBox>
                    <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control mb-2" Placeholder="Capacidad" TextMode="Number"></asp:TextBox>

                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Producto" CssClass="btn btn-primary mb-2" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary mb-2" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>

        <div class="row mt-4">
              <div class="col text-center">
                <asp:DropDownList ID="ddlMozos" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;">
                </asp:DropDownList>

                <asp:Button ID="btnAsignarMozo" runat="server" Text="Asignar Mozo" CssClass="btn btn-primary mx-2" 
                    OnClick="btnAsignarMozo_Click" />
            </div>
        </div>

         <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>

        <div class="row mt-4">
            <div class="col">
                <asp:GridView ID="gvMesa" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdMesa" HeaderText="ID Mesa" />
                        <asp:BoundField DataField="IdMozo" HeaderText="ID Mozo" />
                        <asp:BoundField DataField="usuarioNombre.Nombre" HeaderText="Mesero Asignado" />
                        <asp:BoundField DataField="NumeroMesa" HeaderText="Mesa Numero" />
                        <asp:BoundField DataField="CapacidadMesa" HeaderText="Capacidad" />
                        <asp:BoundField DataField="Disponible" HeaderText="Disponible" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
