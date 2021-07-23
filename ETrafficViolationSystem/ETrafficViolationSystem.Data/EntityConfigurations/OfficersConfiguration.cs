using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class OfficersConfiguration : IEntityTypeConfiguration<Officers>
    {
        public void Configure(EntityTypeBuilder<Officers> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.UserId);

            modelBuilder
                .Property(x => x.UserId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.OfficerId)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

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
                .Property(x => x.Cnic)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(15);

            modelBuilder
                .Property(x => x.Dob)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder
                .Property(x => x.Gender)
                .IsRequired();

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
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.BloodGroupId)
                .IsRequired()
                .HasColumnType("tinyint");

            modelBuilder
                .Property(x => x.DesignationId)
                .IsRequired()
                .HasColumnType("tinyint");

            modelBuilder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.OfficerImage)
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
                .HasIndex(x => x.Cnic, "IX_Officers_Cnic")
                .IsUnique();

            modelBuilder
                .HasIndex(x => x.Email, "IX_Officers_Email")
                .IsUnique();

            modelBuilder
                .HasIndex(x => x.UserId, "IX_Officers_UserId")
                .IsUnique();

            modelBuilder
                .HasOne(x => x.City)
                .WithMany(x => x.Officers)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Officers_City");

            modelBuilder
                .HasOne(x => x.Designation)
                .WithMany(x => x.Officers)
                .HasForeignKey(x => x.DesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Officers_Designation");

            modelBuilder
                .HasOne(x => x.User)
                .WithOne(x => x.Officer)
                .HasForeignKey<Officers>(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Officers_Users");

            modelBuilder
                .ToTable("Officers");
        }
    }
}