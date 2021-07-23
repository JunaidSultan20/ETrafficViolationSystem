using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn(1, 1)
                .HasColumnType("int");

            modelBuilder
                .Property(x => x.ExceptionMessage)
                .IsRequired()
                .HasColumnType("varchar");

            modelBuilder
                .Property(x => x.InnerException)
                .IsRequired()
                .HasColumnType("varchar");

            modelBuilder
                .Property(x => x.Url)
                .IsRequired()
                .HasColumnType("varchar");

            modelBuilder
                .Property(x => x.RemoteIp)
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
                .ToTable("ExceptionLog");
        }
    }
}