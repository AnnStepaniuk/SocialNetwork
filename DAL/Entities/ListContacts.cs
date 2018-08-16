using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ListContacts
    {
        public int ListContactsId { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public ListContacts()
        {
            Contacts = new List<Contact>();
        }
        

    }
}
