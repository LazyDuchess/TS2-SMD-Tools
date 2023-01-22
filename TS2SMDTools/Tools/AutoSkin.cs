using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TS2SMDTools.SMD;

namespace TS2SMDTools.Tools
{
    public static class AutoSkin
    {
        /// <summary>
        /// Automatically skins a Target Model, using a Reference Model.
        /// </summary>
        /// <param name="targetModel">Model to skin.</param>
        /// <param name="referenceModel">Reference skinned model.</param>
        public static void GenerateSkinForTarget(StudioModel targetModel, StudioModel referenceModel)
        {
            targetModel.ClearNodes();
            targetModel.ClearWeights();

            var targetModelVertices = Helpers.GetVertices(targetModel);
            var refModelVertices = Helpers.GetVertices(referenceModel);

            foreach(var node in referenceModel.Nodes)
            {
                var newNode = new Node(node.ID, node.Name, node.ParentID);
                newNode.Position = node.Position;
                newNode.Rotation = node.Rotation;
                targetModel.AddNode(newNode);
            }

            foreach (var element in targetModelVertices)
            {
                var closestVertex = FindClosestVertex(element);
                if (closestVertex != null)
                {
                    var weights = new List<VertexWeight>();
                    foreach (var weight in closestVertex.Weights)
                    {
                        var newWeight = new VertexWeight(weight.NodeID, weight.Weight);
                        weights.Add(newWeight);
                    }
                    element.Weights = weights;
                }
            }

            Vertex FindClosestVertex(Vertex vertex)
            {
                Vertex closest = null;
                float closestDistance = 0f;
                foreach (var element in refModelVertices)
                {
                    var dist = Vector3.Distance(vertex.Position, element.Position);
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
                return closest;
            }
        }
    }
}
