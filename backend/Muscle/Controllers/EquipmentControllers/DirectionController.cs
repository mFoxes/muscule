using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Controllers.EquipmentControllers
{
    public class DirectionController : BaseController
    {
        public DirectionController(IEquipmentUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("GetAllDirections", Name = "GetAllDirections")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _equipmentUnitOfWork.DirectionRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDirectionById", Name = "GetDirectionById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _equipmentUnitOfWork.DirectionRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddDirection", Name = "AddDirection")]
        public async Task<IActionResult> Add(Direction direction)
        {
            var res = await _equipmentUnitOfWork.DirectionRepository.AddAsync(direction);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("AddRangeOfDirections", Name = "AddRangeOfDirections")]
        public async Task<IActionResult> AddRange(IEnumerable<Direction> directions)
        {
            var res = await _equipmentUnitOfWork.DirectionRepository.AddRangeAsync(directions);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateDirection", Name = "UpdateDirection")]
        public async Task<IActionResult> Update(Direction newDirection, int id)
        {
            var directionForUpdate = await _equipmentUnitOfWork.DirectionRepository.GetByIdAsync(id);
            if (directionForUpdate == null)
                return BadRequest("Item does not exist");

            directionForUpdate.Name = newDirection.Name;
            directionForUpdate.Description = newDirection.Description;

            var res = await _equipmentUnitOfWork.DirectionRepository.UpdateAsync(directionForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteDirection", Name = "DeleteDirection")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _equipmentUnitOfWork.DirectionRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }
    }
}
