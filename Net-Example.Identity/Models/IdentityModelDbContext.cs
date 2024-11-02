using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Net_Example.Identity.Models;

public class IdentityModelDbContext : IdentityDbContext<IdentityUser>
{
    public IdentityModelDbContext(DbContextOptions options) : base(options)
    {
    }
}
