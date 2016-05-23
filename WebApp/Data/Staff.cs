using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Stuff_Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Registration_Date { get; set; }
        public string Gender { get; set; }
        public byte[] AddPhoto { get; set; }
        public string IdentityNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Role { get; set; }
    }
}