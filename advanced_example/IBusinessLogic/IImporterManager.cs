using Domain;

namespace IBusinessLogic;

public interface IImporterManager
{
    List<string> GetAllImporters();
    List<Order> ImportOrders(string importerName);
    
}