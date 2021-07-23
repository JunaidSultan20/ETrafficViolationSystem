using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class StatesConfiguration : IEntityTypeConfiguration<States>
    {
        public void Configure(EntityTypeBuilder<States> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.StateId);

            modelBuilder
                .Property(x => x.StateId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.StateTitle)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.CountryId)
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
                .HasIndex(x => x.StateTitle, "IX_States_StateTitle")
                .IsUnique();

            modelBuilder
                .HasOne(x => x.Country)
                .WithMany(x => x.States)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_States_Country");

            modelBuilder
                .ToTable("States");
        }
    }
}