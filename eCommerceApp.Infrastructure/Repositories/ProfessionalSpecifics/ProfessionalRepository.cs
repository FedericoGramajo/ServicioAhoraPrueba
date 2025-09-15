using eCommerceApp.Domain.Entities.Rol;
using eCommerceApp.Domain.Interfaces.Rol;
using eCommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Repositories.ProfessionalSpecifics
{
    public class ProfessionalRepository(AppDbContext context): IProfessional
    {
        public async Task<IEnumerable<Professional>> GetAllAsync()
        {
            var professional = await context
                .Professionals
               .Include(p => p.AppUser)
               .Include(p => p.Licenses)
               .Include(p => p.ProfessionalCategories).ThenInclude(pc => pc.Category)
               .Include(p => p.Services)
               .Include(p => p.Ratings)
               .AsNoTracking()
                .ToListAsync();
            return professional.Count() > 0 ? professional : [];
        }

        public async Task<Professional> GetByIdAsync(string id)
        {
            var professional = await context
                .Professionals
                .Include(p => p.AppUser)
                .Include(p => p.Licenses)
                .Include(p => p.ProfessionalCategories).ThenInclude(pc => pc.Category)
                .Include(p => p.Services)
                .Include(p => p.Ratings)
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync(p => p.Id == id);
            return professional!;
        }
    }
}
