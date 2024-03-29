﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2090694912_NguyenXuanToan_BigSchool.Models
{
    public class Course
    {
        public bool isShowGoing = false;

        public bool isShowFollow = false;

        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public ApplicationUser Lecturer { get; set; }
        [Required]
        public string LecturerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }

        public Category Category { get; set; }
        [Required]
        public byte CategoryID { get; set; }
    }
}