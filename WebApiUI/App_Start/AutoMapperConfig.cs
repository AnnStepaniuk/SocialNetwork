using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.EquivalencyExpression;
using BLL.DTO;
using DAL.EF;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiUI.Models;

namespace WebApiUI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AccountModel, UserDTO>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<UserInformation, UserDTO>();
                cfg.CreateMap<UserDTO, UserInformation>();
                cfg.CreateMap<SentRequest, FriendRequest>();
                cfg.CreateMap<FriendRequest, SentRequest>();
                cfg.CreateMap<SentRequest, SentRequestModel>();
                cfg.CreateMap<FriendRequestDTO, FriendRequest>();
                cfg.CreateMap<MessageDTO, Message>();
                cfg.CreateMap<MessageModel, MessageDTO>();
            });
            
        }
    }

    //public class AutoMapperCollection
    //{
    //    public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source) where TSource : class where TDestination : class
    //    {
    //        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()).CreateMapper();
    //        return source.Select(x => mapper.Map<TDestination>(x));
    //    }

    //    //public Collection<TDestination> MapCollection<TSource, TDestination>(Collection<TSource> source) where TSource : class where TDestination : class
    //    //{
    //    //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()).CreateMapper();
    //    //    return (Collection<TDestination>)source.Select(x => mapper.Map<TDestination>(x));
    //    //}
    //}

}