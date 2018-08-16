using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SearchFriendsService: ISerchFriendsService
    {
        private IUnitOfWork Database { get; set; }
        private AutoMapperCollection mapperCollection;

        public SearchFriendsService(IUnitOfWork uow)
        {
            Database = uow;
            mapperCollection = new AutoMapperCollection();
        }

        public IEnumerable<UserDTO> GetAllContacts(int userId, int pageIndex, int pageSize)
        {
            var user = Database.Users.Get(userId);
            var receivedRequests = user.ReceivedFriendRequests;
            var sentRequests = user.SentFriendRequests;

            List<int> contactsId = new List<int>();

            if (receivedRequests != null)
            {
                foreach (var item in receivedRequests)
                {
                    contactsId.Add(item.SenderId);
                }
            }
            if (sentRequests != null)
            {
                foreach (var item in sentRequests)
                {
                    contactsId.Add(item.ReceiverId);
                }
            }
            
            if (user.ListContacts != null && user.ListContacts.Contacts != null)
            {
                foreach (var item in user.ListContacts.Contacts)
                {
                    contactsId.Add(item.UserId);
                }
            }
            var contacts = Database.Users.GetAll().Where(u => u.UserId != userId && !contactsId.Contains(u.UserId)).Skip(pageIndex*pageSize).Take(pageSize);
            return mapperCollection.Map<User, UserDTO>(contacts);
        }

        public IEnumerable<SentRequest> GetSentRequests(int userId)
        {
            var user = Database.Users.Get(userId);
            var requests = user.SentFriendRequests;
            return mapperCollection.Map<FriendRequest, SentRequest>((IEnumerable<FriendRequest>)requests);
        }

        public IEnumerable<ReceivedRequest> GetReceivedRequests(int userId)
        {
            var user = Database.Users.Get(userId);
            var requests = user.ReceivedFriendRequests;
            return mapperCollection.Map<FriendRequest, ReceivedRequest>((IEnumerable<FriendRequest>)requests);
        }

        public void SendFriendRequest(int userId, int contactId)
        {
            var user = Database.Users.Get(userId);
            var contact = Database.Users.Get(contactId);

            FriendRequest friendRequest = new FriendRequest()
            {
                SenderId = user.UserId,
                ReceiverId = contactId
            };
            Database.FriendRequests.Create(friendRequest);

            user.SentFriendRequests.Add(friendRequest);
            contact.ReceivedFriendRequests.Add(friendRequest);

            Database.Users.Update(user);
            Database.Users.Update(contact);
            Database.Save();
        }

        public void ConfirmRequest(int receiverId, int senderId)
        {
            var receiver = Database.Users.Get(receiverId);
            var sender = Database.Users.Get(senderId);

            var newContact = new Contact() { UserId = sender.UserId };
            Database.Contacts.Create(newContact);

            if (receiver.ListContactsId == null)
            {
                var listContacts = new ListContacts();
                Database.ListsContacts.Create(listContacts);
                Database.Save();
                
                listContacts.Contacts.Add(newContact);
                Database.ListsContacts.Update(listContacts);
                receiver.ListContactsId = listContacts.ListContactsId;
            }
            else
            {
                var listContacts = Database.ListsContacts.Get(Convert.ToInt32(receiver.ListContactsId));
                listContacts.Contacts.Add(newContact);
                Database.ListsContacts.Update(listContacts);
            }
            Database.Users.Update(receiver);
            Database.Save();
        }

        public void DeleteRequest(int receiverId, int senderId)
        {
            var friendRequest = Database.FriendRequests.GetAll().Where(f => f.SenderId == senderId && f.ReceiverId == receiverId).Single();
            Database.FriendRequests.Delete(friendRequest.FriendRequestId);
            Database.Save();
        }

    }
}
