using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using Models.Out;

namespace WebApi.Test;

[TestClass]
public class OrdersControllerTest
{
    [TestMethod]
    public void CreateValidOrderTest()
    {
        Order order = new Order()
        {
            Name = "Papas fritas",
            Address = "Juan Gomez 3878",
            PutchaseNumber = 1,
            Price = 100,
            DeliveryDateTima = DateTime.Now.AddHours(1)
        };//1

        OrderBasicInfoModel createdOrder = new OrderBasicInfoModel()
        {
            Id = order.Id,
            DeliveryDateTime = order.DeliveryDateTima
        };//1

        var mock = new Mock<IOrderService>(MockBehavior.Strict);
        mock.Setup(o => o.Create(It.IsAny<Order>())).Returns(order); //1
    	var controller = new OrderController(mock.Object);
	    var result = controller.Add(order); 
    	var createdResult = result as CreatedAtRouteResult; 
	    var model = createdResult.Value as OrderBasicInfoModel; 

        mock.VerifyAll();//2
        Assert.IsTrue(createdOrder.Id == model.Id && createdOrder.DeliveryDateTime == model.DeliveryDateTime);//3
    }
    
    [TestMethod]
    public void CreateInvalidOrderBadRequestTest()
    {
        var mock = new Mock<IOrderService>(MockBehavior.Strict);
        mock.Setup(m => m.Create(null)).Throws(new ArgumentException());
        var controller = new OrderController(mock.Object);

        var result = controller.Add(null);

        mock.VerifyAll();
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }
}