using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MessageDTO
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public int SenderId { get; set; }

        public virtual UserDTO Sender { get; set; }

        public int ReceiverId { get; set; }
    
        public virtual UserDTO Receiver { get; set; }

        public DateTime MessageDate { get; set; }
        
    }
}
