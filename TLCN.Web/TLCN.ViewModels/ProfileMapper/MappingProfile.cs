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
            CreateMap<Branch, BranchViewModel>().ReverseMap();
            CreateMap<BranchViewModel, Branch>();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartDetail, CartDetailViewModel>().ReverseMap();
            CreateMap<MetadataType, MetadataTypeViewModel>().ReverseMap();
            CreateMap<MetadataValue, MetadataValueViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Promotion, PromotionViewModel>().ReverseMap();
            CreateMap<ReviewProduct, ReviewProductViewModel>().ReverseMap();
        }

    }
}
