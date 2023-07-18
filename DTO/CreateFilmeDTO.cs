using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTO;

public class CreateFilmeDTO
{
    [Required]
    [StringLength(250,ErrorMessage = "O título não pode ter mais de 250 caracteres")]
    public string Titulo { get; set; }
    [Required]
    [StringLength(30,ErrorMessage = "O gênero não pode ter mais de 30 caracteres")]
    public string Genero { get; set; }
    [Required]
    [Range(60, 600, ErrorMessage = "A duração deve ter no mínimo 60 e no máximo 600 minutos")]
    public int Duracao { get; set; }
}