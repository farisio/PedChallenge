using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public partial class Login : System.Web.UI.Page
{
    SqlConnection pcconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PedChalConn"].ConnectionString);
    SqlCommand cmd;

    private static string CalculateHashedPassword(string password)
    {
        using (var sha = SHA256.Create())
        {
            var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(password));
            return Convert.ToBase64String(computedHash);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["id"] = "";
    }
    protected void email_txt_Changed(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SP_CHK_EMAIL", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Email", email_txt.Text);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        pcconn.Open();
        int i = cmd.ExecuteNonQuery();
        pcconn.Close();
        if (dt.Rows.Count > 0)
        {
            emailerror_lbl.Text = "";
            password_txt.Focus();
        }
        else
        {
            emailerror_lbl.Text = "Your email isn't in the database, please check you've entered it correctly or register.";
            emailerror_lbl.ForeColor = System.Drawing.Color.Red;
            email_txt.Focus();
        }
    }

    protected void signin_btn_Click(object sender, EventArgs e)
    {
        if (password_txt.Text != "changeme")
        {
            string HashedPass = CalculateHashedPassword(password_txt.Text);
            cmd =  new SqlCommand("SP_LOGIN", pcconn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email_txt.Text);
            cmd.Parameters.AddWithValue("@Password", HashedPass);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            pcconn.Open();
            int i = cmd.ExecuteNonQuery();
            pcconn.Close();
            if (dt.Rows.Count > 0)
            {
                Session["id"] = email_txt.Text;
                Response.Redirect("Results.aspx");
                Session.RemoveAll();
            }
            else
            {
                LoginError_lbl.Text = "The password you entered is incorrect.";
                LoginError_lbl.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            Session["id"] = email_txt.Text;
            Response.Redirect("ResetPassword.aspx");
        }
    }

    protected void register_btn_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
        Response.Redirect("register.aspx");
    }
}