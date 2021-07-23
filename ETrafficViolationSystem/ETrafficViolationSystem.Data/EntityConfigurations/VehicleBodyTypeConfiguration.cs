using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class VehicleBodyTypeConfiguration : IEntityTypeConfiguration<VehicleBodyType>
    {
        public void Configure(EntityTypeBuilder<VehicleBodyType> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.BodyId);

            modelBuilder
                .Property(x => x.BodyId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.BodyType)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

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
                .ToTable("VehicleBodyType");
        }
    }
}