using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class VehiclesConfiguration : IEntityTypeConfiguration<Vehicles>
    {
        public void Configure(EntityTypeBuilder<Vehicles> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.VehicleId);

            modelBuilder
                .Property(x => x.VehicleId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.ChassisNo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.EngineNo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.FrameNo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.MakeId)
                .IsRequired();

            modelBuilder
                .Property(x => x.Year)
                .IsRequired();

            modelBuilder
                .Property(x => x.CategoryId)
                .IsRequired();

            modelBuilder
                .Property(x => x.BodyTypeId)
                .IsRequired();

            modelBuilder
                .Property(x => x.ClassId)
                .IsRequired();

            modelBuilder
                .Property(x => x.Capacity)
                .IsRequired();

            modelBuilder
                .Property(x => x.HorsePower)
                .IsRequired();

            modelBuilder
                .Property(x => x.Cylinders)
                .IsRequired();

            modelBuilder
                .Property(x => x.ColorId)
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
                .HasIndex(x => x.ChassisNo, "IX_Vehicles_ChassisNo")
                .IsUnique();

            modelBuilder
                .HasIndex(x => x.EngineNo, "IX_Vehicles_EngineNo")
                .IsUnique();
            
            modelBuilder
                .HasIndex(x => x.FrameNo, "IX_Vehicles_FrameNo")
                .IsUnique();

            modelBuilder
                .HasOne(x => x.VehicleBodyType)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.BodyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicles_VehicleBodyType");

            modelBuilder
                .HasOne(x => x.VehicleClass)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicles_VehicleClass");

            modelBuilder
                .HasOne(x => x.VehicleColor)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicles_VehicleColors");

            modelBuilder
                .HasOne(x => x.CarMake)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicles_CarMake");

            modelBuilder
                .ToTable("Vehicles");
        }
    }
}