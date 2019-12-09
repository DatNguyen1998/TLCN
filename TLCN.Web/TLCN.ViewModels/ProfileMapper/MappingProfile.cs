using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TLCN.Models;
namespace TLCN.ViewModels.ProfileMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile(): base()
        {
            CreateMap<AuthUser, AuthUserViewModel>().ReverseMap();
            CreateMap<Bill, BillViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartDetail, CartDetailViewModel>().ReverseMap();
            CreateMap<MetadataType, MetadataTypeViewModel>().ReverseMap();
            CreateMap<MetadataValue, MetadataValueViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductGridViewModel>().ReverseMap();
            CreateMap<Promotion, PromotionViewModel>().ReverseMap();
            CreateMap<ReviewProduct, ReviewProductViewModel>().ReverseMap();
            //CreateMap<MetadataValueGetGridViewModel, MetadataValue>()
            //    .ForMember(e => e.Type.Code, opts => opts.MapFrom(v => v.TypeCode))
            //   .ForMember(e => e.Type.Name, opts => opts.MapFrom(v => v.TypeName));

            CreateMap<MetadataValue, MetadataValueGetGridViewModel>().ReverseMap();
            CreateMap<AuthUser, AuthUserGetGridViewModel>().ReverseMap();
            CreateMap<Menu, MenuViewModel>().ReverseMap();
            CreateMap<Menu, MenuGridViewModel>().ReverseMap();
            CreateMap<DetailBill, BillDetailForClientViewModel>().ReverseMap();
            CreateMap<DetailBill, BillDetailViewModel>().ReverseMap();
            CreateMap<DetailBill, BillDetailForBillIdViewModel>().ReverseMap();
            CreateMap<Bill, BillForGridViewModel>().ReverseMap();
        }

    }
}
