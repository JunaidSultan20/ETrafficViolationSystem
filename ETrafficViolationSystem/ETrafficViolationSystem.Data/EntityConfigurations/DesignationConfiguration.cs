using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class DesignationConfiguration : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.DesignationId);

            modelBuilder
                .Property(x => x.DesignationId)
                .IsRequired();

            modelBuilder
                .Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder
                .Property(x => x.ReportsTo);

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
                .ToTable("Designation");
        }
    }
}