﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreamBox.Models;
using StreamBox.Repositories;

namespace StreamBox.Controllers
{
    public class StreamController : Controller
    {
        private readonly IGenericRepository<Stream> Repository;
        public StreamController(IGenericRepository<Stream> repository)
        {
            this.Repository = repository;
        }
        public IActionResult Manage()
        {
            return View(Repository.All());
        }
        public IActionResult Detalies(int?Id)
        {
            var model = Repository.GetById(Id.Value);
            if (model == null)
            {
                return NotFound();
            }
            else
            { 
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Stream model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Repository.Add(model);
            return RedirectToAction(nameof(Detalies), new { id = model.Id });
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Repository.Delete(Id);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var model = Repository.GetById(id);

            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Edit(Stream model)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(model);
                return RedirectToAction(nameof(Manage));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}