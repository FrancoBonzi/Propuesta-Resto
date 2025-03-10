﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Final_Resto.Home" %>

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
                        <asp:Button ID="btnReportes" runat="server" Text="Reporte de Pedidos" CssClass="btn btn-primary"
                            OnClick="btnReportes_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRendimiento" runat="server" Text="Rendimiento de Meseros" CssClass="btn btn-primary"
                            OnClick="btnRendimiento_Click" />
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Button ID="btnestionarMesas" runat="server" Text="Gestionar Mesas" CssClass="btn btn-primary"
                            OnClick="btnGestionarMesas_Click" />
                    </td>
                </tr>  

                 <tr>
                    <td>
                        <asp:Button ID="btnMenu" runat="server" Text="Revisar productos" CssClass="btn btn-primary"
                            OnClick="btnGestionarMenu_Click" />
                    </td>
                </tr>  
            </tbody>
        </table>
    </div>
</asp:Content>
