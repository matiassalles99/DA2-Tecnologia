using Domain;

namespace IImporter;
public interface IImporterInterface
{
    string GetName();

    // 2 Cosas a notar aqui:
    // - Hacemos referencia a Order, por lo que deberiamos compartir el proyecto domain tambien a 
    // diferencia de lo que dijimos arriba, aca podemos crear otros DTOs para esto y usar el patron Adapter
    // - No recibimos parametros, estaria bueno representar los parametros de alguna forma bastante generica
    // para pasar info necesaria a cada importador
    List<Order> ImportOrders();
    
    // Ej de posible manejo de parametros
    // List<Parameter> GetNeededParameters();
}
