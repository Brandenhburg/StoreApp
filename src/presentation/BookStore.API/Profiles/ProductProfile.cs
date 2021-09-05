using AutoMapper;
using Bookstore.Domain.Entities;
using Bookstore.API.DTOs;

namespace Bookstore.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDTO>();
        }        
    }
}
