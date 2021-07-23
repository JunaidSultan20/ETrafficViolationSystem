using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> modelBuilder)
        {
            modelBuilder
                .ToTable("UserRole");
        }
    }
}