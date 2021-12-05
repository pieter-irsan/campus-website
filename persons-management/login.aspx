<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="persons_management.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="App_Theme/css/awesome.css" />
    <link rel="stylesheet" type="text/css" href="App_Theme/css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500" />
    <title>Campus Information System</title>
</head>
<body>
    <div class="container">
        <form id="formLogin" runat="server">
            <div class="row">
                <div class="col-md-offset-2 col-md-8 text-center">
                    <h1>Welcome to Campus Information System</h1>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-offset-2 col-md-4 col-sm-12">
                    <label>Username</label>
                    <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-4">
                    <label>Password</label>
                    <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-offset-4 col-md-4 col-sm-12">
                    <asp:Button CssClass="btn btn-primary btn-md btn-block" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
