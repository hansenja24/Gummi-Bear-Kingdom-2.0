using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gummi_Bear_Kingdom.Models;

namespace Gummi_Bear_Kingdom.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void GetProductReturnProduct()
        {
            //Arrange
            var item = new Product(1, "testing", 500, "this is only a test");

            //Act
            var resultId = item.ProductId;
            var resultName = item.Name;
            var resultCost = item.Cost;
            var resultDescription = item.Description;

            //Assert
            Assert.AreEqual(1, resultId);
            Assert.AreEqual("testing", resultName);
            Assert.AreEqual(500, resultCost);
            Assert.AreEqual("this is only a test", resultDescription);
        }

        [TestMethod]
        public void GetReviewReturnReview()
        {
            //Arrange
            var item = new Review(1, 5, "this is only a test");

            //Act
            var resultId = item.ReviewId;
            var resultRating = item.Rating;
            var resultComment = item.Comment;

            //Assert
            Assert.AreEqual(1, resultId);
            Assert.AreEqual(5, resultRating);
            Assert.AreEqual("this is only a test", resultComment);
        }
    }
}
