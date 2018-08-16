using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public DateTime MessageDate { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [ForeignKey("SenderId")]
        [InverseProperty("SentMessages")]
        public virtual User Sender { get; set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("ReceivedMessages")]
        public virtual User Receiver { get; set; }

      
        
    }
}
