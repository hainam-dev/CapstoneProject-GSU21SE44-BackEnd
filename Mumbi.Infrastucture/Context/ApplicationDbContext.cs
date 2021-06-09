using Microsoft.EntityFrameworkCore;
using Mumbi.Domain.Entities;

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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SE130022\\SQLEXPRESS;Database=Mumbi_Capstone;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.HasOne(d => d.EmailNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Mom");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
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

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Child)
                    .HasForeignKey<Child>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Children_Pregnancy");

                entity.HasOne(d => d.Mom)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.MomId)
                    .HasConstraintName("FK_Children_Mom");
            });

            modelBuilder.Entity<Dad>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Dad)
                    .HasForeignKey<Dad>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dad_Account1");
            });

            modelBuilder.Entity<Diary>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.IsPublic).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Diaries)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diary_Children");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.FromHospital).IsUnicode(false);

                entity.Property(e => e.FullName).IsFixedLength(true);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.Id)
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
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.AccountId).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);
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

                entity.Property(e => e.IsDone)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

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
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuitableAge).IsUnicode(false);
            });

            modelBuilder.Entity<PregnancyInformation>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);
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
                entity.Property(e => e.Id).ValueGeneratedNever();

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
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.staff)
                    .HasForeignKey<staff>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
