namespace UnitTestProject1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using ADOForPlatform;
    using System.Data.SqlClient;
    [TestClass]
    public class UnitTest1
    {
        int calculate(List<string[]> l)
        {
            return l.Count;
        }
        //імітуємо те, ніби ми знаємо правильний результат нашого запиту, і знаємо, що поверне нам наш запит і так з усіма тестами
        [TestMethod]
        public void Query18TestCount()
        {
            List<string[]> list = new List<string[]>();
            list.Add(new string[] { "Annette Roulet" });
            list.Add(new string[] { "Carine Schmitt" });
            list.Add(new string[] { "Daniel Tonini" });
            list.Add(new string[] { "Dominique Perrier" });
            list.Add(new string[] { "Frederique Citeaux" });
            list.Add(new string[] { "Janine Labrune" });
            list.Add(new string[] { "Laurence Lebihan" });
            list.Add(new string[] { "Martine Rance" });
            list.Add(new string[] { "Mary Saveley" });
            list.Add(new string[] { "Paul Henriot" });

            string query18 = @"SELECT C.ContactName 
                                                FROM Customers AS C 
                                                JOIN Orders AS O ON O.CustomerID = C.CustomerID
                                                WHERE C.Country = 'France'
                                                GROUP BY C.ContactName       
HAVING COUNT (O.CustomerID) > 1;"; 

            var rep = new ADORepository();
            var repositoryMock = new Mock<ADORepository>();
            repositoryMock.Setup(r => r.getFromDatabse(query18,1)).Returns(list);

            var forTest = repositoryMock.Object;

            Assert.AreEqual<int>(calculate(repositoryMock.Object.getFromDatabse(query18,1)), 10);
        }
        [TestMethod]
        public void Query18TestData()
        {
            List<string[]> list = new List<string[]>();
            list.Add(new string[] { "Annette Roulet" });
            list.Add(new string[] { "Carine Schmitt" });
            list.Add(new string[] { "Daniel Tonini" });
            list.Add(new string[] { "Dominique Perrier" });
            list.Add(new string[] { "Frederique Citeaux" });
            list.Add(new string[] { "Janine Labrune" });
            list.Add(new string[] { "Laurence Lebihan" });
            list.Add(new string[] { "Martine Rance" });
            list.Add(new string[] { "Mary Saveley" });
            list.Add(new string[] { "Paul Henriot" });

            string query18 = @"SELECT C.ContactName 
                                                FROM Customers AS C 
                                                JOIN Orders AS O ON O.CustomerID = C.CustomerID
                                                WHERE C.Country = 'France'
                                                GROUP BY C.ContactName       
HAVING COUNT (O.CustomerID) > 1;";

            var rep = new ADORepository();
            var repositoryMock = new Mock<ADORepository>();
            repositoryMock.Setup(r => r.getFromDatabse(query18, 1)).Returns(list);

            var forTest = repositoryMock.Object;

            Assert.AreEqual<string>(repositoryMock.Object.getFromDatabse(query18, 1)[9][0], "Paul Henriot");

        }

    }
}
