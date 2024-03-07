using HalloDocRepository.DataContext;
using HalloDocRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDocRepository.Implementation
{
    public class AspNetUserRepo:IAspNetUserRepo
    {
        private readonly ApplicationDbContext _context;

        public AspNetUserRepo(ApplicationDbContext context)
        {
            _context = context;
        }


    }

}
