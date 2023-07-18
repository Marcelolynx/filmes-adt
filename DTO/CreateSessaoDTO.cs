using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTO;

public class CreateSessaoDTO
{
    [Required]
    public int FilmeId { get; set; }
}