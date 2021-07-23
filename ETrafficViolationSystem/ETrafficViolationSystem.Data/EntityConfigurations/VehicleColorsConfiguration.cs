using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class VehicleColorsConfiguration : IEntityTypeConfiguration<VehicleColors>
    {
        public void Configure(EntityTypeBuilder<VehicleColors> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.ColorId);

            modelBuilder
                .Property(x => x.ColorId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.ColorTypeId)
                .IsRequired();

            modelBuilder
                .Property(x => x.ColorName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.ColorCode)
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
                .HasOne(x => x.VehicleColorType)
                .WithMany(x => x.VehicleColors)
                .HasForeignKey(x => x.ColorTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleColors_VehicleColorType");

            modelBuilder
                .ToTable("VehicleColors");
        }
    }
}