using DAL.Entities;
using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private SocialNetworkContext db;

        public UserRepository(SocialNetworkContext context)
        {
            this.db = context;         
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.SingleOrDefault(d => d.UserId == id);
        }

        public void Create(User item)
        {
            if (item.ListContactsId == 0)
            {
                item.ListContactsId = null;
            }
            db.Users.Add(item);
        }

        public void Update(User item)
        {
            var entity = Get(item.UserId);
           

            db.Entry(entity).CurrentValues.SetValues(item);
            //db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            //var entity = db.Users.Where(c => c.UserId == item.UserId).AsQueryable().FirstOrDefault();
            //db.Entry(entity).CurrentValues.SetValues(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
