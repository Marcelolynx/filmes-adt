using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[Controller]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private ManagerContext _context;
    private IMapper _mapper;

    public SessaoController(ManagerContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult AdicionaSessao(CreateSessaoDTO dto)
    {
        Sessao sessao = _mapper.Map<Sessao>(dto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
    }
    
    [HttpGet("{id}")]
    public IActionResult RecuperaSessaoPorId(int id)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(cinema => cinema.Id == id);
        if (sessao != null)
        {
            ReadSessaoDTO sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);
            return Ok(sessaoDto);
        }
        return NotFound();
    }
    
}