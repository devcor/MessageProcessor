using System;
using System.Linq;
using System.Threading.Tasks;
using WordProcessor.Models;

namespace WordProcessor.Interfaces
{
    public interface IMessageProcessor : IDisposable
    {
        IQueryable<Message> GetMessages();

        Task Add(Message message);
    }
}
