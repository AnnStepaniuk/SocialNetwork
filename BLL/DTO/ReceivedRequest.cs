using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReceivedRequest
    {
        public int FriendRequestId { get; set; }

        public int SenderId { get; set; }

        public virtual UserDTO Sender { get; set; }

    }
}
