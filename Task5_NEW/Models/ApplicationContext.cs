using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Task5_NEW.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<FixModel> FixModels { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
