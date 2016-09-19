<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Results.aspx.cs" Inherits="Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="refresh" content="900;url=Default.aspx" />
    <title>Pedometer Challenge 2016</title>
    <!--[if lte IE 9]>
	<meta http-equiv="refresh" content="0;URL='Redirect.aspx'" />
	<![endif]-->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <link href="css/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header text-center">
                        <span class="pull-left"><img src="imgs/HW_Logo.jpg" width="223" height="100" alt="Health and Wellbeing: Caring compassionately for our staff" /></span>                     
                        <span class="pull-right"><img src="imgs/ATM_Logo.png" width="226" height="100" alt="Active Travel Month Logo: Logo depicts a person walking, running and cycling" /></span>
                        <h1>Pedometer Challenge 2016</h1>
                        <h3 class="text-left">Submit Results for Team: <asp:Label ID="TeamName" runat="server" ForeColor="Red"></asp:Label></h3>
                    </div>
                    <div class="modal-body">
                        <div class="form col-md-12 center-block">
                            <div class="form-group">
                                <asp:TextBox ID="week1_txt" runat="server" placeholder="Week 1 Total number of steps taken by the Team" class="form-control input-lg" Text=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfv_wk1" runat="server" ControlToValidate="week1_txt" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Week 1 steps cannot be blank." ForeColor="Red" ValidationGroup="wk1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:button ID="Week1_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Submit Week 1 results" OnClick="Week1_btn_Click" ValidationGroup="wk1"></asp:button>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="week2_txt" runat="server" class="form-control input-lg" placeholder="Week 2 Total number of steps taken by the Team"  Text=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfv_wk2" runat="server" ControlToValidate="week2_txt" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Week 2 steps cannot be blank." ForeColor="Red"  ValidationGroup="wk2"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:button ID="Week2_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Submit Week 2 results" OnClick="Week2_btn_Click"  ValidationGroup="wk2"></asp:button>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="week3_txt" runat="server" class="form-control input-lg" placeholder="Week 3 Total number of steps taken by the Team"  Text=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfv_wk3" runat="server" ControlToValidate="week3_txt" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Week 3 steps cannot be blank." ForeColor="Red"  ValidationGroup="wk3"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:button ID="Week3_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Submit Week 3 results" OnClick="Week3_btn_Click"  ValidationGroup="wk3"></asp:button>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="week4_txt" runat="server" class="form-control input-lg" placeholder="Week 4 Total number of steps taken by the Team"  Text=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfv_wk4" runat="server" ControlToValidate="week4_txt" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Week 4 steps cannot be blank." ForeColor="Red"  ValidationGroup="wk4"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:button ID="Week4_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Submit Week 4 results" OnClick="Week4_btn_Click"  ValidationGroup="wk4"></asp:button>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="avg_steps_lbl" runat="server" Text="Average number of steps taken will appear here"></asp:Label>
                            <span class="pull-right"><a href="Default.aspx">Logout</a></span>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="error_lbl" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:button ID="DownloadBut" class="btn btn-primary btn-lg btn-block" runat="server" OnClick="AllResults" Text="Download all Teams Data" Visible="false"></asp:button>
                        </div> 
                    </div> 
                </div>
            </div>            
        </div>
    </form>
</body>
</html>
