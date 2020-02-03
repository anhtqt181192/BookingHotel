using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteBookingHotel.Data;

namespace WebsiteBookingHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManagerLayoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ManagerLayoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ErrorClass = "kt-hidden";
            return View(_context.HTML_content.ToList());
        }

        [HttpPost]
        public IActionResult Index(HTML_content models)
        {
            try
            {
                ViewBag.ErrorClass = "kt-hidden";
                _context.HTML_content.Update(models);
                _context.SaveChanges();
                return View(_context.HTML_content.ToList());
            }
            catch (Exception e)
            {
                ViewBag.ErrorClass = "";
                ModelState.AddModelError("500", e.Message);
            }
            return View(_context.HTML_content.ToList());
        }

        [HttpPost]
        public IActionResult Edit(HTML_content models)
        {
            try
            {
                ViewBag.ErrorClass = "kt-hidden";
                _context.HTML_content.Update(models);
                _context.SaveChanges();
                return Redirect("/Admin/ManagerLayout");
            }
            catch (Exception e)
            {
                ViewBag.ErrorClass = "";
                ModelState.AddModelError("500", e.Message);
            }
            return View(_context.HTML_content.ToList());
        }
    }
}