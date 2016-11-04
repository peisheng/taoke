using Abp.Authorization;
using TAOKE.Authorization.Roles;
using TAOKE.MultiTenancy;
using TAOKE.Users;

namespace TAOKE.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
