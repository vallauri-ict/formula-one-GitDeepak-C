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
        #btnMostraNazioni, #btnMostraDrivers, #btnMostraTeams{width: 200px;}
        #wrapperDati{margin: 10px auto;}
        #wrapperDati div{float:left}
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
            <asp:Button ID="btnMostraTeams" runat="server" OnClick="btnLoadTeams_Click" Text="Carica Teams"></asp:Button>
        </div>
        <div id="wrapperDati">
            <asp:GridView ID="GridViewCountries" runat="server" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-striped" >
                <%--<Columns>
                    <asp:BoundField HeaderText="IsoCode" />
                    <asp:BoundField HeaderText="Descrizione"/>
                </Columns>--%>
            </asp:GridView>
            <asp:GridView ID="GridViewDrivers" runat="server"></asp:GridView>
            <asp:GridView ID="GridViewTeams" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
