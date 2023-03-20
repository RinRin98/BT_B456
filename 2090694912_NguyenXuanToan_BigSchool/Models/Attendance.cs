using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2090694912_NguyenXuanToan_BigSchool.Models
{
    public class Attendence
    {
        public Course Course { get; set; }
        [Key]
        [Column(Order = 1)]

        public int CourseId { get; set; }
        public ApplicationUser Attendee { get; set; }
        [Key]
        [Column(Order = 2)]

        public string AttendeeID { get; set; }

    }
}