using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.ServicioAhora;
using eCommerceApp.Domain.Interfaces.CategorySpecifics;
using eCommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Repositories.CategorySpecifics
{
    public class CategoryRepository(AppDbContext context) : ICategory
    {
        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            var products = await context
                .Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();

            return products.Count() > 0 ? products : [];
        }

        public async Task<IEnumerable<ServiceOffering>> GetServOfferingByCategory(Guid categoryId)
        {
            var serviceOffering = await context
                .ServiceOfferings
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();

            return serviceOffering.Count() > 0 ? serviceOffering : [];
        }
    }
}
