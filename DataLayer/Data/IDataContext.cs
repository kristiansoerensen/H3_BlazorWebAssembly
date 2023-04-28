using DataLayer.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public interface IDataContext
    {
        IProductRepository Products { get; }
        IImageRepository Images { get; }
        ICountryRepository Countries { get; }
        ICategoryRepository Categories { get; }
        IBasketItemRepository BasketItems { get; }
        IBasketRepository Baskets { get; }
        IUserRepository Users { get; }
        IBrandRepository Brands { get; }
        IProductCategoryRepository ProductCategories { get; }
        IAddressRepository Addresses { get; }
        IPaymentProviderRepository PaymentProviders { get; }
        Task CommitAsync();
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
