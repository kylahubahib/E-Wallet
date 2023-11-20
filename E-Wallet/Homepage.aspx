<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="E_Wallet.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="style.css" rel="stylesheet" />
    <style>
        .content {
            display: flex;
            flex: 0;
        }

        img{
            width: 50%;
            display:block;
        }

        p{
            text-decoration: none;
            text-align: right;
            margin: auto;
            align-items: center;
            font-size: 60px;
            font-weight:bold;
            color: dodgerblue;
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
                 <li><a runat="server" href="~/SignIn">Sign In</a></li>
              </ul>
     </div>
    <div class="content">
        <img src="fonts/images/background.jpg" />
        <p>Securing Your Funds,<br /> Simplifying Your Life.</p>
    </div>
</body>
</html>
