using DAL.Entities;
using DAL.EF;
using DAL.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class ListContactsRepository : IRepository<ListContacts>
    {
        private SocialNetworkContext db;

        public ListContactsRepository(SocialNetworkContext context)
        {
            this.db = context;
        }

        public IEnumerable<ListContacts> GetAll()
        {
            return db.ListsContacts;
        }

        public ListContacts Get(int id)
        {
            return db.ListsContacts.SingleOrDefault(d => d.ListContactsId == id);
        }

        public void Create(ListContacts item)
        {
            db.ListsContacts.Add(item);
        }

        public void Update(ListContacts item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ListContacts listContacts = db.ListsContacts.Find(id);
            if (listContacts != null)
                db.ListsContacts.Remove(listContacts);
        }
    }
}
