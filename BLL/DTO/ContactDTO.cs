using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }

    }
}
