using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Birthday { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        //public string Password { get; set; }

        public int? ListContactsId { get; set; }

        public virtual ListContacts ListContacts { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; }

        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public virtual ICollection<FriendRequest> ReceivedFriendRequests { get; set; }

        public virtual ICollection<FriendRequest> SentFriendRequests { get; set; }

        public User()
        {
            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
            SentFriendRequests = new List<FriendRequest>();
            ReceivedFriendRequests = new List<FriendRequest>();
        }

    }
}
