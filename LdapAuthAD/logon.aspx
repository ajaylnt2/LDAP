<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logon.aspx.cs" Inherits="LdapAuthAD.logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 102%;
            height: 107px;
        }

        .auto-style2 {
            width: 113px;
        }

        .auto-style3 {
            width: 300px;
        }
    </style>
</head>
<body style="width: 516px; height: 151px">
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1" border="10">
                <tr>
                    <td class="auto-style2">Domain Name:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDomain" runat="server" BackColor="White" ForeColor="#003300" BorderColor="#003300"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDomain" ErrorMessage="Domain Is Mandatory" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style2">User Name:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtUser" runat="server" BackColor="White" ForeColor="#003300" BorderColor="#003300"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="txtUser" ErrorMessage="Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style2">Password:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPassword" runat="server" BackColor="White" ForeColor="#003300" TextMode="Password" BorderColor="#003300"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Please" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnLogin" runat="server" BackColor="White" BorderColor="#003300" ForeColor="#003300" OnClick="btnLogin_Click" Text="Log In" />
                        &nbsp;<asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
