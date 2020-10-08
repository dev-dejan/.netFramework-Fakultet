using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Data;
using RentACar.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        private readonly MainDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(MainDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var podaci = _db.Automobil.ToList();

            var model = new IndexViewModel
            {
                Automobili = podaci
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var osiguranja = _db.Osiguranje.ToList();

            var model = new CreateViewModel()
            {
                Osiguranjes = osiguranja
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            var osiguranja = _db.Osiguranje.ToList();

            if (ModelState.IsValid)
            {
                var auto = new Automobil()
                {
                    Id = model.Automobil.Id,
                    Marka = model.Automobil.Marka,
                    Naziv = model.Automobil.Naziv,
                    Godina = model.Automobil.Godina,
                    Cena = model.Automobil.Cena,
                    IsIznajmljeno = 0,
                    IdOsiguranja = model.Automobil.IdOsiguranja,
                    IsDeleted = 0
                };

                _db.Automobil.Add(auto);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(new CreateViewModel()
                {
                    Automobil = new Automobil(),
                    Osiguranjes = osiguranja
                });
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == id);

            var model = new DetailsViewModel()
            {
                Automobil = auto
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == id);

            auto.IsDeleted = 1;

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == id);
            var osiguranja = _db.Osiguranje.ToList();

            var model = new EditViewModel()
            {
                Automobil = auto,
                Osiguranjes = osiguranja
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            var osiguranja = _db.Osiguranje.ToList();

            if (ModelState.IsValid)
            {
                Automobil auto;

                if(model.Automobil.Id > 0)
                {
                    auto = _db.Automobil.SingleOrDefault(a => a.Id == model.Automobil.Id);

                    if(auto == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    auto = new Automobil();
                }

                auto.Id = model.Automobil.Id;
                auto.Marka = model.Automobil.Marka;
                auto.Naziv = model.Automobil.Naziv;
                auto.Godina = model.Automobil.Godina;
                auto.Cena = model.Automobil.Cena;
                auto.IdOsiguranja = model.Automobil.IdOsiguranja;
                auto.IsIznajmljeno = model.Automobil.IsIznajmljeno;

                await _db.SaveChangesAsync();

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(new EditViewModel()
                {
                    Automobil = new Automobil(),
                    Osiguranjes = osiguranja
                });
            }
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == id);

            var model = new BookViewModel()
            {
                Automobil = auto
            };

            return View(model);
        }

        //OVDE CE SE IZVRSAVATI I PLACANJE REZERVACIJE (pise se logika za naplatu automobila)
        [HttpPost]
        public async Task<IActionResult> Book(BookViewModel model)
        {
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == model.Automobil.Id);
            var brojDana = model.IznajmljeniAutomobil.BrojDana;
            var iznajmljenAuto = _db.IznajmljeniAutomobili.SingleOrDefault(a => a.IdAutomobila == model.Automobil.Id);

            if(iznajmljenAuto == null)
            {
                var iznajmljeniAuto = new IznajmljeniAutomobili()
                {
                    IdIznajmljenogAutomobila = model.Automobil.Id,
                    IdAutomobila = auto.Id,
                    BrojDana = brojDana,
                    IdKorisnika = _userManager.GetUserId(User),
                    IsRazresen = 1
                };

                _db.IznajmljeniAutomobili.Add(iznajmljeniAuto);
                auto.IsIznajmljeno = 1;

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var automobili = _db.Automobil.ToList();
                var poruka = "Auto koji ste izabrali je vec izdan.";

                var noviModel = new IndexViewModel()
                {
                    Automobili = automobili,
                    Poruka = poruka
                };

                return View("Index", noviModel);
            }
        }

        [HttpGet]
        public IActionResult UnBook(int id)
        {
            var automobili = _db.Automobil.ToList();
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == id);
            var iznajmljeniAuto = _db.IznajmljeniAutomobili.SingleOrDefault(i => i.IdAutomobila == id);

            if (auto.IsIznajmljeno == 1)
            {
                auto.IsIznajmljeno = 0;

                _db.IznajmljeniAutomobili.Remove(iznajmljeniAuto);

                _db.SaveChanges();
            }
            else
            {
                return View("Index", new IndexViewModel()
                {
                    Automobili = automobili,
                    Poruka = "Nije moguce stornirati rezervaciju za auto koji nije rezervisan."
                });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Pay(int id)
        {
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == id);
            var iznajmljeniAuto = _db.IznajmljeniAutomobili.SingleOrDefault(i => i.IdAutomobila == auto.Id);
            var ukupnaCena = auto.Cena * iznajmljeniAuto.BrojDana;

            var model = new PayViewModel()
            {
                UkupnaCena = ukupnaCena,
                Automobil = auto,
                IznajmljeniAutomobil = iznajmljeniAuto
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Pay(PayViewModel model)
        {
            var automobili = _db.Automobil.ToList();
            var iznajmljeniAuto = _db.IznajmljeniAutomobili.SingleOrDefault(i => i.IdAutomobila == model.IznajmljeniAutomobil.IdIznajmljenogAutomobila);
            var auto = _db.Automobil.SingleOrDefault(a => a.Id == model.Automobil.Id);

            var noviModel = new IndexViewModel()
            {
                Automobili = automobili,
                Poruka = "Uspesno ste platili racun."
            };

            auto.IsIznajmljeno = 0;
            _db.IznajmljeniAutomobili.Remove(iznajmljeniAuto);

            await _db.SaveChangesAsync();

            return View("Index", noviModel);
        }
    }
}
