using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.CityId);

            modelBuilder
                .Property(x => x.CityId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.CityTitle)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            modelBuilder
                .Property(x => x.PostalCode)
                .IsRequired();

            modelBuilder
                .Property(x => x.StateId)
                .IsRequired(false);

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
                .HasIndex(x => x.CityTitle, "IX_City_CityTitle")
                .IsUnique();

            modelBuilder
                .HasOne(d => d.State)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_City_States");

            modelBuilder
                .ToTable("City");
        }
    }
}