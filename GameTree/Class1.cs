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
        public Dictionary<int, List<List<int>>> nodes;

        // list of all used lookups
        public List<int> lookups;

        // the lookup for the last parent node
        private int last_parent;

        public tree()
        {
            this.lookups = new List<int>();
            lookups.Add(0);
            last_parent = 0;
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
        }

        public void check_children(int parent_lookup)
        {

        }

        public void create_root(List<int> board, int move)
        {
            List<List<int>> data = new List<List<int>>();
            data.Add(board);
            data.Add(new List<int>() {move});
            data.Add(new List<int>() { 0 });
            data.Add(new List<int>());
            nodes.Add(0, data);
        }

        public void get_new_last_parent()
        {

        }

        public List<List<int>> checkou_node(int lookup)
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

        public void edit_node()
        {

        }
    }
}
