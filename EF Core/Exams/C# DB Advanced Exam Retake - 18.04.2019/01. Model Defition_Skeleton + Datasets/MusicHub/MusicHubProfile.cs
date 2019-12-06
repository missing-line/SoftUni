namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;
    using System;
    using System.Globalization;

    public class MusicHubProfile : Profile
    {      
        public MusicHubProfile()
        {
            this.CreateMap<ImportWriterDTO, Writer>();

            this.CreateMap<ImportProcuserDTO, Producer>();

            this.CreateMap<ImportSongDTO, Song>()
                .ForMember(x => x.Duration, y => y.MapFrom(scr => TimeSpan.ParseExact(scr.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CreatedOn, y => y.MapFrom(scr => DateTime.ParseExact(scr.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<ImportPerformerDTO, Performer>();

            this.CreateMap<ImportSongPerformerDTO, SongPerformer>()
               .ForMember(t => t.SongId, y => y.MapFrom(k => k.SongId));

        }
    }
}
