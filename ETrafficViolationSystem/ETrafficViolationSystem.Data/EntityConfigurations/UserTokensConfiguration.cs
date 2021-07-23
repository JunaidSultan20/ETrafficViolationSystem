using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class UserTokensConfiguration : IEntityTypeConfiguration<UserTokens>
    {
        public void Configure(EntityTypeBuilder<UserTokens> modelBuilder)
        {
            modelBuilder
                .ToTable("UserTokens");
        }
    }
}