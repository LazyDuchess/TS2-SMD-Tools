using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS2SMDTools.SMD
{
    /// <summary>
    /// Represents a bone weight for a vertex.
    /// </summary>
    public class VertexWeight
    {
        public int NodeID = -1;
        public float Weight = 0f;
        public VertexWeight(int nodeID, float weight)
        {
            NodeID = nodeID;
            Weight = weight;
        }
    }
}
