using AutoMapper;
using MovieRent.Web.DTOs;
using MovieRent.Web.Models;

namespace MovieRent.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movies, GetMoviesDTO>();
            CreateMap<AddMoviesDTO, Movies>(); 
        }
    }
}
