using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class OwnerDetailsConfiguration : IEntityTypeConfiguration<OwnerDetails>
    {
        public void Configure(EntityTypeBuilder<OwnerDetails> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.OwnerId);

            modelBuilder
                .Property(x => x.OwnerId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.MiddleName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.FatherName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.CNIC)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.Dob)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder
                .Property(x => x.Gender)
                .IsRequired()
                .HasColumnType("tinyint");

            modelBuilder
                .Property(x => x.Religion)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.PostalAddress)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.CityId)
                .IsRequired();

            modelBuilder
                .Property(x => x.PermanentAddress)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.MobileNumber)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            modelBuilder
                .Property(x => x.HomePhone)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            modelBuilder
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.OwnerImage)
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
                .HasIndex(x => x.CNIC, "IX_OwnerDetails_CNIC")
                .IsUnique();

            modelBuilder
                .HasOne(x => x.City)
                .WithMany(x => x.OwnerDetails)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OwnerDetails_City");

            modelBuilder
                .ToTable("OwnerDetails");
        }
    }
}