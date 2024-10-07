using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newform.Models
{
    interface IEmployeeinfo
    {
         int EmployeeId { get; set; }
         string FirstName { get; set; }
         string LastName { get; set; }
         string Email { get; set; }
         string Phone { get; set; }
         DateTime DateOfBirth { get; set; }
         int DepartmentId { get; set; }
         bool IsActive { get; set; }
         string ResumePath { get; set; }
        string DepartmentName { get; set; }
        IList<Departmentmst> Departmentmaster { get; set; }
    }
    interface IDepartmentmst
    {
        int DepID { get; set; }
        string Depname { get; set; }
    }
}
