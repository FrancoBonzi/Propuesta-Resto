<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="Final_Resto.RegistroUsuarios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow-lg p-4 rounded" style="width: 400px;">
            <h2 class="text-center">Registro de Usuario</h2>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre Completo</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es obligatorio." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese un usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"
                    ErrorMessage="El usuario es obligatorio." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="txtContrasena" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese una contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena"
                    ErrorMessage="La contraseña es obligatoria." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="ddlRol" class="form-label">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione un Rol" Value="" />
                    <asp:ListItem Text="Gerente" Value="Gerente" />
                    <asp:ListItem Text="Mesero" Value="Mesero" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvRol" runat="server" ControlToValidate="ddlRol"
                    InitialValue="" ErrorMessage="Debe seleccionar un rol." CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="d-grid gap-2">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success btn-lg"
                    OnClick="btnRegistrar_Click" />
            </div>

            <div class="text-center mt-3">
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
