using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;

namespace TLCN.Web.DALs
{
    public class UnitOfWork : IUnitOfWork
    {
        private TLCNDatabaseContext _context;
        public UnitOfWork(TLCNDatabaseContext context)
        {
            _context = context;
            InitRepository();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        private bool _disposed = false;
        public IRepository<Product> ProductRepository { get; set; }

        public IRepository<AuthUser> AuthUserRepository { get; set; }

        public IRepository<Branch> BranchRepository { get; set; }

        public IRepository<Cart> CartRepository { get; set; }

        public IRepository<CartDetail> CartDetailRepository { get; set; }

        public IRepository<Bill> BillRepository { get; set; }

        public IRepository<DetailBill> DetailBillRepository { get; set; }

        public IRepository<MetadataType> MetadataTypeRepository { get; set; }

        public IRepository<MetadataValue> MetadataValueRepository { get; set; }

        public IRepository<Promotion> PromotionRepository { get; set; }

        public IRepository<ReviewProduct> ReviewProductRepository { get; set; }

        private void InitRepository()
        {
            ProductRepository = new Repository<Product>(_context);
            AuthUserRepository = new Repository<AuthUser>(_context);
            BranchRepository = new Repository<Branch>(_context);
            CartRepository = new Repository<Cart>(_context);
            CartDetailRepository = new Repository<CartDetail>(_context);
            BillRepository = new Repository<Bill>(_context);
            DetailBillRepository = new Repository<DetailBill>(_context);
            MetadataTypeRepository = new Repository<MetadataType>(_context);
            MetadataValueRepository = new Repository<MetadataValue>(_context);
            PromotionRepository = new Repository<Promotion>(_context);
            ReviewProductRepository = new Repository<ReviewProduct>(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TLCNDatabaseContext GetContext
        {
            get
            {
                return _context;
            }
        }

        public TLCNDatabaseContext GetDbContext()
        {
            return this.GetContext;
        }
    }
}
