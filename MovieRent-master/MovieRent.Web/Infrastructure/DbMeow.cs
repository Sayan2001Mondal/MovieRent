using Microsoft.EntityFrameworkCore;
using MovieRent.Web.Models;

namespace MovieRent.Web.Infrastructure
{
    public class DbMeow : DbContext
    {
        public DbMeow(DbContextOptions<DbMeow> options): base(options) 
        {
            
        }
        public DbSet<Movies> MoviesTable { get; set; }
        public DbSet<User> UsersTable { get; set; }

    }

}
