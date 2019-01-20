<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddCompany.aspx.cs" Inherits="WMS1._0.WebPages.AddCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Add Company" Font-Bold="true" ForeColor="Blue"></asp:Label>
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
                Company ID :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtCompanyId" runat="server"></asp:TextBox>
                
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Company Name :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Customer Name"
                    ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtCompanyName"></asp:RequiredFieldValidator>
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
                Contact Person :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Coontact Person Name"
                    ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtContactPerson"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                Address :
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                <asp:GridView ID="gvCompany" runat="server" Width="90%" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="CompanyId"
                    RowStyle-HorizontalAlign="Center" OnRowDeleting="gvCompany_OnRowDeleting" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="Company Code" DataField="CompanyId" />
                        <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Contact Number" DataField="ContactNo" />
                        <asp:BoundField HeaderText="Contact Person" DataField="ContactPerson" />
                        <asp:BoundField HeaderText="Address" DataField="Address" />
                        <asp:CommandField ShowDeleteButton="True" />
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
