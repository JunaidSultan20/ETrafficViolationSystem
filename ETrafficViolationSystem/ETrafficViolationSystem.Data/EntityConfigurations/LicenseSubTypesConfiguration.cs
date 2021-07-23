using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class LicenseSubTypesConfiguration : IEntityTypeConfiguration<LicenseSubTypes>
    {
        public void Configure(EntityTypeBuilder<LicenseSubTypes> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.LicenseSubTypeId);

            modelBuilder
                .Property(x => x.LicenseSubTypeId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.LicenseTypeId)
                .IsRequired();

            modelBuilder
                .Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.SubTypeClass)
                .HasColumnType("varchar")
                .HasMaxLength(10);

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
                .HasOne(x => x.LicenseTypes)
                .WithMany(x => x.LicenseSubTypes)
                .HasForeignKey(x => x.LicenseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicenseSubTypes_LicenseTypes");

            modelBuilder
                .ToTable("LicenseSubTypes");
        }
    }
}