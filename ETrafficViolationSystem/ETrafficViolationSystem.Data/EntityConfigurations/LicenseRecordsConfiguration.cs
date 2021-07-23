using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class LicenseRecordsConfiguration : IEntityTypeConfiguration<LicenseRecords>
    {
        public void Configure(EntityTypeBuilder<LicenseRecords> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.LicenseNo);

            modelBuilder
                .Property(x => x.LicenseNo)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.DriverId)
                .IsRequired();

            modelBuilder
                .Property(x => x.LicenseTypeId)
                .IsRequired();

            modelBuilder
                .Property(x => x.IssueDate)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder
                .Property(x => x.ExpiryDate)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder
                .Property(x => x.PdlNo);

            modelBuilder
                .Property(x => x.Points)
                .IsRequired();

            modelBuilder
                .Property(x => x.Suspended)
                .IsRequired();

            modelBuilder
                .Property(x => x.SuspensionEndDate)
                .HasColumnType("date");

            modelBuilder
                .Property(x => x.Terminated)
                .IsRequired();

            modelBuilder
                .Property(x => x.LicenseImageFront)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.LicenseImageBack)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

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
                .HasIndex(x => x.DriverId, "IX_LicenseRecords_DriverId")
                .IsUnique();
            
            modelBuilder
                .HasIndex(x => x.PdlNo, "IX_LicenseRecords_PdlNo")
                .IsUnique();

            modelBuilder
                .HasOne(x => x.Driver)
                .WithOne(x => x.LicenseRecords)
                .HasForeignKey<LicenseRecords>(x => x.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicenseRecords_DriverDetails");

            modelBuilder
                .HasOne(x => x.LicenseType)
                .WithMany(x => x.LicenseRecords)
                .HasForeignKey(x => x.LicenseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicenseRecords_LicenseTypes");

            modelBuilder
                .ToTable("LicenseRecords");
        }
    }
}