using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph
{
    /// <summary>
    /// Stores the nodes themselves
    /// </summary>
    public class Graph
    {
        List<Node> nodes = new List<Node>();

        List<Connection> connectivities = new List<Connection>();

        public List<Node> Nodes
        {
            get { return nodes; }
        }

        public List<Connection> Connectivities
        {
            get { return connectivities; }
        }
    }
}
