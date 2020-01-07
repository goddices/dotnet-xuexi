using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCoreDbFirst.Models
{
    public partial class SqlearnContext : DbContext
    {
        public SqlearnContext()
        {
        }

        public SqlearnContext(DbContextOptions<SqlearnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=sqlearn;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10);

                entity.Property(e => e.Teacherid).HasColumnName("teacherid");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.Teacherid)
                    .HasConstraintName("FK_course_teacher");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.Courseid)
                    .HasConstraintName("FK_store_course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.Studentid)
                    .HasConstraintName("FK_store_student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(10);

                entity.Property(e => e.Studentno)
                    .HasColumnName("studentno")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10);
            });
        }
    }
}
