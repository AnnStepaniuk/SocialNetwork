using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Message> Messages { get; }
        IRepository<ListContacts> ListsContacts { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<FriendRequest> FriendRequests { get; }

        void Save();
    }
}
