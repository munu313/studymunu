using InterviewTest.Models;

namespace InterviewTest.Abstract
{
    public interface ICountCharacterWord
    {
      public  Task<NumberofCharacterResponse>  GetChacterCounts(string inputword);
    }
}
