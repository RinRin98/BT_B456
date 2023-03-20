using _2090694912_NguyenXuanToan_BigSchool.DTOs;
using _2090694912_NguyenXuanToan_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2090694912_NguyenXuanToan_BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendences.Any(a => a.AttendeeID == userId && a.CourseId == courseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendence
            {
                CourseId = courseId,
                AttendeeID = User.Identity.GetUserId()
            };
            _dbContext.Attendences.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
