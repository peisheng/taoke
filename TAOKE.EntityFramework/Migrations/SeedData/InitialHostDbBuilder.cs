using TAOKE.EntityFramework;
using EntityFramework.DynamicFilters;

namespace TAOKE.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TAOKEDbContext _context;

        public InitialHostDbBuilder(TAOKEDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
