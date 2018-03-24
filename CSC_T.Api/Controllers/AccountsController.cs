using AutoMapper;
using CSC_T.Api.Helpers;
using CSC_T.Api.Models;
using CSC_T.BusinessLayer;
using CSC_T.BusinessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSC_T.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly CSCDbContext _appDbContext;
        private readonly UserManager<BaseUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<BaseUser> userManager, IMapper mapper, CSCDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<BaseUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Users.AddAsync(new User { IdentityId = userIdentity.Id, Address = model.Address });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}