<%@ Page Language="C#" AutoEventWireup="true" CodeFile="play.aspx.cs" Inherits="play" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="WeeklyTeamAverage" runat="server" Width="600" Height="400">
            <Series>
                <asp:Series Name="Series1" XValueMember="TeamName" YValueMembers="w1"></asp:Series>                
                <asp:Series Name="Series2" XValueMember="TeamName" YValueMembers="w2"></asp:Series>
                <asp:Series Name="Series3" XValueMember="TeamName" YValueMembers="w3"></asp:Series>
                <asp:Series Name="Series4" XValueMember="TeamName" YValueMembers="w4"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="WhiteSmoke">
                    <AxisY Title="Average Steps Taken"></AxisY>
                    <AxisX Title="Week"></AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
