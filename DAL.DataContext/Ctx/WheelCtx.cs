using System.Data.Entity.Core.Objects;
using BL.CORE;

namespace DAL.DataContext.Ctx
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class WheelCtx : DbContext, IDbContext
    {
        public WheelCtx()
            : base("name=WheelCtx")
        {
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<WheelCtx, DAL.DataContext.Migrations.Configuration>("WheelCtx"));
            Database.SetInitializer(new DAL.DataContext.Migrations.Configuration());
        }

        public virtual DbSet<Engineer> Engineers { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<TaskEngineer> TaskEngineers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet Set(Type entityType)
        {
            return (DbSet)this.Set(entityType);
        }

        public ObjectResult<TEntity> SpObjectResult<TEntity>() where TEntity : class
        {
            return  null;
        }
       
    }
}
