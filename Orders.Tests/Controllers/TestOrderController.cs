using System.Collections.Generic;
using Orders.Models;
using Xunit;
using Moq;

namespace Orders.Tests.Controllers
{
    public class TestOrderController
    {
        [Fact]
        public void CanPostRequest()
        {
            //Arrange
            List<ObjectType> orderList = new List<ObjectType>()
             {
             new ObjectType {
             ObjectID = 1,
             ObjectName = "C# Book",
             ObjectPrice = 3,
             ObjectQuantity = "10 pieces"
             }
            };
            var controllerMock = new Mock<DemoWebAPIWithSwagger.Controllers.OrderController>();
            controllerMock.Setup(s => s.Post(orderList)).Returns(("Sucessfuly saver Orders."));

            //Act
            string response = controllerMock.Object.Post(orderList);

            //Assert
            Assert.Equal("Sucessfuly saver Orders.", response);
        }

        [Fact]
        public void CanNotPostRequest()
        {
            //Arrange
            List<ObjectType> orderList = new List<ObjectType>()
             {
             new ObjectType {
             ObjectID = 1,
             ObjectName = "C# Book",
             ObjectPrice = 3,
             ObjectQuantity = "10 pieces"
             }
            };
            var controller = new DemoWebAPIWithSwagger.Controllers.OrderController();

            //Act
            string response = controller.Post(orderList);

            //Assert
            Assert.Equal("Error sending HTTP request to Invoices api", response);
        }

    }
}