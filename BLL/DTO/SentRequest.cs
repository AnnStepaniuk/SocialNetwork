using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SentRequest
    {
        public int FriendRequestId { get; set; }

        public int ReceiverId { get; set; }

        public virtual UserDTO Receiver { get; set; }
    }
}
