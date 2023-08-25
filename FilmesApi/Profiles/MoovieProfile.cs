using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class MoovieProfile : Profile
{
    public MoovieProfile()
    {
        CreateMap<CreateMoovieDto, Moovie>();
    }
}