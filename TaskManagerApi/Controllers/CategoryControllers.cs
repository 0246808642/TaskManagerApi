using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TaskManagerApi.Data;
using TaskManagerApi.Data.Dtos.CategoryDto;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryControllers : ControllerBase
{
    private readonly TaskDbContext _context;
    private readonly IMapper _mapper;

    public CategoryControllers(TaskDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int Skip = 0, int Take = 10)
    {
        try
        {
            var categories = await _context.Categories.Include(x=>x.Tasks).ToListAsync();
            var categorieDto = _mapper.Map<List<ReadCategoryDto>>(categories);
            return Ok(categorieDto);
        }
        catch(Exception )
        {
            return StatusCode(500, "Ocorreu um erro no servidor");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        try
        { 
            var category = await _context.Categories.Include(x=>x.Tasks).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            var categoryDto = _mapper.Map<ReadCategoryDto>(category);
            return Ok(categoryDto);
        }
        catch
        {
            return StatusCode(500, "Ocorreu um erro no servidor");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }
        catch
        {
            return StatusCode(500, "Ocorreu um erro no servidor");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            _mapper.Map(updateCategoryDto, category);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500, "Ocorreu um erro no servidor");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500, "Ocorreu um erro no servidor");
        }
    }

}
    
