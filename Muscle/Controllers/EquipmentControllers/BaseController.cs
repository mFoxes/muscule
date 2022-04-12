using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;

namespace Muscle.Controllers.EquipmentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IEquipmentUnitOfWork _equipmentUnitOfWork;

        public BaseController(IEquipmentUnitOfWork equipmentUnitOfWork)
        {
            _equipmentUnitOfWork = equipmentUnitOfWork;
        }
    }
}
