<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html5>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Abarrotes Junior's Inventory</title>
    <link rel="stylesheet" href="LOG ING.css">
    <style>
        body {

    background: url(Fondo.jpg);
    margin: 0;
    padding: 0;
    font-family: "Tahoma", sans-serif;
}
.abarrotes {
    font-size: 40px;
    margin-top: 125px;
    margin-bottom: 60px;
    font-family: "Lucida Calligraphy", sans-serif;
}

.login {
    width: 360px;
    height: 600px;
    background: none;
    position: absolute;
    top: 45%;
    left: 50%;
    transform: translate(-50%, -50%);
    color: white;
    text-align: center;
}
.login h1{
    font-size: 40px;
    margin-top: 125px;
    margin-bottom: 60px;
}
.box{
    width: 260px;
    height: 40px;
    background: #f1f1f1b3;
    border-radius: 10px;
    margin: 10px auto;
}
.box input {
    background: none;
    border: none;
    outline: none;
    text-align: center;
    width: 90%;
    line-height: 37px;
    font-family: "Tahoma", sans-serif;
    font-size: 14px;
    color:  #333;
}
.enter {
    width: 260px;
    height: 40px;
    background: #01c5c4;
    border-radius: 10px;
    margin: 14px auto;
    display: block;
    font-family: "Tahoma", sans-serif;
    font-size: 16px;
    border: none;
    color: white;
}
    </style>
</head>
<body>

    <div class="login">

        <div class="abarrotes">
            <h1>Abarrotes Junior</h1>
        </div>
        <h3>LOG IN</h3>

        <form id="form1" runat="server">

            <div class="box">
                &nbsp;<asp:TextBox ID="txtEMAIL" runat="server"></asp:TextBox>
            </div>

            <div class="box">
                &nbsp;<asp:TextBox ID="txtPASSWORD" runat="server"></asp:TextBox>
            </div>

            <asp:Button class="enter" ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" />


        &nbsp;</form>

    </div>

</body>
</html>
