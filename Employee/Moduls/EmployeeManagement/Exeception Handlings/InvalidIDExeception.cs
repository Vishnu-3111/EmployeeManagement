
using System;

namespace Employee.Moduls.EmployeeManagement.Exeception_Handlings
{
    public class InvalidIDException  :Exception
    {

        public InvalidIDException() : base(message: "Employee Record Not Found")
        {

        }



    }
   
    
}
 
