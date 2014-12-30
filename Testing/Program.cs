using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameTree;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            tree tre = new tree();
            tre.create_root(new List<int>() { 0, 0, 1, 0, 0, 2, 1, 2, 0 }, 7);
            tre.add_data(new List<int>() { 1, 0, 1, 0, 0, 2, 1, 0 }, 0);
            tre.check_children(0, tre.lookups.Last());
            foreach (List<int> list in tre.checkou_node(0))
            {
                Console.WriteLine("New list");
                foreach (int num in list)
                {
                    Console.WriteLine(num.ToString());
                }
            }
        }
    }
}
