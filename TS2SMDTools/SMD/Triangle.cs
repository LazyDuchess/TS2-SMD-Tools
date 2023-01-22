using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS2SMDTools.SMD
{
    /// <summary>
    /// Represents a triangle, composed of 3 vertices.
    /// </summary>
    public class Triangle
    {
        public Vertex[] Vertices;

        public Triangle(Vertex vertex1, Vertex vertex2, Vertex vertex3)
        {
            Vertices = new Vertex[] { vertex1, vertex2, vertex3 };
        }
    }
}
