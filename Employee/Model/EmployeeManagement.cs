using System.ComponentModel.DataAnnotations;

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
        public string degree { get; set; }
        public int percentage { get; set; }


    }
}
