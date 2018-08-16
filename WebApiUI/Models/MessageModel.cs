using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.Models
{
    public class MessageModel
    {
        public string MessageText { get; set; }

        public int SenderId { get; set; }
        
        public int ReceiverId { get; set; }
        
        public DateTime MessageDate { get; set; }
    }
}