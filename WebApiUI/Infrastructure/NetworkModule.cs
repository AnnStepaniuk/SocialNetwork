using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.Infrastructure
{
    public class NetworkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsersService>().To<UsersService>();
            Bind<IFriendsService>().To<FriendsService>();
            Bind<ISerchFriendsService>().To<SearchFriendsService>();
        }
    }
}