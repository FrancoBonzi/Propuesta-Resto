<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Final_Resto.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center">Menu de Navegación</h2>

        <table class="table table-bordered text-center mt-4">
            <thead class="table-dark">
                <tr>
                    <th>Acción</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistroUsuarios" runat="server" Text="Usuarios" CssClass="btn btn-primary"
                            OnClick="btnRegistroUsuarios_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnReportes" runat="server" Text="Reportes" CssClass="btn btn-primary"
                            OnClick="btnReportes_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAsignarMesas" runat="server" Text="Asignación de Mesas" CssClass="btn btn-primary"
                            OnClick="btnAsingarMesas_Click" />
                    </td>
                </tr>   
            </tbody>
        </table>
    </div>
</asp:Content>
