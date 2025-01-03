using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieMobila.Models;

public class CartItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }
}
