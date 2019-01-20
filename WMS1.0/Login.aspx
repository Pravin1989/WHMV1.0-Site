<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WMS1._0.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="background-color:White">
    <center>
    
    <div >
    <div>
        <p id="pnlmessage" runat="server" visible="false">
            <asp:Label ID="lndss" runat="server" Text="You are not register please register your self."
                ForeColor="Red"></asp:Label>
        </p>
        <div class="accountInfo" >
            <fieldset class="login">
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
                <legend>Account Information</legend>
                <p>
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">Username:</asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    &nbsp;</p>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_btnLogin" Text="Log In"
                    ValidationGroup="LoginUserValidationGroup" />
                <%--<asp:Button ID="LoginButton" runat="server"  Text="Log In" ValidationGroup="LoginUserValidationGroup"/>--%>
            </p>
        </div>
    </div>
    </div>
    </center>
    </form>
</body>
</html>
