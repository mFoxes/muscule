using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Muscle.Controllers.EquipmentControllers
{
    public class BuildingController : BaseController
    {
        public BuildingController(IEquipmentUnitOfWork equipmentUnitOfWork)
            : base(equipmentUnitOfWork)
        {

        }

        [HttpGet]
        [Route("GetAllBuildings", Name = "GetAllBuildings")]
        public async Task<IActionResult> GetAllBuildings()
        {
            var result = await _equipmentUnitOfWork.BuildingRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildingById(int id)
        {
            var res = await _equipmentUnitOfWork.BuildingRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddBuilding", Name = "AddBuilding")]
        public async Task<IActionResult> AddBuilding(Building building)
        {
            var res = await _equipmentUnitOfWork.BuildingRepository.AddAsync(building);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("AddRangeOfBuildings", Name = "AddRangeOfBuildings")]
        public async Task<IActionResult> AddRange(IEnumerable<Building> buildings)
        {
            var res = await _equipmentUnitOfWork.BuildingRepository.AddRangeAsync(buildings);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateBuilding", Name = "UpdateBuilding")]
        public async Task<IActionResult> Update(Building newBuilding, int id)
        {
            var buildingForUpdate = await _equipmentUnitOfWork.BuildingRepository.GetByIdAsync(id);
            if (buildingForUpdate == null)
                return BadRequest("Item does not exist");

            buildingForUpdate.Name = newBuilding.Name;

            var res = await _equipmentUnitOfWork.BuildingRepository.UpdateAsync(buildingForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteBuilding", Name = "DeleteBuilding")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _equipmentUnitOfWork.BuildingRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }
    }
}
