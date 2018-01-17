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
    public class ReviewControllerTest
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        EFItemRepository db = new EFItemRepository(new GummiBearKingdomDbContext());


        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Review[]
            {
                new Review {ReviewId = 1, Author = "Hansen", Rating = 5, Comment ="Good"},
                new Review {ReviewId = 2, Author = "Someone", Rating = 4, Comment ="Okay"}

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

            Assert.IsInstanceOfType(result, typeof(List<Review>));

        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection()
        {
            DbSetup();
            ItemController controller = new ItemController(mock.Object);
            Review testItem = new Review();
            testItem.Rating = 5;
            testItem.Author = "Yaaa";
            testItem.Rating = 5;
            testItem.Comment = "Sweet";

            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, testItem);

        }

        //public void Dispose()
        //{
        //    db.ClearAll();
        //}

    }
}
