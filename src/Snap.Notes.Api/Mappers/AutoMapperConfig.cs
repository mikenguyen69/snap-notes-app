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
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<ToDoItem, ToDoItemDTO>();
                cfg.CreateMap<ToDoItemDTO, ToDoItem>();
            });

            return config.CreateMapper();
        }
    }
}
