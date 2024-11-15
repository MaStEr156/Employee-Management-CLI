using System;
using System.Collections.Generic;

namespace Menu
{
    class Employee : IComparable<Employee>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        public char Gender { get; set; }

        public Employee(int id, string name, float salary, char gender)
        {
            ID = id;
            Name = name;
            Salary = salary;
            Gender = gender;
        }
        public Employee()
        {

        }

        public int CompareTo(Employee other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }

    class SortByName : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    class SortBySalary : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }

    internal class Program
    {
        static Employee AddEmployee()
        {

            try
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Salary: ");
                float salary = float.Parse(Console.ReadLine());

                Console.Write("Enter Gender M/F: ");
                char gender = char.Parse(Console.ReadLine());

                Console.WriteLine("___________________________________");

                return new Employee(id, name, salary, gender);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return AddEmployee();
            }
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                try
                {
                    Console.WriteLine($"ID: {employee.ID}, Name: {employee.Name}, Salary: {employee.Salary}, Gender: {employee.Gender}");

                }
                catch (NullReferenceException e)
                {
                    continue;
                }
            }
        }

        static void SearchEmployee(List<Employee> employees)
        {
            Console.WriteLine("Search by:\n 1) ID\n 2) Name\n");
            int searchOption = int.Parse(Console.ReadLine());

            switch (searchOption)
            {
                case 1:
                    Console.Write("Enter ID to search: ");
                    int id = int.Parse(Console.ReadLine());
                    foreach (Employee employee in employees)
                    {
                        if (employee.ID == id)
                        {
                            Console.WriteLine($"Found: ID: {employee.ID}, Name: {employee.Name}, Salary: {employee.Salary}, Gender: {employee.Gender}");
                            return;
                        }
                    }
                    Console.WriteLine("Employee not found.");
                    break;

                case 2:
                    Console.Write("Enter Name to search: ");
                    string name = Console.ReadLine();
                    foreach (Employee employee in employees)
                    {
                        if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Found: ID: {employee.ID}, Name: {employee.Name}, Salary: {employee.Salary}, Gender: {employee.Gender}");
                            return;
                        }
                    }
                    Console.WriteLine("Employee not found.");
                    break;

                default:
                    Console.WriteLine("Invalid search option.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            string[] menu = { "Add", "Display", "Search", "Sort", "Exit" };

            int position = 0;
            bool running = true;

            do
            {
                Console.Clear();
                int x = Console.WindowWidth / 2;
                int y = (Console.WindowHeight / 2) - (menu.Length / 2);

                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == position)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.SetCursorPosition(x, y + i);
                    Console.WriteLine(menu[i]);
                }

                Console.ResetColor();
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        position--;
                        if (position < 0)
                        {
                            position = menu.Length - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        position++;
                        if (position >= menu.Length)
                        {
                            position = 0;
                        }
                        break;

                    case ConsoleKey.Enter:

                        Console.Clear();
                        switch (position)
                        {
                            case 0:
                                employees.Add(AddEmployee());
                                break;
                            case 1:
                                DisplayEmployees(employees);
                                Console.ReadKey();
                                break;
                            case 2:
                                SearchEmployee(employees);
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Sort by:\n 1. ID\n 2. Name\n 3. Salary\n");
                                int sortOption = int.Parse(Console.ReadLine());

                                switch (sortOption)
                                {
                                    case 1:
                                        employees.Sort(); // Sort by ID using IComparable
                                        Console.WriteLine("Sorted by ID:");
                                        DisplayEmployees(employees);
                                        break;

                                    case 2:
                                        employees.Sort(new SortByName()); // Sort by Name using IComparer
                                        Console.WriteLine("Sorted by Name:");
                                        DisplayEmployees(employees);
                                        break;

                                    case 3:
                                        employees.Sort(new SortBySalary()); // Sort by Salary using IComparer
                                        Console.WriteLine("Sorted by Salary:");
                                        DisplayEmployees(employees);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid sort option.");
                                        break;
                                }
                                Console.ReadKey();
                                break;
                            case 4:
                                running = false;
                                break;
                        }
                        break;
                }
            } while (running);
        }
    }
}
