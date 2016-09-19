<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
                    <div class="modal-header">
                        <span class="pull-left"><img src="imgs/HW_Logo.jpg" width="223" height="100" alt="Health and Wellbeing: Caring compassionately for our staff" /></span>                     
                        <span class="pull-right"><img src="imgs/ATM_Logo.png" width="226" height="100" alt="Active Travel Month Logo: Logo depicts a person walking, running and cycling" /></span>
                        <h1 class="text-center">Welcome to the 2016 &amp; <br /> Pedometer Challenge</h1>
                    </div>
                    <div class="modal-body">
                        <div class="form col-md-12 center-block">                    
                            <div class="form-group">
                                <p>Walking is <a href="http://www.nhs.uk/Livewell/loseweight/Pages/10000stepschallenge.aspx">one of the best ways of keeping fit</a> – just pop on some cushioned trainers and start taking steps towards a healthier you.</p><p>We wish you every success with the challenge.</p><p>Your <a href="mailto:Health%26Wellbeing@lthtr.nhs.uk?Subject=Pedometer Challenge 2016">Health and Wellbeing Team</a></p>
                            </div>   
                        </div>                          
                        <div class="form-group">
                            <h3 class="text-center">Please register or login.</h3>
                        </div>
                        <div class="form-group">
                            <asp:button ID="register_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Register" OnClick="register_btn_Click"></asp:button>
                        </div>                        
                        <div class="form-group">                                
                            <asp:button ID="signin_btn" class="btn btn-primary btn-lg btn-block" runat="server" Text="Sign in" OnClick="signin_btn_Click"></asp:button>
                        </div>           
                    </div> 
                </div>
            </div>            
        </div>
    </form>
</body>
</html>
