using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Out;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/Orders")]
public class OrderController : ControllerBase
{
    private IOrderService _orderService;
    private readonly IImporterManager _importerManager;

    public OrderController(IOrderService orderService, IImporterManager importerManager)
    {
        _orderService = orderService;
        _importerManager = importerManager;
    }

    [HttpGet]
    public IActionResult Get()
    {
        IQueryable<Order> orders = _orderService.GetAll();
        return Ok(orders);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Order order)
    {
        try
        {
            Order createdOrder = _orderService.Create(order);
            return CreatedAtRoute("AddOrder", new OrderBasicInfoModel()
            {
                Id = createdOrder.Id,
                DeliveryDateTime = createdOrder.DeliveryDateTima
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest();
        }
    }

    // TODO: Moverlo a otro controller
    [HttpGet("importers")]
    public IActionResult GetImporters()
    {
        List<string> retrievedImporters = _importerManager.GetAllImporters();
        return Ok(retrievedImporters);
    }

    [HttpPost("import")]
    public IActionResult ImportMovies([FromBody] string importerName)
    {
        List<OrderBasicInfoModel> importedOrders = _importerManager.ImportOrders(importerName).Select(order => new OrderBasicInfoModel()
            {
                Id = order.Id,
                DeliveryDateTime = order.DeliveryDateTima
            }).ToList();
        return Ok(importedOrders);
    }
}