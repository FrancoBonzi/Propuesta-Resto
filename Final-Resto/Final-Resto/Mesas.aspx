<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs"  Inherits="Final_Resto.Mesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Gestión de Mesas</h2>

        <div class="row">
            <div class="col text-center">
                <asp:TextBox ID="txtMesa" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Nombre de Mesa para agregar"></asp:TextBox>
                <asp:Button ID="btnAgregarMesa" runat="server" Text="Agregar" CssClass="btn btn-success mx-2" OnClick="btnAgregarMesa_Click" />
                <asp:TextBox ID="txtIdMesa" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Ingresar ID Mesa"></asp:TextBox>
                <asp:Button ID="btnModificarMesa" runat="server" Text="Modificar" CssClass="btn btn-warning mx-2" OnClick="btnModificarMesa_Click" />
                <asp:Button ID="btnEliminarMesa" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminarMesa_Click" />
            </div>
        </div>

              <div class="row mt-4" id="modificar" runat="server" visible="false">
            <div class="col text-center">
                <asp:TextBox ID="txtNuevoNombre" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Nuevo nombre"></asp:TextBox>
                <asp:Button ID="btnAceptarModificacion" runat="server" Text="Aceptar" CssClass="btn btn-primary mx-2" OnClick="btnAceptarModificacion_Click" />
            </div>
        </div>




        <div class="row mt-4">
            <div class="col">
                <asp:GridView ID="gvMesa" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdMesa" HeaderText="ID Mesa" />
                        <asp:BoundField DataField="IdMozo" HeaderText="IdMozo" />
                        <asp:BoundField DataField="NumeroMesa" HeaderText="Numero" />
                        <asp:BoundField DataField="CapacidadMesa" HeaderText="Capacidad" />
                        <asp:BoundField DataField="Disponible" HeaderText="Disponible" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
