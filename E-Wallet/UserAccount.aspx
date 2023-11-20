<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="E_Wallet.UserAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- css for the header menu -->
    <link href="style.css" rel="stylesheet" />

    <style>

        .container2{
           display:flex;
        }

        .containerUser{
            margin: 45px;
            text-align: right;
            width: 50vh;
        }

        .container{
            padding: 10px;
             border: 1px solid lightslategray;
             border-radius: 15px;
             width: 90vh;
             height: 20vh;
             position: relative;
             align-items:center;
             margin-bottom: 20px;
        }

        .actions {
            width: 120vh;
            height: 30vh;
	        justify-content:left;
            margin: 50px 0 0 40vh;
        }

        .balance{
            text-decoration: none;
            color: darkblue;
            font-size: 100px;
            font-weight:bold;
            font-family: "Poppins", sans-serif;
        }

        .UserInfo{
            width: 80vh;
            margin: 10px; 
            text-align: left;
            text-decoration: none;
            color: darkblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
        }
        
        .AccountNumber, .Name, .DateReg, .TotalSent{
            padding-bottom: 15px;
        }

        #Label1 {
            padding-right: 50px;
            font-weight: bold;
        }

        #Label3 {
            padding-right: 146px;
            font-weight: bold;
        }

         #Label5 {
            padding-right: 54px;
            font-weight: bold;
        }

          #Label7 {
            padding-right: 46px;
            font-weight: bold;
        }
        

    </style>
</head>
<body>
    <div class="header">
        <label id="text1">E-WALLET</label>

        <ul class="nav-links">
            <li><a runat="server" href="~/UserAccount">Homepage</a></li>
            <li><a runat="server" href="~/UserAccount">About</a></li>
            <li><a runat="server" href="~/UserAccount">Contact</a></li>
         </ul>

    </div>

    <div class="container2">
        <div class="action2">
            <ul class="actionlist2">
                <li><a runat="server" href="~/Deposit">DEPOSIT</a></li>
                <li><a runat="server" href="~/Withdraw">WITHDRAW</a></li>
                <li><a runat="server" href="~/SendMoney">SEND MONEY</a></li>
                <li><a runat="server" href="~/ViewTransaction">TRANSACTIONS</a></li>
                <li><a runat="server" href="~/Profile">PROFILE</a></li>
            </ul>
        </div>
    
        <div class="containerUser">
            <form id="form1" runat="server">
                <div class="container">
                    <asp:Label class="balance" ID="balance" runat="server" Text="0.00" OnLoad="Page_Load"></asp:Label>
                </div>

                <div class="UserInfo">
                    <div class="AccountNumber">
                    <asp:Label ID="Label1" runat="server" Text="Account Number "></asp:Label>
                    <asp:Label ID="accnum" runat="server" Text=""></asp:Label><br />
                    </div>
                    <div class="Name">
                    <asp:Label ID="Label3" runat="server" Text="Name "></asp:Label>
                    <asp:Label ID="name" runat="server" Text=""></asp:Label><br />
                    </div>
                    <div class="DateReg">
                    <asp:Label ID="Label5" runat="server" Text="Date Registered "></asp:Label>
                    <asp:Label ID="datereg" runat="server" Text=""></asp:Label><br />
                    </div>
                    <div class="TotalSent">
                    <asp:Label ID="Label7" runat="server" Text="Total Sent Money "></asp:Label>
                    <asp:Label ID="totalsent" runat="server" Text=""></asp:Label><br />
                    </div>
                </div>

            </form>
        </div>
    </div>


</body>
</html>
