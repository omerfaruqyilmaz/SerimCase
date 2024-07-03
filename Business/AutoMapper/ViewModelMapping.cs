using AutoMapper;
using SerimCase.Entities.Concrete;
using SerimCase.ViewModels;

namespace SerimCase.Business.AutoMapper
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            CreateMap<CustomerUpdateViewModel, Customer>().ReverseMap();
            CreateMap<CustomerCreateViewModel, Customer>()
                        .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => (DateTime)src.BirthDay))
                        .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                        .ForMember(dest => dest.IsStatus, opt => opt.MapFrom(src => true));
        }
    }
       
}
