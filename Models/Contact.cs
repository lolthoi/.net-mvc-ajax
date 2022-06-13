using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("C_Name", Order = 1, IsUnique = true)]
        public string Name { get; set; }
        [StringLength(50)]
        [Index("C_Name", Order = 2, IsUnique = true)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
    }
}