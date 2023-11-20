<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTransaction.aspx.cs" Inherits="E_Wallet.ViewTransaction" %>

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

         #Button1, #Button2, #Button3, #Button4, #Button5, #Button6, #Button7{
             padding: 10px;
             color:white;
             border-radius: 5px;
             border-style: none;
             background-color: dodgerblue;
             font-size: 12px;
             font-weight: bold;
             font-family: "Poppins", sans-serif
         }

         #Label1, #Label2, #Label3, #Label4{
              margin-top: 10px;
              color:dodgerblue;
              border-radius: 5px;
              border-style: none;
              font-size: 12px;
              font-weight: bold;
              font-family: "Poppins", sans-serif
         }

         #stateAccount, #DepoWithdraw, #Received, #Send{
            padding: 50px;
            border: solid 1px black;
            min-width: 100%;
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
        <div class="date">
            <asp:Label ID="Label1" runat="server" Text="From" ></asp:Label>
            <asp:TextBox ID="fromdate" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Value1RequiredValidator" ControlToValidate="fromdate" ErrorMessage="Please enter date." ForeColor="Red"  display="Dynamic" runat="server"/>
            <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
            <asp:TextBox ID="todate" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="todate" ErrorMessage="Please enter date." ForeColor="Red" display="Dynamic" runat="server"/><br /><br />
        </div>

        <div class="buttons">
            <asp:Button ID="Button1" runat="server" Text="Statement of Account" OnClick="Button1_Click" /><br />
            <asp:Label ID="Label3" runat="server" Text="View Deposits or Withdrawals"></asp:Label><br />
            <asp:Button ID="Button2" runat="server" Text="View All" OnClick="ViewAllDeWith"/>
            <asp:Button ID="Button3" runat="server" Text="View Deposits" OnClick="ViewDeposits"/>
            <asp:Button ID="Button4" runat="server" Text="View Withdrawals" OnClick="ViewWithdrawals" /><br />

            <asp:Label ID="Label4" runat="server" Text="View Sent or Received Money"></asp:Label><br />
            <asp:Button ID="Button5" runat="server" Text="View All" OnClick="Button3_Click"/>
            <asp:Button ID="Button6" runat="server" Text="View Sent Money" OnClick="Button6_Click"/>
            <asp:Button ID="Button7" runat="server" Text="View Received Money" OnClick="Button7_Click"/><br /><br />
        </div>

        <div id="table" class="table" runat="server">
            <asp:GridView ID="stateAccount" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="965px" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="trans_type" HeaderText="Type" />
                    <asp:BoundField DataField="client_id" HeaderText="Account Number" />
                    <asp:BoundField DataField="trans_date" HeaderText="Date" />
                    <asp:BoundField DataField="trans_recipient" HeaderText="Receiver" />
                    <asp:BoundField DataField="trans_sender" HeaderText="Sender" />
                    <asp:BoundField DataField="trans_amount" HeaderText="Amount" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>


         <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
        </div> 


        <div id="table1" class="table1" runat="server">
            <asp:GridView ID="DepoWithdraw" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="833px" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="trans_type" HeaderText="Type" />
                    <asp:BoundField DataField="trans_date" HeaderText="Date" />
                    <asp:BoundField DataField="client_id" HeaderText="Account Number" />
                    <asp:BoundField DataField="trans_amount" HeaderText="Amount" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>

        <div id="table2" class="table2" runat="server">
            <asp:GridView ID="ReceivedSent" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="961px" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="trans_type" HeaderText="Type" />
                    <asp:BoundField DataField="client_id" HeaderText="Account Number" />
                    <asp:BoundField DataField="trans_date" HeaderText="Date" />
                    <asp:BoundField DataField="trans_recipient" HeaderText="Receiver" />
                    <asp:BoundField DataField="trans_sender" HeaderText="Sender" />
                    <asp:BoundField DataField="trans_amount" HeaderText="Amount" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>

        
       
    </form>
</div>
</body>
</html>
