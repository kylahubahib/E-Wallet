<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="E_Wallet.Withdraw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />

    <style>

        .container{
           display:flex;
        }

        .action2{
            width: 50vh;
            
        }

        .container2{
            margin: 45px;
            width: 80vh;
            margin-left: 100px;
        }

        textbox{
           text-align: center;
        }

        .addform{
            text-align: right;
        }

        h5{
            text-decoration: none;
            color: dodgerblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
            font-weight: bold;
        }

        #Label1{
            text-decoration: none;
            color: dodgerblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
            font-weight: bold;
        }

        #amount{
            border-radius:5px;
            border-color: darkblue;
            padding: 10px;

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

        .balance{
            text-decoration: none;
            color: darkblue;
            font-size: 80px;
            font-weight:bold;
            font-family: "Poppins", sans-serif;
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

<div class="container">
        <div class="action2">
            <ul class="actionlist2">
                <li><a runat="server" href="~/Deposit">DEPOSIT</a></li>
                <li><a runat="server" href="~/Withdraw">WITHDRAW</a></li>
                <li><a runat="server" href="~/SendMoney">SEND MONEY</a></li>
                <li><a runat="server" href="~/ViewTransaction">TRANSACTIONS</a></li>
                <li><a runat="server" href="~/Profile">PROFILE</a></li>
            </ul>
        </div>

    <div class="container2">

        <h5>Current Balance: </h5><br />
         <div class="container">
                    <asp:Label class="balance" ID="balance" runat="server" Text="0.00" OnPreRender="CurrentBalance" ></asp:Label>
         </div><br /><br />

        <form id="form1" class="form1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Enter Amount"></asp:Label>
            <asp:TextBox ID="amount" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="Button1" runat="server" Text="Withdraw" OnClick="WithdrawBtn"/><br /><br />
    </form>
    </div>
</div>
   
</body>
</html>
