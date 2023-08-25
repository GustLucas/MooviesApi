using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateMoovieDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O gênero deve possuir no maximo 50 caracteres")]
    public string? Genre { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600")]
    public int Duration { get; set; }
}