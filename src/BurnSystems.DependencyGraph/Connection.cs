using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurnSystems.DependencyGraph
{
    public class Connection
    {
        public Node Node1
        {
            get;
            set;
        }

        public Node Node2
        {
            get;
            set;
        }

        public double Connectivity
        {
            get;
            set;
        }

        public Connection()
        {
        }

        public Connection(Node node1, Node node2, double connectivity)
        {
            Node1 = node1;
            Node2 = node2;
            Connectivity = connectivity;
        }
    }
}
