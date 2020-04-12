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
        private readonly IGenericRepository<Stream> _StreamRepository;
        public StreamController(IGenericRepository<Stream> StreamRepository)
        {
            this._StreamRepository = StreamRepository;
        }
        public IActionResult ManageStream()
        {
            return View(_StreamRepository.GetAllEntities());
        }
        public IActionResult Detalies(int?Id)
        {
            var model = _StreamRepository.GetById(Id.Value);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("StreamNotFound", Id.Value);
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
                _StreamRepository.Add(model);
                return RedirectToAction(nameof(Detalies), new { id = model.Id});
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _StreamRepository.Delete(Id);
            return RedirectToAction(nameof(ManageStream));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var model = _StreamRepository.GetById(id);

            if(model == null)
            {
                Response.StatusCode = 404;
                return View("StreamNotFound", id);
            }
            return View(model);
        }

        public IActionResult Update(Stream model)
        {
            if (ModelState.IsValid)
            {
                _StreamRepository.Update(model);
                return RedirectToAction(nameof(ManageStream));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}