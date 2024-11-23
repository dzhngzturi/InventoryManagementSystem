using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Interfaces
{
    public interface IItem
    {
        string GetItemDetails();
        double CalculateValue();
        void ItemDescription();
    }
}
