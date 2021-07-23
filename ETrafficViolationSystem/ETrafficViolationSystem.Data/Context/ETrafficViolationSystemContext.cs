using ETrafficViolationSystem.Entities.Models;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ETrafficViolationSystem.Data.EntityConfigurations;

namespace ETrafficViolationSystem.Data.Context
{
    public class ETrafficViolationSystemContext : IdentityDbContext<Users, Roles, int, UserClaim, UserRole, UserLogin, RoleClaims, UserTokens>
    {
        public ETrafficViolationSystemContext(DbContextOptions<ETrafficViolationSystemContext> options) : base(options) { }

        public virtual DbSet<BankBranch> BankBranch { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<CarMake> CarMake { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<DriverDetails> DriverDetails { get; set; }
        public virtual DbSet<ExceptionLog> ExceptionLog { get; set; }
        public virtual DbSet<Infractions> Infractions { get; set; }
        public virtual DbSet<LicenseRecords> LicenseRecords { get; set; }
        public virtual DbSet<LicenseSubTypes> LicenseSubTypes { get; set; }
        public virtual DbSet<LicenseTypes> LicenseTypes { get; set; }
        public virtual DbSet<Officers> Officers { get; set; }
        public virtual DbSet<OwnerDetails> OwnerDetails { get; set; }
        public virtual DbSet<PaymentMode> PaymentMode { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<TaxDetails> TaxDetails { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VehicleBodyType> VehicleBodyType { get; set; }
        public virtual DbSet<VehicleClass> VehicleClass { get; set; }
        public virtual DbSet<VehicleColors> VehicleColors { get; set; }
        public virtual DbSet<VehicleColorType> VehicleColorType { get; set; }
        public virtual DbSet<VehicleDetails> VehicleDetails { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<ViolationRecordDetails> ViolationRecordDetails { get; set; }
        public virtual DbSet<ViolationRecords> ViolationRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BankBranchConfiguration());
            modelBuilder.ApplyConfiguration(new BanksConfiguration());
            modelBuilder.ApplyConfiguration(new CarMakeConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DesignationConfiguration());
            modelBuilder.ApplyConfiguration(new DriverDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new ExceptionLogConfiguration());
            modelBuilder.ApplyConfiguration(new InfractionsConfiguration());
            modelBuilder.ApplyConfiguration(new LicenseRecordsConfiguration());
            modelBuilder.ApplyConfiguration(new LicenseSubTypesConfiguration());
            modelBuilder.ApplyConfiguration(new LicenseTypesConfiguration());
            modelBuilder.ApplyConfiguration(new OfficersConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentModeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsConfiguration());
            modelBuilder.ApplyConfiguration(new RoleClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new StatesConfiguration());
            modelBuilder.ApplyConfiguration(new TaxDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokensConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleBodyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleClassConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleColorsConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleColorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesConfiguration());
            modelBuilder.ApplyConfiguration(new ViolationRecordDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new ViolationRecordsConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }


    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETrafficViolationSystemContext>
    {
        public ETrafficViolationSystemContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../ETrafficViolationSystem.API/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ETrafficViolationSystemContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ETrafficViolationSystemContext(builder.Options);
        }
    }
}