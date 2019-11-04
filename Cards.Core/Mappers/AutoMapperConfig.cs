using System.Collections;
using AutoMapper;
using Cards.Core.Entities;
using Cards.Core.Models;

namespace Cards.Core.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<User, UserModel>().ForMember(x => x.Password, opt => opt.Ignore());

                cfg.CreateMap<Card, CardModel>();
                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<Mode, ModeModel>();
                cfg.CreateMap<RepeatRate, RepeatRateModel>();
                cfg.CreateMap<Note, NoteModel>();

                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<CardModel, Card>();
                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<ModeModel, Mode>();
                cfg.CreateMap<RepeatRateModel, RepeatRate>();
                cfg.CreateMap<NoteModel, Note>();

            });

            return config.CreateMapper();
        }
    }
}