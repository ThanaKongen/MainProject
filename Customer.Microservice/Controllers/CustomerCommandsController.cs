using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Controllers
{
    public class CustomerCommandsController : Controller
    {
        // GET: CustomerCommands
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerCommands/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerCommands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerCommands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerCommands/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerCommands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerCommands/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerCommands/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
