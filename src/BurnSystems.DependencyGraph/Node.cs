using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurnSystems.DependencyGraph
{
    public class Node
    {
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the position of the node
        /// </summary>
        public Vector2d Position;

        public Vector2d ForceN;

        public Node()
        {
        }
     
        public Node(string title)
        {
            this.Title = title;
        }
    }
}
