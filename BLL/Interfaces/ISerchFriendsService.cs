using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISerchFriendsService
    {
        IEnumerable<UserDTO> GetAllContacts(int userId, int pageIndex, int pageSize);
        IEnumerable<SentRequest> GetSentRequests(int userId);
        IEnumerable<ReceivedRequest> GetReceivedRequests(int userId);
        void SendFriendRequest(int userId, int contactId);
        void ConfirmRequest(int receiverId, int senderId);
        void DeleteRequest(int receiverId, int senderId);
    }
}
