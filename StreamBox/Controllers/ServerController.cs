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

        private readonly IGenericRepository<Server> StreamRepository;
        public ServerController(IGenericRepository<Server> streamRepository)
        {
            this.StreamRepository = streamRepository;
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
                StreamRepository.Add(model);
                return RedirectToAction(nameof(Details), new { id = model.Id });
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
                StreamRepository.Update(model);
                return RedirectToAction(nameof(Manage));
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
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View(StreamRepository.GetAllEntities());
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            var model = StreamRepository.GetById(Id.Value);
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

    }
}