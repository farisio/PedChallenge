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

public partial class ResetPassword : System.Web.UI.Page
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
        email_txt.Text = Session["id"].ToString();
    }
    protected void reset_btn_Click(object sender, EventArgs e)
    {
        string HashedPass = CalculateHashedPassword(password_txt.Text);

        cmd = new SqlCommand("SP_RESETPASSWORD", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Email", Session["id"].ToString());
        cmd.Parameters.AddWithValue("@Password", HashedPass);
        pcconn.Open();
        try
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("Results.aspx");
        }
        catch (SqlException ex)
        {
            reset_error_lbl.Text = ex.ToString();
        }
        pcconn.Close();
    }
}