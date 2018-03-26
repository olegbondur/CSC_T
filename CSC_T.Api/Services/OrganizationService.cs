using CSC_T.Api.Models.ViewModel;
using CSC_T.Api.Services.Interfaces;
using CSC_T.BusinessLayer.DAL;
using CSC_T.BusinessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC_T.Api.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<OrganizationViewModel>> GetOrganizations()
        {
            return null;   
        }

        public Task<OrganizationViewModel> GetOrganization(int id)
        {
            return null;
        }

        public async Task CreateOrganizationAsync(string email, OrganizationViewModel organizationViewModel)
        {
            var user = await _userManager.FindByEmailAsync(email);

            using (_unitOfWork)
            {
                var organizations = _unitOfWork.OrganizationRepository;
                var organization = new Organization
                {
                    UserId = user.Id,
                    Name = organizationViewModel.Name,
                    Code = organizationViewModel.Code,
                    Type = organizationViewModel.Type
                };
                organizations.Add(organization);
                await _unitOfWork.SaveAsync();
            }
        }

        public Task UpdateOrganization(string email, int OrganizationId, OrganizationViewModel organizationViewModel)
        {
            return null;
        }

        public Task DeleteOrganization(string email, int organizationId)
        {
            return null;
        }
    }
}
