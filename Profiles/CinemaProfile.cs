using AutoMapper;
using FilmesApi.DTO;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDTO,  Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>().ForMember(dto => dto.Endereco,
            opt => opt.MapFrom(cinema => cinema.Endereco));
        CreateMap<UpdateCinemaDTO, Cinema>(); 
        CreateMap<Cinema, UpdateCinemaDTO>();
    }
}