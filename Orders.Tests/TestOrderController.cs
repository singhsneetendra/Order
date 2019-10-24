using System.Collections.Generic;
using Orders.Models;
using Xunit;
namespace Orders.Tests
{

    public class TestOrderController
    {

        [Fact]
        public void AddInvalidOrderList()
        {
            //Arrange 
            List<ObjectType> inValidOrderList = new List<ObjectType>()

            {
                new ObjectType {
                ObjectID = 0,
                ObjectName = "C# Book",
                ObjectPrice = 3,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            bool badResponse;
            string msg;
            (badResponse, msg) = Order.ValidateOrderList(inValidOrderList);

            // Assert
            Assert.False(badResponse, msg);
        }

        [Fact]
        public void AddValidOrderList()
        {
            //Arrange 
            List<ObjectType> inValidOrderList = new List<ObjectType>()

            {
                new ObjectType {
                ObjectID = 1,
                ObjectName = "C# Book",
                ObjectPrice = 3,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            bool badResponse;
            string msg;
            (badResponse, msg) = Order.ValidateOrderList(inValidOrderList);

            // Assert
            Assert.True(badResponse, msg);
        }
    }
}