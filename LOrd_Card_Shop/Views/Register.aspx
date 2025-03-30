<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LOrdCardShop.Views.Register" %>

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

        a {
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

        <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label><br />
        <asp:TextBox ID="emailTb" runat="server" TextMode="Email"></asp:TextBox><br />

        <asp:Label ID="pwLbl" runat="server" Text="Password"></asp:Label><br />
        <asp:TextBox ID="pwTb" runat="server" TextMode="Password"></asp:TextBox><br />

        <asp:Button ID="showPass" runat="server" Text="Show Password" OnClientClick="togglePassword(); return false;" /><br />

        <div style="display: flex; justify-content: center;">
            <asp:RadioButtonList ID="genderRBList" runat="server" style="display: flex;">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        
        <asp:Label ID="Label1" runat="server" Text="Date of Birth"></asp:Label>
        <div style="display: flex; justify-content: center;">
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>

        <br />
        <asp:Label ID="pwConfirmlbl" runat="server" Text="Confirm Password"></asp:Label><br />
        <asp:TextBox ID="pwConfirmTb" runat="server" TextMode="Password"></asp:TextBox><br />

        <br />
        <asp:Label ID="errLbl" runat="server" Text="" ForeColor="#DC1414" Visible="False"></asp:Label><br />

        <asp:Button ID="registerBtn" runat="server" Text="Register New Account" OnClick="registerBtn_Click" />
    </div>
</asp:Content>
