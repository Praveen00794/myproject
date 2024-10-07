using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newform.Models
{
    public class Employeeinfo : IEmployeeinfo
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
       
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
      
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        public bool IsActive { get; set; } 

        public string ResumePath { get; set; }

       
        public string DepartmentName { get; set; }

        public IList<Departmentmst> Departmentmaster { get; set; }
    }
    public class Departmentmst : IDepartmentmst
    {
        public int DepID { get; set; }
        public string Depname { get; set; }
    }
}