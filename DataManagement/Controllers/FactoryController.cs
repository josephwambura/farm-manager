﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace DataManagement.Controllers
{
    [Authorize]
    public class FactoryController : Controller
    {
        private readonly IFactoryService _factoryService;

        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }
        // GET: FactoryController
        public ActionResult Index()
        {
            return View();
        }

        public async ValueTask<JsonResult> GetAllData()
        {
            var data = await _factoryService.GetAllFactoriesAsync();

            return Json(data ?? new List<FactoryModel>());
        }


        // GET: FactoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Create(FactoryModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _factoryService.AddFactoryAsync(model);

                    TempData["Success"] = "Factory added.";

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Failed. {ex.Message}";

                    return View(model);
                }
            }

            TempData["Error"] = "Model State is not valid";

            return View(model);

        }

        // GET: FactoryController/Edit/5
        public async ValueTask<ActionResult> Edit(Guid id)
        {
            var factory = await _factoryService.GetFactoryByIdAsync(id);

            return View(factory!);
        }

        // POST: FactoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<ActionResult> Edit(FactoryModel model)
        {
            try
            {
                await _factoryService.UpdateFactoryAsync(model);

                TempData["Success"] = "Factory updated.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed. {ex.Message}";

                return View(model);
            }
        }

        // POST: FactoryController/Delete/5
        [HttpPost]
        public async ValueTask<ActionResult> Delete(string id)
        {
            try
            {
                await _factoryService.DeleteFactoryAsync(Guid.Parse(id));

                return Json(new { message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { message = $"Failed. {ex.Message}" });
            }
        }
    }
}
