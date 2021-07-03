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

        public virtual DbSet<Mumbi.Domain.Entities.Action> Actions { get; set; }
        public virtual DbSet<ActionChild> ActionChildren { get; set; }
        public virtual DbSet<ChildHistory> ChildHistories { get; set; }
        public virtual DbSet<ChildInfo> ChildInfos { get; set; }
        public virtual DbSet<DadInfo> DadInfos { get; set; }
        public virtual DbSet<Diary> Diaries { get; set; }
        public virtual DbSet<Guidebook> Guidebooks { get; set; }
        public virtual DbSet<GuidebookMom> GuidebookMoms { get; set; }
        public virtual DbSet<GuidebookType> GuidebookTypes { get; set; }
        public virtual DbSet<InjectionSchedule> InjectionSchedules { get; set; }
        public virtual DbSet<MomInfo> MomInfos { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsMom> NewsMoms { get; set; }
        public virtual DbSet<NewsType> NewsTypes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PregnancyActivity> PregnancyActivities { get; set; }
        public virtual DbSet<PregnancyActivityType> PregnancyActivityTypes { get; set; }
        public virtual DbSet<PregnancyHistory> PregnancyHistories { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StandardIndex> StandardIndices { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<Tooth> Teeth { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserNotification> UserNotifications { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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
                    .HasConstraintName("FK_ActionChild_ChildInfo");
            });

            modelBuilder.Entity<ChildHistory>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.Date).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.ChildHistories)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChildHistory_ChildInfo");
            });

            modelBuilder.Entity<ChildInfo>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Birthday).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.EstimatedBornDate).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.MomId).IsUnicode(false);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);

                entity.HasOne(d => d.Mom)
                    .WithMany(p => p.ChildInfos)
                    .HasForeignKey(d => d.MomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChildInfo_MomInfo");
            });

            modelBuilder.Entity<DadInfo>(entity =>
            {
                entity.HasKey(e => e.MomId)
                    .HasName("PK_Dad");

                entity.Property(e => e.MomId).IsUnicode(false);

                entity.Property(e => e.Birthday).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);

                entity.HasOne(d => d.Mom)
                    .WithOne(p => p.DadInfo)
                    .HasForeignKey<DadInfo>(d => d.MomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DadInfo_MomInfo");
            });

            modelBuilder.Entity<Diary>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.PublicFlag).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Diaries)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diary_ChildInfo");
            });

            modelBuilder.Entity<Guidebook>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Guidebooks)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Guidebook_GuildbookType");
            });

            modelBuilder.Entity<GuidebookMom>(entity =>
            {
                entity.Property(e => e.GuidebookId).IsUnicode(false);

                entity.Property(e => e.MomId).IsUnicode(false);

                entity.HasOne(d => d.Guidebook)
                    .WithMany(p => p.GuidebookMoms)
                    .HasForeignKey(d => d.GuidebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GuidebookMom_Guidebook");

                entity.HasOne(d => d.Mom)
                    .WithMany(p => p.GuidebookMoms)
                    .HasForeignKey(d => d.MomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GuidebookMom_MomInfo");
            });

            modelBuilder.Entity<InjectionSchedule>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.InjectionDate).IsUnicode(false);

                entity.Property(e => e.MomId).IsUnicode(false);

                entity.Property(e => e.NextInjectionDate).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.HasOne(d => d.Mom)
                    .WithMany(p => p.InjectionSchedules)
                    .HasForeignKey(d => d.MomId)
                    .HasConstraintName("FK_InjectionSchedule_MomInfo");

                entity.HasOne(d => d.Vaccine)
                    .WithMany(p => p.InjectionSchedules)
                    .HasForeignKey(d => d.VaccineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InjectionSchedule_Vaccine");
            });

            modelBuilder.Entity<MomInfo>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.BloodGroup).IsUnicode(false);

                entity.Property(e => e.DadId).IsUnicode(false);

                entity.Property(e => e.RhBloodGroup).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.MomInfo)
                    .HasForeignKey<MomInfo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MomInfo_User");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_News_NewsType");
            });

            modelBuilder.Entity<NewsMom>(entity =>
            {
                entity.Property(e => e.MomId).IsUnicode(false);

                entity.Property(e => e.NewsId).IsUnicode(false);

                entity.HasOne(d => d.Mom)
                    .WithMany(p => p.NewsMoms)
                    .HasForeignKey(d => d.MomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsMom_MomInfo");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.NewsMoms)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsMom_News");
            });

            modelBuilder.Entity<PregnancyActivity>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.MediaFileUrl).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.PregnancyActivities)
                    .HasForeignKey(d => d.ChildId)
                    .HasConstraintName("FK_PregnancyActivity_ChildInfo");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PregnancyActivities)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PregnancyActivity_PregnancyActivityType");
            });

            modelBuilder.Entity<PregnancyActivityType>(entity =>
            {
                entity.Property(e => e.DelFlag).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PregnancyHistory>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.Date).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.PregnancyHistories)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PregnancyHistory_ChildInfo");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.Property(e => e.EnabledFlag).HasDefaultValueSql("((0))");

                entity.Property(e => e.Frequency).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reminder_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.RoleName).IsUnicode(false);
            });

            modelBuilder.Entity<StandardIndex>(entity =>
            {
                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.Unit).IsUnicode(false);
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.Property(e => e.FcmToken).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Token_User");
            });

            modelBuilder.Entity<Tooth>(entity =>
            {
                entity.Property(e => e.ChildId).IsUnicode(false);

                entity.Property(e => e.GrowTime).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Teeth)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tooth_ChildInfo");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Birthday).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UserInfo)
                    .HasForeignKey<UserInfo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInfo_User");
            });

            modelBuilder.Entity<UserNotification>(entity =>
            {
                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotification_Notification");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserNotifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotification_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
