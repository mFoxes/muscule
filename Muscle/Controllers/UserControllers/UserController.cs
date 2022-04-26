using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.Data;
using Muscle.DataService.IConfiguration;
using Muscle.DataService.IRepository.IRepositoryWorkoutDb;
using Muscle.Entities.DbSet.DbSetForUserDb;
using Muscle.Entities.DbSet.DbSetForWorkoutDb;
using Muscle.Entities.DbSet.Dtos.DtosForUserDb.Incoming;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muscle.Controllers.UserControllers
{
    
    public class UserController : BaseController
    {
        private IWorkoutRepository _workoutRepository;

        public UserController(IUserUnitOfWork unitOfWork, IWorkoutRepository workoutRepository)
            : base(unitOfWork)
        {
            _workoutRepository = workoutRepository;
        }

        [HttpGet]
        [Route("GetAllUsers", Name = "GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _userUnitOfWork.UserRepository.GetAllAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetUserById", Name = "GetUserById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _userUnitOfWork.UserRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetUsersWorkouts", Name = "GetUsersWorkouts")]
        public async Task<IActionResult> GetUsersWorkouts(int userId)
        {
            var user = await _userUnitOfWork.UserRepository.GetByIdAsync(userId);
            var userRole = await _userUnitOfWork.RoleRepository.GetByIdAsync(user.RoleId);

            IEnumerable<Workout> usersWorkouts = null;
            if(userRole.Name == "User")
            {
                var usersSubscriptions = await _userUnitOfWork.UserRepository.GetSubscriptions(userId);
                var subscriptionsIds = usersSubscriptions.Select(x => x.SubscriptionId).ToList();

                usersWorkouts = await _workoutRepository.GetWorkoutsBySubscriptionsIds(subscriptionsIds);
            }
            else if(userRole.Name == "Coach")
                usersWorkouts = await _workoutRepository.GetByCoachId(userId);
            else if(userRole.Name == "Admin")
                usersWorkouts = await _workoutRepository.Get();

            return Ok(usersWorkouts);
        }

        [HttpGet]
        [Route("GetUsersSubscriptions", Name = "GetUserSubscriptions")]
        public async Task<IActionResult> GetUsersSubscriptions(int userId)
        {
            var res = await _userUnitOfWork.UserRepository.GetSubscriptions(userId);
            return Ok(res);
        }

        [HttpPost]
        [Route("LogIn", Name = "LigIn")]
        public async Task<IActionResult> LogIn([FromBody]LogInDto logInDto)
        {
            var user = await _userUnitOfWork.UserRepository.LogIn(logInDto.Name, logInDto.Password);
            return Ok(user);
        }

        [HttpPost]
        [Route("AddUser", Name = "AddUser")]
        public async Task<IActionResult> Add(User newUser)
        {
            var res = await _userUnitOfWork.UserRepository.AddAsync(newUser);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res); //TODO Поменяй на CreatedAtRoute + добавь DTO классы
        }

        [HttpPost]
        [Route("AddRangeOfUsers", Name = "AddRangeOfUsers")]
        public async Task<IActionResult> AddRange(IEnumerable<User> users)
        {
            var res = await _userUnitOfWork.UserRepository.AddRangeAsync(users);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateUser", Name = "UpdateUser")]
        public async Task<IActionResult> Update(User newUser, int id)
        {
            var userForUpdate = await _userUnitOfWork.UserRepository.GetByIdAsync(id);
            if (userForUpdate == null)
                return BadRequest("Item does not exist");

            userForUpdate.Name = newUser.Name;
            userForUpdate.DateOfBirth = newUser.DateOfBirth;
            userForUpdate.Phone = newUser.Phone;
            userForUpdate.Password = newUser.Password;
            userForUpdate.Email = newUser.Email;

            var res = await _userUnitOfWork.UserRepository.UpdateAsync(userForUpdate);
            if(!res)
                return BadRequest("Something went wrong");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteUser", Name = "DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _userUnitOfWork.UserRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _userUnitOfWork.Save();
            return Ok(res);
        }
    }
}
