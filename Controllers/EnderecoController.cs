using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly ManagerContext _context;
    private readonly IMapper _mapper;

    public EnderecoController(ManagerContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarEnderecoPorId),
            new {Id = endereco.Id}, endereco);
    }
    
    [HttpGet]
    public IEnumerable<ReadEnderecoDTO> RecuperarEndereco([FromQuery] int skip = 0, 
        [FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadEnderecoDTO>>(_context.Enderecos.Skip(skip).Take(take));
    }
    
    [HttpGet("{id}")]
    public IActionResult RecuperarEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        return Ok(endereco);
    }
    
    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco([FromBody] UpdateEnderecoDTO enderecoDto, int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult AtualizarEndereco([FromBody] JsonPatchDocument<UpdateEnderecoDTO> patchEndereco, int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        var enderecoDto = _mapper.Map<UpdateEnderecoDTO>(endereco);
        patchEndereco.ApplyTo(enderecoDto);
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
    
}