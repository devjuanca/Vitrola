<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="mimusica.aspx.cs" Inherits="Admin_mimusica" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <div class="row">
        <div class="col-xs-12">
            <br />
            <div id="SuccessDiv" runat="server" class="hidden"></div>
            <br />
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#tab1" aria-controls="Dispositivos" role="tab" data-toggle="tab">Dispositivos</a></li>
                <li role="presentation"><a href="#tab2" aria-controls="CancionesPedidas" role="tab" data-toggle="tab">Canciones Pedidas</a></li>

            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane fade in active" id="tab1">
                    <br />
                    <telerik:RadGrid ID="RadGrid1" runat="server" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" PageSize="50" GridLines="None">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IP" HeaderText="IP" SortExpression="IP" UniqueName="IP">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MAC" HeaderText="MAC" SortExpression="MAC" UniqueName="MAC">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ultimo_Acceso" DataType="System.DateTime" HeaderText="Ultimo_Acceso" SortExpression="Ultimo_Acceso" UniqueName="Ultimo_Acceso">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Contador" DataType="System.Int32" HeaderText="Contador" SortExpression="Contador" UniqueName="Contador">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Cant_Peticiones" DataType="System.Int32" HeaderText="Cant_Peticiones" ReadOnly="True" SortExpression="Cant_Peticiones" UniqueName="Cant_Peticiones">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LaVitrolaConnectionString %>" SelectCommand="S_Dispositivos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
                <div role="tabpanel" class="tab-pane fade MarginBottom20px" id="tab2">
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LaVitrolaConnectionString %>" SelectCommand="Canciones_de_Clientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <telerik:RadGrid ID="RadGrid2" runat="server" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" PageSize="50" GridLines="None">
                        <MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Num" HeaderText="Num" SortExpression="Num" UniqueName="Num">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha" DataType="System.DateTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ultimo_Acceso" DataType="System.DateTime" HeaderText="Ultimo_Acceso" SortExpression="Ultimo_Acceso" UniqueName="Ultimo_Acceso">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="IP" HeaderText="IP" SortExpression="IP" UniqueName="IP">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MAC" HeaderText="MAC" SortExpression="MAC" UniqueName="MAC">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>


            </div>

        </div>
    </div>

</asp:Content>

