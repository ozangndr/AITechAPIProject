using AITech.DataAccess.Context;
using AITech.DataAccess.Repositories.GenericRapository;
using AITech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DataAccess.Repositories.ChooseRepositories
{
    public class ChooseRepository : GenericRepository<Choose>, IChooseRepository
    {
        public ChooseRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
