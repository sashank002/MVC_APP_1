using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MVC.Models
{
    public class Teacher
    {
        [Key]
        public int Teacher_id
        { get; set; }

        [Required]
        public string Teacher_name
        { get; set; }

        [Required]
        public string Teacher_subject
        { get; set; }


        public int rating
        {
            get;
            set;
        }
    }
}