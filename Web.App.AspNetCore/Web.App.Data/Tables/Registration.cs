using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.App.Data.Tables
{
    public class Registration
    {
        [Key]
        public int StudentId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string StudentName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string MobileNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmailId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Mobile { get; set; }
    }
}
