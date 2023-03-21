using _2090694912_NguyenXuanToan_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using _2090694912_NguyenXuanToan_BigSchool.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace _2090694912_NguyenXuanToan_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            
            var upcommingCourses = _dbContext.Courses.Include(c => c.Lecturer).Include(c => c.Category).Where(c => c.DateTime > DateTime.Now).ToList();
            var loginUser = User.Identity.GetUserId();
            ViewBag.LoginUser = loginUser;
            foreach (Course i in upcommingCourses)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.LecturerId);
                Attendence find = _dbContext.Attendences.FirstOrDefault(p => p.CourseId == i.Id && p.AttendeeID== loginUser);
                if (find == null)
                    i.isShowGoing = true;


                Following findFollow = _dbContext.Followings.FirstOrDefault(p => p.FollowerId == loginUser && p.FolloweeId == i.LecturerId);
                if (findFollow == null)
                    i.isShowFollow = true;
            }
            var viewModel = new CourseViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}