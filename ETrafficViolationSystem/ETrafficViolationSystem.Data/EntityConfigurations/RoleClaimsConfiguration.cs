using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class RoleClaimsConfiguration : IEntityTypeConfiguration<RoleClaims>
    {
        public void Configure (EntityTypeBuilder<RoleClaims> modelBuilder)
        {
            modelBuilder
                .ToTable("RoleClaims");
        }
    }
}