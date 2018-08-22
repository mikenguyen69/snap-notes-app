using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snap.Notes.Core.Entities;
using Snap.Notes.Core.Interfaces;
using Snap.Notes.Web.Models.ViewModels;

namespace Snap.Notes.Web.Controllers
{
    public class PostController : Controller
    {
        private IRepository<Post> _repository;
        public int PageSize = 4;

        // Auto resolve via dependency injection
        public PostController(IRepository<Post> repository)
        {
            _repository = repository;
        }

        // Call without view name means tell MVC to render default view for action method
        public ViewResult List(string category, int page = 1)
         => View(new PostsListViewModel
         {
             Posts = _repository.List()
             .Where(x => category == null)
             .OrderBy(p => p.Id)
             .Skip((page - 1) * PageSize)
             .Take(PageSize),

             PagingInfo = new PagingInfo
             {
                 CurrentPage = page,
                 ItemsPerPage = PageSize,
                 TotalItems = category == null ? _repository.List().Count() : 
                 _repository.List().Count()
             },

             CurrentCategory = category
         });
    }
}