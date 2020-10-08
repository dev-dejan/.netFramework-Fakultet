using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACar.Data;
using RentACar.Data.Entities;
using RentACar.Models.OsiguranjeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.Controllers
{
    public class OsiguranjeController : Controller
    {
        private readonly MainDbContext _db;

        public OsiguranjeController(MainDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var osiguranja = _db.Osiguranje.ToList();

            var model = new IndexViewModel()
            {
                Osiguranjes = osiguranja
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var novoOsiguranje = new Osiguranje()
                {
                    IdOsiguranja = model.Osiguranje.IdOsiguranja,
                    Tip = model.Osiguranje.Tip,
                    Trajanje = model.Osiguranje.Trajanje
                };

                _db.Osiguranje.Add(novoOsiguranje);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(new CreateViewModel()
                {
                    Osiguranje = new Osiguranje()
                });
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var osiguranje = _db.Osiguranje.SingleOrDefault(o => o.IdOsiguranja == id);

            var model = new EditViewModel()
            {
                Osiguranje = osiguranje
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            var currentOsiguranje = _db.Osiguranje.SingleOrDefault(o => o.IdOsiguranja == model.Osiguranje.IdOsiguranja);

            if (ModelState.IsValid)
            {
                Osiguranje osiguranje;

                if(model.Osiguranje.IdOsiguranja > 0)
                {
                    osiguranje = _db.Osiguranje.SingleOrDefault(o => o.IdOsiguranja == model.Osiguranje.IdOsiguranja);

                    if(osiguranje == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    osiguranje = new Osiguranje();
                }

                osiguranje.IdOsiguranja = model.Osiguranje.IdOsiguranja;
                osiguranje.Tip = model.Osiguranje.Tip;
                osiguranje.Trajanje = model.Osiguranje.Trajanje;

                await _db.SaveChangesAsync();

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(new EditViewModel()
                {
                    Osiguranje = currentOsiguranje
                });
            }
        }
    }
}