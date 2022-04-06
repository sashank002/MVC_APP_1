using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MVC.Models
{
    public class Subject
    {
        [Key]
        public int Subject_id { get; set; }

        [Required]
        public string Subject_name { get; set; }


        [Required]
        public string Syllabus { get; set; }

        [Range(1, 5)]

        public int credits { get; set; }
    }
}