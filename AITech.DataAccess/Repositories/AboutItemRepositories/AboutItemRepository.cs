using AITech.DataAccess.Context;
using AITech.DataAccess.Repositories.GenericRapository;
using AITech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DataAccess.Repositories.AboutItemRepositories
{
    public class AboutItemRepository : GenericRepository<AboutItem>, IAboutItemRepository
    {
        public AboutItemRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
