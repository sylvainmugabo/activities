using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Activity> Activities { get; set; }
};
