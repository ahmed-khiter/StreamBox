using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreamBox.Models;

namespace StreamBox.Controllers
{
    public class ServerController : Controller
    {

        private readonly IGenericRepository<Server> _StreamRepository;
        public ServerController(IGenericRepository<Server> StreamRepository)
        {
            this._StreamRepository = StreamRepository;
        }
        public IActionResult ManageServer()
        {
            return View(_StreamRepository.GetAllEntities());
        }
        public IActionResult Detalies(int? Id)
        {
            var model = _StreamRepository.GetById(Id.Value);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("ServerNotFound", Id.Value);
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
        public IActionResult Create(Server model)
        {
            if (ModelState.IsValid)
            {
                _StreamRepository.Add(model);
                return RedirectToAction(nameof(Detalies), new { id = model.Id });
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
            return RedirectToAction(nameof(ManageServer));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var model = _StreamRepository.GetById(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("StreamNotFound", id);
            }
            return View(model);
        }

        public IActionResult Update(Server model)
        {
            if (ModelState.IsValid)
            {
                _StreamRepository.Update(model);
                return RedirectToAction(nameof(ManageServer));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}