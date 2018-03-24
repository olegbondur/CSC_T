using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CSC_T.BusinessLayer;
using CSC_T.BusinessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSC_T.Api.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly CSCDbContext _appDbContext;

        public DashboardController(UserManager<BaseUser> userManager, CSCDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        // GET api/dashboard/home
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var user = await _appDbContext.Users.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);

            return new OkObjectResult(new
            {
                Message = "This is secure API and user data!",
                user.Identity.FirstName,
                user.Identity.LastName,
                user.Identity.PictureUrl,
                user.Identity.FacebookId,
                user.Address
            });
        }
    }
}