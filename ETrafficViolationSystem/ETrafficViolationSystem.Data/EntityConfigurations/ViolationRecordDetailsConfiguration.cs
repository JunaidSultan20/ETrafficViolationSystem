using ETrafficViolationSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETrafficViolationSystem.Data.EntityConfigurations
{
    public class ViolationRecordDetailsConfiguration : IEntityTypeConfiguration<ViolationRecordDetails>
    {
        public void Configure(EntityTypeBuilder<ViolationRecordDetails> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder
                .Property(x => x.ViolationId)
                .IsRequired();

            modelBuilder
                .Property(x => x.InfractionId)
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
                .HasOne(x => x.Infraction)
                .WithMany(x => x.ViolationRecordDetails)
                .HasForeignKey(x => x.InfractionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViolationRecordDetails_Infractions");

            modelBuilder
                .HasOne(x => x.ViolationRecords)
                .WithMany(x => x.ViolationRecordDetails)
                .HasForeignKey(x => x.ViolationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViolationRecordDetails_ViolationRecords");

            modelBuilder
                .ToTable("ViolationRecordDetails");
        }
    }
}