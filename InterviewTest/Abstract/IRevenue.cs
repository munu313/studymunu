using InterviewTest.Models;

namespace InterviewTest.Abstract
{
    public interface IRevenue
    {
        public List<RevenueEntity> GetRevenueData();

        public List<RevenueEntity>  GetRevenueByQuarter(int year);
    }
}
