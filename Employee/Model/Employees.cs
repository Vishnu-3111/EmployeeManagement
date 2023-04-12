using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Employee.Model
{
    public class Employees
    {
        [Key]
        public int EmpId { get; set; }
        public string Empname { get; set; }
     
        public string Desgnation { get; set; }
        public int Pincode { get; set; }
        public int MangerID { get; set; }
        public int salary { get; set; }
        public string depName { get; set; }
    }
  

}
