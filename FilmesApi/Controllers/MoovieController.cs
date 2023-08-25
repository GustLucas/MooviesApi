using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using AutoMapper;

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
    public IEnumerable<Moovie> GetMoovies([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _context.Moovies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetMoovieById(int id)
    {
        var moovie = _context.Moovies.FirstOrDefault(moovie => moovie.Id == id);
        if (moovie == null) return NotFound();
        return Ok(moovie);
    }
}
