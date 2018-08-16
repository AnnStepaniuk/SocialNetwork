using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IFriendsService
    {
        IEnumerable<UserDTO> GetListFriends(int userId);
        void SendMessage(MessageDTO messageDto);
        IEnumerable<MessageDTO> GetReceivedMessages(int userId);
        IEnumerable<MessageDTO> GetSentMessages(int userId);
        void DeleteMessage(int messageId);
    }
}
