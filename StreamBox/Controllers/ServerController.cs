using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using StreamBox.Models;
using StreamBox.Repositories;
using StreamBox.Helpers;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Threading;

namespace StreamBox.Controllers
{
    public class ServerController : Controller
    {

        private readonly IGenericRepository<Server> Repository;
        public ServerController(IGenericRepository<Server> repository)
        {
            Repository = repository;
        }
        public IActionResult Manage()
        {
            return View(Repository.All());
        }
        public IActionResult Details(int? Id)
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
            return View(new Server());
        }

        [HttpPost]
        public IActionResult Add(Server model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Repository.Add(model);
            var sbServerIP = ShellHelper.GetServerIPV4();
            var stServerId = model.Id;
            Action runCommand = () => 
            {
                var client = new SshClient(model.IP, "root", model.RootPassword);
                string installScript = System.IO.File.ReadAllText("InstallScripts/Server");
                installScript = string.Format(installScript, sbServerIP, stServerId);
                try 
                {
                    client.Connect();
                    client.RunCommand(installScript);
                }
                finally
                {
                    client.Disconnect();
                    client.Dispose();
                }
            };
            ThreadPool.QueueUserWorkItem(x => runCommand());
            return RedirectToAction(nameof(Details), new { id = model.Id });
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

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Server model)
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