using Domain;
using NUnit.Framework;

namespace Test;

public class OrderTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestMethod]
    public void TestGetSetName()
    {
        Order order = new Order();
        order.Name = "Juan";
        
    }
}