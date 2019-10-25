using System.Collections.Generic;
using Orders.Models;
using Xunit;

namespace Orders.Tests
{

    public class TestOrder
    {

        [Fact]
        public void ValidOrderList()
        {
            //Arrange 
            bool response;
            string msg;
            List<ObjectType> orderList = new List<ObjectType>()
            {
                new ObjectType {
                ObjectID = 1,
                ObjectName = "C# Book",
                ObjectPrice = 3,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            (response, msg) = Order.ValidateOrderList(orderList);

            // Assert
            Assert.True(response, msg);
        }

        [Fact]
        public void InvalidOrderList()
        {
            //Arrange 
            bool response;
            string msg;
            List<ObjectType> orderList = new List<ObjectType>()
            {
                new ObjectType {
                ObjectID = 0,
                ObjectName = "C# Book",
                ObjectPrice = 3,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            (response, msg) = Order.ValidateOrderList(orderList);

            // Assert
            Assert.False(response, msg);
        }

        [Fact]
        public void ValidObjectId()
        {
            //Arrange 
            bool response;
            string msg;
            List<ObjectType> orderList = new List<ObjectType>()
            {
                new ObjectType {
                ObjectID = 1,
                ObjectName = "C# Book",
                ObjectPrice = 3,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            (response, msg) = Order.ValidateOrderList(orderList);

            // Assert
            Assert.True(response, msg);
        }

        [Fact]
        public void InvalidObjectId()
        {
            //Arrange 
            bool response;
            string msg;
            List<ObjectType> orderList = new List<ObjectType>()
            {
                new ObjectType {
                ObjectID = 0,
                ObjectName = "C# Book",
                ObjectPrice = 3,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            (response, msg) = Order.ValidateOrderList(orderList);

            // Assert
            Assert.False(response, msg);
        }

        [Fact]
        public void ValidObjectPrice()
        {
            //Arrange 
            bool response;
            string msg;
            List<ObjectType> orderList = new List<ObjectType>()
            {
                new ObjectType {
                ObjectID = 1,
                ObjectName = "C# Book",
                ObjectPrice = 3,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            (response, msg) = Order.ValidateOrderList(orderList);

            // Assert
            Assert.True(response, msg);
        }

        [Fact]
        public void InValidObjectPrice()
        {
            //Arrange 
            bool response;
            string msg;
            List<ObjectType> orderList = new List<ObjectType>()
            {
                new ObjectType {
                ObjectID = 1,
                ObjectName = "C# Book",
                ObjectPrice = 0,
                ObjectQuantity = "10 pieces"
                }
            };

            //Act
            (response, msg) = Order.ValidateOrderList(orderList);

            // Assert
            Assert.False(response, msg);
        }

    }
}