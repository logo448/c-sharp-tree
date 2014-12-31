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

        // a variable to signify if the user tried to use the up function
        // when currently on root node
        public bool root_up;

        public tree()
        {
            lookups = new List<int>();
            lookups.Add(0);
            last_parent = 0;
            nodes = new Dictionary<int, List<List<int>>>();
            root_up = false;
        }

        public void add_data(int move, int turn)
        {
            List<List<int>> data = new List<List<int>>();
            data.Add(new List<int>());
            data.Add(new List<int>() { move });
            data.Add(new List<int>() {last_parent});
            data.Add(new List<int>());
            data.Add(new List<int>());
            lookups.Add(lookups.Last() + 1);
            nodes.Add(lookups.Last(), data);
            current = lookups.Last();
            add_board(turn);
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
            data.Add(new List<int>());
            nodes.Add(0, data);
            current = lookups.Last();
        }

        private void get_new_last_parent()
        {
            last_parent = current;
        }

        public List<List<int>> checkout_node(int lookup)
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
            if (current == 0)
            {
                root_up = true;
            }
            List<List<int>> val = checkout_node(current);
            current = val[2][0];
            get_new_last_parent();
        }

        public void add_board(int turn)
        {
            var par_val = new List<int>(checkout_node(last_parent)[0]);
            var child_val = checkout_node(current);

            par_val[child_val[1][0]] = turn;
            child_val[0] = par_val;
            nodes[current] = child_val;
        }
    }
}
