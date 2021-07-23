using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class ViolationRecordsConfiguration : IEntityTypeConfiguration<ViolationRecords>
    {
        public void Configure(EntityTypeBuilder<ViolationRecords> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.ViolationId);

            modelBuilder
                .Property(x => x.ViolationId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.LicenseNo)
                .IsRequired();

            modelBuilder
                .Property(x => x.VehicleDetailId)
                .IsRequired();

            modelBuilder
                .Property(x => x.CityId)
                .IsRequired();

            modelBuilder
                .Property(x => x.LocationLongitude)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.LocationLatitude)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.DateTime)
                .IsRequired()
                .HasColumnType("datetime");

            modelBuilder
                .Property(x => x.PointsDeducted)
                .IsRequired();

            modelBuilder
                .Property(x => x.ChallanNo)
                .IsRequired();

            modelBuilder
                .Property(x => x.BookedBy)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

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
                .HasOne(x => x.City)
                .WithMany(x => x.ViolationRecords)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViolationRecords_City");

            modelBuilder
                .HasOne(x => x.LicenseRecords)
                .WithMany(x => x.ViolationRecords)
                .HasForeignKey(x => x.LicenseNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViolationRecords_LicenseRecords");

            modelBuilder
                .HasOne(x => x.VehicleDetail)
                .WithMany(x => x.ViolationRecords)
                .HasForeignKey(x => x.VehicleDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViolationRecords_VehicleDetails");

            modelBuilder
                .ToTable("ViolationRecords");
        }
    }
}