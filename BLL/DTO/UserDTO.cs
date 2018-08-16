
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Birthday { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public int? ListContactsId { get; set; }

        public virtual ListContactsDTO ListContacts { get; set; }

        //public virtual ICollection<MessageDTO> Messages { get; set; }

        //public virtual ICollection<FriendRequestDTO> FriendRequests { get; set; }

        //public UserDTO()
        //{
        //    Messages = new List<MessageDTO>();
        //    FriendRequests = new List<FriendRequestDTO>();
        //}

    }
}
