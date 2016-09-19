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

public partial class Results : System.Web.UI.Page
{
    SqlConnection pcconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PedChalConn"].ConnectionString);
    SqlCommand avgcmd;
    SqlCommand admin;
    SqlCommand cmd;
    SqlCommand w1;
    SqlCommand w2;
    SqlCommand w3;
    SqlCommand w4;
    protected void Page_Load(object sender, EventArgs e)
    {
        avg_steps_lbl.Text = "";
        avgcmd = new SqlCommand("SP_TEAM_AVERAGE", pcconn);
        avgcmd.CommandType = CommandType.StoredProcedure;
        avgcmd.Parameters.AddWithValue("@Email", Session["id"].ToString());
        pcconn.Open();
        SqlDataReader teamaverage = avgcmd.ExecuteReader();
        while (teamaverage.Read())
        {
            if (teamaverage[0].ToString() == "0")
            {
                avg_steps_lbl.Text = "Average number of steps taken will appear here";
            }
            else
            {
                int team_avg = Convert.ToInt32(teamaverage[0]);
                avg_steps_lbl.Text = "The average number of steps taken by your team is " + team_avg.ToString("#,###");
            }
        }
        pcconn.Close();

        admin = new SqlCommand("SP_CHK_ADMIN", pcconn);
        admin.CommandType = CommandType.StoredProcedure;
        admin.Parameters.AddWithValue("@Email", Session["id"].ToString());
        pcconn.Open();
        SqlDataReader admin_dr = admin.ExecuteReader();
        while (admin_dr.Read())
        {
            if (admin_dr[0].ToString() == "True")
            {
                DownloadBut.Visible = true;
            }
        }
        pcconn.Close();

        if (!IsPostBack)
        {
            if (Session["id"] != null)
            {
                cmd = new SqlCommand("SP_TEAMNAME", pcconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Session["id"].ToString());
                pcconn.Open();
                SqlDataReader teamname = cmd.ExecuteReader();
                while (teamname.Read())
                {
                    TeamName.Text += (teamname[0].ToString());
                }
                pcconn.Close();

                w1 = new SqlCommand("SP_W1_RESULTS", pcconn);
                w1.CommandType = CommandType.StoredProcedure;
                w1.Parameters.AddWithValue("@Email", Session["id"].ToString());
                pcconn.Open();
                SqlDataReader w1results = w1.ExecuteReader();
                while (w1results.Read())
                {
                    if (w1results[0].ToString() == "0")
                    {
                        week1_txt.Text = "";
                        week1_txt.Focus();
                        week2_txt.Visible = false;
                        Week2_btn.Visible = false;
                        week3_txt.Visible = false;
                        Week3_btn.Visible = false;
                        week4_txt.Visible = false;
                        Week4_btn.Visible = false;
                    }
                    else
                    {
                        int wk1 = Convert.ToInt32(w1results[0]);
                        int wk1_avg = Convert.ToInt32(w1results[1]);
                        week1_txt.Text = "Week 1 total team steps: " + wk1.ToString("#,###") + " - Team average: " + (wk1_avg.ToString("#,###"));
                        Week1_btn.Visible = false;
                        week1_txt.ReadOnly = true;
                    }
                }
                pcconn.Close();

                w2 = new SqlCommand("SP_W2_RESULTS", pcconn);
                w2.CommandType = CommandType.StoredProcedure;
                w2.Parameters.AddWithValue("@Email", Session["id"].ToString());
                pcconn.Open();
                SqlDataReader w2results = w2.ExecuteReader();
                while (w2results.Read())
                {
                    if (w2results[0].ToString() == "0")
                    {
                        week2_txt.Text = "";
                        week2_txt.Focus();
                        week3_txt.Visible = false;
                        Week3_btn.Visible = false;
                        week4_txt.Visible = false;
                        Week4_btn.Visible = false;
                    }
                    else
                    {
                        int wk2 = Convert.ToInt32(w2results[0]);
                        int wk2_avg = Convert.ToInt32(w2results[1]);
                        week2_txt.Text = "Week 2 total team steps: " + wk2.ToString("#,###") + " - Team average: " + (wk2_avg.ToString("#,###"));
                        Week2_btn.Visible = false;
                        week2_txt.ReadOnly = true;
                    }
                }
                pcconn.Close();

                w3 = new SqlCommand("SP_W3_RESULTS", pcconn);
                w3.CommandType = CommandType.StoredProcedure;
                w3.Parameters.AddWithValue("@Email", Session["id"].ToString());
                pcconn.Open();
                SqlDataReader w3results = w3.ExecuteReader();
                while (w3results.Read())
                {
                    if (w3results[0].ToString() == "0")
                    {
                        week3_txt.Text = "";
                        week3_txt.Focus();
                        week4_txt.Visible = false;
                        Week4_btn.Visible = false;
                    }
                    else
                    {
                        int wk3 = Convert.ToInt32(w3results[0]);
                        int wk3_avg = Convert.ToInt32(w3results[1]);
                        week3_txt.Text = "Week 3 total team steps: " + wk3.ToString("#,###") + " - Team average: " + (wk3_avg.ToString("#,###"));
                        Week3_btn.Visible = false;
                        week3_txt.ReadOnly = true;
                    }
                }
                pcconn.Close();

                w4 = new SqlCommand("SP_W4_RESULTS", pcconn);
                w4.CommandType = CommandType.StoredProcedure;
                w4.Parameters.AddWithValue("@Email", Session["id"].ToString());
                pcconn.Open();
                SqlDataReader w4results = w4.ExecuteReader();
                while (w4results.Read())
                {
                    if (w4results[0].ToString() == "0")
                    {
                        week4_txt.Text = "";
                        week4_txt.Focus();
                    }
                    else
                    {
                        int wk4 = Convert.ToInt32(w4results[0]);
                        int wk4_avg = Convert.ToInt32(w4results[1]);
                        week4_txt.Text = "Week 4 total team steps: " + wk4.ToString("#,###") + " - Team average: " + (wk4_avg.ToString("#,###"));
                        Week4_btn.Visible = false;
                        week4_txt.ReadOnly = true;
                    }
                }
                pcconn.Close();
            }
        }
    }
    protected void Week1_btn_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SP_ADD_W1", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Email", Session["id"].ToString());
        cmd.Parameters.AddWithValue("@Week1", week1_txt.Text);
        pcconn.Open();
        try
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("Results.aspx");

        }
        catch (SqlException ex)
        {
            string error = ex.ToString();
            if (error.Contains("nvarchar"))
            {
                error_lbl.Text = "Please only user numeric characters";
                error_lbl.ForeColor = System.Drawing.Color.Red;
            }
        }
        pcconn.Close();
    }
    protected void Week2_btn_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SP_ADD_W2", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Email", Session["id"].ToString());
        cmd.Parameters.AddWithValue("@Week2", week2_txt.Text);
        pcconn.Open();
        try
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("Results.aspx");

        }
        catch (SqlException)
        {
            error_lbl.Text = "Please only user numeric characters";
            error_lbl.ForeColor = System.Drawing.Color.Red;
        }
        pcconn.Close();
    }
    protected void Week3_btn_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SP_ADD_W3", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Email", Session["id"].ToString());
        cmd.Parameters.AddWithValue("@Week3", week3_txt.Text);
        pcconn.Open();
        try
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("Results.aspx");

        }
        catch (SqlException)
        {
            error_lbl.Text = "Please only user numeric characters";
            error_lbl.ForeColor = System.Drawing.Color.Red;
        }
        pcconn.Close();
    }
    protected void Week4_btn_Click(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SP_ADD_W4", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Email", Session["id"].ToString());
        cmd.Parameters.AddWithValue("@Week4", week4_txt.Text);
        pcconn.Open();
        try
        {
            cmd.ExecuteNonQuery();
            Response.Redirect("Results.aspx");

        }
        catch (SqlException)
        {
            error_lbl.Text = "Please only user numeric characters";
            error_lbl.ForeColor = System.Drawing.Color.Red;
        }
        pcconn.Close();
    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        try
        {
            pcconn.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            pcconn.Close();
            sda.Dispose();
            pcconn.Dispose();
        }
    }

    protected void AllResults(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SP_ALL_RESULTS", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        DataTable dt = GetData(cmd);

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
            "attachment;filename=PedometerChalleng2016.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";

        StringBuilder sb = new StringBuilder();
        for (int k = 0; k < dt.Columns.Count; k++)
        {
            //add separator
            sb.Append(dt.Columns[k].ColumnName + ',');
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                //add separator
                sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + ',');
            }
            //append new line
            sb.Append("\r\n");
        }

        Response.Output.Write(sb.ToString());
        Response.Flush();
        Response.End();
    }
}