using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;
using InterviewTest.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartData : ControllerBase
    {

        
        IRevenue ir=new Revenue();

        // GET: api/<ChartData>
        [HttpGet]
        public List<RevenueEntity>  Getdata(int ajaxid,string UserID,string EmailAddress)
        {
            List<RevenueEntity> rev= ir.GetRevenueData();
            return rev;
            
        }

        [HttpGet]
        [Route("GetRevnueQuarter")] //   /api/example/get1/1?param2=4
        public List<RevenueEntity> GetDataQuarter(int year)
        {
            List<RevenueEntity> rev = ir.GetRevenueByQuarter(year);
            return rev;
        }
        
// GET api/<ChartData>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChartData>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChartData>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChartData>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
