using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportStore.UnitTest
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void CanPiginate()
        {

            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new List<Product> {   new Product {Name = "Football", Price = 25},
                                                                      new Product {Name = "Surf Board", Price = 179}, 
                                                                      new Product {Name = "Running shoes", Price = 95},
                                                                      new Product {Name = "Basketball", Price = 25},
                                                                      new Product {Name = "Tennis", Price = 179}}.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(null, 2).Model;

            Product[]  productArray= result.ToArray();
            Assert.IsTrue(productArray.Length == 2);
        }

        [TestMethod]
        public void CanGeneratePageLinks()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new List<Product> {   new Product {Category = "Football", Description = "Ball", Price = 49, Name = "Adidas Euro 2012 Match Football - Tango 12"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 38, Name = "Mitre Tensile Football"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 25, Name = "Adidas Tango Football : Pasadena"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 25, Name = "Adidas Uefa Europa League Match Ball : 2011/12"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 25, Name = "Mitre Ciero Match Football"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 14.95M, Name = "Mitre Football Ball : Astro Division"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 12.95M, Name = "Mitre Match Football : Campeon"}, 

                                                                      new Product {Category = "Football", Name = "Nike T90 Laser IV", Price = 49, Description = "Lighter, deadlier, more powerful. The T90 Laser IV really is the Perfect Strike"},
                                                                      new Product {Category = "Football", Name = "Nike Mercurial Vapor III", Price = 38, Description = "A Blast from the past - one of our most popular ever articles is all about the classic MVIII!"},

                                                                      new Product {Category = "Tennis", Name = "Wilson BLX Six.One 95 18x20", Price = 86, Description = "New A tighter, more control oriented stringbed plus improved feel separates this one from the pack. A confidence inspiring racquet for advanced players. 18/20 string pattern, standard length, 95 sq. inch headsize, traditional head light balance."},
                                                                      new Product {Category = "Tennis", Name = "Wilson BLX Six.One Team", Price = 155, Description = "New This update features a more open 16x18 string pattern than its predecessor for added pop and topspin. Great feel and a clean response will impress intermediate to advanced level players. Headsize: 95 sq. in. Length: 27. Strung weight: 10.7 oz."},
                                                                      new Product {Category = "Tennis", Name = "Wilson BLX Six.One 95 16x18", Price = 79, Description = "New An updated look with excellent maneuverability and access to spin, this easy to swing racket is great for 4.0+ level players. Strung weight: 10.4 ounces. Swingweight: 313. Headsize: 100 square inches."},
                                                                      new Product {Category = "Tennis", Name = "Boris Becker Delta Core London", Price = 79, Description = "Feel, comfort, control, maneuverability, power and stability, this one has it all. A truly impressive option for the 4.0+ level player this one comes with a standard length, 98sq.in headsize and 16x19 string pattern."},
                                                                    }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            controller.List("Football", 1);

            int actual = controller.pagingInfo.TotalPages;
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CategorySelectTest()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new List<Product> {   new Product {Category = "Football", Description = "Ball", Price = 49, Name = "Adidas Euro 2012 Match Football - Tango 12"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 38, Name = "Mitre Tensile Football"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 25, Name = "Adidas Tango Football : Pasadena"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 25, Name = "Adidas Uefa Europa League Match Ball : 2011/12"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 25, Name = "Mitre Ciero Match Football"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 14.95M, Name = "Mitre Football Ball : Astro Division"},
                                                                      new Product {Category = "Football", Description = "Ball", Price = 12.95M, Name = "Mitre Match Football : Campeon"}, 

                                                                      new Product {Category = "Football", Name = "Nike T90 Laser IV", Price = 49, Description = "Lighter, deadlier, more powerful. The T90 Laser IV really is the Perfect Strike"},
                                                                      new Product {Category = "Football", Name = "Nike Mercurial Vapor III", Price = 38, Description = "A Blast from the past - one of our most popular ever articles is all about the classic MVIII!"},

                                                                      new Product {Category = "Tennis", Name = "Wilson BLX Six.One 95 18x20", Price = 86, Description = "New A tighter, more control oriented stringbed plus improved feel separates this one from the pack. A confidence inspiring racquet for advanced players. 18/20 string pattern, standard length, 95 sq. inch headsize, traditional head light balance."},
                                                                      new Product {Category = "Tennis", Name = "Wilson BLX Six.One Team", Price = 155, Description = "New This update features a more open 16x18 string pattern than its predecessor for added pop and topspin. Great feel and a clean response will impress intermediate to advanced level players. Headsize: 95 sq. in. Length: 27. Strung weight: 10.7 oz."},
                                                                      new Product {Category = "Tennis", Name = "Wilson BLX Six.One 95 16x18", Price = 79, Description = "New An updated look with excellent maneuverability and access to spin, this easy to swing racket is great for 4.0+ level players. Strung weight: 10.4 ounces. Swingweight: 313. Headsize: 100 square inches."},
                                                                      new Product {Category = "Tennis", Name = "Boris Becker Delta Core London", Price = 79, Description = "Feel, comfort, control, maneuverability, power and stability, this one has it all. A truly impressive option for the 4.0+ level player this one comes with a standard length, 98sq.in headsize and 16x19 string pattern."},
                                                                    }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            controller.List("Football", 1);

            int actual = controller.pagingInfo.TotalPages;
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }
    }
}
