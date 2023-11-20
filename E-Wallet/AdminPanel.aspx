<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="E_Wallet.AdminPanel" %>

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
        
        .containerUser{
            margin: 45px;
            text-align: right;
            
        }

        .AdminInfo{
            width: 80vh;
            margin: 30px; 
            text-align: left;
            text-decoration: none;
            color: darkblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
            width: 100%;
        }
        
        .adNumber, .Name, .DateCreated, .Email{
            padding-bottom: 15px;
        }

        #Label1 {
            padding-right: 40px;
            font-weight: bold;
        }

        #Label2 {
            padding-right: 110px;
            font-weight: bold;
        }

         #Label3 {
            padding-right: 27px;
            font-weight: bold;
        }

          #Label4 {
            padding-right: 40px;
            font-weight: bold;
        }

          h3{
            text-align: left;
            text-decoration: none;
            color: dodgerblue;
            font-size: 60px;
            font-family: "Poppins", sans-serif;
          }

           #Logout{
            text-align:left;
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

        <div class="containerUser">
            <form id="form1" runat="server" onload="Page_Load">
            <h3>Welcome, Admin!</h3><br />
                <div class="AdminInfo">
                    <div class="adNumber">
                    <asp:Label ID="Label1" runat="server" Text="Admin Number "></asp:Label>
                    <asp:Label ID="adnum" runat="server" Text=""></asp:Label><br />
                    </div>
                    <div class="Name">
                    <asp:Label ID="Label2" runat="server" Text="Name "></asp:Label>
                    <asp:Label ID="name" runat="server" Text=""></asp:Label><br />
                    </div>
                    <div class="Email">
                    <asp:Label ID="Label3" runat="server" Text="Email Address "></asp:Label>
                    <asp:Label ID="email" runat="server" Text=""></asp:Label><br />
                    </div>
                    <div class="DateCreated">
                    <asp:Label ID="Label4" runat="server" Text="Date Created "></asp:Label>
                    <asp:Label ID="datecreated" runat="server" Text=""></asp:Label><br /><br />
                    </div>
                    <div class="Password">
                    <asp:Button ID="Editpass" runat="server" Text="Edit Password" OnClick="Editpass_Click"/>
                    <asp:Button ID="UpdatePass" runat="server" Text="Save Password" OnClick="UpdatePass_Click" Visible="false"/>
                    <asp:TextBox ID="newpass" runat="server"  TextMode="Password" Enabled="false"></asp:TextBox><br /><br />
                    </div>

                    
                    <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click"/>
              </div>
            </form>
        </div>

</div>
</body>
</html>
