using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

public partial class Register : System.Web.UI.Page
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
        name_txt.Focus();
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
        if (dt.Rows.Count == 0)
        {
            EmailError_lbl.Text = "";
            password_txt.Focus();
        }
        else
        {
            EmailError_lbl.Text = "The email you entered is already registered for the Pedometer Challenge. Please use a different email or sign in.";
            EmailError_lbl.ForeColor = System.Drawing.Color.Red;
            email_txt.Focus();
        }
    }

    protected void register_btn_Click(object sender, EventArgs e)
    {
        string HashedPass = CalculateHashedPassword(password_txt.Text);

        cmd = new SqlCommand("SP_REGISTRATION", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Name", name_txt.Text);
        cmd.Parameters.AddWithValue("@TeamName", team_name_txt.Text);
        cmd.Parameters.AddWithValue("@NumMembers", teammembers_ddl.SelectedValue);
        cmd.Parameters.AddWithValue("@Admin", 0);
        cmd.Parameters.AddWithValue("@Email", email_txt.Text);
        cmd.Parameters.AddWithValue("@Password", HashedPass);
        pcconn.Open();
        try
        {
            cmd.ExecuteNonQuery();
            Session["id"] = email_txt.Text;
            Session["teamname"] = team_name_txt.Text;
            Response.Redirect("Results.aspx");
            Session.RemoveAll();
        }
        catch (SqlException ex)
        {
            string error = ex.ToString();
            if (error.Contains("UN_Email"))
            {
                RegisterError_lbl.Text = "That email has already been registered please click on Login to sign in.";
                RegisterError_lbl.ForeColor = System.Drawing.Color.Red;
            }
            if (error.Contains("UN_TeamName"))
            {
                RegisterError_lbl.Text = "That team name is already taken, please choose a different one.";
                RegisterError_lbl.ForeColor = System.Drawing.Color.Red;
            }
        }
        pcconn.Close();
    }
    protected void signin_btn_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
        Response.Redirect("login.aspx");
    }
}