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
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BooksController(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List()
                            .Select(item => _mapper.Map<Book, BookDTO>(item));
            return Ok(items);
        }

        // GET: api/Books
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _mapper.Map<Book, BookDTO>(_repository.GetById(id));
            return Ok(item);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult Post([FromBody] BookDTO item)
        {
            var book = _mapper.Map<BookDTO, Book>(item);

            _repository.Add(book);

            return Ok(_mapper.Map<Book, BookDTO>(book));
        }

        
        [HttpPatch("update")]
        public IActionResult Complete([FromBody] BookDTO itemDTO)
        {
            var item = _mapper.Map<BookDTO, Book>(itemDTO);
            
            _repository.Update(item);

            return Ok(_mapper.Map<Book, BookDTO>(item));
        }
    }
}
