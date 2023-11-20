<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="E_Wallet.ViewUsers" %>

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

        #userform{
            margin: 45px;
        }

        #viewUsers, #viewAdmins, #Button1, #suspendBtn, #unsuspendBtn, #Button2{
            padding: 5px;
            color:white;
            border-radius: 5px;
            border-style: none;
            background-color: dodgerblue;
            font-size: 15px;
            font-weight: bold;
            font-family: "Poppins", sans-serif
        }

        #TextBox1, #TextBox2{
            padding: 3px;
            border-radius: 5px;
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

    <form id="userform" runat="server">
           
            <asp:Button ID="viewUsers" runat="server" Text="View Users" OnClick="viewUsers_Click" />
            <asp:Button ID="viewAdmins" runat="server" Text="View Admin" OnClick="viewAdmins_Click" /><br /><br />

        <div id="userView" runat="server" visible="false">
            <asp:Label ID="Label22" runat="server" Text="Search account number"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="View" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;
            <br /><br />
            <br />

           <div id="divView" runat="server" visible="false">
                <asp:Image ID="vwPic" runat="server" width="300px" Height="300px" /><br />
                <div class="div1">
                    <asp:Label ID="Label1" runat="server" Text="Account Number:"></asp:Label>
                    <asp:Label ID="accnum" runat="server" Text=""></asp:Label><br />
                </div>
                <div class="div2">
                    <asp:Label ID="Label3" runat="server" Text="Fullname: "></asp:Label>
                    <asp:Label ID="name" runat="server" Text=""></asp:Label><br />
                </div>
                <div class="div3">
                    <asp:Label ID="Label5" runat="server" Text="Gender: "></asp:Label>
                    <asp:Label ID="gender" runat="server" Text=""></asp:Label><br />
                </div>
               <div class="div4">
                    <asp:Label ID="Label7" runat="server" Text="Date of Birth: "></asp:Label>
                    <asp:Label ID="bday" runat="server" Text=""></asp:Label><br />
                </div>
               <div class="div5">
                    <asp:Label ID="Label9" runat="server" Text="Address: "></asp:Label>
                    <asp:Label ID="address" runat="server" Text=""></asp:Label><br />
                </div>
               <div class="div6">
                    <asp:Label ID="Label11" runat="server" Text="Phone Number: "></asp:Label>
                    <asp:Label ID="pnumber" runat="server" Text=""></asp:Label><br />
                </div>
               <div class="div7">
                    <asp:Label ID="Label13" runat="server" Text="Email Address: "></asp:Label>
                    <asp:Label ID="email" runat="server" Text=""></asp:Label><br /><br />
                </div>

               <asp:Button ID="suspendBtn" runat="server" Text="Suspend" OnClick="Suspend_Click" />
               <asp:Button ID="unsuspendBtn" runat="server" Text="Unsuspend" OnClick="Unsuspend_Click" />
            </div> 

            
            <asp:GridView ID="grdRcrds" runat="server" AutoGenerateColumns="False" Width="1279px" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="client_id" HeaderText="Account Number" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lastname" HeaderText="Family Name" />
                    <asp:BoundField DataField="firstname" HeaderText="First Name" />
                    <asp:BoundField DataField="gender" HeaderText="Gender" />
                    <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="phone_num" HeaderText="Phone Number" />
                    <asp:BoundField DataField="email_add" HeaderText="Email Address" />
                    <asp:BoundField DataField="datestarted" HeaderText="Date Started" />
                     <asp:BoundField DataField="status" HeaderText="Status" />
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
           
            <br /><br />

        <div id="viewAdmin" runat="server" visible="false">
            <div class="gridView" runat="server">
            <asp:GridView ID="viewAdminRcrds" runat="server" AutoGenerateColumns="False" DataKeyNames="admin_id" Width="849px" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="admin_id" HeaderText="Admin Id">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lastname" HeaderText="Family Name" >
                    <ItemStyle HorizontalAlign="Justify" />
                    </asp:BoundField>
                    <asp:BoundField DataField="firstname" HeaderText="First Name" />
                    <asp:BoundField DataField="email" HeaderText="Email Address" />
                    <asp:BoundField DataField="date_created" HeaderText="Date Started" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="DeleteBtn_Click" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
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
            <br /><br />
        </div>

     </form>
</div>
</body>
</html>
