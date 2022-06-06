using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;
using Muscle.Entities.DbSet.DbSetForUserDb;
using Muscle.Entities.DbSet.Dtos.DtosForUserDb.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Controllers.UserControllers
{
    public class SubscriptionUserController : BaseController
    {
        public SubscriptionUserController(IUserUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("GetAllSubscriptionUsers", Name = "GetAllSubscriptionUsers")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _userUnitOfWork.SubscriptionUserRepository.GetAllAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetSubscriptionUserById", Name = "GetSubscriptionUserById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _userUnitOfWork.UserRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddSubscriptionUser", Name = "AddSubscriptionUser")]
        public async Task<IActionResult> Add(SubscriptionUserDto subscriptionUser)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SubscriptionUserDto, SubscriptionUser>());
            var mapper = new Mapper(config);

            var newSubscriptionUser = mapper.Map<SubscriptionUserDto, SubscriptionUser>(subscriptionUser);
            newSubscriptionUser.VisitCount = 0;

            var res = await _userUnitOfWork.SubscriptionUserRepository.AddAsync(newSubscriptionUser);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res); //TODO Поменяй на CreatedAtRoute + добавь DTO классы
        }

        [HttpPost]
        [Route("AddRangeOfSubscriptionUsers", Name = "AddRangeOfSubscriptionUsers")]
        public async Task<IActionResult> AddRange(IEnumerable<SubscriptionUser> subscriptionUsers)
        {
            var res = await _userUnitOfWork.SubscriptionUserRepository.AddRangeAsync(subscriptionUsers);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateSubscriptionUser", Name = "UpdateSubscriptionUser")]
        public async Task<IActionResult> Update(SubscriptionUser newSubscriptionUser, int id)
        {
            var subscriptionUserForUpdate = await _userUnitOfWork.SubscriptionUserRepository.GetByIdAsync(id);
            if (subscriptionUserForUpdate == null)
                return BadRequest("Item does not exist");

            subscriptionUserForUpdate.VisitCount = newSubscriptionUser.VisitCount;

            var res = await _userUnitOfWork.SubscriptionUserRepository.UpdateAsync(subscriptionUserForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteSubscriptionUser", Name = "DeleteSubscriptionUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _userUnitOfWork.SubscriptionUserRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _userUnitOfWork.Save();
            return Ok(res);
        }
    }
}
