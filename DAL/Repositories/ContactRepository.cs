using DAL.Entities;
using DAL.EF;
using DAL.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private SocialNetworkContext db;

        public ContactRepository(SocialNetworkContext context)
        {
            this.db = context;
        }

        public IEnumerable<Contact> GetAll()
        {
            return db.Contacts;
        }

        public Contact Get(int id)
        {
            return db.Contacts.SingleOrDefault(d => d.UserId == id);
        }

        public void Create(Contact item)
        {
            db.Contacts.Add(item);
        }

        public void Update(Contact item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact != null)
                db.Contacts.Remove(contact);
        }
    }
}
