using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TAOKE.MultiTenancy.Dto;

namespace TAOKE.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
