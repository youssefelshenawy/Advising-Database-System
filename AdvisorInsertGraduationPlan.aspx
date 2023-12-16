<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorInsertGraduationPlan.aspx.cs" Inherits="databaseproject.InsertGraduationPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
            Insert graduation plan for a certain student<br />
            <br />
            Enter the semester code</div>
        <asp:TextBox ID="semestercodetext" runat="server"></asp:TextBox>
        <br />
        <br />
        Enter the expected graduation date<p>
            <asp:TextBox ID="expected_graduation_datetext" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            Enter the semester credit hours:</p>
        <p>
            <asp:TextBox ID="sem_credit_hourstext" runat="server"></asp:TextBox>
        </p>
        <p>
            student id</p>
        <p>
            <asp:TextBox ID="StudentIdtext" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Procedures_AdvisorCreateGP" Text="Add" />
            <asp:Button ID="Button2" runat="server" OnClick="Go_Back" Text="Go back" />
        </p>    
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        </div>
    </form>
</body>
</html>
