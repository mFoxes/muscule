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
    public class HallController : BaseController
    {
        public HallController(IEquipmentUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("GetAllHalls", Name = "GetAllHalls")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _equipmentUnitOfWork.HallRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetHallById", Name = "GetHallById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _equipmentUnitOfWork.HallRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddHall", Name = "AddHall")]
        public async Task<IActionResult> Add(HallDto hall)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HallDto, Hall>());
            var mapper = new Mapper(config);
            Hall newHall = mapper.Map<HallDto, Hall>(hall);

            var res = await _equipmentUnitOfWork.HallRepository.AddAsync(newHall);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("AddRangeOfHalls", Name = "AddRangeOfHalls")]
        public async Task<IActionResult> AddRange(IEnumerable<Hall> halls)
        {
            var res = await _equipmentUnitOfWork.HallRepository.AddRangeAsync(halls);
            if (!res)
                return BadRequest("Error while adding");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateHall", Name = "UpdateHall")]
        public async Task<IActionResult> Update(Hall newHall, int id)
        {
            var hallForUpdate = await _equipmentUnitOfWork.HallRepository.GetByIdAsync(id);
            if (hallForUpdate == null)
                return BadRequest("Item does not exist");

            hallForUpdate.Name = newHall.Name;

            var res = await _equipmentUnitOfWork.HallRepository.UpdateAsync(hallForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteHall", Name = "DeleteHall")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _equipmentUnitOfWork.HallRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _equipmentUnitOfWork.Save();
            return Ok(res);
        }
    }
}
