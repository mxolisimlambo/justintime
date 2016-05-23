using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class StaffViewModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Stuff_Number")]
        public string Stuff_Number { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Registration_Date")]
        public DateTime Registration_Date { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Identity Number")]
        [StringLength(13)]
        public string IdentityNumber { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        [StringLength(10)]
        public string ContactNumber { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
        public byte[] AddPhoto { get; set; }
    }
}