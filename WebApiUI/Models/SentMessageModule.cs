using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.Models
{
    public class SentMessageModule
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public int ReceiverId { get; set; }

        public UserInformation Receiver { get; set; }

        public DateTime MessageDate { get; set; }
    }
}