using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.ModelId);

            modelBuilder
                .Property(x => x.ModelId)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            modelBuilder
                .Property(x => x.ModelTitle)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.ProductionYear)
                .IsRequired();

            modelBuilder
                .Property(x => x.MakeId)
                .IsRequired()
                .HasColumnType("smallint");

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
                .HasOne(x => x.CarMake)
                .WithMany(x => x.CarModels)
                .HasForeignKey(x => x.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarModel_CarMake");

            modelBuilder
                .ToTable("CarModel");
        }
    }
}