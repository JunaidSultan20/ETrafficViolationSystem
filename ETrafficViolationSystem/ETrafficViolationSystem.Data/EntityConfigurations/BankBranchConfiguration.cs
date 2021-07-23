using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class BankBranchConfiguration : IEntityTypeConfiguration<BankBranch>
    {
        public void Configure(EntityTypeBuilder<BankBranch> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.BankBranchId);

            modelBuilder
                .Property(x => x.BankBranchId)
                .IsRequired()
                .UseIdentityColumn(1, 1)
                .HasColumnType("int");

            modelBuilder
                .Property(x => x.BranchCode)
                .IsRequired()
                .HasColumnType("int");

            modelBuilder
                .Property(x => x.BranchTitle)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.BankId)
                .IsRequired()
                .HasColumnType("tinyint");

            modelBuilder
                .Property(x => x.CityId)
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
                .HasOne(x => x.Bank)
                .WithMany(x => x.BankBranches)
                .HasForeignKey(x => x.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankBranch_Banks");

            modelBuilder
                .HasOne(x => x.City)
                .WithMany(x => x.BankBranches)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankBranch_City");

            modelBuilder
                .ToTable("BankBranch");
        }
    }
}