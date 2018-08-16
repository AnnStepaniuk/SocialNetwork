using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.Models
{
    public class ReceivedMessageModel
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public int SenderId { get; set; }

        public virtual UserInformation Sender { get; set; }

        public DateTime MessageDate { get; set; }
    }
}