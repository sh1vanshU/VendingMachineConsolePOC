using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachinePOC
{
    class MachineData
    {
        public string Name;
        public int Rate;
        public int SoldQuantity;
        public int Quantity;

        public MachineData(string name, int rate, int quantity)
        {
            this.Name = name;
            this.Rate = rate;
            this.Quantity = quantity;
        }
    }
}
