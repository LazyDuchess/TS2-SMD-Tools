using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS2SMDTools.SMD;

namespace TS2SMDTools.Tools
{
    public static class Helpers
    {
        /// <summary>
        /// Gets all vertices from a StudioModel.
        /// </summary>
        /// <param name="model">StudioModel to get vertices from.</param>
        /// <returns>List of all vertices.</returns>
        public static List<Vertex> GetVertices(StudioModel model)
        {
            var vertexList = new List<Vertex>();
            foreach(var triangle in model.Triangles)
            {
                vertexList.Add(triangle.Vertices[0]);
                vertexList.Add(triangle.Vertices[1]);
                vertexList.Add(triangle.Vertices[2]);
            }
            return vertexList;
        }

        /// <summary>
        /// Merges vertices that have the same position, normals and uvs.
        /// </summary>
        /// <param name="vertices">List of vertices to merge.</param>
        /// <returns>Merged vertex list.</returns>
        public static List<Vertex> MergeVertexList(List<Vertex> vertices)
        {
            var alreadyMergedVertices = new HashSet<Vertex>();
            var mergedVertices = new List<Vertex>();
            foreach(var vertex in vertices)
            {
                if (alreadyMergedVertices.Contains(vertex))
                    continue;
                foreach(var comparisonVertex in vertices)
                {
                    if (vertex.Equals(comparisonVertex))
                    {
                        alreadyMergedVertices.Add(vertex);
                        mergedVertices.Add(vertex);
                    }
                }
            }
            return mergedVertices;
        }
    }
}
