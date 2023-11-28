using InterviewTest.Abstract;
using InterviewTest.Models;
using Moq;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CountCharacterTest
{
    public class UnitTest1
    {
        [Fact]
        public async void CountCharacter_Success_Test()
        {
            
            ICountCharacterWord countcharword=new CountCharacterInWord();
            var numberofCharacterResponse =await countcharword.GetChacterCounts("munu");
            Assert.Equal(numberofCharacterResponse.CharandCount.Count, 3);
            var GetCharCountExpected = GetChacterCounts();
            bool result = numberofCharacterResponse.CharandCount.All(o =>GetCharCountExpected.CharandCount.Any(w => w.Character == o.Character && w.Count == o.Count));
            Assert.True(result);


        }
        [Fact]
        public async void CountCharacter_Failue_Test()
        {

            ICountCharacterWord countcharword = new CountCharacterInWord();
            var numberofCharacterResponse = await countcharword.GetChacterCounts("munu");
            Assert.Equal(numberofCharacterResponse.CharandCount.Count, 3);
            var GetCharCountExpected = GetChacterCountsFailure();
            bool result = numberofCharacterResponse.CharandCount.All(o => GetCharCountExpected.CharandCount.Any(w => w.Character == o.Character && w.Count == o.Count));
            Assert.False(result);


        }

        public NumberofCharacterResponse GetChacterCounts()
        {
            NumberofCharacterResponse CharandCountData=new NumberofCharacterResponse();
            CharandCountData.CharandCount = new List<CharacterCount>()
            {
                new CharacterCount() {Character='m',Count=1},
                new CharacterCount(){Character='u',Count=2},
                new CharacterCount(){Character='n',Count=1}
                
            };

             return CharandCountData;
        }

        public NumberofCharacterResponse GetChacterCountsFailure()
        {
            NumberofCharacterResponse CharandCountData = new NumberofCharacterResponse();
            CharandCountData.CharandCount = new List<CharacterCount>()
            {
                new CharacterCount() {Character='m',Count=1},
                new CharacterCount(){Character='u',Count=3},
                new CharacterCount(){Character='n',Count=1}

            };

            return CharandCountData;
        }
    }
}