using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Interfaces
{
    public interface ISellable
    {
        double GetPrice();
        void SetPrice(double price);
    }
}
