using CSC_T.Api.Models.ViewModel;
using CSC_T.BusinessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSC_T.Api.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationViewModel>> GetOrganizations();
        Task<OrganizationViewModel> GetOrganization(int id);
        Task CreateOrganizationAsync(string email, OrganizationViewModel organizationViewModel);
        Task UpdateOrganization(string email, int OrganizationId, OrganizationViewModel organizationViewModel);
        Task DeleteOrganization(string email, int organizationId);
    }
}
