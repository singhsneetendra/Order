using System.Collections.Generic;
using Orders.Models;
using Xunit;
namespace Orders.Tests
{

    public class TestOrderController
    {

        [Fact]
        public void InvalidOrderList()
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
            bool response;
            string msg;
            (response, msg) = Order.ValidateOrderList(inValidOrderList);

            // Assert
            Assert.False(response, msg);
        }

        [Fact]
        public void ValidOrderList()
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
            bool response;
            string msg;
            (response, msg) = Order.ValidateOrderList(inValidOrderList);

            // Assert
            Assert.True(response, msg);
        }

        [Fact]
        public void InvalidObjectId()
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
            bool response;
            string msg;
            (response, msg) = Order.ValidateOrderList(inValidOrderList);

            // Assert
            Assert.False(response, msg);
        }

        [Fact]
        public void ValidObjectId()
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
            bool response;
            string msg;
            (response, msg) = Order.ValidateOrderList(inValidOrderList);

            // Assert
            Assert.True(response, msg);
        }
    }
}