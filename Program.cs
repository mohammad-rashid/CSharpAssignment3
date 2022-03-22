using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace EmployeeBook
{
	public class Program
	{
		IList employeeList;
		IList salaryList;

		public Program()
		{
            employeeList = new List<Employee>() {
			new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
			new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
			new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
			new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
			new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
			new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
			new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
		};

			salaryList = new List<Salary>() {
			new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
		};
		}

		public static void Main()
		{
			Program program = new Program();

			program.Task1();

			program.Task2();

			program.Task3();
		}

		public void Task1()
		{
            Console.WriteLine("Task 1 : \n");
			
			var query2 =
				from emp in employeeList.OfType<Employee>()
				join sal in salaryList.OfType<Salary>()
				on emp.EmployeeID equals sal.EmployeeID
				orderby sal.Amount descending

				select new
				{
					emp.EmployeeFirstName, emp.EmployeeLastName,
					sal.Amount,
					sum=sal.Amount
				};



			foreach (var emp in query2)
			{
				Console.WriteLine($"Total Salary of {emp.EmployeeFirstName} {emp.EmployeeLastName} : {emp.Amount}");
			}
				
		}

		public void Task2()
		{
            Console.WriteLine("\nTask 2 : \n");
			
			var query =
				from emp in employeeList.OfType<Employee>()
				join sal in salaryList.OfType<Salary>()
				on emp.EmployeeID equals sal.EmployeeID
				orderby emp.Age descending


				select new
				{
					Sal = sal.Amount,
					emp.EmployeeFirstName,
					emp.EmployeeLastName,
					emp.Age
				};

			foreach (var i in query.Where(a => a.Age < query.Max(a=>a.Age)).Take(1))
            {
                Console.WriteLine($"Name: {i.EmployeeFirstName} {i.EmployeeLastName}");
                Console.WriteLine($"Age: {i.Age}");
                Console.WriteLine($"Salary: {i.Sal}");	
            }
			
		}

		public void Task3()
		{
            Console.WriteLine("\nTask 3 :");
			var query =
				from emp in employeeList.OfType<Employee>()
				join sal in salaryList.OfType<Salary>()
				on emp.EmployeeID equals sal.EmployeeID
				group sal 
				by new { emp.EmployeeFirstName, emp.Age } into g
				select new
				{
					
					g,
					avg=g.Average(a=>a.Amount)
				};
			
			foreach (var i in query.Where(a=>a.g.Key.Age>30))
			{
				Console.WriteLine($"Mean Salary of {i.g.Key.EmployeeFirstName} : {i.avg:N2}   Age: {i.g.Key.Age}");
		
			}		
		}
	}

	public enum SalaryType
	{
		Monthly,
		Performance,
		Bonus
	}

	public class Employee
	{
		public int EmployeeID { get; set; }
		public string EmployeeFirstName { get; set; }
		public string EmployeeLastName { get; set; }
		public int Age { get; set; }
	}

	public class Salary
	{
		public int EmployeeID { get; set; }
		public int Amount { get; set; }
		public SalaryType Type { get; set; }
	}
}
