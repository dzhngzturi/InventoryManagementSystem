using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Interfaces
{
    public interface IPerishable
    {
        bool IsPerishable();
        void HandleExpiration();
    }
}
