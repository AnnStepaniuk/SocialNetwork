using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiUI.Models;

namespace WebApiUI.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPut]
        [Route("edit/{id}")]
        public HttpResponseMessage EditPersonalInform(int id, [FromBody]UserInformation user)
        {
            usersService.EditPersonalInformationOfUser(Mapper.Map<UserInformation, UserDTO>(user));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("addAvatar/{userId}")]
        public HttpResponseMessage AddAvatar([FromUri] int userId)
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            
            imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);
            usersService.AddAvatar(userId, imageName);
            return Request.CreateResponse(HttpStatusCode.Created);

        }

        [HttpGet]
        [Route("getUser")]
        public UserInformation GetUser()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            Console.WriteLine(identityClaims.Claims);

            AccountModel model = new AccountModel()
            {
                Email = identityClaims.FindFirstValue("Email")
            };
            UserInformation user = Mapper.Map<UserDTO, UserInformation>(usersService.GetUserByEmail(model.Email));
                  
            return user;
        }
        

        [HttpGet]
        [Route("user/image/get")]
        public HttpResponseMessage ImageGet(string imageName)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var path = "~/Image/" + imageName;
            path = System.Web.Hosting.HostingEnvironment.MapPath(path);
            var ext = System.IO.Path.GetExtension(path);

            var contents = System.IO.File.ReadAllBytes(path);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(contents);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");

            return response;
        }
    }
}
