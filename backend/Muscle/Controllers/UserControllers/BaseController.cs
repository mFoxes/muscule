using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;

namespace Muscle.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IUserUnitOfWork _userUnitOfWork;

        public BaseController(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }
    }
}
