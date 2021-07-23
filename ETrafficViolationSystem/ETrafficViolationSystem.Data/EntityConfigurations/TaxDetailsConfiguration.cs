using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class TaxDetailsConfiguration : IEntityTypeConfiguration<TaxDetails>
    {
        public void Configure(EntityTypeBuilder<TaxDetails> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.TaxId);

            modelBuilder
                .Property(x => x.TaxId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.VehicleId)
                .IsRequired();

            modelBuilder
                .Property(x => x.OwnerId)
                .IsRequired();

            modelBuilder
                .Property(x => x.TaxFilerType)
                .IsRequired()
                .HasColumnType("tinyint");

            modelBuilder
                .Property(x => x.AmountPaid)
                .IsRequired();

            modelBuilder
                .Property(x => x.PaidDate)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder
                .Property(x => x.PaidUpToDate)
                .IsRequired()
                .HasColumnType("date");

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
                .HasOne(x => x.Owner)
                .WithMany(x => x.TaxDetails)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaxDetails_OwnerDetails");

            modelBuilder
                .HasOne(x => x.Vehicle)
                .WithMany(x => x.TaxDetails)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaxDetails_Vehicles");

            modelBuilder
                .ToTable("TaxDetails");
        }
    }
}