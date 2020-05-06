using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace MySqlTest.Models
{
    public partial class consoledbContext : DbContext
    {
        public consoledbContext()
        {
        }

        public consoledbContext(DbContextOptions<consoledbContext> options)
            : base(options)
        {
        }


        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });


        public virtual DbSet<Auditlogs> Auditlogs { get; set; }
        public virtual DbSet<Correlationentitys> Correlationentitys { get; set; }
        public virtual DbSet<Crontasklogs> Crontasklogs { get; set; }
        public virtual DbSet<Crontasks> Crontasks { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Jobinstancelogs> Jobinstancelogs { get; set; }
        public virtual DbSet<Jobinstances> Jobinstances { get; set; }
        public virtual DbSet<Licensebindings> Licensebindings { get; set; }
        public virtual DbSet<Licensesapplys> Licensesapplys { get; set; }
        public virtual DbSet<Licensesettings> Licensesettings { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Packageversions> Packageversions { get; set; }
        public virtual DbSet<Phonetokens> Phonetokens { get; set; }
        public virtual DbSet<Resourcegroups> Resourcegroups { get; set; }
        public virtual DbSet<Robots> Robots { get; set; }
        public virtual DbSet<Roleassignments> Roleassignments { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Tenants> Tenants { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Uploadrecords> Uploadrecords { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workflowrobots> Workflowrobots { get; set; }
        public virtual DbSet<Workflows> Workflows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=42.159.226.184;port=3306;database=consoledb;uid=consoleuser;pwd=Encoo123!@#;sslmode=Preferred", x => x.ServerVersion("8.0.19-mysql"));
            }

            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Auditlogs>(entity =>
              {
                  entity.ToTable("auditlogs");

                  entity.Property(e => e.Id)
                      
                      ;

                  entity.Property(e => e.ApplicationName)
                      .HasColumnType("varchar(150)")
                      
                      ;

                  entity.Property(e => e.BrowserInfo)
                      .HasColumnType("longtext")
                      
                      ;

                  entity.Property(e => e.ClientIpAddress)
                      .HasColumnType("varchar(50)")
                      
                      ;

                  entity.Property(e => e.ClientName)
                      .HasColumnType("varchar(150)")
                      
                      ;

                  entity.Property(e => e.CreatorUserId)
                      
                      ;

                  entity.Property(e => e.CreatorUserName)
                      .HasColumnType("varchar(50)")
                      
                      ;

                  entity.Property(e => e.DeleterUserId)
                      
                      ;

                  entity.Property(e => e.Description)
                      .HasColumnType("longtext")
                      
                      ;

                  entity.Property(e => e.EntityType)
                      .HasColumnType("varchar(150)")
                      
                      ;

                  entity.Property(e => e.ExtraProperties)
                      .HasColumnType("longtext")
                      
                      ;

                  entity.Property(e => e.GroupId)
                      
                      ;

                  entity.Property(e => e.HttpMethod)
                      .HasColumnType("varchar(10)")
                      
                      ;

                  entity.Property(e => e.LastModifierUserId)
                      
                      ;

                  entity.Property(e => e.MacAddress)
                      .HasColumnType("varchar(50)")
                      
                      ;

                  entity.Property(e => e.Parameters)
                      .HasColumnType("longtext")
                      
                      ;

                  entity.Property(e => e.TenantId)
                      
                      ;

                  entity.Property(e => e.TenantName)
                      .HasColumnType("varchar(150)")
                      
                      ;

                  entity.Property(e => e.Url)
                      .HasColumnType("varchar(500)")
                      
                      ;
              });

            modelBuilder.Entity<Correlationentitys>(entity =>
            {
                entity.ToTable("correlationentitys");

                entity.HasIndex(e => e.AuditLogId)
                    .HasName("IX_CorrelationEntitys_AuditLogId");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.AuditLogId)
                    
                    ;

                entity.Property(e => e.EntityId)
                    
                    ;

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(150)")
                    
                    ;

                entity.HasOne(d => d.AuditLog)
                    .WithMany(p => p.Correlationentitys)
                    .HasForeignKey(d => d.AuditLogId)
                    .HasConstraintName("FK_CorrelationEntitys_AuditLogs_AuditLogId");
            });

            modelBuilder.Entity<Crontasklogs>(entity =>
            {
                entity.ToTable("crontasklogs");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreationDateTime).HasDefaultValueSql("'0001-01-01 00:00:00.000000'");

                entity.Property(e => e.CronTaskId)
                    
                    ;

                entity.Property(e => e.GroupId)
                    
                    ;

                entity.Property(e => e.Message)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.OperatorUserId)
                    
                    ;

                entity.Property(e => e.OperatorUserName)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Crontasks>(entity =>
            {
                entity.ToTable("crontasks");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.CronExpression)
                    .HasColumnType("varchar(64)")
                    
                    ;

                entity.Property(e => e.GroupId)
                    
                    ;

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(128)")
                    
                    ;

                entity.Property(e => e.Remark)
                    .HasColumnType("varchar(256)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.Property(e => e.UserTimeZoneInfoId)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.WorkflowId)
                    
                    ;

                entity.Property(e => e.WorkflowName)
                    .HasColumnType("varchar(256)")
                    
                    ;
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    
                    ;

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    
                    ;
            });

            modelBuilder.Entity<Jobinstancelogs>(entity =>
            {
                entity.ToTable("jobinstancelogs");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.Description)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.ImageBlobUri)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.JobId)
                    
                    ;

                entity.Property(e => e.Level)
                    .HasColumnType("varchar(16)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Jobinstances>(entity =>
            {
                entity.ToTable("jobinstances");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.GroupId)
                    
                    ;

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(256)")
                    
                    ;

                entity.Property(e => e.PackageName)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.PackageVersion)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.PackageVersionId)
                    
                    ;

                entity.Property(e => e.RobotId)
                    
                    ;

                entity.Property(e => e.RobotName)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(256)")
                    
                    ;

                entity.Property(e => e.Variables)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.WorkflowId)
                    
                    ;
            });

            modelBuilder.Entity<Licensebindings>(entity =>
            {
                entity.ToTable("licensebindings");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.Code)
                    .HasColumnType("varchar(100)")
                    
                    ;

                entity.Property(e => e.CreatorUser)
                    .HasColumnType("varchar(25)")
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Licensesapplys>(entity =>
            {
                entity.ToTable("licensesapplys");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    
                    ;

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Licensesettings>(entity =>
            {
                entity.ToTable("licensesettings");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.Code)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.CreatorUser)
                    .HasColumnType("varchar(25)")
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.ToTable("packages");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.GroupId)
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.Property(e => e.UploadFile)
                    .HasColumnType("varchar(150)")
                    
                    ;
            });

            modelBuilder.Entity<Packageversions>(entity =>
            {
                entity.ToTable("packageversions");

                entity.HasIndex(e => e.CreatorUserId)
                    .HasName("IX_PackageVersions_CreatorUserId");

                entity.HasIndex(e => e.PackageId)
                    .HasName("IX_PackageVersions_PackageId");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    
                    ;

                entity.Property(e => e.GroupId)
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.PackageId)
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    
                    ;

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.Packageversions)
                    .HasForeignKey(d => d.CreatorUserId)
                    .HasConstraintName("FK_PackageVersions_Users_CreatorUserId");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Packageversions)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PackageVersions_Packages_PackageId");
            });

            modelBuilder.Entity<Phonetokens>(entity =>
            {
                entity.ToTable("phonetokens");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(20)")
                    
                    ;

                entity.Property(e => e.LatestToken)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    
                    ;

                entity.Property(e => e.Purpose)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    
                    ;
            });

            modelBuilder.Entity<Resourcegroups>(entity =>
            {
                entity.ToTable("resourcegroups");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Robots>(entity =>
            {
                entity.ToTable("robots");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.DomainUsers)
                    .HasColumnType("varchar(1024)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.GroupId)
                    
                    ;

                entity.Property(e => e.MachineCode)
                    .HasColumnType("varchar(512)")
                    
                    ;

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    
                    ;

                entity.Property(e => e.Remark)
                    .HasColumnType("varchar(512)")
                    
                    ;

                entity.Property(e => e.RobotCode)
                    
                    ;

                entity.Property(e => e.Tags)
                    .HasColumnType("varchar(512)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.Property(e => e.Version)
                    .HasColumnType("varchar(32)")
                    
                    ;
            });

            modelBuilder.Entity<Roleassignments>(entity =>
            {
                entity.ToTable("roleassignments");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleAssignments_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_RoleAssignments_UserId");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.RoleId)
                    
                    ;

                entity.Property(e => e.ScopeId)
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.Property(e => e.UserId)
                    
                    ;

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Roleassignments)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleAssignments_Roles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roleassignments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_RoleAssignments_Users_UserId");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    
                    ;

                entity.Property(e => e.DisplayName)
                    .HasColumnType("varchar(50)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            modelBuilder.Entity<Tenants>(entity =>
            {
                entity.ToTable("tenants");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(100)")
                    
                    ;
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("token");

                entity.HasIndex(e => e.Account)
                    .HasName("IX_Token_Account")
                    .IsUnique();

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    
                    ;

                entity.Property(e => e.LastToken)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    
                    ;

                entity.Property(e => e.Purpose)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    
                    ;

                entity.Property(e => e.TokenType)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    
                    ;
            });

            modelBuilder.Entity<Uploadrecords>(entity =>
            {
                entity.ToTable("uploadrecords");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.FileName)
                    .HasColumnType("varchar(512)")
                    
                    ;

                entity.Property(e => e.Product)
                    .HasColumnType("varchar(128)")
                    
                    ;

                entity.Property(e => e.UploadUser)
                    .HasColumnType("varchar(128)")
                    
                    ;

                entity.Property(e => e.Version)
                    .HasColumnType("varchar(128)")
                    
                    ;
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_Users_RoleId");

                entity.HasIndex(e => e.TenantId)
                    .HasName("IX_Users_TenantId");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(50)")
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("varchar(100)")
                    
                    ;

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(20)")
                    
                    ;

                entity.Property(e => e.RoleId)
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles_RoleId");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Users_Tenants_TenantId");
            });

            modelBuilder.Entity<Workflowrobots>(entity =>
            {
                entity.ToTable("workflowrobots");

                entity.HasIndex(e => e.WorkflowId)
                    .HasName("IX_WorkflowRobots_WorkflowId");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.RobotId)
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;

                entity.Property(e => e.WorkflowId)
                    
                    ;

                entity.HasOne(d => d.Workflow)
                    .WithMany(p => p.Workflowrobots)
                    .HasForeignKey(d => d.WorkflowId)
                    .HasConstraintName("FK_WorkflowRobots_Workflows_WorkflowId");
            });

            modelBuilder.Entity<Workflows>(entity =>
            {
                entity.ToTable("workflows");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.CreatorUserId)
                    
                    ;

                entity.Property(e => e.DeleterUserId)
                    
                    ;

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    
                    ;

                entity.Property(e => e.ExtraProperties)
                    .HasColumnType("longtext")
                    
                    ;

                entity.Property(e => e.GroupId)
                    
                    ;

                entity.Property(e => e.LastModifierUserId)
                    
                    ;

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    
                    ;

                entity.Property(e => e.PackageId)
                    
                    ;

                entity.Property(e => e.PackageVersionId)
                    
                    ;

                entity.Property(e => e.TenantId)
                    
                    ;
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
