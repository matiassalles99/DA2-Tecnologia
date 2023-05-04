using System;
using Domain;
using IImporter;

namespace JsonImporter;
// Este proyecto podria estar en otra solucion tranquilamente, solo necesito el dll
// que resulta de compilar el proyecto para ponerlo en la carpeta Importers
public class JsonImporter : IImporterInterface
{
    public string GetName()
    {
        return "Json Importer";
    }

    // Aca obviamente va a leer de un JSON, no devolver algo hardcodeado
    public List<Order> ImportOrders()
    {
        List<Order> ordersToReturn = new List<Order>()
        {
            new Order()
            {
                Id = 1,
                Name = "Papas fritas",
                Address = "Juan Gomez 3878",
                PutchaseNumber = 1,
                Price = 100,
                DeliveryDateTima = DateTime.Now.AddHours(1)
            },
            new Order()
            {
                Id = 2,
                Name = "Milanesa",
                Address = "Juan Gomez 3878",
                PutchaseNumber = 1,
                Price = 150,
                DeliveryDateTima = DateTime.Now.AddHours(1)
            }
        };
        return ordersToReturn;
    }
}