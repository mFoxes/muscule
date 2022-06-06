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
    public class RoleController : BaseController
    {
        public RoleController(IUserUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {

        }

        [HttpGet]
        [Route("GetAllRoles", Name = "GetAllRoles")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _userUnitOfWork.RoleRepository.GetAllAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetRoleById", Name = "GetRoleById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _userUnitOfWork.RoleRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddRole", Name = "AddRole")]
        public async Task<IActionResult> Add(Role role)
        {
            var res = await _userUnitOfWork.RoleRepository.AddAsync(role);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res); //TODO Поменяй на CreatedAtRoute + добавь DTO классы
        }

        [HttpPost]
        [Route("AddRangeOfRoles", Name = "AddRangeOfRoles")]
        public async Task<IActionResult> AddRange(IEnumerable<Role> roles)
        {
            var res = await _userUnitOfWork.RoleRepository.AddRangeAsync(roles);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateRole", Name = "UpdateRole")]
        public async Task<IActionResult> Update(Role newRole, int id)
        {
            var roleForUpdate = await _userUnitOfWork.RoleRepository.GetByIdAsync(id);
            if (roleForUpdate == null)
                return BadRequest("Item does not exist");

            roleForUpdate.Name = newRole.Name;
            roleForUpdate.Description = newRole.Description;

            var res = await _userUnitOfWork.RoleRepository.UpdateAsync(roleForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteRole", Name = "DeleteRole")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _userUnitOfWork.RoleRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _userUnitOfWork.Save();
            return Ok(res);
        }
    }
}
