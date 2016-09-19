<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Pedometer Challenge 2016</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>      
    <link href="css/styles.css" rel="stylesheet" />  
    <!--[if lte IE 9]>
	<meta http-equiv="refresh" content="0;URL='Redirect.aspx'" />
	<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <span class="pull-left"><img src="imgs/HW_Logo.jpg" width="223" height="100" alt="Health and Wellbeing: Caring compassionately for our staff" /></span>                     
                        <span class="pull-right"><img src="imgs/ATM_Logo.png" width="226" height="100" alt="Active Travel Month Logo: Logo depicts a person walking, running and cycling" /></span>
                        <h1 class="text-center">Pedometer Challenge 2016</h1>
                        <h2 class="text-left">Reset Password</h2>
                    </div>
                    <div class="modal-body">
                        <div class="form col-md-12 center-block">
                            <div class="form-group">
                                <asp:TextBox ID="email_txt" runat="server" TextMode="Email" class="form-control input-lg" placeholder="Email" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="password_txt" runat="server" TextMode="Password" class="form-control input-lg" placeholder="New Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvPass" runat="server" ErrorMessage="Please enter a password" ForeColor="Red" ControlToValidate="password_txt" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="password_check_txt" runat="server" TextMode="Password" class="form-control input-lg" placeholder="Confirm New Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:RequiredFieldValidator ID="rfvPassChk" runat="server" ErrorMessage="Please confirm your password" ForeColor="Red" ControlToValidate="password_check_txt" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:CompareValidator ID="comparePasswords" runat="server" ErrorMessage=" || Passwords don't match || " ForeColor="Red" ControlToValidate="password_check_txt" ControlToCompare="password_txt" Display="Dynamic"></asp:CompareValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="reset_error_lbl" runat="server"></asp:Label>
                            </div>
                        </div>                        
                        <div class="form-group">
                            <asp:button ID="reset_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Update Password" OnClick="reset_btn_Click"></asp:button>
                        </div>                      
                    </div> 
                </div>
            </div>            
        </div>
    </form>
</body>
</html>
