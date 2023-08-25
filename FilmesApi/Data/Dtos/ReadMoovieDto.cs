using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class ReadMoovieDto
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int Duration { get; set; }
    public DateTime TimeOfQuery { get; set; } = DateTime.Now;
}