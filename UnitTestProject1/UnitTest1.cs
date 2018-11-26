namespace UnitTestProject1
{
    using System.Collections.Generic;
    using ADOForPlatform;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

 /// <summary>
 /// Unit tests
 /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Calculate strings
        /// </summary>
        /// <param name="l"> list of strings </param>
        /// <returns> number of strings in list </returns>
        public int Calculate(List<string[]> l)
        {
            return l.Count;
        }
        ////імітуємо те, ніби ми знаємо правильний результат нашого запиту, і знаємо, що поверне нам наш запит і так з усіма тестами
        
        /// <summary>
        /// First test
        /// </summary>
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
            repositoryMock.Setup(r => r.GetFromDatabse(query18, 1)).Returns(list);

            var forTest = repositoryMock.Object;

            Assert.AreEqual<int>(this.Calculate(repositoryMock.Object.GetFromDatabse(query18, 1)), 10);
        }

        /// <summary>
        /// Test 2
        /// </summary>
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
            repositoryMock.Setup(r => r.GetFromDatabse(query18, 1)).Returns(list);

            var forTest = repositoryMock.Object;

            Assert.AreEqual<string>(repositoryMock.Object.GetFromDatabse(query18, 1)[9][0], "Paul Henriot");
        }
    }
}