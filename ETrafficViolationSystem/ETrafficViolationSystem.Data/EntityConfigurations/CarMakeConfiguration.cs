using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class CarMakeConfiguration : IEntityTypeConfiguration<CarMake>
    {
        public void Configure(EntityTypeBuilder<CarMake> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.MakeId);

            modelBuilder
                .Property(x => x.MakeId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.MakeTitle)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.OriginCountryId)
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
                .HasOne(x => x.Country)
                .WithMany(x => x.CarMakes)
                .HasForeignKey(x => x.OriginCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarMake_Country");

            modelBuilder
                .ToTable("CarMake");
        }
    }
}