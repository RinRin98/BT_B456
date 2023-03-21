using _2090694912_NguyenXuanToan_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace _2090694912_NguyenXuanToan_BigSchool.Controllers.Api
{
    public class CoursesController : ApiController
    {
        // GET: Courses
        ApplicationDbContext _dbContext { get; set; }

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);


            if (course.IsCanceled)
            {
                return NotFound();
            }

            course.IsCanceled = true;

            _dbContext.SaveChanges();

            return Ok();

        }
    }
}