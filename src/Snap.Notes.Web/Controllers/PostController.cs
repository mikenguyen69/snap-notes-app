using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snap.Notes.Core.Entities;
using Snap.Notes.Core.Interfaces;

namespace Snap.Notes.Web.Controllers
{
    public class PostController : Controller
    {
        private IRepository<Post> repository;

        public PostController(IRepository<Post> repository)
        {
            this.repository = repository;
        }

        public ViewResult List() => View(this.repository.List());
    }
}