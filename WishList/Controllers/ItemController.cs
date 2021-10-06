using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Model;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _context;

        ItemController(ApplicationDbContext param)
        {
            _context = param;
        }

        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item myItem)
        {
            _context.Items.Add(myItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Delete(int Id)
        {
            Item myI = _context.Items.FirstOrDefault(e => e.Id == Id);
            _context.Items.Remove(myI);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
