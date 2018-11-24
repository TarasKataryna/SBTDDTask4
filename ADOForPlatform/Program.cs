using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOForPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"); //Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //1
            SqlCommand query1 = new SqlCommand("select * from Employees where EmployeeID = 8;", Connection);
            SqlDataReader queryReader = query1.ExecuteReader();
            Console.WriteLine("1.Show all info about the employee with ID 8.");
            Console.WriteLine();
            while (queryReader.Read())
            {
                for(int i = 0; i < queryReader.FieldCount; ++i)
                {
                        Console.Write("{0,-25}  {1}",queryReader.GetName(i),queryReader.GetValue(i));
                    Console.WriteLine();
                }

            }
            Console.WriteLine();
            queryReader.Close();

            //2
            SqlCommand query2 = new SqlCommand("select FirstName, LastName from Employees where City = 'London';", Connection);
            queryReader = query2.ExecuteReader();
            Console.WriteLine("2.Show the list of first and last names of the employees from London.");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //3
            SqlCommand query3 = new SqlCommand("select FirstName, LastName from Employees where FirstName like 'A%';", Connection);
            queryReader = query3.ExecuteReader();
            Console.WriteLine("3.Show the list of first and last names of the employees whose first name begins with letter A.");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //4
            SqlCommand query4 = new SqlCommand("select FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) as Age from Employees wher WHERE DATEDIFF(year, BirthDate, GETDATE()) > 55 order by LastName;", Connection);
            queryReader = query4.ExecuteReader();
            Console.WriteLine("4.Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "  " + queryReader[2] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //5
            SqlCommand query5 = new SqlCommand("select COUNT(*) as AmmountOfEmployees from Employees where City = 'London';", Connection);
            queryReader = query5.ExecuteReader();
            Console.WriteLine("5.Calculate the count of employees from London.");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //6
            SqlCommand query6 = new SqlCommand("select MAX(DATEDIFF(year, BirthDate, GETDATE())) as MaxAge, MIN(DATEDIFF(year, BirthDate, GETDATE())) as MinAge, AVG(DATEDIFF(year, BirthDate, GETDATE())) as AvgAge from Employees where City = 'London';", Connection);
            queryReader = query6.ExecuteReader();
            Console.WriteLine("6.Calculate the greatest, the smallest and the average age among the employees from London.");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "  " + queryReader[2] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //7
            SqlCommand query7 = new SqlCommand("select City, MAX(DATEDIFF(year, BirthDate, GETDATE())) as MaxAge, MIN(DATEDIFF(year, BirthDate, GETDATE())) as MinAge, AVG(DATEDIFF(year, BirthDate, GETDATE())) as AvgAge from Employees GROUP BY City;", Connection);
            queryReader = query7.ExecuteReader();
            Console.WriteLine("7.Calculate the greatest, the smallest and the average age of the employees for each city.");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "  " + queryReader[2] + "  " + queryReader[3] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //8
            SqlCommand query8 = new SqlCommand("SELECT City, AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees GROUP BY City HAVING AVG(DATEDIFF(year, BirthDate, GETDATE())) > 60;", Connection);
            queryReader = query8.ExecuteReader();
            Console.WriteLine("8. Show the list of cities in which the average age of employees is greater than 60(the average age is also to be shown)\n");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] +  "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //9
            SqlCommand query9 = new SqlCommand("SELECT TOP 1 FirstName, LastName FROM Employees ORDER BY BirthDate;", Connection);
            queryReader = query9.ExecuteReader();
            Console.WriteLine("9. Show the first and last name(s) of the eldest employee(s). \n");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //10
            SqlCommand query10 = new SqlCommand("SELECT TOP 3 FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age FROM Employees ORDER BY BirthDate;", Connection);
            queryReader = query10.ExecuteReader();
            Console.WriteLine("10. Show first, last names and ages of 3 eldest employees. \n");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "  " + queryReader[2] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //11
            SqlCommand query11 = new SqlCommand("SELECT DISTINCT City FROM Employees;", Connection);
            queryReader = query11.ExecuteReader();
            Console.WriteLine("11. Show the list of all cities where the employees are from. \n");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //12
            SqlCommand query12 = new SqlCommand("SELECT FirstName, LastName, BirthDate FROM Employees WHERE MONTH(BirthDate) = 12;", Connection);
            queryReader = query12.ExecuteReader();
            Console.WriteLine("12. Show first, last names and dates of birth of the employees who celebrate their birthdays this month \n");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "  " + queryReader[2] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //13
            SqlCommand query13 = new SqlCommand("SELECT DISTINCT FirstName, LastName FROM Employees JOIN Orders ON Employees.EmployeeID = Orders.EmployeeID WHERE ShipCity = 'Madrid';", Connection);
            queryReader = query13.ExecuteReader();
            Console.WriteLine("13. Show first and last names of the employees who used to serve orders shipped to Madrid. \n");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //14
            SqlCommand query14 = new SqlCommand("SELECT E.FirstName, E.LastName, COUNT(O.EmployeeID) AS OrdersAmount FROM Employees AS E LEFT JOIN Orders AS O ON O.EmployeeID = E.EmployeeID WHERE O.OrderDate BETWEEN '1997-01-01' AND '1997-12-31' GROUP BY E.FirstName, E.LastName;", Connection);
            queryReader = query14.ExecuteReader();
            Console.WriteLine("14. Show first and last names of the employees as well as the count of orders each of them have received during the year 1997 (use left join). \n");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "  " + queryReader[2] + "\n");
            }
            Console.WriteLine();
            queryReader.Close();

            //19 query
            SqlCommand query19 = new SqlCommand(@"select Customers.ContactName,Count(Orders.CustomerID) as OrdersCount from Customers inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' Group By(Customers.ContactName)  HAVING(COUNT(Orders.CustomerID) > 1) ;", Connection);
            queryReader = query19.ExecuteReader();
            Console.WriteLine("19.Show the list of french customers’ names who have made more than one order");
            Console.WriteLine();
            while (queryReader.Read())
            {
                Console.Write("  " + queryReader[0] + "\t\t");
                Console.WriteLine(queryReader[1]);
            }
            Console.WriteLine();
            queryReader.Close();

            //20 query
            SqlCommand query20 = new SqlCommand(@"select Customers.ContactName from Customers inner join Orders  on Customers.CustomerID=Orders.CustomerID inner join [Order Details] on [Order Details].OrderID=Orders.OrderID inner join Products on [Order Details].ProductID = Products.ProductID where Products.ProductName = 'Tofu';", Connection);
            queryReader = query20.ExecuteReader();
            Console.WriteLine("20.Show the list of customers’ names who used to order the ‘Tofu’ product");
            while (queryReader.Read())
            {
                Console.WriteLine("  " + queryReader[0]);
            }
            Console.WriteLine();
            queryReader.Close();



            //23 query
            SqlCommand query23 = new SqlCommand(@"select distinct Customers.ContactName 
from Customers 
inner join Orders  
on Customers.CustomerID=Orders.CustomerID 
inner join [Order Details] 
on [Order Details].OrderID=Orders.OrderID 
inner join Products 
on [Order Details].ProductID = Products.ProductID
inner join Suppliers
on Products.SupplierID = Suppliers.SupplierID 
where Customers.Country = 'France' AND Suppliers.Country != 'France' AND Customers.ContactName not in 
(select distinct Customers.ContactName 
from Customers 
inner join Orders  
on Customers.CustomerID=Orders.CustomerID 
inner join [Order Details] 
on [Order Details].OrderID=Orders.OrderID 
inner join Products 
on [Order Details].ProductID = Products.ProductID
inner join Suppliers
on Products.SupplierID = Suppliers.SupplierID 
where Customers.Country = 'France' AND Suppliers.Country = 'France')", Connection);
            queryReader = query23.ExecuteReader();
            Console.WriteLine("23.*Show the list of french customers’ names who used to order non-french products.");
            while (queryReader.Read())
            {
                Console.WriteLine("  " + queryReader[0]);
            }
            Console.WriteLine();
            queryReader.Close();


            //24 query
            SqlCommand query24 = new SqlCommand(@"select distinct Customers.ContactName from Customers inner join Orders on Customers.CustomerID=Orders.CustomerID inner join [Order Details] on [Order Details].OrderID=Orders.OrderID inner join Products on [Order Details].ProductID = Products.ProductID inner join Suppliers on Products.SupplierID = Suppliers.SupplierID where Customers.Country = 'France' AND Suppliers.Country = 'France'", Connection);
            queryReader = query24.ExecuteReader();
            Console.WriteLine("24.*Show the list of french customers’ names who used to order french products");
            while(queryReader.Read())
            {
                Console.WriteLine("  " + queryReader[0]);
            }
            Console.WriteLine();
            queryReader.Close();
            Console.Read();



        }
    }
}
