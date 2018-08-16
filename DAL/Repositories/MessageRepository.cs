using DAL.Entities;
using DAL.EF;
using DAL.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private SocialNetworkContext db;

        public MessageRepository(SocialNetworkContext context)
        {
            this.db = context;
        }

        public IEnumerable<Message> GetAll()
        {
            return db.Messages;
        }

        public Message Get(int id)
        {
            return db.Messages.SingleOrDefault(d => d.MessageId == id);
        }

        public void Create(Message item)
        {
            db.Messages.Add(item);
        }

        public void Update(Message item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Message message = db.Messages.Find(id);
            if (message != null)
                db.Messages.Remove(message);
        }
    }
}
