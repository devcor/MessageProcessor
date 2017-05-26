using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace WordGenerator.Business
{
    public class Generator
    {
        private readonly Random RandomSize;
        private readonly Random RandomLetter;
        private readonly static string Letters = "abcdefghijklmnñopqrstuvwxyz";
        private readonly static string Numbers = "1234567890";
        private readonly static string SpecialChars = " ,.\n\t" + Environment.NewLine;
        private readonly static string Pattern = Letters + Letters.ToUpper() + Numbers + SpecialChars;
        private readonly static int PatternLen = Pattern.Length;

        public Generator()
        {
            RandomSize = new Random();
            RandomLetter = new Random();
        }

        ConcurrentBag<string> bag = new ConcurrentBag<string>();
        public List<string> GetMessages(int quantity)
        {
            var wordList = new List<string>();

            for (var i = 0; i < quantity; i++)
                wordList.Add(CreateMessage());

            return wordList;
        }

        private string CreateMessage()
        {     
            StringBuilder message = new StringBuilder();
            int length = RandomSize.Next(1024, 1050);

            while (0 < length--)            
                message.Append(Pattern[RandomLetter.Next(PatternLen)]);
            
            return message.ToString();
        }        
    }
}
