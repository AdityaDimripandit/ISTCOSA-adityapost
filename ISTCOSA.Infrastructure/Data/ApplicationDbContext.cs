using ISTCOSA.Application.Interfaces;
using ISTCOSA.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ISTCOSA.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext,IApplicationDBContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet <UserRegister> userRegisters { get; set; }
        public DbSet <RollNumber> rollNumbers { get; set; }
        public DbSet <Batch> batches { get; set; }
        public DbSet <Country> countries { get; set; }
        public DbSet <State> states { get; set; }
        public DbSet <City> cities { get; set; }
        public DbSet <Company> companies { get; set; }
        public DbSet <Industry> industries { get; set; }
        public DbSet <Profession> professions { get; set; }
        public DbSet <UserWork> userWorks { get; set; }
        public DbSet <UserStudent> userStudents { get; set; }
        public DbSet <PostEmployment> postEmployments { get; set; }
        public DbSet <UserPersonalInformation> UserPersonalInformation { get; set; }
        public DbSet<PostBusiness> postBusinesss { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Update(entity);
        }

        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Add(entity);
        }

        public void AddRange(params object[] entities)
        {
            base.AddRange(entities);
        }

        public void AddRange(IEnumerable<object> entities)
        {
            base.AddRange(entities);
        }

        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Remove(entity);
        }

        public void RemoveRange(params object[] entities)
        {
            base.RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<object> entities)
        {
            base.RemoveRange(entities);
        }

        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Attach(entity);
        }

        public void AttachRange(params object[] entities)
        {
            base.AttachRange(entities);
        }

        public void AttachRange(IEnumerable<object> entities)
        {
            base.AttachRange(entities);
        }

        public async Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
        {
            return await base.AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(params object[] entities)
        {
            await base.AddRangeAsync(entities);
        }

        public async Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
        {
            await base.AddRangeAsync(entities, cancellationToken);
        }

        public DatabaseFacade Database => base.Database;

        
    }
}
