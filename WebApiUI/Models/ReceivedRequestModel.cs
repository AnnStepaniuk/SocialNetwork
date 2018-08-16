using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUI.Models
{
    public class ReceivedRequestModel
    {
        public int FriendRequestId { get; set; }

        public int SenderUserId { get; set; }

        public virtual UserInformation Sender { get; set; }

    }
}
