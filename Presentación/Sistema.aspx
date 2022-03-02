<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/MP_BaseSistema.Master" AutoEventWireup="true" CodeBehind="Sistema.aspx.cs" Inherits="Presentación.Sistema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBaseDelSistema" runat="server">
    <div class="d-flex" id="content-wrapper">
        <div id="sidebar-container" class="bg-primary">
            <div class="logo">
                <h4 class="text-light font-weight-bold mb-0">Eureka</h4>
            </div>
            <div class="menu">
                <asp:LinkButton ID="BtnPerfil2" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnPerfil2_Click" CausesValidation="False"><i class="icon ion-md-person lead mr-2"></i>Mi perfil</asp:LinkButton>
                <asp:LinkButton ID="BtnEstadistica" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnEstadistica_Click" CausesValidation="False"><i class="icon ion-md-stats lead mr-2"></i>Estadísticas</asp:LinkButton>
                <asp:LinkButton ID="BtnRegistro" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnRegistro_Click" CausesValidation="False"><i class="icon ion-md-apps lead mr-2"></i>Ver entregas realizadas</asp:LinkButton>
                <asp:LinkButton ID="BtnVerEntregas" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnVerEntregas_Click" CausesValidation="False"><i class="icon ion-md-apps lead mr-2"></i>Ver entregas</asp:LinkButton>
                <asp:LinkButton ID="BtnRegProyecto" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnRegProyecto_Click" CausesValidation="False"><i class="icon ion-md-apps lead mr-2"></i>Registrar nuevo proyecto</asp:LinkButton>
                <asp:LinkButton ID="BtnHacerInforme" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnHacerInforme_Click" CausesValidation="False"><i class="icon ion-md-apps lead mr-2"></i>Subir informe de proyecto</asp:LinkButton>
                <asp:LinkButton ID="BtnReportarC" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnReportarC_Click" CausesValidation="False"><i class="icon ion-md-people lead mr-2"></i>Registrar capacitación</asp:LinkButton>
                <asp:LinkButton ID="BtnGestionE" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnGestionE_Click" CausesValidation="False"><i class="icon ion-md-people lead mr-2"></i>Gestión de empleados</asp:LinkButton>
                <asp:LinkButton ID="BtnSoliPublicidad" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnSoliPublicidad_Click" CausesValidation="False"><i class="icon ion-md-people lead mr-2"></i>Solicitar publicidad a diseñadores</asp:LinkButton>
                <asp:LinkButton ID="BtnVerInformes" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnVerInformes_Click" CausesValidation="False"><i class="icon ion-md-people lead mr-2"></i>Ver informes</asp:LinkButton>
                <asp:LinkButton ID="BtnHacerC" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnHacerC_Click" CausesValidation="False"><i class="icon ion-md-people lead mr-2"></i>Iniciar capacitación</asp:LinkButton>
                <asp:LinkButton ID="BtnHacerEntrega" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnHacerEntrega_Click" CausesValidation="False"><i class="icon ion-md-settings lead mr-2"></i>Hacer entrega</asp:LinkButton>
                <asp:LinkButton ID="BtnHacerCorrecion" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnHacerCorrecion_Click" CausesValidation="False"><i class="icon ion-md-settings lead mr-2"></i>Corregir entregas</asp:LinkButton>
                <asp:LinkButton ID="BtnHacerAprobacion" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnHacerAprobacion_Click" CausesValidation="False"><i class="icon ion-md-settings lead mr-2"></i>Aprobar aplicaciones con documentación</asp:LinkButton>
                <asp:LinkButton ID="BtnDesPublicidad" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnDesPublicidad_Click" CausesValidation="False"><i class="icon ion-md-settings lead mr-2"></i>Descargar publicidad</asp:LinkButton>
                <asp:LinkButton ID="BtnDesInterfaz" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnDesInterfaz_Click" CausesValidation="False"><i class="icon ion-md-settings lead mr-2"></i>Descargar interfaz</asp:LinkButton>
                <asp:LinkButton ID="BtnReportarE" runat="server" class="d-block text-light p-3 border-0" OnClick="BtnReportarE_Click" CausesValidation="False"><i class="icon ion-md-settings lead mr-2"></i>Reportar errores</asp:LinkButton>
            </div>
        </div>
        <div class="w-100">
            <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
                <div class="container">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav ml-auto mt-2 mt-lg-0">
                            <li class="nav-item dropdown">
                                <a class="nav-link text-light dropdown-toggle" id="navbarDropdown" role="button"
                                    data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="icon ion-md-person lead mr-2"></i>
                                    <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                                </a>
                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                                    <asp:LinkButton ID="BtnPerfil1" class="dropdown-item" runat="server" OnClick="BtnPerfil1_Click" CausesValidation="False">Mi perfil</asp:LinkButton>
                                    <div class="dropdown-divider"></div>
                                    <asp:LinkButton ID="BtnCerrarSesion" class="dropdown-item" runat="server" OnClick="BtnCerrarSesion_Click" CausesValidation="False">Cerrar sesión</asp:LinkButton>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div id="content" class="bg-grey w-100">
                <section class="bg-light py-3">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-9 col-md-8">
                                <h1>
                                    <asp:Label ID="LblBienvenida" class="font-weight-bold mb-0" runat="server" Text="Bienvenido"></asp:Label></h1>
                                <p>
                                    <asp:Label ID="LblRol" class="lead text-light" runat="server" Text="Revisa la última información"></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                </section>
                <section class="bg-mix py-3">
                    <asp:Panel ID="PnlEstadistica" runat="server" class="container">
                        <div class="card rounded-0">
                            <div class="card-header bg-light">
                                <h6 class="font-weight-bold mb-0">Estadísticas</h6>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-3 col-md-6 d-flex stat my-3">
                                        <div class="mx-auto">
                                            <asp:Label ID="LblAtr1" runat="server" class="text-muted" Text="Proyectos asignados"></asp:Label>
                                            <h3>
                                                <asp:Label ID="LblNum1" runat="server" class="font-weight-bold" Text="0"></asp:Label></h3>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 d-flex stat my-3">
                                        <div class="mx-auto">
                                            <asp:Label ID="LblAtr2" runat="server" class="text-muted" Text="Proyectos asignados"></asp:Label>
                                            <h3>
                                                <asp:Label ID="LblNum2" runat="server" class="font-weight-bold" Text="0"></asp:Label></h3>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 d-flex stat my-3">
                                        <div class="mx-auto">
                                            <asp:Label ID="LblAtr3" runat="server" class="text-muted" Text="Proyectos asignados"></asp:Label>
                                            <h3>
                                                <asp:Label ID="LblNum3" runat="server" class="font-weight-bold" Text="0"></asp:Label></h3>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 d-flex my-3">
                                        <div class="mx-auto">
                                            <asp:Label ID="LblAtr4" runat="server" class="text-muted" Text="Proyectos asignados"></asp:Label>
                                            <h3>
                                                <asp:Label ID="LblNum4" runat="server" class="font-weight-bold" Text="0"></asp:Label></h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </section>
                <section class="py-3">
                    <asp:Panel ID="PnlRegistros" runat="server" class="container">
                        <asp:Panel ID="PnlAuxx" runat="server" class="card rounded-0">
                            <div class="card-header bg-light">
                                <asp:Label ID="LblTRegistros" runat="server" class="font-weight-bold mb-0" Text="Registros"></asp:Label>
                            </div>
                            <asp:Panel ID="GrvUsuarios" runat="server">
                                <div class="card-body">
                                    <asp:GridView ID="GridViewU" runat="server" class="container" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IDUsuario" ForeColor="#333333" GridLines="None" OnRowEditing="GrvUsuario_RowEditing" OnRowDeleting="GridViewU_RowDeleting">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="IDUsuario" HeaderText="IDUsuario" InsertVisible="False" ReadOnly="True" SortExpression="IDUsuario" />
                                            <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" SortExpression="NombreUsuario" />
                                            <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
                                            <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />
                                            <asp:TemplateField InsertVisible="false" ShowHeader="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="GrvBtnEditarU" runat="server" CommandName="Edit">Editar</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField InsertVisible="false" ShowHeader="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="GrvBtnEliminarU" runat="server" CommandName="Delete">Eliminar</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#BF1932" />
                                        <FooterStyle BackColor="#BF1932" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#BF1932" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#454A4C" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E6E6E6" ForeColor="#2D2926" />
                                        <SelectedRowStyle BackColor="#CC3300" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>
                                <div class="row pl-0 pr-0 ml-0 mr-0">
                                    <div class="col-lg-12 py-3">
                                        <asp:Button ID="BtnPnlUsuario" class="btn btn-primary w-100" runat="server" Text="Registrar Usuario" CausesValidation="false" OnClick="BtnPnlUsuario_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="GrvProyectos" runat="server">
                                <div class="card-body">
                                    <asp:GridView ID="GridViewP" runat="server" class="container" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IDProyecto" ForeColor="#333333" GridLines="None" OnRowEditing="GridViewP_RowEditing">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="IDProyecto" HeaderText="IDProyecto" InsertVisible="False" ReadOnly="True" SortExpression="IDProyecto" />
                                            <asp:BoundField DataField="NombreProyecto" HeaderText="NombreProyecto" SortExpression="NombreProyecto" />
                                            <asp:BoundField DataField="NombreCliente" HeaderText="NombreCliente" SortExpression="NombreCliente" />
                                            <asp:BoundField DataField="CorreoCliente" HeaderText="CorreoCliente" SortExpression="CorreoCliente" />
                                            <asp:BoundField DataField="EstadoProyecto" HeaderText="EstadoProyecto" SortExpression="EstadoProyecto" />
                                            <asp:TemplateField InsertVisible="false" ShowHeader="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="GrvBtnEditarU" runat="server" CommandName="Edit">Ver</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#BF1932" />
                                        <FooterStyle BackColor="#BF1932" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#BF1932" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#454A4C" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E6E6E6" ForeColor="#2D2926" />
                                        <SelectedRowStyle BackColor="#CC3300" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="GrvEntregas" runat="server">
                                <div class="card-body">
                                    <asp:GridView ID="GridViewE" runat="server" class="container" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IDEntrega" ForeColor="#333333" GridLines="None" OnRowEditing="GridViewE_RowEditing">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="IDEntrega" HeaderText="IDEntrega" InsertVisible="False" ReadOnly="True" SortExpression="IDEntrega" />
                                            <asp:BoundField DataField="IDProyecto" HeaderText="IDProyecto" SortExpression="IDProyecto" />
                                            <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                                            <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto" />
                                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                            <asp:TemplateField InsertVisible="false" ShowHeader="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="GrvBtnEditarU" runat="server" CommandName="Edit">Ver</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#BF1932" />
                                        <FooterStyle BackColor="#BF1932" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#BF1932" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#454A4C" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E6E6E6" ForeColor="#2D2926" />
                                        <SelectedRowStyle BackColor="#CC3300" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PnlBuscarEntregas" runat="server">
                                <div class="card-body">
                                    <asp:Label ID="LblP" runat="server" class="font-weight-bold mb-0" Text="ID del proyecto a buscar"></asp:Label>
                                </div>
                                <div class="row pl-0 pr-0 ml-0 mr-0">
                                    <div class="col-lg-12 py-3">
                                        <asp:TextBox ID="ProyectoBusqueda" class="w-100" runat="server" ValidateRequestMode="Enabled" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="ProyectoBusqueda" ValidateRequestMode="Enabled" class="d-block text-muted" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:Button ID="BtnEntregasxProyecto" class="btn btn-primary w-100" runat="server" Text="Ver las entregas del proyecto" CausesValidation="false" OnClick="BtnEntregasxProyecto_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PnlBotones" runat="server">
                                <div class="row pl-0 pr-0 ml-0 mr-0">
                                    <div class="col-lg-12 py-2">
                                        <asp:Button ID="BtnProyectos" class="btn btn-primary w-100" runat="server" Text="Ver todos los proyectos" CausesValidation="false" />
                                        <asp:Button ID="BtnIUsuarios" class="btn btn-primary w-100" runat="server" Text="Registrar nuevo empleado" CausesValidation="false" />
                                        <asp:Button ID="BtnEntregas" class="btn btn-primary w-100" runat="server" Text="Ver todas las entregas" CausesValidation="false" />
                                        <asp:Panel ID="PnlBtnEntregas" runat="server">
                                            <asp:Button ID="BtnEntregasCorregir" class="btn btn-primary w-100" runat="server" Text="Ver las entregas por corregir" CausesValidation="false" />
                                            <asp:Button ID="BtnEntregasAprobadas" class="btn btn-primary w-100" runat="server" Text="Ver las entregas aprobadas" CausesValidation="false" />
                                            <asp:Button ID="BtnEntregasPendiente" class="btn btn-primary w-100" runat="server" Text="Ver las entregas pendientes" CausesValidation="false" />
                                            <asp:Button ID="BtnEntregasEntregadas" class="btn btn-primary w-100" runat="server" Text="Ver las entregas realizadas" CausesValidation="false" />
                                            <asp:Button ID="BtnEntregasFinalizadas" class="btn btn-primary w-100" runat="server" Text="Ver las aplicaciones finalizadas" CausesValidation="false" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </section>
                <section class="py-3">
                    <asp:Panel ID="PnlProyecto" runat="server" class="container">
                        <div class="card rounded-0">
                            <div class="card-header bg-light">
                                <asp:Label ID="LblTProyecto" runat="server" class="font-weight-bold mb-0" Text="Registrar Proyecto"></asp:Label>
                            </div>
                            <asp:Panel ID="PnlFormP" runat="server">
                                <div class="row pl-0 pr-0 ml-0 mr-0 pt-4">
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label6" runat="server" class="font-weight-bold mb-0" Text="Nombre del Cliente"></asp:Label><br />
                                            <asp:TextBox ID="NombreCliente" runat="server" class="w-100" ValidateRequestMode="Enabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="NombreCliente" ValidateRequestMode="Enabled" class="d-block text-muted" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" class="font-weight-bold mb-0" Text="Correo del Cliente"></asp:Label><br />
                                            <asp:TextBox ID="CorreoCliente" runat="server" ValidateRequestMode="Enabled" class="w-100" TextMode="Email"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="CorreoCliente" ValidateRequestMode="Enabled" class="d-block text-muted" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row pl-0 pr-0 ml-0 mr-0">
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" class="font-weight-bold mb-0" Text="Nombre del Proyecto"></asp:Label><br />
                                            <asp:TextBox ID="NombreProyecto" runat="server" ValidateRequestMode="Enabled" class="w-100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="NombreProyecto" ValidateRequestMode="Enabled" class="d-block text-muted" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" class="font-weight-bold mb-0" Text="Estado del Proyecto"></asp:Label><br />
                                            <asp:TextBox ID="EstadoProyecto" runat="server" ValidateRequestMode="Enabled" class="w-100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="EstadoProyecto" ValidateRequestMode="Enabled" class="d-block text-muted" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel ID="PnlSubirInforme" runat="server">
                                    <div class="card-body">
                                        <asp:Label ID="Label1" runat="server" class="font-weight-bold mb-0" Text="Subir Informe"></asp:Label>
                                    </div>
                                    <div class="row pl-0 pr-0 ml-0 mr-0">
                                        <div class="col-lg-12">
                                            <asp:FileUpload ID="FUInforme" runat="server" ValidateRequestMode="Enabled" /><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="FUInforme" ValidateRequestMode="Enabled" class="d-block text-muted" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row pl-0 pr-0 ml-0 mr-0">
                                        <div class="col-lg-12">
                                            <asp:Button ID="BtnSubirInforme" class="btn btn-primary w-100" runat="server" Text="Subir Informe" CausesValidation="true" OnClick="BtnSubirInforme_Click" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="row pl-0 pr-0 ml-0 mr-0">
                                    <div class="col-lg-12 py-3">
                                        <asp:Button ID="IBM_InsertarP" class="btn btn-primary w-100" runat="server" Text="Registrar proyecto" CausesValidation="true" OnClick="IBM_InsertarP_Click" />
                                        <asp:Button ID="IBM_ModificarP" class="btn btn-primary w-100" runat="server" Text="Modificar proyecto" CausesValidation="true" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </asp:Panel>
                </section>
                <section class="py-3">
                    <asp:Panel ID="PnlEntrega" runat="server" class="container">
                        <div class="card rounded-0">
                            <div class="card-header bg-light">
                                <asp:Label ID="LblTEntrega" runat="server" class="font-weight-bold mb-0" Text="Hacer Entrega"></asp:Label>
                            </div>
                            <asp:Panel ID="PnlFormE" runat="server">
                                <div class="row pl-0 pr-0 ml-0 mr-0 pt-4">
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" class="font-weight-bold mb-0" Text="Concepto"></asp:Label><br />
                                            <asp:TextBox ID="ConceptoEntrega" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="ConceptoEntrega" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-sm-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" class="font-weight-bold mb-0" Text="Estado de la Entrega"></asp:Label><br />
                                        <asp:TextBox ID="EstadoEntrega" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="EstadoEntrega" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row pl-0 pr-0 ml-0 mr-0">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <asp:Label ID="LblComentarios_Requerimientos" runat="server" class="font-weight-bold mb-0" Text="Comentarios sobre la Entrega"></asp:Label><br />
                                            <asp:TextBox ID="ComentariosEntrega" class="w-100" runat="server" ValidateRequestMode="Disabled" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel ID="PnlSubirEntrega" runat="server">
                                    <div class="card-body">
                                        <asp:Label ID="Label10" runat="server" class="font-weight-bold mb-0" Text="Subir Entrega"></asp:Label>
                                    </div>
                                    <div class="row pl-0 pr-0 ml-0 mr-0">
                                        <div class="col-lg-12">
                                            <asp:FileUpload ID="FUEntrega" runat="server" ValidateRequestMode="Enabled" /><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="FUEntrega" ValidateRequestMode="Enabled" class="d-block text-muted" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row pl-0 pr-0 ml-0 mr-0">
                                        <div class="col-lg-12">
                                            <asp:Button ID="BtnSubirEntrega" class="btn btn-primary w-100" runat="server" Text="Subir Entrega" CausesValidation="false" OnClick="BtnSubirEntrega_Click" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="PnlBotonesEntrega" class="row pl-0 pr-0 ml-0 mr-0" runat="server">
                                    <div class="col-lg-12 py-3">
                                        <asp:Button ID="IBM_ModificarE" class="btn btn-primary w-100" runat="server" Text="Modifica Solicitud" CausesValidation="true" />
                                        <asp:Button ID="IBM_InsertarE" class="btn btn-primary w-100" runat="server" Text="Realizar Solicitud" CausesValidation="true" OnClick="IBM_InsertarE_Click" />
                                        <asp:Button ID="BtnAprobar" class="btn btn-primary w-100" runat="server" Text="Aprobar" CausesValidation="true" OnClick="BtnAprobar_Click" />
                                        <asp:Button ID="BtnACorregir" class="btn btn-primary w-100" runat="server" Text="Enviar a corregir" CausesValidation="true" OnClick="BtnACorregir_Click" />
                                        <asp:Button ID="BtnErrores" class="btn btn-primary w-100" runat="server" Text="Reportar Errores" CausesValidation="true" OnClick="BtnErrores_Click" />
                                        <asp:Button ID="BtnCapacitar" class="btn btn-primary w-100" runat="server" Text="Registrar Capacitacion" CausesValidation="true" OnClick="BtnCapacitar_Click" />
                                        <asp:Button ID="BtnZoom" class="btn btn-primary w-100" runat="server" Text="Iniciar Capacitacion en Zoom" CausesValidation="true" OnClick="BtnZoom_Click" />
                                    </div>
                                </asp:Panel>
                            </asp:Panel>
                        </div>
                    </asp:Panel>
                </section>
                <section class="py-3">
                    <asp:Panel ID="PnlUsuarios" runat="server" class="container">
                        <div class="card rounded-0">
                            <div class="card-header bg-light">
                                <asp:Label ID="LblTUsuario" runat="server" class="font-weight-bold mb-0" Text="Mi Cuenta"></asp:Label>
                            </div>
                            <asp:Panel ID="PnlFormU" runat="server">
                                <div class="row pl-0 pr-0 ml-0 mr-0 pt-4">
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Lbl1" runat="server" class="font-weight-bold mb-0" Text="Nombre del empleado"></asp:Label><br />
                                            <asp:TextBox ID="NombreUsuario" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="NombreUsuario" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Lbl2" runat="server" class="font-weight-bold mb-0" Text="Rol del Empleado"></asp:Label><br />
                                            <asp:TextBox ID="RolUsuario" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="RolUsuario" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row pl-0 pr-0 ml-0 mr-0">
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Lbl3" runat="server" class="font-weight-bold mb-0" Text="Nombre de usuario del empleado"></asp:Label><br />
                                            <asp:TextBox ID="LoginUsuario" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="LoginUsuario" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" class="font-weight-bold mb-0" Text="Contraseña del empleado"></asp:Label><br />
                                            <asp:TextBox ID="ClaveUsuario" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="Dato requerido" Text="Campo requerido" ControlToValidate="ClaveUsuario" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row pl-0 pr-0 ml-0 mr-0 py-2">
                                    <div class="col-lg-12 py-3">
                                        <asp:Button ID="IBM_ModificarU" class="btn btn-primary w-100" runat="server" Text="Modifica Usuario" CausesValidation="true" OnClick="IBM_ModificarU_Click" />
                                        <asp:Button ID="BtnModificarU" class="btn btn-primary w-100" runat="server" Text="Modifica tu cuenta" CausesValidation="true" OnClick="BtnModificarU_Click" />
                                        <asp:Button ID="IBM_EliminarU" class="btn btn-primary w-100" runat="server" Text="Eliminar Usuario" CausesValidation="true" OnClick="IBM_EliminarU_Click" />
                                        <asp:Button ID="IBM_InsertarU" class="btn btn-primary w-100" runat="server" Text="Registrar Usuario" CausesValidation="true" OnClick="IBM_InsertarU_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </asp:Panel>
                </section>
                <section class="py-3">
                    <asp:Panel ID="PnlVisualizarArchivo" runat="server" class="container">
                        <div class="card rounded-0">
                            <div class="card-header bg-light">
                                <asp:Label ID="LblTVerArchivo" runat="server" class="font-weight-bold mb-0" Text="Ver archivo de entrega"></asp:Label>
                            </div>
                            <div class="row pl-0 pr-0 ml-0 mr-0 pt-4">
                                <div class="col-lg-6 col-sm-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" class="font-weight-bold mb-0" Text="Nombre del archivo"></asp:Label><br />
                                        <asp:TextBox ID="NombreArchivo" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-sm-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" class="font-weight-bold mb-0" Text="Tipo de Archivo"></asp:Label><br />
                                        <asp:TextBox ID="TipoArchivo" class="w-100" runat="server" ValidateRequestMode="Enabled"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row pl-0 pr-0 ml-0 mr-0 py-2">
                                <div class="col-lg-12">
                                    <asp:Button ID="BtnAbrirArchivo" class="btn btn-primary w-100" runat="server" Text="Abrir Archivo" CausesValidation="false" OnClick="BtnAbrirArchivo_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </section>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfIDUsuario" runat="server" />
    <asp:HiddenField ID="hfTipoArchivo" runat="server" />
    <asp:HiddenField ID="hfIDEntrega" runat="server" />
    <asp:HiddenField ID="hfIDPEntrega" runat="server" />
    <asp:HiddenField ID="hfIDVEntrega" runat="server" />
    <asp:HiddenField ID="HfIDEEntrega" runat="server" />
    <asp:HiddenField ID="hfIDProyecto" runat="server" />
    <asp:HiddenField ID="hfAccionV" runat="server" />
</asp:Content>
