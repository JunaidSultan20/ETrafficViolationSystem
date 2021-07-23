using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class VehicleClassConfiguration : IEntityTypeConfiguration<VehicleClass>
    {
        public void Configure(EntityTypeBuilder<VehicleClass> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.ClassId);

            modelBuilder
                .Property(x => x.ClassId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.ClassTitle)
                .IsRequired()
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
                .HasIndex(x => x.ClassTitle, "IX_VehicleClass_ClassTitle")
                .IsUnique();

            modelBuilder
                .ToTable("VehicleClass");
        }
    }
}