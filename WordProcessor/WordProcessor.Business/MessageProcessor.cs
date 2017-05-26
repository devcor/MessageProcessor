using System;
using System.Linq;
using System.Threading.Tasks;
using WordProcessor.Interfaces;
using WordProcessor.Models;

namespace WordProcessor.Business
{
    public class MessageProcessor : IMessageProcessor
    {
        #region Attributes
        private readonly WProcessorDBContext DataBase;
        private readonly string[] WordSplitter;
        private readonly string[] ParagraphSplitter;
        private readonly char[] SentenceSplitter;
        #endregion

        #region Constructor
        public MessageProcessor()
        {
            DataBase = new WProcessorDBContext();
            WordSplitter = new[] { Environment.NewLine, "\t", "\n", " ", ",", "." };
            ParagraphSplitter = new[] { Environment.NewLine, "\t", "\n" };
            SentenceSplitter = new[] { '.' };
        }
        #endregion

        #region Public Methods
        public async Task Add(Message message)
        {
            CountWords(message);
            CountSentences(message);
            CountParagraphs(message);
            CountCharacters(message);

            DataBase.Message.Add(message);
            await DataBase.SaveChangesAsync();
        }

        public IQueryable<Message> GetMessages()
        {
            return DataBase.Message;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Protected Methods
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DataBase.Dispose();
            }
        }
        #endregion

        #region Private Methods
        private void CountParagraphs(Message message)
        {
            message.Paragraphs = message.Input.Split(ParagraphSplitter, StringSplitOptions.RemoveEmptyEntries)
                .Where(p => p.Trim() != "").Count();
        }

        /// <summary>
        /// Count sentences with more than 15 words
        /// </summary>
        /// <param name="message"></param>
        private void CountSentences(Message message)
        {
            var sentences = message.Input.Split(SentenceSplitter, StringSplitOptions.RemoveEmptyEntries)
                .Where(i => i.Trim() != "");

            foreach (var sentence in sentences)
            {
                if (CountWords(sentence) > 15)
                    message.Sentences += 1;
            }
        }

        /// <summary>
        /// Count the words end in 'n'
        /// </summary>
        /// <param name="message"></param>
        private void CountWords(Message message)
        {
            message.Words = message.Input.Split(WordSplitter, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.EndsWith("n")).Count();
        }

        private int CountWords(string message)
        {
            return message.Split(WordSplitter, StringSplitOptions.RemoveEmptyEntries).Count();
        }

        /// <summary>
        /// Count alphanumercs distinct to 'n' or 'N'
        /// </summary>
        /// <param name="message"></param>
        private void CountCharacters(Message message)
        {
            message.Characters = message.Input.LongCount(
                c => char.IsLetterOrDigit(c) && c != 'n' && c != 'N');
        }
        #endregion
    }
}
