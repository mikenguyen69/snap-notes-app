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
    public class PostsController : Controller
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public PostsController(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Posts
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List()
                            .Select(item => _mapper.Map<Post, PostDTO>(item));
            return Ok(items);
        }

        // GET: api/Posts
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _mapper.Map<Post, PostDTO>(_repository.GetById(id));
            return Ok(item);
        }

        // POST: api/Posts
        [HttpPost]
        public IActionResult Post([FromBody] PostDTO item)
        {
            var Post = new Post()
            {
                Content = item.Content,
                CategoryId = item.CategoryId,
                BookId = item.BookId
            };

            if (item.Id > 0)
            {
                Post.Id = item.Id;
            }

            _repository.Add(Post);
            return Ok(_mapper.Map<Post, PostDTO>(Post));
        }

        
        [HttpPatch("update")]
        public IActionResult Complete([FromBody] PostDTO itemDTO)
        {
            var item = _mapper.Map<PostDTO, Post>(itemDTO);
            
            _repository.Update(item);

            return Ok(_mapper.Map<Post, PostDTO>(item));
        }
    }
}
