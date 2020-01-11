using System.Collections.Generic;

namespace Tracker.Models
{
  public class Order
  {
    public string Description { get; set; }
    public string Date { get; set; }
    public double Price { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order>();

    public Order(string date, string description, double price)
    {
      Description = description;
      Date = date;
      Price = price;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }


    public static Order Find(int searchId)
    {
      return _instances[searchId -1];
    }
    
  }
}