using Eventures.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<UserModel> users { get; set; }
        public DbSet<EventModel> events { get; set; }
    }
}
