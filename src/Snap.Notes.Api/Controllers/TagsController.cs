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
    public class TagsController : Controller
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public TagsController(IRepository<Tag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Tags
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List()
                            .Select(item => _mapper.Map<Tag, TagDTO>(item));
            return Ok(items);
        }

        // GET: api/Tags
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _mapper.Map<Tag, TagDTO>(_repository.GetById(id));
            return Ok(item);
        }

        // POST: api/Tags
        [HttpPost]
        public IActionResult Post([FromBody] TagDTO item)
        {
            var tag = _mapper.Map<TagDTO, Tag>(item);

            _repository.Add(tag);

            return Ok(_mapper.Map<Tag, TagDTO>(tag));
        }

        
        [HttpPatch("update")]
        public IActionResult Complete([FromBody] TagDTO itemDTO)
        {
            var item = _mapper.Map<TagDTO, Tag>(itemDTO);
            
            _repository.Update(item);

            return Ok(_mapper.Map<Tag, TagDTO>(item));
        }
    }
}
