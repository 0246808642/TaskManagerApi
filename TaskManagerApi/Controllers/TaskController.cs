
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Data;
using TaskManagerApi.Data.Dtos.CategoryDto;
using TaskManagerApi.Data.Dtos.TaskOnDto;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TaskDbContext _context;

        public TaskController(IMapper mapper, TaskDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]   
        public async Task<IActionResult> Get(int Skip =0, int Take = 10)
        {
            try
            {
                var tasks = _context.Tasks.ToListAsync();
                var taskDto = _mapper.Map<List<TaskReadDto>>(tasks); 
                return Ok(taskDto);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error");
            }   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task == null) return NotFound();
                var taskDto = _mapper.Map<TaskReadDto>(task);
                return Ok(taskDto);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatedTaskDto taskDto)
        {
            try
            {
                var task = _mapper.Map<TaskOn>(taskDto);
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
                var taskReadDto = _mapper.Map<TaskReadDto>(task);
                return CreatedAtAction(nameof(GetById), new { id = task.Id }, taskReadDto);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateTaskDto taskDto, long id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task == null) return NotFound();
                _mapper.Map(taskDto, task);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task == null) return NotFound();
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
