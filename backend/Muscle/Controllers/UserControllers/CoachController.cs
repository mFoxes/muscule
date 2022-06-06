using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;
using Muscle.DataService.IRepository.IRepositoryWorkoutDb;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Controllers.UserControllers
{
    public class CoachController : BaseController
    {
        private IWorkoutRepository _workoutRepository;
        public CoachController(IUserUnitOfWork unitOfWork, IWorkoutRepository workoutRepository)
            : base(unitOfWork)
        {
            _workoutRepository = workoutRepository;
        }

        [HttpGet]
        [Route("GetAllCoaches", Name = "GetAllCoaches")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _userUnitOfWork.CoachRepository.GetAllAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetCoachById", Name = "GetCoachById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _userUnitOfWork.CoachRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetCoachesWorkoutsCount", Name = "GetCoachesWorkoutsCount")]
        public async Task<IActionResult> GetCoachesWorkoutsCount()
        {
            var coaches = await _userUnitOfWork.CoachRepository.GetAllAsync();
            
            var res = new[] {  new { CoachId = -1, CountOfWorkouts = 0 }  }.ToList();
            
            foreach (var item in coaches)
            {
                var workouts = await _workoutRepository.GetCurrentByCoachId(item.Id);
                res.Add(new { CoachId = item.Id, CountOfWorkouts = workouts.Count() });
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("AddCoach", Name = "AddCoach")]
        public async Task<IActionResult> Add(Coach coach)
        {
            var res = await _userUnitOfWork.CoachRepository.AddAsync(coach);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res); //TODO Поменяй на CreatedAtRoute + добавь DTO классы
        }

        [HttpPost]
        [Route("AddRangeOfCoaches", Name = "AddRangeOfCoaches")]
        public async Task<IActionResult> AddRange(IEnumerable<Coach> coaches)
        {
            var res = await _userUnitOfWork.CoachRepository.AddRangeAsync(coaches);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateCoach", Name = "UpdateCoach")]
        public async Task<IActionResult> Update(Coach newCoach, int id)
        {
            var coachForUpdate = await _userUnitOfWork.CoachRepository.GetByIdAsync(id);
            if (coachForUpdate == null)
                return BadRequest("Item does not exist");

            coachForUpdate.Name = newCoach.Name;
            coachForUpdate.Description = newCoach.Description;
            coachForUpdate.Phone = newCoach.Phone;
            coachForUpdate.Email = newCoach.Email;
            coachForUpdate.Password = newCoach.Password;

            var res = await _userUnitOfWork.CoachRepository.UpdateAsync(coachForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteCoach", Name = "DeleteCoach")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _userUnitOfWork.CoachRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _userUnitOfWork.Save();
            return Ok(res);
        }
    }
}
