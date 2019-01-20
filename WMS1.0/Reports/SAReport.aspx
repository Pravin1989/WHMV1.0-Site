<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SAReport.aspx.cs" Inherits="WMS1._0.Reports.SAReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
<table width="100%">
        <tr>
            
            <td align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Active Warehouse" Font-Bold="true"
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
                Report List :
            </td>
            <td style="margin-left: 40px">
                <asp:DropDownList ID="ddlReport" runat="server" Width="200px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
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
                <asp:Button ID="btnReport" runat="server" Text="Save" OnClick="btnReport_Click" ValidationGroup="Add" />
                &nbsp;
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
                <asp:GridView ID="gvReportData" runat="server" Width="90%" AutoGenerateColumns="true" CellPadding="4"
                    ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    
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
</div>
</asp:Content>
