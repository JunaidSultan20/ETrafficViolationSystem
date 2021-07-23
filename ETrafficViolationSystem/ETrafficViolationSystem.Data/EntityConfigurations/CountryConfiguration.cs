using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.CountryId);

            modelBuilder
                .Property(x => x.CountryId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.CountryTitle)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.ShortCode)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(10);

            modelBuilder
                .Property(x => x.CountryCode)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(10);

            modelBuilder
                .Property(x => x.DialingCode)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(15);

            modelBuilder
                .Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValueSql("1")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Property(x => x.CreatedBy)
                .IsRequired()
                .HasColumnType("int");

            modelBuilder
                .Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetDate()")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Property(x => x.UpdatedBy)
                .IsRequired(false)
                .HasColumnType("int");

            modelBuilder
                .Property(x => x.UpdatedDate)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetDate()");

            modelBuilder
                .HasIndex(x => x.CountryTitle, "IX_Country_CountryTitle")
                .IsUnique();

            modelBuilder
                .ToTable("Country");
        }
    }
}