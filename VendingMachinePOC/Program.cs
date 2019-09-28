using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachinePOC
{
    class Program
    {
        public List<MachineData> machineDatas = new List<MachineData>();

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("\n WELCOME TO VENDING MACHINE \n");

            while (true)
            {

                Console.WriteLine("Press U for 'User' and A for 'Admin'");
                string input = Console.ReadLine();

                if (input == "A" || input == "a")
                {
                    Console.WriteLine("\n" +
                        "Fill  Vending Machine" +
                        "\n");
                    program.MachineFilling();
                    program.Print();
                }
                else if (input == "U" || input == "u")
                {
                    program.Purchase();
                }

                Console.WriteLine("Do you Want to Exit!\n" +
                    "if Yes press 'Y'," +
                    " if no Press any key"
                    );
                string exitInput = Console.ReadLine();

                if (exitInput.Equals("Y") || exitInput.Equals("y"))
                {
                    break;
                }

            }
        }
        public void Print()
        {
            foreach (var machineData in machineDatas)
            {
                Console.WriteLine(machineData.Name + "    " + machineData.Rate + "    " + machineData.Quantity);
            }
        }
        public void MachineFilling()
        {
            Console.WriteLine("\n" +
                "Enter number of types" +
                "\n");
            int productType = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < productType; i++)
            {
                Console.WriteLine("Enter the name of product");
                string name = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Enter the Rate of Product");
                var rate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the quantity of Product ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                var machineData = new MachineData(name,rate,quantity);
                machineDatas.Add(machineData);
            }
        }
        public void Purchase()
        {
            Console.WriteLine("\n" +
                "What do you want to purchase" +
                "\n");
            var input = Console.ReadLine();

            try
            {
                //If items are not available in list of datas
                if (!machineDatas.Any())
                {
                    Console.WriteLine("Item not Available!!!");
                }
                //Iterate list of datas
                foreach (var machineData in machineDatas)
                {
                    if (input.Equals(machineData.Name))
                    {
                        Console.WriteLine("\n" +
                            "Enter Quantity" +
                            "\n");
                        var quantity = Convert.ToInt32(Console.ReadLine());
                        int i = 0;
                        if (quantity > machineData.Quantity)
                        {
                            i = 1;

                        }
                        if (i != 1)
                        {
                            Console.WriteLine("Your Total AMOUNT is:  {0}", quantity * machineData.Rate);
                            Console.WriteLine();
                            machineData.Quantity -= quantity;
                            machineData.SoldQuantity += quantity;
                            Console.WriteLine("Total Sales till now are:    {0} ", machineData.SoldQuantity);
                            foreach (var machine in machineDatas)
                            {
                                Console.WriteLine("Remaining items of type {0} are:      {1}", machineData.Name, machineData.Quantity);
                            }

                        }
                        else
                        {
                            Console.WriteLine("\nQuantity not available");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Thank you for using Vending Machine!!");
                    }
                }

            }
            catch (NullReferenceException)
            {
                Console.WriteLine();
                Console.WriteLine("This Product is not available!!e");
            }
        }
    }
}
