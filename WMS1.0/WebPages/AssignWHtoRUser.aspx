<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AssignWHtoRUser.aspx.cs" Inherits="WMS1._0.WebPages.AssignWHtoRUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Assinged WH TO Users" Font-Bold="true"
                    ForeColor="Blue"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="80%">
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
            <td style="margin-left: 40px">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Company :
            </td>
            <td style="margin-left: 40px">
                <asp:DropDownList ID="ddlCompany" runat="server" Width="200px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                User :
            </td>
            <td style="margin-left: 40px">
                <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td style="margin-left: 40px">
                &nbsp;
                <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td style="margin-left: 40px">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Add" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:GridView ID="gvWH" runat="server" Width="90%" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center" DataKeyNames="Id">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="cbwh" AutoPostBack="false" Checked='<%# Eval("Assinged").ToString()=="True" ? true : false %>'                               />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Company Code" DataField="CompanyCode" />
                        <asp:BoundField HeaderText="WHID" DataField="WHId" />
                        <asp:BoundField HeaderText="WH Name" DataField="WHName" />
                        <asp:BoundField HeaderText="WH Address" DataField="Address" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
