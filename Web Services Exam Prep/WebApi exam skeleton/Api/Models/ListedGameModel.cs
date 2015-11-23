using System;
using AutoMapper;
using Model;
using Web.Infrastructure.Mappings;

namespace Web.Models
{
    public class ListedGameModel:IMapFrom<Game>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name2 { get; set; }

        public string RedUser { get; set; }

        public string BlueUser { get; set; }

        public GameStateType GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, ListedGameModel>()
                .ForMember(g => g.BlueUser, opts => opts.MapFrom(x => x.BlueUser == null ? "no blue player yet" : x.BlueUser.Email))
                .ForMember(g => g.RedUser, opts => opts.MapFrom(x => x.RedUser.Email))
                .ForMember(g=>g.Name2, opts=> opts.MapFrom(x=>x.Name))
                .ForMember(g => g.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(g => g.GameState, opts => opts.MapFrom(x => x.GameState))
                .ForMember(g => g.DateCreated, opts => opts.MapFrom(x => x.DateCreated));
        }
    }
}