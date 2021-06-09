<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site2.master" AutoEventWireup="true" CodeFile="admin_cupones.aspx.cs" Inherits="Admin_mimusica" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <div class="row" style="margin-top: 10px">
        <div class="col-md-3" style="border: solid 1px black">

            <telerik:RadTreeView ID="RadTreeView1" runat="server">
                <Nodes>
                    <telerik:RadTreeNode NavigateUrl="admin_cupones.aspx" Expanded="true" Text="Inicio">
                        <Nodes>
                            <telerik:RadTreeNode NavigateUrl="registrar_cupones.aspx" Text="Registrar Cupones"></telerik:RadTreeNode>
                           
                            <telerik:RadTreeNode Text="Registrar Distribuidores"></telerik:RadTreeNode>
                        </Nodes>
                    </telerik:RadTreeNode>
                </Nodes>
            </telerik:RadTreeView>

        </div>
        <div class="col-md-9">
            <div class="row" style="margin-top: 0px">
                <div class="col-lg-3 col-xs-12" style="margin-bottom: 4px">
                    <asp:TextBox ID="TextBox1" CssClass="input-sm" Text="0" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-lg-9 col-xs-12" style="margin-bottom: 4px">
                    <asp:Button ID="Button1" CssClass="btn btn-sm btn-success" runat="server" Text="Buscar" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">

                    <telerik:RadGrid ID="RadGrid1" runat="server" DataSourceID="SqlDataSource1" GridLines="None">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>

                                <telerik:GridBoundColumn DataField="Numero" DataType="System.Int32" HeaderText="Numero" SortExpression="Numero" UniqueName="Numero">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="Descuento" DataType="System.Int32" HeaderText="Descuento" SortExpression="Descuento" UniqueName="Descuento">
                                    <ItemTemplate>
                                        <%#Eval("Descuento").ToString()+"%" %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Valido_Hasta" DataType="System.DateTime" HeaderText="Fecha Validez" SortExpression="Valido_Hasta" UniqueName="Valido_Hasta">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" SortExpression="Estado" UniqueName="Estado">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Distribuidor" HeaderText="Distribuidor" SortExpression="Distribuidor" UniqueName="Distribuidor">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fecha_Expedido" DataType="System.DateTime" HeaderText="Fecha_Expedido" SortExpression="Fecha_Expedido" UniqueName="Fecha_Expedido">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Control_CuponesConnectionString %>" SelectCommand="S_Descuentos" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBox1" DefaultValue="0" Name="Numero" PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>

            </div>

        </div>
    </div>

</asp:Content>

