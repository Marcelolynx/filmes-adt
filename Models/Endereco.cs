using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string cep { get; set; }
    public string logradouro { get; set; }
    public string complemento { get; set; }
    public string bairro { get; set; }
    public string localidade { get; set; }
    public string uf { get; set; }
    public string ibge { get; set; }
    public string gia { get; set; }
    public string ddd { get; set; }
    public string siafi { get; set; }
    
    public virtual Cinema Cinema { get; set; }
}