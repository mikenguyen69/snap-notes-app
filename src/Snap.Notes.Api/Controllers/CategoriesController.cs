using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Snap.Notes.Core.Interfaces;
using Snap.Notes.Core.Entities;
using Snap.Notes.Api.DTO;
using Snap.Notes.Api.Filters;

namespace CASportStore.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoriesController(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Categorys
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List()
                            .Select(item => _mapper.Map<Category, CategoryDTO>(item));
            return Ok(items);
        }

        // GET: api/Categorys
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _mapper.Map<Category, CategoryDTO>(_repository.GetById(id));
            return Ok(item);
        }

        // POST: api/Categorys
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO item)
        {
            var Category = new Category()
            {
                Title = item.Title,
                Description = item.Description
            };

            if (item.Id > 0)
            {
                Category.Id = item.Id;
            }

            _repository.Add(Category);
            return Ok(_mapper.Map<Category, CategoryDTO>(Category));
        }

        
        [HttpPatch("update")]
        public IActionResult Complete([FromBody] CategoryDTO itemDTO)
        {
            var item = _mapper.Map<CategoryDTO, Category>(itemDTO);
            
            _repository.Update(item);

            return Ok(_mapper.Map<Category, CategoryDTO>(item));
        }
    }
}
