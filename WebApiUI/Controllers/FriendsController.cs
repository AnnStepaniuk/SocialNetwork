using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiUI.Models;

namespace WebApiUI.Controllers
{
    [RoutePrefix("api")]
    public class FriendsController : ApiController
    {
        private IFriendsService friendsService;
        private AutoMapperCollection mapperCollection;

        public FriendsController(IFriendsService friendsService)
        {
            this.friendsService = friendsService;
            mapperCollection = new AutoMapperCollection();
        }

        [HttpGet]
        [Route("friends/get/{id}")]
        public IEnumerable<UserInformation> GetFriends(int id)
        {
            var friends = friendsService.GetListFriends(id);
            var result = mapperCollection.Map<UserDTO, UserInformation>(friends);
            return result;
        }

        [HttpPost]
        [Route("messages/send")]
        public HttpResponseMessage SendMessage([FromBody] MessageModel model)
        {
            model.MessageDate = TimeZoneInfo.ConvertTime(model.MessageDate,
            TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time"));
            var message = Mapper.Map<MessageModel, MessageDTO>(model);
            friendsService.SendMessage(message);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("messages/getReceived/{id}")]
        public IEnumerable<ReceivedMessageModel> GetReceivedMessages(int id)
        {          
            var messages = friendsService.GetReceivedMessages(id);
            return mapperCollection.Map<MessageDTO, ReceivedMessageModel>(messages);
        }

        [HttpGet]
        [Route("messages/getSent/{id}")]
        public IEnumerable<SentMessageModule> GetSentMessages(int id)
        {
            var messages = friendsService.GetSentMessages(id);
            return mapperCollection.Map<MessageDTO, SentMessageModule>(messages);
        }

        [HttpDelete]
        [Route("messages/{id}")]
        public void DeletedSentMessage(int id)
        {
           friendsService.DeleteMessage(id);       
        }

    }
}
