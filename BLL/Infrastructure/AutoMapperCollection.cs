using AutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BLL.Infrastructure
{
    public class AutoMapperCollection
    {
        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source) where TSource : class where TDestination : class
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()).CreateMapper();
            return source.Select(x => mapper.Map<TDestination>(x));
        }


        //public Collection<TDestination> MapCollection<TSource, TDestination>(Collection<TSource> source) where TSource : class where TDestination : class
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()).CreateMapper();
        //    return (Collection<TDestination>)source.Select(x => mapper.Map<TDestination>(x));
        //}
    }
}
