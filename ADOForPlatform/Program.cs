namespace ADOForPlatform
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"> string args </param>
        public static void Main(string[] args)
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
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            ADORepository repository = new ADORepository(connection);
            ////1
             string query1 = @"select * from Employees where EmployeeID = 8;";
             Console.WriteLine("1.Show all info about the employee with ID 8.");
            List<string[]> res = repository.GetFromDatabse(query1, 18);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
             
            ////2
             string query2 = "select FirstName, LastName from Employees where City = 'London';";
             Console.WriteLine("2.Show the list of first and last names of the employees from London.");
            res = repository.GetFromDatabse(query2, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////3
            string query3 = "select FirstName, LastName from Employees where FirstName like 'A%';";
             
             Console.WriteLine("3.Show the list of first and last names of the employees whose first name begins with letter A.");
            res = repository.GetFromDatabse(query3, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////4
            string query4 = "select FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) as Age from Employees wher WHERE DATEDIFF(year, BirthDate, GETDATE()) > 55 order by LastName;";
             Console.WriteLine("4.Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.");
            res = repository.GetFromDatabse(query4, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////5
            string query5 = "select COUNT(*) as AmmountOfEmployees from Employees where City = 'London';";
             Console.WriteLine("5.Calculate the count of employees from London.");
            res = repository.GetFromDatabse(query5, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////6
            string query6 = "select MAX(DATEDIFF(year, BirthDate, GETDATE())) as MaxAge, MIN(DATEDIFF(year, BirthDate, GETDATE())) as MinAge, AVG(DATEDIFF(year, BirthDate, GETDATE())) as AvgAge from Employees where City = 'London';";
             
             Console.WriteLine("6.Calculate the greatest, the smallest and the average age among the employees from London.");
            res = repository.GetFromDatabse(query6, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////7
            string query7 = "select City, MAX(DATEDIFF(year, BirthDate, GETDATE())) as MaxAge, MIN(DATEDIFF(year, BirthDate, GETDATE())) as MinAge, AVG(DATEDIFF(year, BirthDate, GETDATE())) as AvgAge from Employees GROUP BY City;";
             Console.WriteLine("7.Calculate the greatest, the smallest and the average age of the employees for each city.");
            res = repository.GetFromDatabse(query7, 4);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////8
            string query8 = "SELECT City, AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees GROUP BY City HAVING AVG(DATEDIFF(year, BirthDate, GETDATE())) > 60;";
          
            Console.WriteLine("8. Show the list of cities in which the average age of employees is greater than 60(the average age is also to be shown)\n");
            res = repository.GetFromDatabse(query8, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////9
            string query9 = "SELECT TOP 1 FirstName, LastName FROM Employees ORDER BY BirthDate;";
            
            Console.WriteLine("9. Show the first and last name(s) of the eldest employee(s). \n");

            res = repository.GetFromDatabse(query9, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////10
            string query10 = "SELECT TOP 3 FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age FROM Employees ORDER BY BirthDate;";
           
            Console.WriteLine("10. Show first, last names and ages of 3 eldest employees. \n");
            res = repository.GetFromDatabse(query10, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////11
            string query11 = "SELECT DISTINCT City FROM Employees;";
            
            Console.WriteLine("11. Show the list of all cities where the employees are from. \n");
            res = repository.GetFromDatabse(query11, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////12
            string query12 = "SELECT FirstName, LastName, BirthDate FROM Employees WHERE MONTH(BirthDate) = 12;";
            Console.WriteLine("12. Show first, last names and dates of birth of the employees who celebrate their birthdays this month \n");
            res = repository.GetFromDatabse(query12, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////13
            string query13 = "SELECT DISTINCT FirstName, LastName FROM Employees JOIN Orders ON Employees.EmployeeID = Orders.EmployeeID WHERE ShipCity = 'Madrid';";
            Console.WriteLine("13. Show first and last names of the employees who used to serve orders shipped to Madrid. \n");
            res = repository.GetFromDatabse(query13, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////14
            string query14 = "SELECT E.FirstName, E.LastName, COUNT(O.EmployeeID) AS OrdersAmount FROM Employees AS E LEFT JOIN Orders AS O ON O.EmployeeID = E.EmployeeID WHERE O.OrderDate BETWEEN '1997-01-01' AND '1997-12-31' GROUP BY E.FirstName, E.LastName;";
            Console.WriteLine("14. Show first and last names of the employees as well as the count of orders each of them have received during the year 1997 (use left join). \n");
            res = repository.GetFromDatabse(query14, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////15
            string query15 = @"SELECT Employees.FirstName, Employees.LastName, COUNT(Orders.EmployeeID) AS numOfOrders
FROM Employees
JOIN Orders ON Orders.EmployeeID = Employees.EmployeeID
WHERE Orders.OrderDate BETWEEN '1997-01-01' AND '1997-12-31'
GROUP BY Employees.FirstName, Employees.LastName;";
            Console.WriteLine("15.	Show first and last names of the employees as well as the count of " +
                "orders each of them have received during the year 1997\n");
            res = repository.GetFromDatabse(query15, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////16
            string query16 = @"SELECT Employees.FirstName, Employees.LastName, COUNT(Orders.EmployeeID) AS numOfOrders 
FROM Employees 
LEFT JOIN Orders ON Orders.EmployeeID = Employees.EmployeeID 
WHERE Orders.OrderDate BETWEEN '1997-01-01' AND '1997-12-31' AND Orders.ShippedDate > Orders.RequiredDate 
GROUP BY Employees.FirstName, Employees.LastName;";
            Console.WriteLine("16.	Show first and last names of the employees as well as the count of their " +
                "orders shipped after required date during the year 1997 (use left join).\n");
            res = repository.GetFromDatabse(query16, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////17
            string query17 = @"SELECT Customers.CustomerID, COUNT(Orders.CustomerID) AS numOfOrders 
FROM Customers 
JOIN Orders ON Orders.CustomerID = Customers.CustomerID 
WHERE Customers.Country = 'France'
GROUP BY Customers.CustomerID;";
            Console.WriteLine("17.	17.	Show the count of orders made by each customer from France.\n");
            res = repository.GetFromDatabse(query17, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////18 query
            string query18 = @"SELECT C.ContactName 
                                                FROM Customers AS C 
                                                JOIN Orders AS O ON O.CustomerID = C.CustomerID
                                                WHERE C.Country = 'France'
                                                GROUP BY C.ContactName       
HAVING COUNT (O.CustomerID) > 1;";
            Console.WriteLine("18. Show the list of french customers’ names who have made more than one order(use grouping)");
            res = repository.GetFromDatabse(query18, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////19 query
            string query19 = @"select Customers.ContactName from Customers inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' Group By(Customers.ContactName)  HAVING(COUNT(Orders.CustomerID) > 1) ;";
            Console.WriteLine("19.Show the list of french customers’ names who have made more than one order");
            Console.WriteLine();
            res = repository.GetFromDatabse(query19, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////20 query
            string query20 = @"select Customers.ContactName from Customers inner join Orders  on Customers.CustomerID=Orders.CustomerID inner join [Order Details] on [Order Details].OrderID=Orders.OrderID inner join Products on [Order Details].ProductID = Products.ProductID where Products.ProductName = 'Tofu';";
            Console.WriteLine("20.Show the list of customers’ names who used to order the ‘Tofu’ product");
            Console.WriteLine();
            res = repository.GetFromDatabse(query20, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////21 query
            string query21 = @"SELECT C.ContactName, SUM(OD.Quantity) AS Count, SUM(OD.UnitPrice * OD.Quantity) AS PriceSum 
                                                 FROM Customers AS C 
                                                 LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID 
                                                 LEFT JOIN [Order Details] AS OD ON OD.OrderId = O.OrderId
                                                 LEFT JOIN [Products] AS P ON P.ProductID = OD.ProductID 
                                                 WHERE P.ProductName = 'Tofu'
                                                 GROUP BY C.ContactName;";
            Console.WriteLine("21.	*Show the list of customers’ names who used to order the ‘Tofu’ product, along with the total amount of the product they have ordered and with the total sum for ordered product calculated.");
            res = repository.GetFromDatabse(query21, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////22 query
            string query22 = @"SELECT DISTINCT C.ContactName 
                                                 FROM Customers as C 
                                                 LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID 
                                                 LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID 
                                                 LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID 
                                                 LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID 
                                                 WHERE S.Country <> 'France' AND C.Country = 'France'";
            Console.WriteLine("22.	*Show the list of french customers’ names who used to order non-french products (use left join).");
            res = repository.GetFromDatabse(query22, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////23 query
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
            res = repository.GetFromDatabse(query23, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////24 query
            string query24 = @"select distinct Customers.ContactName from Customers inner join Orders on Customers.CustomerID=Orders.CustomerID inner join [Order Details] on [Order Details].OrderID=Orders.OrderID inner join Products on [Order Details].ProductID = Products.ProductID inner join Suppliers on Products.SupplierID = Suppliers.SupplierID where Customers.Country = 'France' AND Suppliers.Country = 'France'";
            Console.WriteLine("24.*Show the list of french customers’ names who used to order french products");
            res = repository.GetFromDatabse(query24, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////25
            string query25 = @"SELECT Customers.Country, SUM(([Order Details].UnitPrice*[Order Details].Quantity)*(1-[Order Details].Discount)) AS sumOfOrders 
FROM Customers 
JOIN Orders ON Orders.CustomerID = Customers.CustomerID 
Join [Order Details] on [Order Details].OrderID = Orders.OrderID
GROUP BY Customers.Country;";
            Console.WriteLine("25.	*Show the total ordering sum calculated for each country of customer.\n");
            res = repository.GetFromDatabse(query25, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////26
            string query26 = @"SELECT Dom.Country, Dom.DomSum, NonDom.NonDomSum 
FROM (select Customers.Country, SUM(([Order Details].UnitPrice*[Order Details].Quantity)*(1-[Order Details].Discount)) AS DomSUM
From Customers 
join Orders On Customers.CustomerID = Orders.CustomerID
join [Order Details] ON [Order Details].OrderID = Orders.OrderID
join Products On Products.ProductID = [Order Details].ProductID
join Suppliers On Suppliers.SupplierID = Products.SupplierID
where Suppliers.Country = Customers.Country
Group BY Customers.Country) As Dom
Join (select Customers.Country, SUM(([Order Details].UnitPrice*[Order Details].Quantity)*(1-[Order Details].Discount)) AS NonDomSUM
From Customers 
join Orders On Customers.CustomerID = Orders.CustomerID
join [Order Details] ON [Order Details].OrderID = Orders.OrderID
join Products On Products.ProductID = [Order Details].ProductID
join Suppliers On Suppliers.SupplierID = Products.SupplierID
where Suppliers.Country <> Customers.Country
Group BY Customers.Country) As NonDom
On Dom.Country = NonDom.Country;";
            Console.WriteLine("26.	*Show the total ordering sums calculated for each customer’s" +
                " country for domestic and non-domestic products separately (e.g.: “France – " +
                "French products ordered – Non-french products ordered” and so on for each country).\n");
            res = repository.GetFromDatabse(query26, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////27
            string query27 = @"Select Categories.CategoryName, SUM(([Order Details].UnitPrice*[Order Details].Quantity)*(1-[Order Details].Discount)) AS sumOfOrders 
From Categories
Join Products On Categories.CategoryID = Products.CategoryID
join [Order Details] On [Order Details].ProductID = products.ProductID
join Orders On Orders.OrderID = [Order Details].OrderID
where Orders.OrderDate BETWEEN '1997-01-01' AND '1997-12-31'
Group By Categories.CategoryName;";
            Console.WriteLine("27.	*Show the list of product categories along with total ordering sums " +
                "calculated for the orders made for the products of each category, during the year 1997.\n");
            res = repository.GetFromDatabse(query27, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////28
            string query28 = @"Select distinct Products.ProductName,Products.UnitPrice, [Order Details].UnitPrice As HistoricalPrice 
From Products
Left Join [Order Details] On Products.ProductID = [Order Details].ProductID
Group by Products.ProductName,Products.UnitPrice,[Order Details].UnitPrice
Order by Products.ProductName;";
            Console.WriteLine("28.	*Show the list of product names along with unit prices and the history of " +
                "unit prices taken from the orders (show ‘Product name – Unit price – Historical price’)." +
                " The duplicate records should be eliminated. If no orders were made " +
                "for a certain product, then the result for this " +
                "product should look like ‘Product name – Unit price – NULL’. Sort the list by the product name.\n");
            res = repository.GetFromDatabse(query28, 3);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////29
            Console.WriteLine("29.");
            string com29 = "select e.FirstName + ' ' + e.LastName as FullNameEmployee," +
                            " c.FirstName + ' '+c.LastName as FullNameChief " +
                            "from Employees as e " +
                            "left join employees as c " +
                            "on e.reportsto = c.employeeid";
            res = repository.GetFromDatabse(com29, 2);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            ////query30
            Console.WriteLine("30");
            string cmd30 = "(select city from Customers) " +
                            "union " +
                            "(select city from Employees) " +
                            "union " +
                            "(select s.city from products as p " +
                            "inner join suppliers as s on " +
                            "p.supplierid = s.SupplierID); ";
            res = repository.GetFromDatabse(cmd30, 1);
            for (int i = 0; i < res.Count; ++i)
            {
                for (int j = 0; j < res[i].Length; ++j)
                {
                    Console.Write(res[i][j] + "   ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            ////query31

            Console.WriteLine("31.");
            string cmd31 = "insert into employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) " +
"values " +
"('Petro', 'Rebro', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 10 str.', 'Ternopil', 'Ukraine', 'Eduard'), " +
"('Oleg', 'Wou', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 11 str.', 'Lviv', 'Ukraine', 'Eduard') , " +
"('Andriy', 'Kou', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 12 str.', 'Ternopil', 'Ukraine', 'Eduard') , " +
"('Asdad', 'Aqweewr', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 13 str.', 'Lviv', 'Ukraine', 'Eduard') , " +
"('Pezvzxcvtro', 'Vcbvcb', Convert(datetime, '1999-03-23'), Convert(datetime, '2015-10-29'), 'Kyivska 14 str.', 'Lviv', 'Ukraine', 'Eduard'); ";

            SqlCommand query31 = new SqlCommand(cmd31, connection);
            int employeeid = 0;
            int rowsAffected = query31.ExecuteNonQuery();
            Console.Write($"Rows affected : {rowsAffected}");
            Console.WriteLine();

            ////query32
            Console.WriteLine("32.");
            string cmd32 = "select * from employees where cast(notes as nvarchar) = 'Eduard'";

            SqlCommand query32 = new SqlCommand(cmd32, connection);

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

            ////query33
            string cmd33 = $"update employees set city = 'obuhiv' where employeeid = (select top 1 employeeid from employees where cast(notes as nvarchar) = 'Eduard')";
            SqlCommand sqlCommand33 = new SqlCommand(cmd33, connection);
            rowsAffected = sqlCommand33.ExecuteNonQuery();
            Console.WriteLine($"Rows affected : {rowsAffected}");
            Console.WriteLine();

            ////query34
            Console.WriteLine("34.");
            string cmd34 = $"update employees set hiredate = GETDATE() where cast(notes as nvarchar) = 'Eduard'";
            sqlCommand33 = new SqlCommand(cmd34, connection);
            rowsAffected = sqlCommand33.ExecuteNonQuery();
            Console.WriteLine($"Rows affected : {rowsAffected}");
            Console.WriteLine();

            ////query35

            Console.WriteLine("35.");
            cmd34 = "delete from employees where employeeid = (select top 1 employeeid from employees where cast(notes as nvarchar) = 'Eduard')";
            sqlCommand33 = new SqlCommand(cmd34, connection);
            Console.WriteLine($"Rows affected : {sqlCommand33.ExecuteNonQuery()}");
            Console.ReadKey();
        }
    }
}
