using _2090694912_NguyenXuanToan_BigSchool.DTOs;
using _2090694912_NguyenXuanToan_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace _2090694912_NguyenXuanToan_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        // GET: Followings
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow (FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
        
            Following find = _dbContext.Followings.FirstOrDefault(p => p.FollowerId == userId && p.FolloweeId == followingDto.FolloweeId);
           
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            if (find == null)
                _dbContext.Followings.Add(following);
            else
                _dbContext.Followings.Remove(find);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}