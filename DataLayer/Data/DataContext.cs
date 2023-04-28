using DataLayer.Core.Repositories;
using DataLayer.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class DataContext : IDataContext, IDisposable
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; private set; }

        public IImageRepository Images { get; private set; }

        public ICountryRepository Countries { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IBasketItemRepository BasketItems { get; private set; }

        public IBasketRepository Baskets { get; private set; }
        public IBrandRepository Brands { get; private set; }
        public IUserRepository Users { get; private set; }
        public IProductCategoryRepository ProductCategories { get; private set; }
        public IAddressRepository Addresses { get; private set; }
        public IPaymentProviderRepository PaymentProviders { get; private set; }

        public DataContext(
            AppDbContext context, ILoggerFactory logger)
        {
            _context = context;
            var _logger = logger.CreateLogger("logs");

            this.Products = new ProductRepository(context, _logger);
            this.Images = new ImageRepository(context, _logger);
            this.Countries = new CountryRepository(context, _logger);
            this.Categories = new CategoryRepository(context, _logger);
            this.BasketItems = new BasketItemRepository(context, _logger);
            this.Baskets = new BasketRepository(context, _logger);
            this.Brands = new BrandRepository(context, _logger);
            this.Users = new UserRepository(context, _logger);
            this.ProductCategories = new ProductCategoryRepository(context, _logger);
            this.Addresses = new AddressRepository(context, _logger);
            this.PaymentProviders = new PaymentProviderRepository(context, _logger);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class
        {
            return this._context.Entry(entity);
        }
    }
}
