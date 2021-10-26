using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryApi.Entities
{
    public class YapiContext : DbContext
    {
        public YapiContext(DbContextOptions<YapiContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
