using InterviewTest.Models;
using System.Data;
using Microsoft.Data.SqlClient;


namespace InterviewTest.Abstract
{
    public class Revenue : IRevenue
    {
     
        public List<RevenueEntity> GetRevenueData()
        {
            List<RevenueEntity> YearRevenues = new List<RevenueEntity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-D2E0OGS\\SQLEXPRESS;Trusted_Connection=true;DataBase=test;TrustServerCertificate=True;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select year,SUM(amount)amount from tblRevenue group by year";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "dsRevenue");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["dsRevenue"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["dsRevenue"].Rows)
                        {
                            YearRevenues.Add(new RevenueEntity
                            {
                                year = dr["year"].ToString(),
                                amount = Convert.ToInt32(dr["amount"]),
                                drilldown = true
                            });
                        }
                    }
                }
            }
            return YearRevenues;
        }


        public List<RevenueEntity> GetRevenueByQuarter(int year)
        {
            List<RevenueEntity> QuarterRevenues = new List<RevenueEntity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-D2E0OGS\\SQLEXPRESS;Trusted_Connection=true;DataBase=test;TrustServerCertificate=True;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select quarter,SUM(amount)amount from tblRevenue where year='" + year + "' group by quarter";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "dsQuarter");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["dsQuarter"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["dsQuarter"].Rows)
                        {
                            QuarterRevenues.Add(new RevenueEntity
                            {
                                year = dr["quarter"].ToString(),
                                amount = Convert.ToInt32(dr["amount"])

                            });
                        }
                    }
                }
            }
            return QuarterRevenues;
        }
    }
}
