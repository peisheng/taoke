using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using TAOKE.Authorization.Roles;
using TAOKE.Entities;
using TAOKE.MultiTenancy;
using TAOKE.Users;

namespace TAOKE.EntityFramework
{
    public class TAOKEDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

            //public IDbSet<Student> Students { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TAOKEDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TAOKEDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TAOKEDbContext since ABP automatically handles it.
         */
        public TAOKEDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TAOKEDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

         
    }
}
