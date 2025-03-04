<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MesasAsignadas.aspx.cs"  Inherits="Final_Resto.MesasAsignadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Mis Mesas</h2>



         <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>

        <div class="row mt-4">
            <div class="col">
<asp:GridView ID="gvMesa" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowCommand="gvMesa_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdMesa" HeaderText="ID Mesa" />
        <asp:BoundField DataField="IdMozo" HeaderText="ID Mozo" />
        <asp:BoundField DataField="NumeroMesa" HeaderText="Numero" />
        <asp:BoundField DataField="CapacidadMesa" HeaderText="Capacidad" />
        <asp:BoundField DataField="Disponible" HeaderText="Disponible" />

        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnAbrir" runat="server" Text="Abrir" CssClass="btn btn-success btn-sm"
                    CommandName="AbrirMesa" CommandArgument='<%# Eval("IdMesa") %>' />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="btn btn-danger btn-sm"
                    CommandName="CerrarMesa" CommandArgument='<%# Eval("IdMesa") %>' />
                <asp:Button ID="btnAgregarPedido" runat="server" Text="Agregar Pedido" CssClass="btn btn-primary btn-sm"
                    CommandName="AgregarPedido" CommandArgument='<%# Eval("IdMesa") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

            </div>
        </div>
    </div>

</asp:Content>
