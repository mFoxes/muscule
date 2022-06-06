using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using Muscle.Entities.DbSet.Dtos.DtosForEquipmentDb.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Controllers.EquipmentControllers
{
    public class EquipmentHallController : BaseController
    {
        public EquipmentHallController(IEquipmentUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        [HttpGet]
        [Route("GetAllEquipmentHalls", Name = "GetAllEquipmentHalls")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _equipmentUnitOfWork.EquipmentHallRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetEquipmentHallById", Name = "GetEquipmentHallById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _equipmentUnitOfWork.EquipmentHallRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddEquipmentHall", Name = "AddEquipmentHall")]
        public async Task<IActionResult> Add(EquipmentHallDto equipmentHall)
        {
            if(ModelState.IsValid)
            {
                var config = new MapperConfiguration(x => x.CreateMap<EquipmentHallDto, EquipmentHall>());
                var mapper = new Mapper(config);

                EquipmentHall newEquipmentHall = mapper.Map<EquipmentHallDto, EquipmentHall>(equipmentHall);

                var res = await _equipmentUnitOfWork.EquipmentHallRepository.AddAsync(newEquipmentHall);
                if (!res)
                    return BadRequest("Error while adding");
                await _equipmentUnitOfWork.Save();
                return Ok(res);
            }
            return BadRequest("Invalid input");
            
        }

        [HttpPost]
        [Route("AddRangeOfEquipmentHalls", Name = "AddRangeOfEquipmentHalls")]
        public async Task<IActionResult> AddRange(IEnumerable<EquipmentHall> equipmentHalls)
        {
            var res = await _equipmentUnitOfWork.EquipmentHallRepository.AddRangeAsync(equipmentHalls);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateEquipmentHall", Name = "UpdateEquipmentHall")]
        public async Task<IActionResult> Update(EquipmentHall newEquipmentHall, int id)
        {
            var equipmentHallForUpdate = await _equipmentUnitOfWork.EquipmentHallRepository.GetByIdAsync(id);
            if (equipmentHallForUpdate == null)
                return BadRequest("Item does not exist");

            equipmentHallForUpdate.Quantity = newEquipmentHall.Quantity;

            var res = await _equipmentUnitOfWork.EquipmentHallRepository.UpdateAsync(equipmentHallForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteEquipmentHall", Name = "DeleteEquipmentHall")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _equipmentUnitOfWork.EquipmentHallRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }
    }
}
