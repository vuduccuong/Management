using AutoMapper;
using Management.Model.Models;
using Management.Web.Models;

namespace Management.Web.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<Tag, TagViewModel>();

            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategory, ProductViewModel>();
            CreateMap<ProductTag, ProductTagViewModel>();

            CreateMap<Driver, DriverViewModel>();
            CreateMap<Car, CarViewModel>();
            CreateMap<Router, RouterViewModel>();
            CreateMap<TypeCar, TypeCarViewModel>();
        }
    }
}