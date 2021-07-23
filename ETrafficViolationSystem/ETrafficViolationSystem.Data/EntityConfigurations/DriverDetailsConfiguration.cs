using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class DriverDetailsConfiguration : IEntityTypeConfiguration<DriverDetails>
    {
        public void Configure(EntityTypeBuilder<DriverDetails> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.DriverId);

            modelBuilder
                .Property(x => x.DriverId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            modelBuilder
                .Property(x => x.MiddleName)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            modelBuilder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            modelBuilder
                .Property(x => x.FatherName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.CNIC)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(15);

            modelBuilder
                .Property(x => x.Dob)
                .IsRequired()
                .HasColumnType("datetime");

            modelBuilder
                .Property(x => x.Gender)
                .IsRequired()
                .HasColumnType("tinyint");

            modelBuilder
                .Property(x => x.Religion)
                .IsRequired()
                .HasColumnType("tinyint");

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
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.BloodGroupId)
                .IsRequired()
                .HasColumnType("tinyint");

            modelBuilder
                .Property(x => x.Height)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(5);

            modelBuilder
                .Property(x => x.Mark)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.Disability)
                .IsRequired();

            modelBuilder
                .Property(x => x.DisabilityDescription)
                .IsRequired(false)
                .HasColumnType("varchar");

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
                .HasIndex(x => x.CNIC, "IX_DriverDetails_CNIC")
                .IsUnique();

            modelBuilder
                .HasIndex(x => x.Email, "IX_DriverDetails_Email")
                .IsUnique();

            modelBuilder
                .HasOne(x => x.City)
                .WithMany(x => x.DriverDetails)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DriverDetails_City");

            modelBuilder
                .ToTable("DriverDetails");
        }
    }
}