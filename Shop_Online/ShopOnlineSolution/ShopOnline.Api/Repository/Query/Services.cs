using AutoMapper;

namespace ShopOnline.Api.Repository.Query
{
    public class Services
    {
        public static MapperConfiguration Mapping<map1, map2>()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<map1, map2>();
                c.CreateMap<map2, map1>();
            });

        }
        public static MapperConfiguration OneTimeMapping<map1, map2>()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<map1, map2>();
            });

        }
    }
}
