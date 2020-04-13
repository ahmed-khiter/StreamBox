using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreamBox.Models;

namespace StreamBox.Controllers
{
    public class StreamController : Controller
    {
        private readonly IGenericRepository<Stream> StreamRepository;
        public StreamController(IGenericRepository<Stream> streamRepository)
        {
            this.StreamRepository = streamRepository;
        }
        public IActionResult ManageStreamRepository()
        {
            return View(StreamRepository.GetAllEntities());
        }
        public IActionResult Detalies(int?Id)
        {
            var model = StreamRepository.GetById(Id.Value);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("StreamRepositoryNotFound", Id.Value);
            }
            else
            { 
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stream model)
        {
            if (ModelState.IsValid)
            {
                StreamRepository.Add(model);
                return RedirectToAction(nameof(Detalies), new { id = model.Id});
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var model = StreamRepository.GetById(id);

            if(model == null)
            {
                Response.StatusCode = 404;
                return View("StreamRepositoryNotFound", id);
            }
            return View(model);
        }

        public IActionResult Update(Stream model)
        {
            if (ModelState.IsValid)
            {
                StreamRepository.Update(model);
                return RedirectToAction(nameof(ManageStreamRepository));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            StreamRepository.Delete(Id);
            return RedirectToAction(nameof(ManageStreamRepository));
        }

    }
}