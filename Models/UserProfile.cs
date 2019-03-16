using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace UserProfileAPIDemo.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public double Salary { get; set; }

        [DisplayName("Upload Profile Image")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}