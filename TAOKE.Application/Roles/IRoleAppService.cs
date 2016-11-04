using System.Threading.Tasks;
using Abp.Application.Services;
using TAOKE.Roles.Dto;

namespace TAOKE.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
