using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RemoteCarDiagz.Shared.Domain;

namespace RemoteCarDiagz.Server.Data
{
    public class RemoteCarDiagzContext : DbContext
    {
        public RemoteCarDiagzContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}remotecardiagz.db";
        }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<ProvisioningConfiguration> GrafanaConfig { get; set; }

        public string DbPath { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var allPidValues = Enum.GetValues<PidIdsEnum>().Select(x => new Measurement() { Value = x, IsAvailable = true });
            builder.Entity<Measurement>().HasData(allPidValues);
            base.OnModelCreating(builder);
        }
    }
}