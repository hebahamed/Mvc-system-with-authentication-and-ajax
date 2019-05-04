using AdminSystemManagement.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminSystemManagement.Models.Entities
{
        [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(20, 100)]
        public int Age { get; set; }
        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        [ForeignKey("Department")]
        public int Fk_DepartmentId { get; set; }

        public Department Department { get; set; }

        public DateTime DateProperty { get; set; }

    }
}