<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMoney.aspx.cs" Inherits="E_Wallet.SendMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />

    <style>

        .container{
           display:flex;
        }

        #form1{
            margin: 45px;
            width: 80vh;
            margin-left: 100px;
            text-align: left;
        }

        h3{
            text-decoration: none;
            color: dodgerblue;
            font-size: 30px;
            font-family: "Poppins", sans-serif;
            font-weight: bold;
        }

        .form2{
            width: 80vh;
            margin: 10px; 
            text-align: left;
            text-decoration: none;
            color: darkblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
        }

        #Label1 {
            padding-right: 10px;
            font-weight: bold;
        }

        #Label2 {
            padding-right: 116px;
            font-weight: bold;
        }

         #Label3 {
            padding-right: 96px;
            font-weight: bold;
        }

          #Label4 {
            padding-right: 20px;
            font-weight: bold;
        }

          
        #accnum, #name, #amount, #pass{
            padding: 5px;
        }

        .div1, .div2, .div3, .div4{
            padding-bottom: 15px;
        }

          #SendBtn{
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


    <form id="form1" runat="server">
        <h3>SEND MONEY</h3><br />
        <div class ="form2">
            <div class ="div1">
                <asp:Label ID="Label1" runat="server" Text="Account Number"></asp:Label>
                <asp:TextBox ID="accnum" runat="server"></asp:TextBox><br />
            </div>
            <div class ="div2">
                <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="name" runat="server"></asp:TextBox><br />
            </div>
            <div class ="div3">
                <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
                <asp:TextBox ID="amount1" runat="server"></asp:TextBox><br /><br />
            </div>
            <asp:Label ID="Label4" runat="server" Text="Enter your password"></asp:Label>
            <asp:TextBox ID="pass"  TextMode="Password" runat="server"></asp:TextBox><br /><br />
        </div>

        <asp:Button ID="SendBtn" runat="server" Text="Send Money" OnClick="SendBtn_Click"/>
    </form>
</div>
</body>
</html>
