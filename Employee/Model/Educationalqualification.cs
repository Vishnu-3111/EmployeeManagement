using Employee.Moduls.EmployeeManagement.Command.Create;
using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{/// <summary>
/// Education Qualification model used to add Education Qualification of employee
/// </summary>
    public class Educationalqualification
    { 
        [Key]
        public string degree { get; set; }
        public int percentage { get; set; }

        public int EmployeesEmpId { get; set; }
    }

}
