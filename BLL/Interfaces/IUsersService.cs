using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsersService
    {
        void RegisterNewUser(UserDTO user);
        void EditPersonalInformationOfUser(UserDTO user);          
        void AddAvatar(int userId, string imageName);
        UserDTO GetUserByEmail(string email);
    }
}
