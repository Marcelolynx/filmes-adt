using System.Collections;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private ManagerContext _context;
    private IMapper _mapper;

    public CinemaController(ManagerContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost] 
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, cinema);
    }
    
    [HttpGet]
    public IEnumerable<ReadCinemaDTO> RecuperaCinemas()
    {
        var cinemas = _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());
        return cinemas;
    }
    
    [HttpGet("{id}")]
    public IActionResult RecuperaCinemasPorId(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema != null)
        {
            ReadCinemaDTO cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }
    
    [HttpPut("{id}")] 
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult AtualizaCinemaPatch(int id, [FromBody] UpdateCinemaDTO cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }
}