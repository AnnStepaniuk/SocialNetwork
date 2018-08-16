using System;
using DAL.Repositories;
using DAL.EF;
using DAL.Interfaces;
using DAL.Interface;
using DAL.Entities;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SocialNetworkContext db;
        private UserRepository userRepository;
        private MessageRepository messageRepository;
        private ListContactsRepository listContactsRepository;
        private ContactRepository contactRepository;
        private FriendRequestRepository friendRequestRepository;

        public UnitOfWork(string connectionString)
        {
            db = new SocialNetworkContext(connectionString);
        }


        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepository<Message> Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);
                return messageRepository;
            }
        }
        public IRepository<ListContacts> ListsContacts
        {
            get
            {
                if (listContactsRepository == null)
                    listContactsRepository = new ListContactsRepository(db);
                return listContactsRepository;
            }
        }

        public IRepository<Contact> Contacts
        {
            get
            {
                if (contactRepository == null)
                    contactRepository = new ContactRepository(db);
                return contactRepository;
            }
        }

        public IRepository<FriendRequest> FriendRequests
        {
            get
            {
                if (friendRequestRepository == null)
                    friendRequestRepository = new FriendRequestRepository(db);
                return friendRequestRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
