using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {}

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

    }
}
