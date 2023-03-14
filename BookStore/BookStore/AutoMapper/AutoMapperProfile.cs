using AutoMapper;
using BookStore.Models.Models;
using BookStore.Models.Models.Requests;

namespace BookStore.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();
        }
    }
}
