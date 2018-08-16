using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ListContactsDTO
    {
        public int ListContactsId { get; set; }

        public virtual ICollection<ContactDTO> Contacts { get; set; }

        public ListContactsDTO()
        {
            Contacts = new List<ContactDTO>();
        }
    }
}
