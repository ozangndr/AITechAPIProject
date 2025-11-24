using AITech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AITech.DataAccess.Repositories.GenericRapository;
using AITech.DataAccess.Context;

namespace AITech.DataAccess.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
