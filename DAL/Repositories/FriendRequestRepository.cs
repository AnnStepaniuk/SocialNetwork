using DAL.Entities;
using DAL.EF;
using DAL.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class FriendRequestRepository: IRepository<FriendRequest>
    {
        private SocialNetworkContext db;

        public FriendRequestRepository(SocialNetworkContext context)
        {
            this.db = context;
        }

        public IEnumerable<FriendRequest> GetAll()
        {
            return db.FriendRequests;
        }

        public FriendRequest Get(int id)
        {
            return db.FriendRequests.SingleOrDefault(d => d.FriendRequestId == id);
        }

        public void Create(FriendRequest item)
        {
            db.FriendRequests.Add(item);
        }

        public void Update(FriendRequest item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            FriendRequest item = db.FriendRequests.Find(id);
            if (item != null)
                db.FriendRequests.Remove(item);
        }


    }
}
