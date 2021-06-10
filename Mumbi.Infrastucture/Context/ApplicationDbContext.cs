using Microsoft.EntityFrameworkCore;
using Mumbi.Domain.Entities;
using System;


#nullable disable

namespace Mumbi.Infrastucture.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Domain.Entities.Action> Actions { get; set; }
        public virtual DbSet<ActionChild> ActionChildren { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Dad> Dads { get; set; }
        public virtual DbSet<Diary> Diaries { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Guidebook> Guidebooks { get; set; }
        public virtual DbSet<GuildbookType> GuildbookTypes { get; set; }
        public virtual DbSet<InjectionSchedule> InjectionSchedules { get; set; }
        public virtual DbSet<Mom> Moms { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsType> NewsTypes { get; set; }
        public virtual DbSet<PregnancyActivity> PregnancyActivities { get; set; }
        public virtual DbSet<PregnancyActivityType> PregnancyActivityTypes { get; set; }
        public virtual DbSet<PregnancyInformation> PregnancyInformations { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<Tooth> Teeth { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<ActionChild>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionChildren)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionChild_Action");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.ActionChildren)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionChild_Child");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.DadId).IsUnicode(false);

                entity.Property(e => e.Fingertips).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.MomId).IsUnicode(false);

                entity.Property(e => e.Nickname).IsFixedLength(true);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);

                entity.HasOne(d => d.Dad)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.DadId)
                    .HasConstraintName("FK_Children_Dad");

                entity.HasOne(d => d.Mom)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.MomId)
                    .HasConstraintName("FK_Children_Mom");
            });

            modelBuilder.Entity<Dad>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);
            });

            modelBuilder.Entity<Diary>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Diaries)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diary_Children");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Doctor__349DA5A69BAFC2B6");

                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.FromHospital).IsUnicode(false);

                entity.Property(e => e.FullName).IsFixedLength(true);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Account");
            });

            modelBuilder.Entity<Guidebook>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.EstimateFinishTime).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Guidebooks)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Guidebook_GuildbookType");
            });

            modelBuilder.Entity<InjectionSchedule>(entity =>
            {
                entity.Property(e => e.ChildrenId).IsUnicode(false);

                entity.Property(e => e.MotherId).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.VaccineId).IsUnicode(false);

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.InjectionSchedules)
                    .HasForeignKey(d => d.ChildrenId)
                    .HasConstraintName("FK_InjectionSchedule_Children");

                entity.HasOne(d => d.Mother)
                    .WithMany(p => p.InjectionSchedules)
                    .HasForeignKey(d => d.MotherId)
                    .HasConstraintName("FK_InjectionSchedule_Mom");

                entity.HasOne(d => d.Vaccine)
                    .WithMany(p => p.InjectionSchedules)
                    .HasForeignKey(d => d.VaccineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InjectionSchedule_Vaccine");
            });

            modelBuilder.Entity<Mom>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Mom__349DA5A68520F284");

                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Mom)
                    .HasForeignKey<Mom>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Mom");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.EstimateFinishTime).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_News_NewsType");
            });

            modelBuilder.Entity<PregnancyActivity>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.IsDone).IsUnicode(false);

                entity.Property(e => e.MediaFile).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.PregnancyActivities)
                    .HasForeignKey(d => d.ChildId)
                    .HasConstraintName("FK_Activity_Children");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PregnancyActivities)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Activity_ActivityType");
            });

            modelBuilder.Entity<PregnancyActivityType>(entity =>
            {
                entity.Property(e => e.SuitableAge).IsUnicode(false);
            });

            modelBuilder.Entity<PregnancyInformation>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PregnancyInformation)
                    .HasForeignKey<PregnancyInformation>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Children_Pregnancy");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.Frequency).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reminder_Account");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.Token1).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Token_Account");
            });

            modelBuilder.Entity<Tooth>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Tooth)
                    .HasForeignKey<Tooth>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teeth_Child");
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Staff__349DA5A69F3B2D6C");

                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.staff)
                    .HasForeignKey<staff>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
