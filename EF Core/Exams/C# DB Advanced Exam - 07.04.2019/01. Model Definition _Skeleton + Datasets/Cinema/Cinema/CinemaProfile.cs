namespace Cinema
{
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using System;
    using System.Globalization;

    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            this.CreateMap<ImportMovieDTO, Movie>();
                           
        }
    }
}
