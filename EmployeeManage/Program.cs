using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.WebRequestMethods;

public class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        // client.BaseAddress = new Uri("https://localhost:7253/api/Employee");
    
        //request.Headers.Add("Custom-Header", "Header-Value");
        // HttpResponseMessage responce = client.SendAsync(request).Result;




        //HttpResponseMessage response = await client.GetAsync("https://localhost:7253/api/Employee");


        //IEnumerable<string> headerValues = response.Headers.GetValues("mycustomheader");
        //response.Headers.Contains()

        Console.WriteLine("Enter choice");
        Console.WriteLine("1.Create");
        Console.WriteLine("2.Put");
        Console.WriteLine("3.Get");
        Console.WriteLine("4.GetById");
        Console.WriteLine("5.Delete");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
           
            case 1:
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
                Console.WriteLine("Enter Custom-Header ");
                string value = Console.ReadLine();
                client.DefaultRequestHeaders.Add("Custom-Header", value);
                HttpResponseMessage message = await client.PostAsync("https://localhost:7253/api/Employee/CreateEmployee", contents);
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
          
            case 2:
                Console.WriteLine("Enter Employee Details");
                Console.WriteLine("Enter Employee ID");
                int Id = Convert.ToInt32(Console.ReadLine());
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
            case 3:
                Console.WriteLine("Enter Custom-Header ");
                value = Console.ReadLine();
                client.DefaultRequestHeaders.Add("Custom-Header", value);
                HttpResponseMessage response = client.GetAsync("https://localhost:7253/api/Employee").Result;
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
            case 4:
                Console.WriteLine("Enter Employee Id");
                int employeeID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Custom-Header ");
                value = Console.ReadLine();
                client.DefaultRequestHeaders.Add("Custom-Header", value);

                response = await client.GetAsync("https://localhost:7253/api/Employee/GetEmployeebyId?Id=" + employeeID);
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
            case 5:
                Console.WriteLine("Enter Employee ID");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Custom-Header ");
                value = Console.ReadLine();
                client.DefaultRequestHeaders.Add("Custom-Header", value);
                HttpResponseMessage respon = await client.DeleteAsync("https://localhost:7253/api/Employee/DeleteEmployee?id=" + id);

                if (respon.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data deleted successfully." + respon);
                }
                else
                {
                    Console.WriteLine($"Failed to delete data: {respon.StatusCode}");
                }
                Console.ReadKey();
                break;

        }
    }

}


