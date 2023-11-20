<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="E_Wallet.AddAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="style.css" rel="stylesheet" />

    <style>
        
        .action2{
             height: 30%;
        }

        .actionlist2{
           display: flex;
          
        }

        .actionlist2 li{
            margin-right: 40px;
        }

        h3{
            text-decoration: none;
            color: dodgerblue;
            font-size: 30px;
            font-family: "Poppins", sans-serif;
            font-weight: bold;
        }

        .addform{
            margin: 45px;
            text-align: left;
            width: 80vh;
        }

        #Label1, #Label2, #Label3, #Label4{
            margin-bottom: 10px;
            text-decoration: none;
            color: darkblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
        }

        
        #Label1 {
            padding-right: 41px;
            font-weight: bold;
        }

        #Label2 {
            padding-right: 41px;
            font-weight: bold;
        }

         #Label3 {
            padding-right: 25px;
            font-weight: bold;
        }

         #Label4 {
            padding-right: 70px;
            font-weight: bold;
        }

        #lname, #fname, #email, #password{
            padding: 10px;
            border-radius: 5px;
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
                 <li><a runat="server" href="~/AdminPanel">Homepage</a></li>
                 <li><a runat="server" href="~/AdminPanel">About</a></li>
                 <li><a runat="server" href="~/AdminPanel">Contact</a></li>
              </ul>
     </div>

<div class="container">

    <div class="action2">
        <ul class="actionlist2">
            <li><a runat="server" href="~/ViewUsers">VIEW USERS</a></li>
            <li><a runat="server" href="~/AddAdmin">ADD ADMIN</a></li>
            <li><a runat="server" href="~/AdminPanel">PROFILE</a></li>
        </ul>
    </div>

    <div class="addform">
        <h3>ADD NEW ADMIN</h3><br /><br />
        <form id="form1" class="form1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="FIRST NAME"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="fname" runat="server" Width="250px" Height="26px"></asp:TextBox><br /><br />

            <asp:Label ID="Label2" runat="server" Text="LAST NAME"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lname" runat="server" Width="250px" Height="26px"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="EMAIL ADDRESS"></asp:Label>
            <asp:TextBox ID="email" runat="server" Width="250px" Height="26px" ></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server" Text="PASSWORD"></asp:Label>
            <asp:TextBox ID="password" runat="server" Width="250px" Height="26px" TextMode="Password"></asp:TextBox><br /><br />
             
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="BtnSubmit"/><br /><br />
    </form>
    </div>
</div>
</body>
</html>
