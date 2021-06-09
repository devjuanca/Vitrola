<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site2.master" AutoEventWireup="true" CodeFile="registrar_cupones.aspx.cs" Inherits="Admin_mimusica" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <div class="row" style="margin-top: 10px">
        <div class="row">
            <div class="col-xs-12">
                <br />
                <div id="SuccessDiv" runat="server" class="hidden"></div>
                <br />
            </div>
        </div>
          <div class="row" style="margin-bottom: 5px">
            <div class="col-xs-12" style="margin-bottom: 10px">
                <div class="col-xs-2">
                    
                    <strong>Descuento:</strong>
                </div>
                <div class="col-xs-10">
                    <asp:TextBox ID="TextBox4" CssClass="input-sm" Text="0" runat="server" TextMode="Number"></asp:TextBox>%
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Escriba el % de descuento" ForeColor="Red" ControlToValidate="TextBox4" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>

            </div>
        </div>
          <div class="row" style="margin-bottom: 5px">
            <div class="col-xs-12" style="margin-bottom: 10px">
                <div class="col-xs-2">
                    <strong>Valido hasta:</strong>
                </div>
                <div class="col-xs-10">
                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Escriba la fecha de vencimiento" ForeColor="Red" ControlToValidate="RadDatePicker1" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>

            </div>
        </div>
        <div class="row" style="margin-bottom: 5px">
            <div class="col-xs-12" style="margin-bottom: 10px">
                <div class="col-xs-2">
                    <strong>Desde:</strong>
                </div>
                <div class="col-xs-10">
                    <asp:TextBox ID="TextBox2" CssClass="input-sm"  runat="server" TextMode="Number"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Escriba inicio del # de los cupones" ForeColor="Red" ControlToValidate="TextBox2" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>

            </div>
        </div>
        <div class="row" style="margin-bottom: 5px">
            <div class="col-xs-12">
                <div class="col-xs-2">
                    <strong>Hasta:</strong>
                </div>
                <div class="col-xs-10">
                    <asp:TextBox ID="TextBox3" CssClass="input-sm"  runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Escriba final del # de los cupones" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox3" ValidationGroup="A"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="TextBox2" ControlToValidate="TextBox3" Display="Dynamic" ForeColor="Red" Operator="GreaterThanEqual" Type="Integer" ValidationGroup="A">El # inicio de cupones debe ser menor que el final</asp:CompareValidator>
                </div>

            </div>
        </div>
        <div class="row" style="margin-bottom: 5px">
            <div class="col-xs-12">
                <div class="col-xs-2">

                    <strong>Distribuidor:</strong>
                </div>
                <div class="col-xs-10">
                    <asp:DropDownList ID="DropDownList1" CssClass="input-sm" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Control_CuponesConnectionString %>" SelectCommand="S_Distribuidor" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>

            </div>
        </div>
        <div class="row" style="margin-bottom: 5px">
            <div class="col-xs-12">
                <div class="col-xs-2">
                </div>
                <div class="col-xs-10">

                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-lg btn-success" OnClick="Button2_Click" ValidationGroup="A" Text="Registrar" />
                </div>


            </div>
        </div>

        <div class="row" style="margin-top: 0px">
            <hr />
            <div class="col-lg-2 col-xs-12" style="margin-bottom: 4px">
                <asp:TextBox ID="TextBox1" CssClass="input-sm" Text="0" runat="server" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-lg-10 col-xs-12" style="margin-bottom: 4px">
                <asp:Button ID="Button1" CssClass="btn btn-sm btn-success" runat="server" Text="Buscar" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">

                <telerik:RadGrid ID="RadGrid1" runat="server" DataSourceID="SqlDataSource1" GridLines="None" AllowPaging="True" PageSize="100">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" CommandItemDisplay="Top">
                        <CommandItemTemplate>
                            <div style="margin:2px">
                                 <asp:Button ID="Button3" runat="server" CssClass="btn btn-xs btn-danger" OnClick="Button3_Click" Text="Cancelar Cupón" />
                                 <asp:Button ID="Button4" runat="server" CssClass="btn btn-xs btn-info" OnClick="Button4_Click" Text="Reactivar Cupón" />
                            </div>
                         
                        </CommandItemTemplate>

                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>

                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>

                            <telerik:GridBoundColumn DataField="Numero" DataType="System.Int32" HeaderText="Numero" SortExpression="Numero" UniqueName="Numero">
                            </telerik:GridBoundColumn>
                             <telerik:GridTemplateColumn  DataField="Descuento" DataType="System.Int32" HeaderText="Descuento" SortExpression="Descuento" UniqueName="Descuento">
                                <ItemTemplate>
                                    <%#Eval("Descuento").ToString()+"%" %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" SortExpression="Estado" UniqueName="Estado">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Valido_Hasta" DataType="System.DateTime" HeaderText="Fecha Validez" SortExpression="Valido_Hasta" UniqueName="Valido_Hasta">
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
</asp:Content>

