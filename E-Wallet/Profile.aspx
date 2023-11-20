<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="E_Wallet.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
    <style>
        .container{
            display: flex;
        }

        #form1, #form2{
            margin: 45px;
            text-align: left;
        }
        #vwPic{
            width: 250px;
            height: 250px;
        }

        .div1, .div2, .div3, .div4, .div5, .div6, .div7, .div8{
            text-align: left;
            text-decoration: none;
            color: darkblue;
            font-size: 20px;
            font-family: "Poppins", sans-serif;
            margin-bottom: 20px;
        }

        #accnum, #lname, #fname,  #genderList, #birthday, #address, #pnumber, #email{
            padding: 5px;
        }

        #Label1 {
            padding-right: 30px;
            font-weight: bold;
        }

        #Label2 {
            padding-right: 83px;
            font-weight: bold;
        }

         #Label3 {
            padding-right: 83px;
            font-weight: bold;
        }

          #Label4 {
            padding-right: 107px;
            font-weight: bold;
        }

          #Label5 {
            padding-right: 60px;
            font-weight: bold;
        }

        #Label6 {
            padding-right: 98px;
            font-weight: bold;
        }

         #Label7 {
            padding-right: 37px;
            font-weight: bold;
        }

          #Label8 {
            padding-right: 40px;
            font-weight: bold;
        }

          #divView{
              display: flex;
          }

          .imgdiv{
              margin-right: 50px;
              text-align: left;
          }

          #Deactivate, #Logout, #Editprofile, #savechanges, #refresh{
            margin-top: 10px;
            margin-bottom: 10px;
            margin-right: 10px;
            padding: 10px;
            color:white;
            border-radius: 5px;
            border-style: none;
            background-color: dodgerblue;
            font-size: 15px;
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

    <form id="form2" runat="server" onprerender="Page_Load"> 
        
            <div id="divView" runat="server">
                <div class="imgdiv">
                <asp:Image ID="vwPic" runat="server" /><br />
                <asp:Button ID="imgUpload" runat="server" Text="Upload" Visible="false" OnClick="imgUpload_Click"/>
                <asp:Button ID="imgBtn" runat="server" Text="Edit Image" OnClick="imgBtn_Click"/>
                <asp:FileUpload ID="picUpload" runat="server" Width="246px" Visible="false"/><br />
                <asp:Button ID="Deactivate" runat="server" Text="Deactivate" OnClick="Deactivate_Click" /><br />
                <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click"/>
                </div>  
               
                <div class="profdiv">
                     <asp:Button ID="Editprofile" runat="server" Text="Edit Profile" OnClick="EditProfile_Click" />
                     <asp:Button ID="savechanges" runat="server" Text="Save Changes" OnClick="Savechanges_Click" visible="false"/><br />
                     

                    <div id="viewprofile" runat="server">
                        <div class="div1">
                            <asp:Label ID="Label9" runat="server" Text="Account Number: "></asp:Label>
                            <asp:Label ID="accnumlbl" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="div2">
                            <asp:Label ID="Label11" runat="server" Text="Firstname: "></asp:Label>
                            <asp:Label ID="fnamelbl" runat="server" Text=""></asp:Label><br />
                        </div>
                        <div class="div8">
                            <asp:Label ID="Label12" runat="server" Text="Lastname: "></asp:Label>
                            <asp:Label ID="lnamelbl" runat="server" Text=""></asp:Label><br />
                        </div>
                        <div class="div3">
                            <asp:Label ID="Label13" runat="server" Text="Gender: "></asp:Label>
                            <asp:Label ID="genderlbl" runat="server" Text=""></asp:Label>
                            
                        </div>
                        <div class="div4">
                            <asp:Label ID="Label14" runat="server" Text="Date of Birth: "></asp:Label>
                            <asp:Label ID="doblbl" runat="server" Text=""></asp:Label><br />
                        </div>
                        <div class="div5">
                            <asp:Label ID="Label15" runat="server" Text="Address: "></asp:Label>
                            <asp:Label ID="addlbl" runat="server" Text=""></asp:Label><br />
                        </div>
                        <div class="div6">
                            <asp:Label ID="Label16" runat="server" Text="Phone Number: "></asp:Label>
                            <asp:Label ID="pnumlbl" runat="server" Text=""></asp:Label><br />
                        </div>
                        <div class="div7">
                            <asp:Label ID="Label17" runat="server" Text="Email Address: "></asp:Label>
                           <asp:Label ID="emaillbl" runat="server" Text=""></asp:Label><br /><br />
                        </div>
                    </div>

                    
                <div id="viewpass" runat="server">
                    <asp:Button ID="Editpass" runat="server" Text="Edit Password" OnClick="Editpass_Click"/>
                   <asp:TextBox ID="newpass" runat="server"  TextMode="Password" Enabled="false"></asp:TextBox>
                    <asp:Button ID="UpdatePass" runat="server" Text="Save Password" OnClick="UpdatePass_Click" Visible="false"/><br />
               </div>

                <div id="editprof" runat="server" visible="false">
                    <div class="div1">
                        <asp:Label ID="Label1" runat="server" Text="Account Number "></asp:Label>
                        <asp:Label ID="accnum" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="div2">
                        <asp:Label ID="Label2" runat="server" Text="Firstname "></asp:Label>
                        <asp:TextBox ID="fname" runat="server" ></asp:TextBox><br />
                    </div>
                    <div class="div8">
                        <asp:Label ID="Label3" runat="server" Text="Lastname "></asp:Label>
                        <asp:TextBox ID="lname" runat="server" ></asp:TextBox><br />
                    </div>
                    <div class="div3">
                        <asp:Label ID="Label4" runat="server" Text="Gender "></asp:Label>
                        <asp:DropDownList ID="genderList" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Non-binary</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="div4">
                        <asp:Label ID="Label5" runat="server" Text="Date of Birth "></asp:Label>
                        <asp:TextBox ID="birthday" runat="server"></asp:TextBox><br />
                    </div>
                    <div class="div5">
                        <asp:Label ID="Label6" runat="server" Text="Address "></asp:Label>
                        <asp:TextBox ID="address" runat="server" ></asp:TextBox><br />
                    </div>
                    <div class="div6">
                        <asp:Label ID="Label7" runat="server" Text="Phone Number "></asp:Label>
                        <asp:TextBox ID="pnumber" runat="server" ></asp:TextBox><br />
                    </div>
                   <div class="div7">
                        <asp:Label ID="Label8" runat="server" Text="Email Address "></asp:Label>
                        <asp:TextBox ID="email" runat="server" ></asp:TextBox><br /><br />
                   </div>
                </div>
                
            </div>
        </div>
    </form>
</div>
</body>
</html>
