using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;

namespace TLCN.Web.DALs
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<AuthUser> AuthUserRepository { get; }
        IRepository<Cart> CartRepository { get; }
        IRepository<CartDetail> CartDetailRepository { get; }
        IRepository<Bill> BillRepository { get; }
        IRepository<DetailBill> DetailBillRepository { get; }
        IRepository<MetadataType> MetadataTypeRepository { get; }
        IRepository<MetadataValue> MetadataValueRepository { get; }
        IRepository<Promotion> PromotionRepository { get; }
        IRepository<ReviewProduct> ReviewProductRepository { get; }
        IRepository<Menu> MenuRepository { get; }
        Task SaveChangesAsync();
    }
}
