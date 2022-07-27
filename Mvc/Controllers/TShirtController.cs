using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class TShirtController : Controller
    {
        // GET: TShirtController
        public IActionResult Index()
        {
            return View();
        }

        // GET: TShirtController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: TShirtController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TShirtController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TShirtViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("CreateSuccess", viewModel);
            }

            return View("Create", viewModel);
        }

        public IActionResult CreateSuccess(TShirtViewModel viewModel)
        {
            return View("CreateSuccess", viewModel);
        }

        // GET: TShirtController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: TShirtController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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

        // GET: TShirtController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: TShirtController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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
