using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.ChallanNo);

            modelBuilder
                .Property(x => x.ChallanNo)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.TotalAmount)
                .IsRequired();

            modelBuilder
                .Property(x => x.PaidAmount)
                .IsRequired();

            modelBuilder
                .Property(x => x.DateTime)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder
                .Property(x => x.PaymentModeId)
                .IsRequired();

            modelBuilder
                .Property(x => x.BankBranchId)
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
                .HasOne(x => x.PaymentMode)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_PaymentMode");

            modelBuilder
                .HasOne(x => x.BankBranch)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.BankBranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_BankBranch");

            modelBuilder
                .ToTable("Payments");
        }
    }
}