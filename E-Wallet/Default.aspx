<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Wallet._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <link href=" c:\users\lenovo\source\repos\e-wallet\E-Wallet\Content\Site.css" rel="stylesheet" type="text/css" />
    
    <div class="jumbotron">
        <h1>E-WALLET SYSTEM</h1>
        <p class="lead">Final Project for ASP.Net</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="createAccount">
            
            <a runat="server" href="~/CreateAccount"><img id="createAcc" src="fonts/images/add user.png" /></a>
            <h2>Create Account</h2>
        </div>
        <div class="user">
           
             <a runat="server" href="~/Homepage"> <img id="userImg" src="fonts/images/user1.png" /></a>
             <h2>HOME</h2>
        </div>
        <div class="admin">
            
            <a runat="server" href="~/AdminPanel"><img id="adminImg" src="fonts/images/admin.png" /></a>
            <h2>Admin</h2>
        </div>
    </div>

</asp:Content>
