using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.Models
{
    public class SentRequestModel
    {
        public int FriendRequestId { get; set; }

        public int ReceiverId { get; set; }

        public virtual UserInformation Receiver { get; set; }
    }
}