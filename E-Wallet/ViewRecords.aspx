<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRecords.aspx.cs" Inherits="E_Wallet.ViewRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Id Number <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="View" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="vwRcrdsBtn" runat="server" Text="View ALL" OnClick="vwRcrdsBtn_Click" />
            <br /><br />
            <br />
           <div id="divView" runat="server">
            <asp:Image ID="vwPic" runat="server" Width="10%" /><br />
            Lastname <br />
            <asp:Label ID="lname" runat="server"></asp:Label><br />
            Firstname <br />
            <asp:Label ID="fname" runat="server" Text=""></asp:Label><br />
           </div>
           
            <br /><br />

            <asp:GridView ID="grdRcrds" runat="server" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="client_id" HeaderText="Employee Id" />
                    <asp:BoundField DataField="lastname" HeaderText="Family Name" />
                    <asp:BoundField DataField="firstname" HeaderText="First Name" />
                </Columns>


            </asp:GridView>

        </div>
    </form>
</body>
</html>
