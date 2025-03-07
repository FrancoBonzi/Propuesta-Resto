<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MesasAsignadas.aspx.cs"  Inherits="Final_Resto.MesasAsignadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center mt-6">Mis Mesas</h2>



         <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>

        <div class="row mt-4">
            <div class="col">
<asp:GridView ID="gvMesa" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" >
    <Columns>

        <asp:BoundField DataField="NumeroMesa" HeaderText="Numero de Mesa" />
        <asp:BoundField DataField="CapacidadMesa" HeaderText="Capacidad" />

    </Columns>
</asp:GridView>

                
        <div class="row mb-3">
            <div class="col text-center">
            
                
                <asp:TextBox ID="txtMesa" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 150px;" Placeholder="Ingresar Numero de Mesa"></asp:TextBox>
                <asp:Button ID="btnAbrirPedido" runat="server" Text="Tomar Pedido" CssClass="btn btn-success mx-2" OnClick="btnAbrirPedido_Click" />
                <asp:Button ID="btnCerrarPedido" runat="server" Text="Cerrar mesa" CssClass="btn btn-danger mx-2" OnClick="btnCerrarPedido_Click" />
                <asp:Button ID="btnAgregarPedido" runat="server" Text="Agregar al pedido" CssClass="btn btn-warning mx-2" OnClick="btnAgregarPedido_Click" />
            </div>
        </div>




            </div>
        </div>
    </div>

</asp:Content>
