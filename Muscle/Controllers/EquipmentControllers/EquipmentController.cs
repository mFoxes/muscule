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
    public class EquipmentController : BaseController
    {
        public EquipmentController(IEquipmentUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("GetAllEquipments", Name = "GetAllEquipments")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _equipmentUnitOfWork.EquipmentRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetEquipmentById", Name = "GetEquipmentById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _equipmentUnitOfWork.EquipmentRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddEquipment", Name = "AddEquipment")]
        public async Task<IActionResult> Add(EquipmentDto equipment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EquipmentDto, Equipment>());
            var mapper = new Mapper(config);
            Equipment newEquipment = mapper.Map<EquipmentDto, Equipment>(equipment);

            var res = await _equipmentUnitOfWork.EquipmentRepository.AddAsync(newEquipment);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("AddRangeOfEquipments", Name = "AddRangeOfEquipments")]
        public async Task<IActionResult> AddRange(IEnumerable<Equipment> equipments)
        {
            var res = await _equipmentUnitOfWork.EquipmentRepository.AddRangeAsync(equipments);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateEquipment", Name = "UpdateEquipment")]
        public async Task<IActionResult> Update(Equipment newEquipment, int id)
        {
            var equipmentForUpdate = await _equipmentUnitOfWork.EquipmentRepository.GetByIdAsync(id);
            if (equipmentForUpdate == null)
                return BadRequest("Item does not exist");

            equipmentForUpdate.Name = newEquipment.Name;
            equipmentForUpdate.Description = newEquipment.Description;

            var res = await _equipmentUnitOfWork.EquipmentRepository.UpdateAsync(equipmentForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteEquipment", Name = "DeleteEquipment")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _equipmentUnitOfWork.EquipmentRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }
    }
}
