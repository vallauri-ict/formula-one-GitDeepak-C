<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOne_WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FormulaOne - WebFrom</title>
</head>
     <style>        
        body{background: rgb(50, 50, 50); color: #fff}
        #form1 div{margin:30px auto; width: fit-content; padding: 0 20px}
        h1{text-align: center; margin: 10px auto; color: #fff}
        #btnMostraNazioni, #btnMostraDrivers{width: 200px;}
    </style>
<body>
    <h1>Formula 1 - WebForm</h1>
    <form id="form1" runat="server">
        <%--<div>
            userName <asp:TextBox ID="txtUserName" runat="server"/> <br />
            Password <input type="text" ID="txtPassword"/> <br />
            <asp:Button ID="btnInvia" runat="server" Text="Invia" /> <br />
        </div>
        --%>
        <div>
            <%--<asp:Label ID="lblMessaggio" runat="server" Text=" "/> <br />--%>
            <asp:Button ID="btnMostraNazioni" runat="server" OnClick="btnLoadCountries_Click" Text="Carica Nazioni"></asp:Button>
            <asp:Button ID="btnMostraDrivers" runat="server" OnClick="btnLoadDrivers_Click" Text="Carica Drivers"></asp:Button>
        </div>        
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
        <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    </form>
</body>
</html>
