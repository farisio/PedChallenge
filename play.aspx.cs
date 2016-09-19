using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

public partial class play : System.Web.UI.Page
{
    SqlConnection pcconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PedChalConn"].ConnectionString);
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SP_WEEKLY_AVERAGE_TEST", pcconn);
        cmd.CommandType = CommandType.StoredProcedure;
        pcconn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        pcconn.Close();

        WeeklyTeamAverage.DataSource = ds;
        //WeeklyTeamAverage.Series["Series1"].XValueMember = "w1";
        //WeeklyTeamAverage.Series["Series2"].XValueMember = "w2";
        //WeeklyTeamAverage.Series["Series3"].XValueMember = "w3";
        //WeeklyTeamAverage.Series["Series4"].XValueMember = "w4";
        WeeklyTeamAverage.Series["Series1"].YValueMembers = "w1";
        WeeklyTeamAverage.Series["Series2"].YValueMembers = "w2";
        WeeklyTeamAverage.Series["Series3"].YValueMembers = "w3";
        WeeklyTeamAverage.Series["Series4"].YValueMembers = "w4";
        WeeklyTeamAverage.DataBind();

        WeeklyTeamAverage.Series["Series1"].ChartType = SeriesChartType.Spline;
        WeeklyTeamAverage.Series["Series1"]["DrawingStyle"] = "Emboss";
        WeeklyTeamAverage.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

        WeeklyTeamAverage.Series["Series2"].ChartType = SeriesChartType.Spline;
        WeeklyTeamAverage.Series["Series2"]["DrawingStyle"] = "Emboss";
        WeeklyTeamAverage.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

        WeeklyTeamAverage.Series["Series3"].ChartType = SeriesChartType.Spline;
        WeeklyTeamAverage.Series["Series3"]["DrawingStyle"] = "Emboss";
        WeeklyTeamAverage.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

        WeeklyTeamAverage.Series["Series4"].ChartType = SeriesChartType.Spline;
        WeeklyTeamAverage.Series["Series4"]["DrawingStyle"] = "Emboss";
        WeeklyTeamAverage.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
    }
}