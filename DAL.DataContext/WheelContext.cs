using System.Data.Entity.Core.Objects;
using BL.CORE;

namespace DAL.DataContext
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WheelContext : DbContext, IDbContext
    {
        // Your context has been configured to use a 'WheelContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.DataContext.WheelContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WheelContext' 
        // connection string in the application configuration file.
        public WheelContext()
            : base("WheelContext")
        {
        }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        public DbSet<TaskEngineer> Tasks { get; set; }

        //public DbSet<Author> Authors { get; set; }

        public ObjectResult<TEntity> SpObjectResult<TEntity>() where TEntity : class
        {
            return null;
        }
    }

}