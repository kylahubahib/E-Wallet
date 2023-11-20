<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="E_Wallet.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />

    <style>
        .form1, h2{
            margin-left: 100px;
        }

        textbox{
           text-align: center;
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

     <h2>PERSONAL INFORMATION FORM</h2>
    <form id="form1" class="form1" runat="server">
        <asp:Label ID="Label2" runat="server" Text="FIRST NAME"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fname" runat="server" Width="312px" Height="26px"></asp:TextBox><br /><br />

        <asp:Label ID="Label1" runat="server" Text="LAST NAME"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="lname" runat="server" Width="306px" Height="26px"></asp:TextBox><br /><br />

        <asp:Label ID="Label11" runat="server" Text="GENDER    "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="btnMale" runat="server" Text="Male" GroupName="gender" />
        <asp:RadioButton ID="btnFmale" runat="server" Text="Female"  GroupName="gender"   />
        <asp:RadioButton ID="btnNB" runat="server" Text="Non-Binary"  GroupName="gender"  />&nbsp;<br /><br />

        <asp:Label ID="Label7" runat="server" Text="DATE OF BIRTH"></asp:Label>
        &nbsp;
        <asp:TextBox ID="dob" runat="server" Width="307px" Height="26px"></asp:TextBox><br /><br />

        <asp:Label ID="Label4" runat="server" Text="ADDRESS"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="address" runat="server" Width="305px" Height="26px"></asp:TextBox><br /><br />

        <asp:Label ID="Label13" runat="server" Text="PHONE NUMBER"></asp:Label>
        <asp:TextBox ID="pnumber" runat="server" Width="305px" Height="26px"></asp:TextBox><br /><br />
        <asp:Label ID="Label6" runat="server" Text="EMAIL ADDRESS"></asp:Label>
        &nbsp;<asp:TextBox ID="email" runat="server" Width="304px" Height="26px" ></asp:TextBox><br /><br />
        <asp:Label ID="Label3" runat="server" Text="PASSWORD"></asp:Label>
        &nbsp;<asp:TextBox ID="password" runat="server" Width="304px" Height="26px"  TextMode="Password"></asp:TextBox><br /><br />

        <asp:FileUpload ID="picUpload" runat="server" Width="246px" /><br /><br />

        <asp:Button ID="btnVwPic" runat="server" Text="View Image" OnClick="btnVwPic_Click" /><br />
        <asp:Image ID="vwPic" runat="server" Width="208px" Height="145px" /><br /><br />

        <asp:Label ID="dsplyResult" runat="server" Text=""></asp:Label>

        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="BtnSubmit"/><br /><br />
    </form>
</body>
</html>
