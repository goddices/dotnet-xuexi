using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlTest.LocalTest
{
    public interface IEntity
    {

    }

    public class MyRobots : IEntity
    {
        public Guid Id { get; set; }
        public Guid RobotCode { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? GroupId { get; set; }

        public string ExtraProperties { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int RobotStatus { get; set; }
        public int RobotType { get; set; }
        public DateTime LastCommTime { get; set; }
        public DateTime CreationTime { get; set; }
        public string Version { get; set; }
        public string Tags { get; set; }
        public string DomainUsers { get; set; }
        public string MachineCode { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext()
        {

        }
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
              : base(options)
        {
        }
        public virtual DbSet<MyRobots> MyRobotSet { get; set; }

        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=dbtest;uid=root;pwd=123456;sslmode=Preferred", x =>
                {
                    x.ServerVersion("8.0.19-mysql");

                });
            }
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(LoggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MyRobots>(entity =>
            {
                entity.ToTable("robots");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired(false).HasMaxLength(256).HasCollation("utf8mb4");
            });

            modelBuilder.Entity<MyRobots>().HasData(
                new MyRobots { Id = Guid.NewGuid(), Name = "aabb" },
                new MyRobots { Id = Guid.NewGuid(), Name = "AABB" },
                new MyRobots { Id = Guid.NewGuid(), Name = "AaBb" },
                new MyRobots { Id = Guid.NewGuid(), Name = "aAbB" },
                new MyRobots { Id = Guid.NewGuid(), Name = "bbcc" },
                new MyRobots { Id = Guid.NewGuid(), Name = "zxcv" },
                new MyRobots { Id = Guid.NewGuid(), Name = "朱峰" },
                new MyRobots { Id = Guid.NewGuid(), Name = "朱峰11" },
                new MyRobots { Id = Guid.NewGuid(), Name = "朱峰阿阿不" },
                new MyRobots { Id = Guid.NewGuid(), Name = "朱峰aabb" },
                new MyRobots { Id = Guid.NewGuid(), Name = "朱峰cccccc" }
            );
        }


    }
}
