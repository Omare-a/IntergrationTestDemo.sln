using IntergrationTestDemo.sln;
using IntergrationTestDemo.sln.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MyApp.IntergrationTest.sln;

public class UnitTest1 : IDisposable
{
    private readonly AppDbContext _context;

    public UnitTest1()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        _context = new AppDbContext(options);
        _context.Database.EnsureCreated();
    }

    [Fact]
    public void AddUser_SavesUserToDatabase()
    {
        var user = new User { Name = "Kalle" };

        _context.Users.Add(user);
        _context.SaveChanges();

        var savedUser = _context.Users.Single();

        Assert.Equal("Kalle", savedUser.Name);
    }

    public void Dispose() 
    {
        _context.Dispose();
    }

}
