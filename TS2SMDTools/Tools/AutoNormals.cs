using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TS2SMDTools.SMD;

namespace TS2SMDTools.Tools
{
    public static class AutoNormals
    {
        /// <summary>
        /// Copies Normals from a Reference Model into a Target Model.
        /// </summary>
        /// <param name="targetModel">Target Model.</param>
        /// <param name="referenceModel">Reference Model to take normals from.</param>
        /// <param name="maxDistance">Maximum distance between two vertices to copy normals from one to the other.</param>
        /// <param name="minNormalFacing">Minimum dot product between the normals of two vertices.</param>
        /// <param name="checkNormalFacing">Check dot product for normals?</param>
        public static void FixNormalsForTarget(StudioModel targetModel, StudioModel referenceModel, float maxDistance, float minNormalFacing, bool checkNormalFacing)
        {
            var targetModelVertices = Helpers.GetVertices(targetModel);
            var refModelVertices = Helpers.GetVertices(referenceModel);
            foreach(var element in targetModelVertices)
            {
                var closestVertex = FindClosestVertex(element);
                if (closestVertex != null)
                {
                    element.Normal = closestVertex.Normal;
                }
            }

            Vertex FindClosestVertex(Vertex vertex)
            {
                Vertex closest = null;
                float closestDistance = 0f;
                foreach(var element in refModelVertices)
                {
                    var dist = Vector3.Distance(vertex.Position, element.Position);
                    if (dist <= maxDistance)
                    {
                        if (checkNormalFacing)
                        {
                            var normalFacing = Vector3.Dot(element.Normal, vertex.Normal);
                            if (normalFacing < minNormalFacing)
                                continue;
                        }
                        if (closest == null)
                        {
                            closest = element;
                            closestDistance = dist;
                        }
                        else
                        {
                            if (dist < closestDistance)
                            {
                                closest = element;
                                closestDistance = dist;
                            }
                        }
                    }
                }
                return closest;
            }
        }
    }
}
