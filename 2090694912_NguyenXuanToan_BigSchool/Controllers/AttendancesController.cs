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
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
          
            Attendence find = _dbContext.Attendences.FirstOrDefault(p => p.AttendeeID == userId && p.CourseId == attendanceDto.CourseId);
            var attendance = new Attendence
            {
                CourseId = attendanceDto.CourseId,
                AttendeeID = userId
            };
            if (find == null)
                _dbContext.Attendences.Add(attendance);
            else
                _dbContext.Attendences.Remove(find);
           
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
