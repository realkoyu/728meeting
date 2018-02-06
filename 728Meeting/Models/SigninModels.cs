using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _728Meeting.Models
{
    public class CheckNameModel
    {
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }
    }
}