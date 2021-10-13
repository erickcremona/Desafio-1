using AutoMapper;
using Desafio.Api.ViewModels;
using Desafio.Domain.Entities;

namespace Desafio.Api.Configurations
{
    public class AutoMaperConfig: Profile
    {
        public AutoMaperConfig()
        {
            CreateMap<ProductViewModelRequest, Product>();
            CreateMap<Product, ProductViewModelResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(dest => dest.CategoryProfit, opt => opt.MapFrom(p => p.Category.Profit))
                .ForMember(dest => dest.NameSupplier, opt => opt.MapFrom(p => p.Supplier.Name))
                .ForMember(dest => dest.DocumentSupplier, opt => opt.MapFrom(p => p.Supplier.Document));
                       
            CreateMap<Category, CategoryViewModelResponse>().ReverseMap();
            CreateMap<Category, CategoryViewModelRequest>().ReverseMap();

            CreateMap<SupplierViewModelResponse, Supplier>().ReverseMap();
            CreateMap<SupplierViewModelRequest, Supplier>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
        }
    }
}
