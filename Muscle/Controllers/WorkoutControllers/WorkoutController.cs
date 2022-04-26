using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IRepository.IRepositoryWorkoutDb;
using Muscle.Entities.DbSet.DbSetForWorkoutDb;
using Muscle.Entities.DbSet.Dtos.DtosForWorkoutDb.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Controllers.WorkoutControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private IWorkoutRepository _workoutRepository;

        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutDto workout)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(x => x.CreateMap<WorkoutDto, Workout>());
                var mapper = new Mapper(config);

                Workout newWorkout = mapper.Map<WorkoutDto, Workout>(workout);

                var id = await _workoutRepository.Create(newWorkout);

                return Ok(id);
            }
            return BadRequest("Invalid input");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workouts = await _workoutRepository.Get();

            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var workout = await _workoutRepository.Get(id);
            return Ok(workout);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Workout workout)
        {
            var result = await _workoutRepository.Update(id, workout);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _workoutRepository.Delete(id);
            if (result) return Ok("Delete success");
            return BadRequest("Error during deletion");
        }
    }
}
