using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentACar.Data;
using RentACar.Data.Entities;
using RentACar.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.Controllers
{
    public class AdminController : Controller
    {
        private readonly MainDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(MainDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _db.User.ToList();

            var model = new IndexViewModel()
            {
                Users = users
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
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                await _userManager.CreateAsync(user, model.Password);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(new CreateViewModel()
                {
                    Email = "",
                    Password = ""
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var users = _db.User.ToList();

            if(_userManager.GetUserId(User) != id)
            {
                var user = _db.User.SingleOrDefault(u => u.Id == id);

                _db.Remove(user);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                string poruka = "Nije moguce da obriseti sami sebe. :)";

                return View("Index", new IndexViewModel()
                {
                    Users = users,
                    Poruka = poruka
                });
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _db.User.SingleOrDefault(u => u.Id == id);

            var model = new EditViewModel()
            {
                User = user
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            var currentUser = _db.User.SingleOrDefault(u => u.Id == model.User.Id);

            if (ModelState.IsValid)
            {
                User user;

                if(model.User.Id != "")
                {
                    user = _db.User.SingleOrDefault(u => u.Id == model.User.Id);

                    if(user == null)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    user = new User();
                }

                user.UserName = model.User.UserName;
                user.PhoneNumber = model.User.PhoneNumber;
                user.Email = model.User.Email;

                await _db.SaveChangesAsync();

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(new EditViewModel()
                {
                    User = currentUser
                });
            }
        }
    }
}