<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1" />--%>
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
        <div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header text-center">
                        <span class="pull-left"><img src="imgs/HW_Logo.jpg" width="223" height="100" alt="Health and Wellbeing: Caring compassionately for our staff" /></span>                     
                        <span class="pull-right"><img src="imgs/ATM_Logo.png" width="226" height="100" alt="Active Travel Month Logo: Logo depicts a person walking, running and cycling" /></span>
                        <h1>Pedometer Challenge 2016</h1>
                        <h2 class="text-left">Register</h2>
                    </div>
                    <div class="modal-body">
                        <div class="form col-md-12 center-block">
                            <div class="form-group">
                                <asp:TextBox ID="name_txt" runat="server" placeholder="Name" class="form-control input-lg"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please enter your name" ForeColor="Red" ControlToValidate="name_txt" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="email_txt" runat="server" placeholder="Email" TextMode="email" class="form-control input-lg" OnTextChanged="email_txt_Changed" AutoPostBack="true" AutoCompleteType="Email"></asp:TextBox>
                            </div>                            
                            <div class="form-group">
                                <asp:label ID="EmailError_lbl" runat="server"></asp:label>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvemail" runat="server" ErrorMessage="Please enter your email" ForeColor="Red" ControlToValidate="email_txt" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="password_txt" runat="server" TextMode="Password" class="form-control input-lg" placeholder="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvPass" runat="server" ErrorMessage="Please enter a password" ForeColor="Red" ControlToValidate="password_txt" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="password_check_txt" runat="server" TextMode="Password" class="form-control input-lg" placeholder="Confirm Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvPassChk" runat="server" ErrorMessage="Please confirm your password" ForeColor="Red" ControlToValidate="password_check_txt" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:CompareValidator ID="comparePasswords" runat="server" ErrorMessage=" || Passwords don't match || " ForeColor="Red" ControlToValidate="password_check_txt" ControlToCompare="password_txt" Display="Dynamic"></asp:CompareValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="team_name_txt" runat="server" placeholder="Team Name" class="form-control input-lg"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvTeamName" runat="server" ErrorMessage="Please choose a team name" ForeColor="Red" ControlToValidate="team_name_txt" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="teammembers_ddl" class="form-control input-lg">
                                    <asp:ListItem Value="0" Selected="True">How many people are in your team?</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvDDL" runat="server" ErrorMessage="You have not selected the number of people in your team" ForeColor="Red" ControlToValidate="teammembers_ddl" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="RegisterError_lbl" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:button ID="register_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Register" OnClick="register_btn_Click"></asp:button>
                        </div>
                        <div class="form-group">
                            <a href="Login.aspx" class="btn btn-primary btn-lg btn-block">Already registered, then sign in</a>
                        </div>  
                    </div> 
                </div>
            </div>            
        </div>
    </form>
</body>
</html>

