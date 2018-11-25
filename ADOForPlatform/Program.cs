namespace ADOForPlatform
{
    using System;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            /*SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            ADORepository repository = new ADORepository(Connection);
            //1
            /* SqlCommand query1 = new SqlCommand("select * from Employees where EmployeeID = 8;", Connection);
             SqlDataReader queryReader = query1.ExecuteReader();
             Console.WriteLine("1.Show all info about the employee with ID 8.");
             Console.WriteLine();
             while (queryReader.Read())
             {
                 for (int i = 0; i < queryReader.FieldCount; ++i)
                 {
                     Console.Write("{0,-25}  {1}", queryReader.GetName(i), queryReader.GetValue(i));
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
                 Console.Write("  " + queryReader[0] + "  " + queryReader[1] + "\n");
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
             */
            //18 query
            string query18 = @"SELECT C.ContactName 
                                                FROM Customers AS C 
                                                JOIN Orders AS O ON O.CustomerID = C.CustomerID
                                                WHERE C.Country = 'France'
                                                GROUP BY C.ContactName       
HAVING COUNT (O.CustomerID) > 1;";
            Console.WriteLine("18. Show the list of french customers’ names who have made more than one order(use grouping)");
            List<string[]> res = repository.getFromDatabse(query18, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //19 query
            string query19 = @"select Customers.ContactName from Customers inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' Group By(Customers.ContactName)  HAVING(COUNT(Orders.CustomerID) > 1) ;";
            Console.WriteLine("19.Show the list of french customers’ names who have made more than one order");
            Console.WriteLine();
            res = repository.getFromDatabse(query19, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //20 query
            string query20 = @"select Customers.ContactName from Customers inner join Orders  on Customers.CustomerID=Orders.CustomerID inner join [Order Details] on [Order Details].OrderID=Orders.OrderID inner join Products on [Order Details].ProductID = Products.ProductID where Products.ProductName = 'Tofu';";
            Console.WriteLine("20.Show the list of customers’ names who used to order the ‘Tofu’ product");
            Console.WriteLine();
            res = repository.getFromDatabse(query20, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //21 query
            string query21 = @"SELECT C.ContactName, SUM(OD.Quantity) AS Count, SUM(OD.UnitPrice * OD.Quantity) AS PriceSum 
                                                 FROM Customers AS C 
                                                 LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID 
                                                 LEFT JOIN [Order Details] AS OD ON OD.OrderId = O.OrderId
                                                 LEFT JOIN [Products] AS P ON P.ProductID = OD.ProductID 
                                                 WHERE P.ProductName = 'Tofu'
                                                 GROUP BY C.ContactName;";
            Console.WriteLine("21.	*Show the list of customers’ names who used to order the ‘Tofu’ product, along with the total amount of the product they have ordered and with the total sum for ordered product calculated.");
            res = repository.getFromDatabse(query21, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //22 query
            string query22 = @"SELECT DISTINCT C.ContactName 
                                                 FROM Customers as C 
                                                 LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID 
                                                 LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID 
                                                 LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID 
                                                 LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID 
                                                 WHERE S.Country <> 'France' AND C.Country = 'France'";
            Console.WriteLine("22.	*Show the list of french customers’ names who used to order non-french products (use left join).");
            res = repository.getFromDatabse(query22, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //23 query
            string query23 = @"select distinct Customers.ContactName 
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
 where Customers.Country = 'France' AND Suppliers.Country = 'France')";

            Console.WriteLine("23.*Show the list of french customers’ names who used to order non-french products.");
            res = repository.getFromDatabse(query23, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            //24 query
            string query24 = @"select distinct Customers.ContactName from Customers inner join Orders on Customers.CustomerID=Orders.CustomerID inner join [Order Details] on [Order Details].OrderID=Orders.OrderID inner join Products on [Order Details].ProductID = Products.ProductID inner join Suppliers on Products.SupplierID = Suppliers.SupplierID where Customers.Country = 'France' AND Suppliers.Country = 'France'";
            Console.WriteLine("24.*Show the list of french customers’ names who used to order french products");
            res = repository.getFromDatabse(query24, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Read();

            //29
            /*Console.WriteLine("29.");
            string com29 = "select e.FirstName + ' ' + e.LastName as FullNameEmployee," +
                            " c.FirstName + ' '+c.LastName as FullNameChief " +
                            "from Employees as e " +
                            "left join employees as c " +
                            "on e.reportsto = c.employeeid";
            SqlCommand query29 = new SqlCommand(com29, Connection);
            SqlDataReader reader29 = query29.ExecuteReader();

            while (reader29.Read())
            {
                for (int i = 0; i < reader29.FieldCount; i++)
                {
                    Console.Write($"   {reader29.GetName(i)} : {reader29.GetValue(i)}");
                }
                Console.WriteLine();
            }

            reader29.Close();
            Console.WriteLine();
            //query30
            Console.WriteLine("30");
            string cmd30 = "(select city from Customers) " +
                            "union " +
                            "(select city from Employees) " +
                            "union " +
                            "(select s.city from products as p " +
                            "inner join suppliers as s on " +
                            "p.supplierid = s.SupplierID); ";
            SqlCommand query30 = new SqlCommand(cmd30, Connection);
            SqlDataReader reader30 = query30.ExecuteReader();

            while (reader30.Read())
            {
                Console.WriteLine($"   City : {reader30[0]}");
            }
            reader30.Close();
            Console.WriteLine();

            //query31

            Console.WriteLine("31.");
            string cmd31 = "insert into employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) " +
"values " +
"('Petro', 'Rebro', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 10 str.', 'Ternopil', 'Ukraine', 'Eduard'), " +
"('Oleg', 'Wou', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 11 str.', 'Lviv', 'Ukraine', 'Eduard') , " +
"('Andriy', 'Kou', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 12 str.', 'Ternopil', 'Ukraine', 'Eduard') , " +
"('Asdad', 'Aqweewr', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 13 str.', 'Lviv', 'Ukraine', 'Eduard') , " +
"('Pezvzxcvtro', 'Vcbvcb', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 14 str.', 'Lviv', 'Ukraine', 'Eduard'); ";

            SqlCommand query31 = new SqlCommand(cmd31, Connection);
            int employeeid = 0;
            int rowsAffected = query31.ExecuteNonQuery();
            Console.Write($"Rows affected : {rowsAffected}");
            Console.WriteLine();


            //query32
            Console.WriteLine("32.");
            string cmd32 = "select * from employees where cast(notes as nvarchar) = 'Eduard'";

            SqlCommand query32 = new SqlCommand(cmd32, Connection);

            SqlDataReader sqlData32 = query32.ExecuteReader();

            while (sqlData32.Read())
            {
                employeeid = (int)sqlData32.GetValue(0);
                for (int i = 0; i < sqlData32.FieldCount; i++)
                {
                    Console.Write($"{sqlData32.GetValue(i)} ");
                }
                Console.WriteLine();
            }
            sqlData32.Close();
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("33.");

            //query33
            string cmd33 = $"update employees set city = 'obuhiv' where employeeid = (select top 1 employeeid from employees where cast(notes as nvarchar) = 'Eduard')";
            SqlCommand sqlCommand33 = new SqlCommand(cmd33, Connection);
            rowsAffected = sqlCommand33.ExecuteNonQuery();
            Console.WriteLine($"Rows affected : {rowsAffected}");
            Console.WriteLine();

            //query34
            Console.WriteLine("34.");
            string cmd34 = $"update employees set hiredate = GETDATE() where cast(notes as nvarchar) = 'Eduard'";
            sqlCommand33 = new SqlCommand(cmd34, Connection);
            rowsAffected = sqlCommand33.ExecuteNonQuery();
            Console.WriteLine($"Rows affected : {rowsAffected}");
            Console.WriteLine();

            //query35

            Console.WriteLine("35.");
            cmd34 = "delete from employees where employeeid = (select top 1 employeeid from employees where cast(notes as nvarchar) = 'Eduard')";
            sqlCommand33 = new SqlCommand(cmd34, Connection);
            Console.WriteLine($"Rows affected : {sqlCommand33.ExecuteNonQuery()}");
            Console.ReadKey();*/
        }
    }
}
