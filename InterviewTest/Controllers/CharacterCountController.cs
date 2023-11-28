using InterviewTest.Abstract;
using InterviewTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterCountController : ControllerBase
    {
              
        ICountCharacterWord charword = new CountCharacterInWord();
        public CharacterCountController()
        {
            
        }

        [HttpGet(Name = "GetCharacterCount")]
        public async Task<NumberofCharacterResponse> Get([FromQuery] string inputWord)
        {
           NumberofCharacterResponse chresponse= await charword.GetChacterCounts(inputWord);
           return chresponse;
        }
    }
}