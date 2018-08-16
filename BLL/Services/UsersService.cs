using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class UsersService : IUsersService
    {
        private IUnitOfWork Database { get; set; }
        private AutoMapperCollection mapperCollection;

        public UsersService(IUnitOfWork uow)
        {
            Database = uow;
            mapperCollection = new AutoMapperCollection();
        }

        public void RegisterNewUser(UserDTO user)
        {
            
            Database.Users.Create(Mapper.Map<UserDTO, User>(user));
            Database.Save();
        }

        public void EditPersonalInformationOfUser(UserDTO user)
        {
            Database.Users.Update(Mapper.Map<UserDTO, User>(user));
            Database.Save();
        }

        public void AddAvatar(int userId, string imageName)
        {
            var user = Database.Users.Get(userId);
            user.Image = imageName;
            Database.Users.Update(user);
            Database.Save();
        }       

        public UserDTO GetUserByEmail(string email)
        {
            var user = Database.Users.GetAll().Where(u => u.Email == email).Single();
            return Mapper.Map<User, UserDTO>(user);
        }

    }
}
