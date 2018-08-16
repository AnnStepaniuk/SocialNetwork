using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class FriendRequest
    {
        //public int FriendRequestId { get; set; }

        //public int SenderId { get; set; }

        //public virtual User Sender { get; set; }

        //public int ReceiverId { get; set; }

        //public virtual User Receiver { get; set; }

        public int FriendRequestId { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [ForeignKey("SenderId")]
        [InverseProperty("SentFriendRequests")]
        public virtual User Sender { get; set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("ReceivedFriendRequests")]
        public virtual User Receiver { get; set; }

    }
}
