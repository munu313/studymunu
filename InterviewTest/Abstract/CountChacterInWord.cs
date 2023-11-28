using InterviewTest.Models;
using InterviewTest.Abstract;

namespace InterviewTest.Abstract
{
    public class CountCharacterInWord: ICountCharacterWord
    {
       
      async  Task<NumberofCharacterResponse> ICountCharacterWord.GetChacterCounts(string inputword)
        {
            try
            {
                string inputWord = inputword.Replace(" ", string.Empty);
                NumberofCharacterResponse response = new NumberofCharacterResponse()
                {
                    CharandCount = new List<CharacterCount>()
                };

                while (inputWord.Length > 0)
                {

                    int count = 0;
                    for (int j = 0; j < inputWord.Length; j++)
                    {
                        if (inputWord[0] == inputWord[j])
                        {
                            count++;
                        }
                    }


                    response.CharandCount.Add(new CharacterCount()
                    {
                        Character = inputWord[0],
                        Count = count
                    });
                    inputWord = inputWord.Replace(inputWord[0].ToString(), string.Empty);

                }

                return response;
            }
            catch (Exception ex)
            {
                string msg=ex.Message.ToString();
                return null;
            }
            
            
        }

       
    }
}
