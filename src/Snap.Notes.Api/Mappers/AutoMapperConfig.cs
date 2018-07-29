using AutoMapper;
using Snap.Notes.Api.DTO;
using Snap.Notes.Core.Entities;

namespace Snap.Notes.Api.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();

                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();

                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();

                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<TagDTO, Tag>();
            });

            return config.CreateMapper();
        }
    }
}
