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
        private List<Node> nodes = new List<Node>();

        private List<Connection> connectivities = new List<Connection>();

        public List<Node> Nodes
        {
            get { return this.nodes; }
        }

        public List<Connection> Connectivities
        {
            get { return this.connectivities; }
        }
    }
}
