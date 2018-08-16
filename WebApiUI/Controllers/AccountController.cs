using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApiUI.Models;
using System.Web.Razor;
using RazorEngine;
using BLL.Interfaces;
using BLL.Services;
using AutoMapper;
using BLL.DTO;
using System.Security.Claims;
using System.Runtime.Remoting.Contexts;

namespace WebApiUI.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        private IUsersService usersService;

        public AccountController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Account/Register")]
        [HttpPost]
        public IdentityResult Register(AccountModel model)
        {
            Console.WriteLine(model.Birthday);
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
            manager.PasswordValidator = new PasswordValidator{ };
            IdentityResult result = manager.Create(user, model.Password);
            usersService.RegisterNewUser(Mapper.Map<AccountModel, UserDTO>(model));

            return result;

        }

        

       
    }
}
