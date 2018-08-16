using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebApiUI.Models;

namespace WebApiUI.Controllers
{
    [RoutePrefix("api/searchFriends")]
    public class SearchFriendsController : ApiController
    {
        private ISerchFriendsService searchFriendsService;
        private AutoMapperCollection mapperCollection; 

        public SearchFriendsController(ISerchFriendsService searchFriendsService)
        {
            this.searchFriendsService = searchFriendsService;
            mapperCollection = new AutoMapperCollection();
        }

        [HttpGet]
        [Route("getContacts/{userId}/{pageIndex}/{pageSize}")]
        public IEnumerable<UserInformation> GetAllContacts(int userId, int pageIndex, int pageSize)
        {
            var contactsDto = searchFriendsService.GetAllContacts(userId, pageIndex, pageSize);
            var contacts = mapperCollection.Map<UserDTO, UserInformation>(contactsDto);
            return contacts;
        }

        [HttpGet]
        [Route("requests/getSent/{id}")]
        public IEnumerable<SentRequestModel> GetSentRequests(int id)
        {
            var requests = mapperCollection.Map<SentRequest, SentRequestModel>(searchFriendsService.GetSentRequests(id));
            return requests;
        }

        [HttpGet]
        [Route("requests/getReceived/{id}")]
        public IEnumerable<ReceivedRequestModel> GetReceivedRequests(int id)
        {
            var requests = mapperCollection.Map<ReceivedRequest, ReceivedRequestModel>(searchFriendsService.GetReceivedRequests(id));
            return requests;
        }

        [HttpPost]
        [Route("request/send")]
        public HttpResponseMessage SendRequest([FromBody]RequestModel model)
        {
            searchFriendsService.SendFriendRequest(model.SenderId, model.ReceiverId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("request/confirm")]
        public HttpResponseMessage ConfirmFriendRequest([FromBody]RequestModel model)
        {
            searchFriendsService.ConfirmRequest(model.SenderId, model.ReceiverId);
            searchFriendsService.ConfirmRequest(model.ReceiverId, model.SenderId);
            searchFriendsService.DeleteRequest(model.ReceiverId, model.SenderId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }

   
}
