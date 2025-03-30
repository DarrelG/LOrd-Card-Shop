<%@ Page Title="Login" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LOrdCardShop.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-container {
            width: 350px;
            margin: 100px auto;
            padding: 20px;
            border: 2px solid #ccc;
            border-radius: 10px;
            background-color: #f9f9f9;
            text-align: center;
            box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.1);
        }

        .login-container input, .login-container button {
            width: 90%;
            padding: 10px;
            margin: 8px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .login-container button {
            background-color: #007bff;
            color: white;
            font-size: 16px;
            cursor: pointer;
            border: none;
        }

        .login-container button:hover {
            background-color: #0056b3;
        }

        .remember-me {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            gap: 5px;
        }

        a{
            display: inline;
            font-size: smaller;
        }
    </style>

    <script type="text/javascript">
        function togglePassword() {
            var pwTb = document.getElementById('<%= pwTb.ClientID %>');
            if (pwTb.type === "password") {
                pwTb.type = "text";
            } else {
                pwTb.type = "password";
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <h2>Login</h2>

        <asp:Label ID="uNameLbl" runat="server" Text="Username"></asp:Label><br />
        <asp:TextBox ID="uNameTb" runat="server"></asp:TextBox><br />

        <asp:Label ID="pwLbl" runat="server" Text="Password"></asp:Label><br />
        <asp:TextBox ID="pwTb" runat="server" TextMode="Password"></asp:TextBox><br />

        <asp:Button ID="showPass" runat="server" Text="Show Password" OnClientClick="togglePassword(); return false;"/>

        <div class="remember-me">
            <asp:CheckBox ID="rememberMe" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Remember&nbspMe!"></asp:Label>
        </div>
        <br />
        <asp:Label ID="errLbl" runat="server" Text="" ForeColor="#DC1414" Visible="False"></asp:Label><br />

        <asp:Button ID="loginBtn" runat="server" Text="Login" onClick="loginBtn_Click"/>

        <p style="display: inline; font-size: smaller;">Create new account </p><a href="Register.aspx">here.</a>
    </div>
</asp:Content>
