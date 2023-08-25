using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoovieController : ControllerBase
{
    private MoovieContext _context;
    private IMapper _mapper;

    public MoovieController(MoovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMoovie([FromBody] CreateMoovieDto moovieDto)
    {
        Moovie moovie = _mapper.Map<Moovie>(moovieDto);
        _context.Moovies.Add(moovie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMoovieById),
            new { id = moovie.Id },
            moovie);
    }

    [HttpGet]
    public IEnumerable<ReadMoovieDto> GetMoovies([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadMoovieDto>>(_context.Moovies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetMoovieById(int id)
    {
        var moovie = _context.Moovies.FirstOrDefault(moovie => moovie.Id == id);
        if (moovie == null) return NotFound();
        var moovieDto = _mapper.Map<ReadMoovieDto>(moovie);
        return Ok(moovie);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMoovie(int id,
        [FromBody] UpdateMoovieDto moovieDto)
    {
        var moovie = _context.Moovies.FirstOrDefault(moovie => moovie.Id == id);
        if (moovie == null) return NotFound();
        _mapper.Map(moovieDto, moovie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchMoovie(int id,
    JsonPatchDocument<UpdateMoovieDto> patch)
    {
        var moovie = _context.Moovies.FirstOrDefault(moovie => moovie.Id == id);
        if (moovie == null) return NotFound();

        var moovieToPatch = _mapper.Map<UpdateMoovieDto>(moovie);

        patch.ApplyTo(moovieToPatch, ModelState);

        if (!TryValidateModel(moovieToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(moovieToPatch, moovie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMoovie(int id)
    {
        var moovie = _context.Moovies.FirstOrDefault(
           moovie => moovie.Id == id);
        if (moovie == null) return NotFound();
        _context.Remove(moovie);
        _context.SaveChanges();
        return NoContent();
    }
}
