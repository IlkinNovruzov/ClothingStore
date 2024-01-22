using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BankAccount.Model
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Card> Cards { get; set; }
    }
}
