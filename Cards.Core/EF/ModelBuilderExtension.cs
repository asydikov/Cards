using System;
using System.Linq;
using Cards.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Core.EF
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category() { Id = Guid.NewGuid(), Name = "Word", Sort = 1 },
                 new Category() { Id = Guid.NewGuid(), Name = "Phrase", Sort = 2 },
                 new Category() { Id = Guid.NewGuid(), Name = "Sentence", Sort = 3 });

            modelBuilder.Entity<RepeatRate>().HasData(
                new RepeatRate() { Id = Guid.NewGuid(), Name = "Daily", Sort = 1 },
                new RepeatRate() { Id = Guid.NewGuid(), Name = "Two Days", Sort = 2 },
                new RepeatRate() { Id = Guid.NewGuid(), Name = "Three Days", Sort = 3 },
                new RepeatRate() { Id = Guid.NewGuid(), Name = "Weekly", Sort = 4 },
                new RepeatRate() { Id = Guid.NewGuid(), Name = "Two Weeks", Sort = 5 },
                new RepeatRate() { Id = Guid.NewGuid(), Name = "Monthly", Sort = 6 });

            modelBuilder.Entity<Mode>().HasData(
                new Mode() { Id = Guid.NewGuid(), PrimaryLang = "En", SecondaryLang = "Fr", Sort = 1 },
                new Mode() { Id = Guid.NewGuid(), PrimaryLang = "Fr", SecondaryLang = "En", Sort = 2 });
        }

    }
}