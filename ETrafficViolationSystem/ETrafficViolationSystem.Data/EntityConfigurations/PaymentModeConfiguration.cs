using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class PaymentModeConfiguration : IEntityTypeConfiguration<PaymentMode>
    {
        public void Configure(EntityTypeBuilder<PaymentMode> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.PaymentModeId);

            modelBuilder
                .Property(x => x.PaymentModeId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

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
                .HasIndex(x => x.Title, "IX_PaymentMode_Title")
                .IsUnique();

            modelBuilder
                .ToTable("PaymentMode");
        }
    }
}