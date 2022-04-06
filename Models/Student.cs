using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        public int Student_id
        { get; set; }

        [Required]
        public string Student_name
        { get; set; }

        [Required]
        public string Student_class
        { get; set; }


        [ForeignKey("Subject")]
        [Display(Name = "Subject")]
        public int Subject_id
        { get; set; }


    }
}