using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WordProcessor.Business;
using WordProcessor.Interfaces;
using WordProcessor.Models;

namespace WordProcessor.Controllers
{
    public class MessageController : ApiController
    {
        IMessageProcessor processor = new MessageProcessor();

        // GET: api/Message
        public IQueryable<Message> GetMessages()
        {
            return processor.GetMessages();
        }

        // POST: api/Message
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await processor.Add(message);

            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                processor.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}