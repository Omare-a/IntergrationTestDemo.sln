using IntergrationTestDemo.sln.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergrationTestDemo.sln;

public class AppDbContext : DbContext
{
    public DbSet<User> Users
    {
        get
        {
            return Set<User>();
        }
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
