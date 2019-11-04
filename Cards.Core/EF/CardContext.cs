using System;
using Cards.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cards.Core.EF
{
    public class CardContext : DbContext
    {
        private IOptions<SqlSettings> _sqlSettings;

        public CardContext(DbContextOptions<CardContext> options, IOptions<SqlSettings> sqlSettings)
              : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RepeatRate> RepeatRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlSettings.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.CreatedAt).IsRequired();
            modelBuilder.Entity<Card>().Property(x => x.Word).IsRequired();
            modelBuilder.Entity<Card>().Property(x => x.Meaning).IsRequired();
            modelBuilder.Entity<Card>().Property(x => x.CreatedAt).IsRequired();
            modelBuilder.Entity<Card>().HasKey(x => x.Id);
            modelBuilder.Entity<Card>().HasOne<Category>(x => x.Category).WithMany(c => c.Cards).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Card>().HasOne<RepeatRate>(x => x.RepeatRate).WithMany(c => c.Cards).HasForeignKey(x => x.RepeatRateId); ;
            modelBuilder.Entity<Card>().HasOne<Mode>(x => x.Mode).WithMany(c => c.Cards).HasForeignKey(x => x.ModeId);
            modelBuilder.Entity<Card>().HasOne<User>(x => x.User).WithMany(c => c.Cards).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Note>().HasOne<User>(x => x.User).WithMany(c => c.Notes).HasForeignKey(x => x.UserId);

            modelBuilder.Seed();
        }
    }
}