<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReportUser.aspx.cs" Inherits="WMS1._0.WebPages.AddReportUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Add Users" Font-Bold="true" ForeColor="Blue"></asp:Label>
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
                User ID :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtWHId" runat="server"></asp:TextBox>
                
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
                    onselectedindexchanged="ddlCompany_SelectedIndexChanged" ></asp:DropDownList>
                
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Name : 
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Name"
                    ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Email :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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
                Contact Number :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
         <tr>
            <td>
            </td>
            <td>
                Possition :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtPossition" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>   
         
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Password :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
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
                <asp:GridView ID="gvWH" runat="server" Width="90%" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="Company Code" DataField="CompanyCode" />
                        <asp:BoundField HeaderText="UserId" DataField="ReportUserId" />
                        <asp:BoundField HeaderText="Name" DataField="Name" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Contact Number" DataField="ContactNo" />
                        <asp:BoundField HeaderText="Possition" DataField="Position" />                        
                        
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