<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOne_WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FormulaOne - WebFrom</title>
</head>
<style>
    body {
        background: rgb(50, 50, 50);
        color: #fff
    }

    #form1 div {
        margin: 30px auto;
        width: fit-content;
        padding: 0 20px
    }

    h1 {
        text-align: center;
        margin: 10px auto;
        color: #fff
    }

    #wrapperDati {
        margin: 10px auto;
    }

    #wrapperDati div {
        float: left
    }

    .mydatagrid {
        border: solid 2px black;
        min-width: 80%;
    }

    .header {
        background-color: #000;
        font-family: Arial;
        color: White;
        height: 25px;
        text-align: center;
        font-size: 16px;
    }

    .rows {
        background-color: #fff;
        font-family: Arial;
        font-size: 14px;
        color: #000;
        min-height: 25px;
        text-align: left;
    }

    .rows:hover {
        background-color: #5badff;
        color: #fff;
    }

    .mydatagrid a /** FOR THE PAGING ICONS **/ {
        background-color: Transparent;
        padding: 5px 5px 5px 5px;
        color: #fff;
        text-decoration: none;
        font-weight: bold;
    }

    .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/ {
        background-color: #000;
        color: #fff;
    }

    .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
        background-color: #fff;
        color: #000;
        padding: 5px 5px 5px 5px;
    }

    .pager {
        background-color: #5badff;
        font-family: Arial;
        color: White;
        height: 30px;
        text-align: left;
    }

    .mydatagrid td {
        padding: 5px;
    }

    .mydatagrid th {
        padding: 5px;
    }
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
            <label>
                Seleziona il nome del database:
                <asp:DropDownList ID="cmbDb" runat="server" OnSelectedIndexChanged="cmbDb_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </label>
        </div>
        <div id="wrapperDati">
            <asp:GridView ID="GridViewDati" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" OnRowDataBound="GridView1_RowDataBound">
            </asp:GridView>
            <asp:ListBox ID="lbxNazioni" runat="server" Height="400px" Width="400px"></asp:ListBox>
        </div>
    </form>
</body>
</html>
