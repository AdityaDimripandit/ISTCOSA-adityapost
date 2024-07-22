using ISTCOSA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace ISTCOSA.Application.Interfaces
{
    public interface IApplicationDBContext
    {
        public DbSet<UserRegister> userRegisters { get; set; }
        public DbSet<RollNumber> rollNumbers { get; set; }
        public DbSet<Batch> batches { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Industry> industries { get; set; }
        public DbSet<Profession> professions { get; set; }
        public DbSet<UserWork> userWorks { get; set; }
        public DbSet<UserStudent> userStudents { get; set; }
        public DbSet<PostEmployment> postEmployments { get; set; }
        public DbSet<UserPersonalInformation> UserPersonalInformation { get; set; }
        public DbSet<PostBusiness> postBusinesss {  get; set; }
     



        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange(params object[] entities);
        void AddRange(IEnumerable<object> entities);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange(params object[] entities);
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        void AttachRange(params object[] entities);
        void AttachRange(IEnumerable<object> entities);
        Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task AddRangeAsync(params object[] entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
        DatabaseFacade Database { get; }

    }
}
