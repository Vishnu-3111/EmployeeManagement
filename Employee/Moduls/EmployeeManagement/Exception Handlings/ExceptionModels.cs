namespace Employee.Moduls.EmployeeManagement.Exeception_Handlings
{
    public class InvalidIDException  
    {

        public  class InvalidIDExceptions:Exception
        { 
             public  InvalidIDExceptions() : base(message: "Employee Record Not Found")
             {

             }

        }
        public class BadRequest : Exception
        {
            public BadRequest() : base(message: "Bad request")
            {

            }

        }



    }
   
    
}
 
