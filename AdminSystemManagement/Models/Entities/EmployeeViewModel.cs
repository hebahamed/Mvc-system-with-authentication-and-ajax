using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminSystemManagement.Models.Entities
{
    public class EmployeeViewModel
    {
        public Employee employee { get; set; }
        public List<Department> departments { get; set; }

        public List<Employee> Employees { get; set; }
    }
}