using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteBookingHotel.Data;

namespace WebsiteBookingHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetListBlog()
        {
            return Json(_context.Blog.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ErrorClass = "kt-hidden";
            return View(new BLog());
        }

        [HttpPost]
        public IActionResult Create(BLog models)
        {
            try
            {
                models.DateCreate = DateTime.Now;
                models.Alias = Regex.Replace(nonAccentVietnamese(models.Title), @"[^A-Za-z0-9_\.~]+", "-") + "-" + DateTime.Now.ToString("HHmmssddMMyyyy");
                _context.Blog.Add(models);
                _context.SaveChanges();
                return Redirect("/Admin/Blog");
            }
            catch(Exception e)
            {
                ViewBag.ErrorClass = "";
                ModelState.AddModelError("500", e.Message);
                return View(models);
            }
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            BLog bLog = _context.Blog.Find(Id);
            ViewBag.ErrorClass = "kt-hidden";
            if(bLog == null)
                return Redirect("/Admin/Blog");
            return View(bLog);
        }

        [HttpPost]
        public IActionResult Edit(BLog models)
        {
            try
            {
                models.DateCreate = DateTime.Now;
                models.Alias = Regex.Replace(nonAccentVietnamese(models.Title), @"[^A-Za-z0-9_\.~]+", "-") + "-" + models.Id;
                _context.Blog.Update(models);
                _context.SaveChanges();
                return Redirect("/Admin/Blog");
            }
            catch (Exception e)
            {
                ViewBag.ErrorClass = "";
                ModelState.AddModelError("500", e.Message);
                return View(models);
            }
        }

        [HttpPost]
        public IActionResult Remove(int Id)
        {
            try
            {
                BLog models = _context.Blog.Find(Id);
                _context.Blog.Remove(models);
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        public string nonAccentVietnamese(string str)
        {
            str = str.ToLower();
            str = Regex.Replace(str, @"à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ", "a");
            str = Regex.Replace(str, @"è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ", "e");
            str = Regex.Replace(str, @"ì|í|ị|ỉ|ĩ", "i");
            str = Regex.Replace(str, @"ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ", "o");
            str = Regex.Replace(str, @"ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ", "u");
            str = Regex.Replace(str, @"ỳ|ý|ỵ|ỷ|ỹ", "y");
            str = Regex.Replace(str, @"đ", "d");
            return str;
        }
    }
}