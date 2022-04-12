using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.Data;
using Muscle.DataService.IConfiguration;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Muscle.Controllers.UserControllers
{
    
    public class UserController : BaseController
    {
        public UserController(IUserUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

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
