using Employee.Moduls.EmployeeManagement.Command.Create;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Employee.Model
{
    /// <summary>
    /// Employee Management Class
    /// </summary>
    public class EmployeeManagement
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int Pincode { get; set; }
        public int ManagerID { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public List<Educationalqualification> EducationalQualifications { get; set; }
    }


}
