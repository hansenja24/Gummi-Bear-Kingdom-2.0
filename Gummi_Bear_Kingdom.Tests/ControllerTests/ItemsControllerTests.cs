using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gummi_Bear_Kingdom.Models;
using Gummi_Bear_Kingdom.Controllers;

using Moq;
using System.Linq;

namespace Gummi_Bear_Kingdom.Tests
{
    [TestClass]
    public class ItemsControllerTests
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        EFItemRepository db = new EFItemRepository(new GummiBearKingdomDbContext());


        private void DbSetup()
        {
            mock.Setup(m=>m.Items).Returns(new Product[]
            {
                new Product (1, "test", 100, "This is a testing"),
                new Product (2, "something", 500, "This is a something")
                
            }.AsQueryable()); 
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            DbSetup();
            ItemController controller = new ItemController(mock.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ActionResult));

        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            DbSetup();
            ViewResult indexView = new ItemController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Product>));

        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection()
        {
            DbSetup();
            ItemController controller = new ItemController(mock.Object);
            Product testItem = new Product();
            testItem.ProductId = 5;
            testItem.Name = "Gummy";
            testItem.Cost = 5;
            testItem.Description = "Sweet and Sour";

            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, testItem);

        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Anything",
                Cost = 5,
                Description = "Cool"
            };

            DbSetup();
            ItemController controller = new ItemController(mock.Object);

            // Act
            var resultView = controller.Create(testProduct) as ViewResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Product testProduct = new Product
            {
                ProductId = 10,
                Name = "Apple",
                Cost = 10,
                Description = "Red"
            };

            DbSetup();
            ItemController controller = new ItemController(mock.Object);

            // Act
            var resultView = controller.Details(testProduct.ProductId) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));
        }
  
    }
}
