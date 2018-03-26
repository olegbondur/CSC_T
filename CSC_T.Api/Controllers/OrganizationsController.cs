using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSC_T.Api.Models.ViewModel;
using CSC_T.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSC_T.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            await _organizationService.GetOrganizations();

            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrganization([FromBody] OrganizationViewModel organizationViewModel)
        {
            string email = User.Identity.Name;

            if (email == null)
                return Unauthorized();

            await _organizationService.CreateOrganizationAsync(email, organizationViewModel);
            return Ok();
        }
    }
}