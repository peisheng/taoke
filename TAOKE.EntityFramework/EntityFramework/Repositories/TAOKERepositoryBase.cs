using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace TAOKE.EntityFramework.Repositories
{
    public abstract class TAOKERepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TAOKEDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TAOKERepositoryBase(IDbContextProvider<TAOKEDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TAOKERepositoryBase<TEntity> : TAOKERepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TAOKERepositoryBase(IDbContextProvider<TAOKEDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
