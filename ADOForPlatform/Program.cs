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
            SqlConnection Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //19 query
            SqlCommand query19 = new SqlCommand(@"select Customers.ContactName,Count(Orders.CustomerID) as OrdersCount from Customers inner join Orders on Customers.CustomerID = Orders.CustomerID where Customers.Country = 'France' Group By(Customers.ContactName)  HAVING(COUNT(Orders.CustomerID) > 1) ;", Connection);
            SqlDataReader queryReader = query19.ExecuteReader();
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
