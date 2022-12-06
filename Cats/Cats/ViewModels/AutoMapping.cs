using AutoMapper;
using Cats.API.Models;
using Cats.API.ViewModels.Response;

namespace Cats.API.ViewModels
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
            CreateMap<Fact, GetFactsResponseItem>().ReverseMap();
        }
    }
}
