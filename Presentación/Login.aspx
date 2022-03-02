<%@ Page Title="" Language="C#" MasterPageFile="PaginasMaestras/MP_BaseSistema.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentación.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBaseDelSistema" runat="server">
    <div class="container col-lg-4 my-3">
        <div class="card rounded-0">
            <div class="card-header bg-light">
                <asp:Label ID="LblMensaje" class="font-weight-bold mb-0" runat="server" Text="Inicia sesión"></asp:Label>
            </div>
            <div class="card-body pt-2">
                <div class="row pl-0 pr-0 ml-0 mr-0">
                    <div class="col-lg-12 align-content-center">
                        <div class="form-group">
                            <h2 class="font-weight-bold"><i class="icon ion-md-person pr-2"></i>Usuario</h2>
                            <asp:TextBox ID="Usuario" runat="server" class="w-100" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="Usuario" ValidateRequestMode="Enabled" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row pl-0 pr-0 ml-0 mr-0">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <h2 class="font-weight-bold"><i class="icon ion-md-key pr-2"></i>Contraseña</h2>
                            <asp:TextBox ID="Pass" runat="server" class="w-100" ValidateRequestMode="Enabled" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="Pass" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <asp:Button ID="entra" class="btn btn-primary w-100" runat="server" Text="Iniciar sesión" CausesValidation="true" OnClick="entra_Click" />
            </div>
        </div>
    </div>
</asp:Content>
