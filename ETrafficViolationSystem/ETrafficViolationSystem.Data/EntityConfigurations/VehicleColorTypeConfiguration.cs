using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class VehicleColorTypeConfiguration : IEntityTypeConfiguration<VehicleColorType>
    {
        public void Configure(EntityTypeBuilder<VehicleColorType> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.ColorTypeId);

            modelBuilder
                .Property(x => x.ColorTypeId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.ColorTypeTitle)
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
                .ToTable("VehicleColorType");
        }
    }
}