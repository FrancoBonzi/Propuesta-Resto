<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RendimientoMeseros.aspx.cs" Inherits="Final_Resto.RendimientoMeseros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col text-center">
                <div class="row mb-3">

                    <div class="col-md-3">
                        <asp:Label ID="lblFecha" runat="server" Text="Fecha del Pedido:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFechaPedido" runat="server" CssClass="form-control" Placeholder="YYYY-MM-DD"></asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre Cliente:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>


                    <div class="col-md-3">
                        <asp:Label ID="lblNumeroMesa" runat="server" Text="Número de Mesa:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNumeroMesa" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-md-3 align-self-end">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mx-2" OnClick="btnFiltrar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" />
                    </div>

                    <div class="text-center">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    </div>

                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="card shadow p-4">
                    <h3 class="text-center mb-4">Registro de Pedidos</h3>
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="IdPedido" HeaderText="ID Pedido" />
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha de Apertura" />
                            <asp:BoundField DataField="FechaHoraCierre" HeaderText="Fecha de Cierre" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="NumeroMesa" HeaderText="Número de Mesa" />
                            <asp:BoundField DataField="Total" HeaderText="Total Pedido" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
