using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Domain.Entity;
using AutoMapper;

namespace Acme.Ecommerce.Transverse.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            // CreateMap<Customer, CustomerDto>()
            //     .ForMember(dst => dst.CustomerId, src => src.MapFrom(s => s.CustomerId))
            //     .ForMember(dst => dst.CompanyName, src => src.MapFrom(s => s.CompanyName))
            //     .ForMember(dst => dst.ContactName, src => src.MapFrom(s => s.ContactName))
            //     .ForMember(dst => dst.ContactTitle, src => src.MapFrom(s => s.ContactTitle))
            //     .ForMember(dst => dst.Address, src => src.MapFrom(s => s.Address))
            //     .ForMember(dst => dst.City, src => src.MapFrom(s => s.City))
            //     .ForMember(dst => dst.Region, src => src.MapFrom(s => s.Region))
            //     .ForMember(dst => dst.PostalCode, src => src.MapFrom(s => s.PostalCode))
            //     .ForMember(dst => dst.Country, src => src.MapFrom(s => s.Country))
            //     .ForMember(dst => dst.Phone, src => src.MapFrom(s => s.Phone))
            //     .ForMember(dst => dst.Fax, src => src.MapFrom(s => s.Fax))
            //     .ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
