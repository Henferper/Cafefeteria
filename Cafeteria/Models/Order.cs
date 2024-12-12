using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Features;

namespace Cafeteria.Models;
public class Order
{
    public int Id{ get ; set ;}
    public DateTime TimeStamp { get ; set ;} = DateTime.Now;
    public decimal TotalPrice { get ; set ;}
    public List<Product> Products { get; set; }
    public List<OrderItem> Items { get; set; }  // Alterei para List<Item>
}