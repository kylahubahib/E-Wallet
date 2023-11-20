<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="E_Wallet.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="style.css" rel="stylesheet" />
    <style>
        #form1{
            margin: auto;
            margin-top: 50px;
            border: 1px solid darkblue;
            border-radius: 5px;
            text-align: center;
            width: 400px;
            height: 500px
        }

        .login{
            text-align: left;
            padding: 20px;
            margin-top: 80px;
        }

        #Label1, #Label2{
            text-decoration: none;
            color: steelblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
        }
        
        #email, #password{
             border-radius:5px;
             border-color: darkblue;
             padding: 10px;
             width: 350px;
             margin-bottom: 15px;
        }

        #Button1{
            padding: 10px;
            color:white;
            border-radius: 5px;
            border-style: none;
            background-color: dodgerblue;
            font-size: 20px;
            font-weight: bold;
            font-family: "Poppins", sans-serif
        }
    </style>

</head>
<body>
    <div class="header">
             <label id="text1">E-WALLET</label>

             <ul class="nav-links">
                 <li><a runat="server" href="~/Homepage">Homepage</a></li>
                 <li><a runat="server" href="~/Homepage">About</a></li>
                 <li><a runat="server" href="~/Homepage">Contact</a></li>
                 <li><a runat="server" href="~/CreateAccount">Create Account</a></li>
              </ul>
     </div>


    <form id="form1" runat="server">
        <div class="login">
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="email" runat="server"></asp:TextBox><br />

            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="password"  TextMode="Password" runat="server"></asp:TextBox><br />
        </div>
        <asp:CheckBox ID="adminCheck" runat="server" Text="Login as admin"/><br /><br />

        <asp:Button ID="Button1" runat="server" Text="LOG IN" OnClick="LoginBtn" />
    </form>
</body>
</html>
