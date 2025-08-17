using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using ITM_College.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITM_College.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ITM_CollegeAdmin>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserIdentityConfiguration());
    }
}

internal class ApplicationUserIdentityConfiguration : IEntityTypeConfiguration<ITM_CollegeAdmin>
{
    public void Configure(EntityTypeBuilder<ITM_CollegeAdmin> builder)
    {
        builder.Property(x => x.FirstName)
               .HasMaxLength(120);

        builder.Property(x => x.LastName)
               .HasMaxLength(120);
    }
}

