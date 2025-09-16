using eCommerceApp.Domain.Entities.ServicioAhora;
using eCommerceApp.Domain.Interfaces.ServicioAhora;
using eCommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Repositories.ServicioAhora.ServiceOfferring
{
    public class ServiceOfferingRepository(AppDbContext context) : IServiceOffering
    {
        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ServiceOffering>> GetAllAsync()
        {
            var serviceOffering = await context
                .ServiceOfferings
                .Include(o => o.Professional)
                .ThenInclude(p => p.AppUser)
                .AsNoTracking()
                .ToListAsync();


            return serviceOffering.Count() > 0 ? serviceOffering : [];
        }

        public async Task<ServiceOffering> GetByIdAsync(Guid id)
        {

            var serviceOffering = await context
                .ServiceOfferings
                .Include(o => o.Professional)
                .ThenInclude(p => p.AppUser)
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync(p => p.Id == id);
   
            return serviceOffering!;
        }
    }
}
