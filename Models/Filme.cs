using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(250,ErrorMessage = "O título não pode ter mais de 250 caracteres")]
    public string Titulo { get; set; }
    [Required]
    [StringLength(30,ErrorMessage = "O gênero não pode ter mais de 30 caracteres")]
    public string Genero { get; set; }
    [Required]
    [Range(60, 600, ErrorMessage = "A duração deve ter no mínimo 60 e no máximo 600 minutos")]
    public int Duracao { get; set; }
    
    public virtual ICollection<Sessao> Sessoes { get; set; }
}