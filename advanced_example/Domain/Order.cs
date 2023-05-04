using System;
namespace Domain;

public class Order: IEqualityComparer<Order>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address  { get; set; }
    public int PutchaseNumber { get; set; }
    public int Price { get; set; }
    public DateTime DeliveryDateTima { get; set; }

    public bool Equals(Order x, Order y)
    {
	    if (ReferenceEquals(x, y)) return true;
	    if (ReferenceEquals(x, null)) return false;
	    if (ReferenceEquals(y, null)) return false;
	    if (x.GetType() != y.GetType()) return false;
	    return x.Id == y.Id && x.Name == y.Name;
    }

    public int GetHashCode(Order obj)
    {
	    return HashCode.Combine(obj.Id, obj.Name);
    }
}