using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2.Question1
{
    internal class question1
    {
        public static void Run()
        {
            // list of employees
            List<Employee> employees = new List<Employee>();
            // array of departments
            string[] departments = { "Frontend Dev", "Backend Dev", "DevOps", "UI/UX Designer" };
            while (true)
            {
                Console.WriteLine("---Welcome to Employee Management System---");
                Console.WriteLine("Press 1 to Add the Employee");
                Console.WriteLine("Press 2 to Update the Employee");
                Console.WriteLine("Press 3 to Find the Employee");
                Console.WriteLine("Press 4 to Delete the Employee");
                Console.WriteLine("Press 5 to Display the Employees");
                Console.WriteLine("Press Any other number to Exit");


                string? inp = Console.ReadLine();
                if (string.IsNullOrEmpty(inp) || string.IsNullOrWhiteSpace(inp))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    if (int.TryParse(inp,out int num))
                    {
                       
                        if (num == 1)
                        {
                            Console.WriteLine("Enter the name of Employee:");
                            string name = Console.ReadLine() ?? "User";
                            Console.WriteLine("Enter the age of Employee:");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Select department:");
                            string department = "";
                            for(int i = 1; i < departments.Length; i++)
                            {
                                Console.WriteLine($"Press {i} for the department {departments[i-1]}");
                            }
                            string? numInp = Console.ReadLine();
                            if(string.IsNullOrEmpty(numInp) || string.IsNullOrWhiteSpace(numInp))
                            {
                                Console.WriteLine("No Department Assigned, You can update the department later!");
                            }
                            else if(int.TryParse(numInp,out int num2))
                            {
                                department = departments[num2 - 1];
                            }
                            else
                            {
                                Console.WriteLine("No Department Assigned, You can update the department later!");
                            }
                            employees.Add(new Employee(name, age, department));
                            Console.WriteLine("Employee Added Successfully!");
                        }
                        else if (num == 2)
                        {
                            // update the employee
                            Console.WriteLine("Enter the Id of Employee to Update: ");
                            int id = int.Parse(Console.ReadLine());
                            int index = indexFind(employees, id);
                            if (index != -1)
                            {
                                Console.WriteLine("Enter the name of Employee:");
                                string name = Console.ReadLine() ?? "User";
                                Console.WriteLine("Enter the name of Employee:");
                                int age = int.Parse(Console.ReadLine());
                                Console.WriteLine("Select department:");
                                string department = "";
                                for (int i = 1; i < departments.Length; i++)
                                {
                                    Console.WriteLine($"Press {i} for the department {departments[i - 1]}");
                                }
                                string? numInp = Console.ReadLine();
                                if (string.IsNullOrEmpty(numInp) || string.IsNullOrWhiteSpace(numInp))
                                {
                                    Console.WriteLine("No Department Assigned, You can update the department later!");
                                }
                                else if (int.TryParse(numInp, out int num2))
                                {
                                    department = departments[num2 - 1];
                                }
                                else
                                {
                                    Console.WriteLine("No Department Assigned, You can update the department later!");
                                }
                                employees[index].name = name;
                                employees[index].department = department;
                                employees[index].age = age;
                                Console.WriteLine("Employee Updated Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Employee not found");
                            }

                        }
                        else if (num == 3)
                        {
                            // find employee
                            Console.WriteLine("Enter the id of Employee to Find: ");
                            int id = int.Parse(Console.ReadLine());

                            findEmployee(employees,id);
                        }
                        else if (num == 4)
                        {
                            // delete 
                            DeleteEmployee(employees);
                        }
                        else if (num == 5)
                        {
                            // display all employees
                            if (employees.Count > 0) 
                            {
                                foreach (Employee emp in employees)
                                {
                                    Console.WriteLine("----------------");
                                    Console.WriteLine($"Name:{emp.name}");
                                    Console.WriteLine($"Id:{emp.eId}");
                                    Console.WriteLine($"Age:{emp.age}");
                                    Console.WriteLine($"Department:{emp.department}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No employees in the list yet!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quit...");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input should be Integer!");
                    }
                }
            }
            
        }

        public static bool findEmployee(List<Employee> employees,int id)
        {
            Employee emp = employees.Find(x => x.eId == id);
            if(emp == null)
            {
                Console.WriteLine("Employee Not Found");
                return false;
            }
            Console.WriteLine("Employee Found");
            Console.WriteLine($"Name:{emp.name}");
            Console.WriteLine($"Id:{emp.eId}");
            Console.WriteLine($"Age:{emp.age}");
            Console.WriteLine($"Department:{emp.department}");
            return true;
        }

        public static void DeleteEmployee(List<Employee> employees)
        {
            // delete employee
            Console.WriteLine("Enter the Id of Employee to Find: ");
            int id = int.Parse(Console.ReadLine());
            int index = indexFind(employees, id);
            if (index!= -1)
            {
                employees.RemoveAt(index);
                Console.WriteLine("Employee Deleted Sucessfully!");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }

        }

        public static int indexFind(List<Employee> employees,int id)
        {
            for(int i = 0; i < employees.Count; i++)
            {
                if(id == employees[i].eId)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    class Employee
    {
        public string name;
        public int age;
        public string department;
        public int eId;
        public static int genId = 0;

        public Employee(string name,int age,string department) {
            this.name = name;
            this.age = age;
            this.department = department;
            eId = ++genId;
        }
    }
}
