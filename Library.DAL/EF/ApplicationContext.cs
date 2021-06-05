using Library.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AuthorDocument> AuthorDocuments { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Udk> Udks { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<PublicationPeriods> PublicationPeriods { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).ModifiedOn = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entityEntry.Property("CreatedOn").IsModified = false;
                }
            }

            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}
