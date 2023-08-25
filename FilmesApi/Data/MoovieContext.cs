using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class MoovieContext : DbContext
{
    public MoovieContext(DbContextOptions<MoovieContext> options)
        : base(options)
    {

    }

    public DbSet<Moovie> Moovies { get; set; }

}