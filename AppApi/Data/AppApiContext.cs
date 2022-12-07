using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppApi.Models;

namespace AppApi.Data
{
    public class AppApiContext : DbContext
    {
        public AppApiContext (DbContextOptions<AppApiContext> options)
            : base(options)
        {
        }

        public DbSet<AppApi.Models.Exercicio> Exercicio { get; set; } = default!;
    }
}
