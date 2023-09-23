using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models;

public class FilmeDTO
{
    private const int MAX_LENGTH  = 700;
    private const int MIN_LENGTH  = 70;

    [JsonIgnore]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Título é obrigatório")]
    [StringLength(100, ErrorMessage = "Tamanho não pode ser maior que 100 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Genêro é obrigatório")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Duração é obrigatório")]
    [Range(MIN_LENGTH, MAX_LENGTH, ErrorMessage = "Tamanho maior que o intervalo permitido entre 70 e 700")]
    public int? Duracao{ get; set; }
}
