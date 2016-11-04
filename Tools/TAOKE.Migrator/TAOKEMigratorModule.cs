using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using TAOKE.EntityFramework;

namespace TAOKE.Migrator
{
    [DependsOn(typeof(TAOKEDataModule))]
    public class TAOKEMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TAOKEDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}