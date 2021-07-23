using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class VehicleDetailsConfiguration : IEntityTypeConfiguration<VehicleDetails>
    {
        public void Configure(EntityTypeBuilder<VehicleDetails> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.VehicleDetailId);

            modelBuilder
                .Property(x => x.VehicleDetailId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.VehicleId)
                .IsRequired();

            modelBuilder
                .Property(x => x.RegistrationNo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            modelBuilder
                .Property(x => x.RegistrationCityId)
                .IsRequired();

            modelBuilder
                .Property(x => x.OwnerId)
                .IsRequired();

            modelBuilder
                .Property(x => x.ClearanceStatus)
                .IsRequired();

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
                .HasIndex(x => x.RegistrationNo, "IX_VehicleDetails_RegistrationNo")
                .IsUnique();

            modelBuilder
                .HasOne(x => x.Owner)
                .WithMany(x => x.VehicleDetails)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleDetails_OwnerDetails");

            modelBuilder
                .HasOne(x => x.City)
                .WithMany(x => x.VehicleDetails)
                .HasForeignKey(x => x.RegistrationCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleDetails_City");

            modelBuilder
                .HasOne(x => x.Vehicle)
                .WithMany(x => x.VehicleDetails)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleDetails_Vehicles");

            modelBuilder
                .ToTable("VehicleDetails");
        }
    }
}