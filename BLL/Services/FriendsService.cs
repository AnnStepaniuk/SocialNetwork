using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class FriendsService : IFriendsService
    {
        private IUnitOfWork Database { get; set; }
        private AutoMapperCollection mapperCollection;

        public FriendsService(IUnitOfWork uow)
        {
            Database = uow;
            mapperCollection = new AutoMapperCollection();
        }

        public IEnumerable<UserDTO> GetListFriends(int userId)
        {
            var user = Database.Users.Get(userId);
            ICollection<User> users = new List<User>();
            if (user.ListContacts != null && user.ListContacts.Contacts != null)
            {
                foreach (var temp in user.ListContacts.Contacts)
                {
                    users.Add(temp.User);
                }
            }
            return (users != null) ? mapperCollection.Map<User, UserDTO>((IEnumerable<User>)users) : null;
        }

        public void SendMessage(MessageDTO messageDto)
        {
            var sender = Database.Users.Get(messageDto.SenderId);
            var receiver = Database.Users.Get(messageDto.ReceiverId);
            var message = Mapper.Map<MessageDTO, Message>(messageDto);
            Database.Messages.Create(message);
            sender.SentMessages.Add(message);
            receiver.ReceivedMessages.Add(message);
            Database.Users.Update(sender);
            Database.Users.Update(receiver);
            Database.Save();
        }

        public IEnumerable<MessageDTO> GetReceivedMessages(int userId)
        {
            var user = Database.Users.Get(userId);
            var messages = user.ReceivedMessages.OrderByDescending(x => x.MessageDate);
            return mapperCollection.Map<Message, MessageDTO>(messages);
        }

        public IEnumerable<MessageDTO> GetSentMessages(int userId)
        {
            var user = Database.Users.Get(userId);
            var messages = user.SentMessages.OrderByDescending(x =>x.MessageDate);
            return mapperCollection.Map<Message, MessageDTO>(messages);
        }

        public void DeleteMessage(int messageId)
        {
            Database.Messages.Delete(messageId);
            Database.Save();
        }

        
    }
}
