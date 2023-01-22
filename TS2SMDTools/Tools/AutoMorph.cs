using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TS2SMDTools.SMD;

namespace TS2SMDTools.Tools
{
    public static class AutoMorph
    {
        /// <summary>
        /// Represents a set of vertex influences.
        /// </summary>
        class VertexMap
        {
            public List<KeyValuePair<int, float>> indicesAndDistances = new List<KeyValuePair<int, float>>();
        }

        /// <summary>
        /// Transfers a reference morph to the target model.
        /// </summary>
        /// <param name="targetModel">Target model to transfer morph to.</param>
        /// <param name="refBaseModel">Reference base model.</param>
        /// <param name="refMorphModel">Reference morph model.</param>
        /// <param name="interpolation">Distance to interpolate vertices.</param>
        /// <param name="maxInfluenceDistance">Maximum distance at which vertices will be interpolated at 100% strength, to avoid gaps.</param>
        public static void GenerateMorphForTarget(StudioModel targetModel, StudioModel refBaseModel, StudioModel refMorphModel, float interpolation, float maxInfluenceDistance)
        {
            var vertexMap = new Dictionary<int, VertexMap>();
            var targetModelVertices = Helpers.GetVertices(targetModel);
            var refModelVertices = Helpers.GetVertices(refBaseModel);
            var refMorphVertices = Helpers.GetVertices(refMorphModel);
            MapVertices();
            MorphTargetModel();

            void MorphTargetModel()
            {
                for (var i = 0; i < targetModelVertices.Count; i++)
                {
                    var vertMap = vertexMap[i].indicesAndDistances;
                    for (var n = 0; n < vertMap.Count; n++)
                    {
                        var refBaseVert = refModelVertices[vertMap[n].Key];
                        var refMorphVert = refMorphVertices[vertMap[n].Key];
                        var diff = (refMorphVert.Position - refBaseVert.Position);
                        var nDiff = (refMorphVert.Normal - refBaseVert.Normal);
                        targetModelVertices[i].Position += diff * vertMap[n].Value;
                        targetModelVertices[i].Normal += nDiff * vertMap[n].Value;
                    }
                }
            }

            void MapVertices()
            {
                for(var i=0;i<targetModelVertices.Count;i++)
                {
                    var targetVertex = targetModelVertices[i];
                    var map = FindInfluences(targetVertex.Position, refModelVertices);
                    vertexMap[i] = map;
                }
            }

            VertexMap FindInfluences(Vector3 position, List<Vertex> refVertices)
            {
                var influences = new VertexMap();
                var totalInfluence = 0f;
                for (var i = 0; i < refVertices.Count; i++)
                {
                    var dist = Vector3.Distance(position, refVertices[i].Position);
                    if (dist <= interpolation)
                    {
                        var to1 = 1f / interpolation;
                        var influence = (-(dist - interpolation)) * to1;
                        var pair = new KeyValuePair<int, float>(i, influence);
                        influences.indicesAndDistances.Add(pair);
                        totalInfluence += influence;
                    }
                    if (dist <= maxInfluenceDistance)
                    {
                        var pair = new KeyValuePair<int, float>(i, 1f);
                        influences.indicesAndDistances.Clear();
                        influences.indicesAndDistances.Add(pair);
                        return influences;
                    }
                }
                
                for (var i = 0; i < influences.indicesAndDistances.Count; i++)
                {
                    var index = influences.indicesAndDistances[i].Key;
                    var inf = influences.indicesAndDistances[i].Value;
                    inf /= totalInfluence;
                    var pair = new KeyValuePair<int, float>(index, inf);
                    influences.indicesAndDistances[i] = pair;
                }
                return influences;
            }
        }
    }
}
