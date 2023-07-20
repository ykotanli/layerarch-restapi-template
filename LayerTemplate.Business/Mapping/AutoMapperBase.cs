using AutoMapper;
using PagedList;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplate.Business.Mapping
{
    public static class AutoMapperBase
    {
        public static readonly IMapper _mapper;

        static AutoMapperBase()
        {
            var config = new MapperConfiguration(c=>c.AddProfile<MappingProfile>());
            _mapper=config.CreateMapper();
        }

        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        {
            IEnumerable<TDestination> sourcelist = _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourcelist, list.GetMetaData());
            return pagedResult;
        }

    }
}
