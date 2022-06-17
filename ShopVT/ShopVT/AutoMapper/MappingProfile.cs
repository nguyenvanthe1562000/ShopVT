using AutoMapper;
using Model.Model;
using ViewModel.catalog.AccDoc;
using ViewModel.catalog.Employee;
using ViewModel.catalog.Post;
using ViewModel.catalog.Product;
using ViewModel.catalog.Slide;

namespace API.AutoMapper
{

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<ProductCreateRequest, vB10ProductModel>()
                  .ReverseMap();
            CreateMap<ProductUpdateRequest, vB10ProductModel>()
                 .ReverseMap();
            CreateMap<PostRequest,B10PostModel>()
                .ReverseMap();
            CreateMap<PostTransferRequest, B10PostModel>()
              .ReverseMap();
            CreateMap<EmployeeRequest, B10EmployeeModel>()
                .ReverseMap();
            CreateMap<AccDocProductRequest, B20AccDocProductModel>().ReverseMap();
            CreateMap<B20AccDocProductModel, AccDocProductRequest>().ReverseMap();
            CreateMap<SlideRequest, vB10SlideModel>().ReverseMap();
            CreateMap<OrderRequest, vB20OrderModel>().ReverseMap();
        }

    }

    //public static class CommonMappings
    //{
    //    public static IMappingExpression<TSource, TDestination> MapToBaseViewModel<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map)
    //        where TDestination : BaseDto
    //    {
    //        return map
    //            .ForMember(dest => dest.CreatedByUserName, soucre => soucre.MapFrom("CreatedByUser.UserName"))
    //            .ForMember(dest => dest.UpdatedByUserName, soucre => soucre.MapFrom("UpdatedByUser.UserName"))
    //            .ForMember(dest => dest.UpdatedByUserName, soucre => soucre.MapFrom("DeletedByUser.UserName"));


    //        //else { return map; }
    //        ////return map
    //        //.ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom("CreatedByUserName"));

    //    }
    //}
}
