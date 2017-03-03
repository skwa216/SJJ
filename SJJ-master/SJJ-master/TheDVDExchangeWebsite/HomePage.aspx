<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  
   
<head runat="server">
    <title></title>
  
</head>
    <body>
    <form id="form1" runat="server">


           
       
    <div>    
            <img alt="banner" class="auto-style1" style="width:100%" src="DVD%20rental%20banner.jpg" /><br /><br />
    </div>
        
             
    <div>
           <asp:Button ID="SignUpPageButton" runat="server" Text="Sign Up!" OnClick="LoadSignUpPage"/>
           <asp:Button ID="LoginPageButton" runat="server" Text="Login" OnClick="LoadLoginPage"/>
           <asp:Button ID="BrowsePageButton" runat="server" Text="Browse" OnClick="LoadBrowsePage"/>
    </div>
           
    </form>

     <p>
       Welcome to the DVD Exchange where you can make connections, trade movies, watch movies, and blog about your thoughts!
    </p>
    <p>
</body>
</html>
