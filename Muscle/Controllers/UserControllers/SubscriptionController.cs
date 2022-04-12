using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Controllers.UserControllers
{
    public class SubscriptionController : BaseController
    {
        public SubscriptionController(IUserUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("GetAllSubscriptions", Name = "GetAllSubscriptions")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _userUnitOfWork.SubscriptionRepository.GetAllAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetSubscriptionById", Name = "GetSubscriptionById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _userUnitOfWork.SubscriptionRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddSubscription", Name = "AddSubscription")]
        public async Task<IActionResult> Add(Subscription subscription)
        {
            var res = await _userUnitOfWork.SubscriptionRepository.AddAsync(subscription);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res); //TODO Поменяй на CreatedAtRoute + добавь DTO классы
        }

        [HttpPost]
        [Route("AddRangeOfSubscriptions", Name = "AddRangeOfSubscriptions")]
        public async Task<IActionResult> AddRange(IEnumerable<Subscription> subscriptions)
        {
            var res = await _userUnitOfWork.SubscriptionRepository.AddRangeAsync(subscriptions);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateSubscription", Name = "UpdateSubscription")]
        public async Task<IActionResult> Update(Subscription newSubscription, int id)
        {
            var subscriptionForUpdate = await _userUnitOfWork.SubscriptionRepository.GetByIdAsync(id);
            if (subscriptionForUpdate == null)
                return BadRequest("Item does not exist");

            subscriptionForUpdate.Name = newSubscription.Name;
            subscriptionForUpdate.Price = newSubscription.Price;
            subscriptionForUpdate.Count = newSubscription.Count;

            var res = await _userUnitOfWork.SubscriptionRepository.UpdateAsync(subscriptionForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteSubscription", Name = "DeleteSubscription")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _userUnitOfWork.SubscriptionRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _userUnitOfWork.Save();
            return Ok(res);
        }
    }
}
