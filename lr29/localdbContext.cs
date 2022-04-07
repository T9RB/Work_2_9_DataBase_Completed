using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lr29
{
    public partial class localdbContext : DbContext
    {
        public localdbContext()
        {
            Database.EnsureCreated();
        }

        public localdbContext(DbContextOptions<localdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=localdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.NameStatus).HasColumnName("Name_Status");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasIndex(e => e.Statusid, "IX_Tasks_Statusid");

                entity.HasIndex(e => e.AcceptorId, "IX_Tasks_UsersUserid");

                entity.Property(e => e.DatePub).HasColumnName("Date_Pub");

                entity.Property(e => e.DescriptionTask).HasColumnName("Description_Task");

                entity.Property(e => e.NameTask).HasColumnName("Name_Task");

                entity.HasOne(d => d.Acceptor)
                    .WithMany(p => p.TaskAcceptors)
                    .HasForeignKey(d => d.AcceptorId)
                    .HasConstraintName("FK_Tasks_Users_UsersUserid");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TaskCreators)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_Users");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Statusid);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FName).HasColumnName("F_Name");

                entity.Property(e => e.LName).HasColumnName("L_Name");

                entity.Property(e => e.NumberPhone).HasColumnName("Number_Phone");

                entity.Property(e => e.SName).HasColumnName("S_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
