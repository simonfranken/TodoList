using Microsoft.EntityFrameworkCore;
using TodoListApi.Data.Models;

namespace TodoListApi.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<TodoEntry> TodoEntries { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}