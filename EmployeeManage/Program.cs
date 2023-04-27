using Microsoft.VisualBasic;
using System.Text;

public class Program
{
    HttpClient client = new HttpClient();
    public async Task<string> sendMethod(HttpRequestMessage request)
    {
        
        HttpResponseMessage response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
           return "unsuccessfull";
        }
    }
    public async Task<string> CreateEmployee(string HeaderValue)
    {
        Program program = new Program();
        Console.WriteLine("Enter Employee Details");
        Console.WriteLine("Enter Employee Name");
        string Name = Console.ReadLine();
        Console.WriteLine("Enter Designation Name");
        string Design = Console.ReadLine();
        Console.WriteLine("Enter Pincode ");
        int Pin = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter ManagerID ");
        int Managerid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Salary");
        int salary = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter DepartmentName");
        string departmentName = Console.ReadLine();
        Console.WriteLine("Enter degree");
        string Degree = Console.ReadLine();
        Console.WriteLine("Enter percentage");
        int Percentage = Convert.ToInt32(Console.ReadLine());

        var data = new
        {
            EmployeeName = Name,
            Designation = Design,
            Pincode = Pin,
            ManagerID = Managerid,
            Salary = salary,
            DepartmentName = departmentName,
            degree = Degree,
            percentage = Percentage
        };
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        var contents = new StringContent(json, Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Add("Custom-Header", HeaderValue);
        Uri u = new("https://localhost:7253/api/Employee/CreateEmployee,");
        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = u,
            Content = contents
        };

        string response = await program.sendMethod(request);
        Console.WriteLine("Result:", response);
        return "";

    }
    public async Task<string> GetAllEmployee(string HeaderValue)
    {
        client.DefaultRequestHeaders.Add("Custom-Header", HeaderValue);
        Uri u = new("https://localhost:7253/api/Employee");
        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = u,
            
        };
       string response = await this.sendMethod(request);

            Console.WriteLine(response);
            return "";
    }
    public async Task<string> UpdateEmployee(string HeaderValue)
    {
        Console.WriteLine("Enter Employee Details");
        Console.WriteLine("Enter Employee ID");
        int Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Employee Name");
        string Name = Console.ReadLine();
        Console.WriteLine("Enter Designation Name");
        string Design = Console.ReadLine();
        Console.WriteLine("Enter Pincode ");
        int Pin = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter ManagerID ");
        int Managerid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Salary");
        int salary = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter DepartmentName");
        string departmentName = Console.ReadLine();
        Console.WriteLine("Enter degree");
        string Degree = Console.ReadLine();
        Console.WriteLine("Enter percentage");
        int Percentage = Convert.ToInt32(Console.ReadLine());

        var datas = new
        {
            EmployeeID = Id,
            EmployeeName = Name,
            Designation = Design,
            Pincode = Pin,
            ManagerID = Managerid,
            Salary = salary,
            DepartmentName = departmentName,
            degree = Degree,
            percentage = Percentage
        };
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(datas);
        var contents = new StringContent(json, Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Add("Custom-Header", HeaderValue);
       
        Uri u = new("https://localhost:7253/api/Employee/UpdateEmployee,");
        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = u,
            Content = contents
        };
        string message = await this.sendMethod(request);
      
            Console.WriteLine(message);
            return "";
    }
    public async Task<string> GetById(string HeaderValue)
    {
        Console.WriteLine("Enter Employee Id");
        int employeeID = Convert.ToInt32(Console.ReadLine());
        client.DefaultRequestHeaders.Add("Custom-Header", HeaderValue);

        Uri u = new("https://localhost:7253/api/Employee/GetEmployeebyId?Id=" + employeeID);
        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = u,
            
        };
        string message = await this.sendMethod(request);
      
            Console.WriteLine(message);
            return  message;
    }

    public async Task<string> DeleteEmployee(string HeaderValue)
    {
        Console.WriteLine("Enter Employee ID");
        int id = Convert.ToInt32(Console.ReadLine());
        client.DefaultRequestHeaders.Add("Custom-Header", HeaderValue);
        Uri u = new("https://localhost:7253/api/Employee/DeleteEmployee?Id=" + id);
        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = u,

        };


        return await this.sendMethod(request);
    }
        
    static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine("Enter Header Value");
        string choice = Console.ReadLine();
       

        switch (choice)
        {
            case "Create-Value":
                program.CreateEmployee(choice);
                Console.ReadKey();
                break;

            case "Update-Value":
                program.UpdateEmployee(choice);
                Console.ReadKey();
                break;

            case "Get-Value":
                program.GetAllEmployee(choice);
                Console.ReadLine();
                break;

            case "GetById-Value":
                program.GetById(choice);
                Console.ReadKey();
                break;

            case "Delete-Value":
                program.DeleteEmployee(choice);
                Console.ReadLine();
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

}


