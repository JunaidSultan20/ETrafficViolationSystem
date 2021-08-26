using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class InfractionsConfiguration : IEntityTypeConfiguration<Infractions>
    {
        public void Configure(EntityTypeBuilder<Infractions> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.InfractionId);

            modelBuilder
                .Property(x => x.InfractionId)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            modelBuilder
                .Property(x => x.Penalty)
                .IsRequired();

            modelBuilder
                .Property(x => x.Points)
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
                .HasColumnType("datetime");

            modelBuilder
                .ToTable("Infractions");
        }
    }
}