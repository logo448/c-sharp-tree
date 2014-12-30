using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace GameTree
{
    public class tree
    {
        // list of all nodes
        private Dictionary<int, List<List<int>>> nodes;

        // list of all used lookups
        private List<int> lookups;

        // the lookup for the last parent node
        private int last_parent;

        // current lookup number
        public int current;

        public tree()
        {
            lookups = new List<int>();
            lookups.Add(0);
            last_parent = 0;
            nodes = new Dictionary<int, List<List<int>>>();
        }

        public void add_data(List<int> board, int move)
        {
            List<List<int>> data = new List<List<int>>();
            data.Add(board);
            data.Add(new List<int>() { move });
            data.Add(new List<int>() {last_parent});
            data.Add(new List<int>());
            lookups.Add(lookups.Last() + 1);
            nodes.Add(lookups.Last(), data);
            current = lookups.Last();
            check_children(last_parent, current);
            get_new_last_parent();
        }

        private void check_children(int parent_lookup, int lookup)
        {
            List<List<int>> value = new List<List<int>>();
            if (nodes.TryGetValue(parent_lookup, out value))
            {
                if (!value[3].Contains(lookup))
                {
                    value[3].Add(lookup);
                    nodes[parent_lookup] = value;
                }
            }
        }

        public void create_root(List<int> board, int move)
        {
            List<List<int>> data = new List<List<int>>();
            data.Add(board);
            data.Add(new List<int>() {move});
            data.Add(new List<int>() { 0 });
            data.Add(new List<int>());
            nodes.Add(0, data);
            current = lookups.Last();
        }

        private void get_new_last_parent()
        {
            last_parent = current;
        }

        private List<List<int>> checkout_node(int lookup)
        {
            List<List<int>> value = new List<List<int>>();
            if (nodes.TryGetValue(lookup, out value))
            {
                return value;
            }
            else
            {
                MessageBox.Show("Key not found");
            }
            return null;
        }

        public void up()
        {
            List<List<int>> val = checkout_node(current);
            current = val[2][0];
            get_new_last_parent();
        }       
    }
}
