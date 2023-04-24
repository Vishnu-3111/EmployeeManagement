using System.Net.Http.Json;
using System.Text;
using System.Transactions;

public class Program
{
     static async Task Main(string[] args)
     {
        HttpClient client = new HttpClient();
        Console.WriteLine("Enter choice");
        Console.WriteLine("1.Create");
        Console.WriteLine("2.Put");
        Console.WriteLine("3.Get");
        Console.WriteLine("4.GetById");
        Console.WriteLine("5.Delete");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 3:

                HttpResponseMessage response = await client.GetAsync("https://localhost:7253/api/Employee");
                if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to retrieve data: {response.StatusCode}");
                    }

                    Console.ReadKey();
                break;
            case 1:
                Console.WriteLine("Enter Employee Details");
                Console.WriteLine("Enter Employee Name");
                string Name= Console.ReadLine();
                Console.WriteLine("Enter Designation Name");
                string Design= Console.ReadLine();
                Console.WriteLine("Enter Pincode ");
                int Pin= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter ManagerID ");
                int Managerid= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Salary");
                int salary= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter DepartmentName");
                string departmentName = Console.ReadLine();
                Console.WriteLine("Enter degree");
                string Degree= Console.ReadLine();
                Console.WriteLine("Enter percentage");
                int Percentage= Convert.ToInt32(Console.ReadLine());

                var data = new { EmployeeName = Name,
                    Designation = Design,
                    Pincode=Pin,
                    ManagerID= Managerid,
                    Salary=salary,
                    DepartmentName= departmentName,
                    degree= Degree,
                    percentage=Percentage };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var contents = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync("https://localhost:7253/api/Employee", contents);
                if (message.IsSuccessStatusCode)
                {
                    string result = await message.Content.ReadAsStringAsync();
                    Console.WriteLine($"Data added successfully. Result: {result}");
                }
                else
                {
                    Console.WriteLine($"Failed to add data: {message.StatusCode}");
                }
                Console.ReadKey();
                break;
            case 5:
                Console.WriteLine("Enter Employee ID");
                int id=Convert.ToInt32(Console.ReadLine());
                HttpResponseMessage respon = await client.DeleteAsync("https://localhost:7253/api/Employee/"+id);

                if (respon.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to delete data: {respon.StatusCode}");
                }

                Console.ReadKey();
                break;
            case 2:
                Console.WriteLine("Enter Employee Details");
                Console.WriteLine("Enter Employee ID");
                int Id=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Name");
                 Name = Console.ReadLine();
                Console.WriteLine("Enter Designation Name");
                 Design = Console.ReadLine();
                Console.WriteLine("Enter Pincode ");
                 Pin = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter ManagerID ");
                 Managerid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Salary");
                 salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter DepartmentName");
                 departmentName = Console.ReadLine();
                Console.WriteLine("Enter degree");
                 Degree = Console.ReadLine();
                Console.WriteLine("Enter percentage");
                 Percentage = Convert.ToInt32(Console.ReadLine());

                 var datas = new
                {
                     EmployeeID=Id,
                    EmployeeName = Name,
                    Designation = Design,
                    Pincode = Pin,
                    ManagerID = Managerid,
                    Salary = salary,
                    DepartmentName = departmentName,
                    degree = Degree,
                    percentage = Percentage
                };
                 json = Newtonsoft.Json.JsonConvert.SerializeObject(datas);
                 contents = new StringContent(json, Encoding.UTF8, "application/json");
                 message = await client.PutAsync("https://localhost:7253/api/Employee", contents);
                if (message.IsSuccessStatusCode)
                {
                    string result = await message.Content.ReadAsStringAsync();
                    Console.WriteLine($"Data Updated successfully. Result: {result}");
                }
                else
                {
                    Console.WriteLine($"Failed to Update data: {message.StatusCode}");
                }
                Console.ReadKey();
                break;
            case 4:
                Console.WriteLine("Enter Employee Id");
                int employeeID=Convert.ToInt32(Console.ReadLine());

                 response = await client.GetAsync("https://localhost:7253/api/Employee/GetEmployeebyId?Id="+employeeID);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve data: {response.StatusCode}");
                }

                Console.ReadKey();
                break;

        }


    }
}

    
