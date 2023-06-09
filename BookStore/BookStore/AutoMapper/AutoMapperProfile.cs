using AutoMapper;
using BookStore.Models.Models;
using BookStore.Models.Models.Requests.AddRequests;
using BookStore.Models.Models.Requests.UpdateRequests;

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
