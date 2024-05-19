using AutoMapper;

namespace Collections.Mapping
{
    public class BaseMapper<TSource, TDestination> : Profile
    {
        public BaseMapper()
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }
    }
}
