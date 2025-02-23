using AutoMapper;
using GraphQlStorage.Model;
using GraphQlStorage.Model.DTO;

namespace GraphQlStorage.Mapper
{
    public class MapperStore : Profile
    {
        public MapperStore()
        {
            CreateMap<Product, ProductDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Storage, StorageDTO>(MemberList.Destination).ReverseMap();

        }
    }
}
