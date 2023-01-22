using System.Collections.Generic;
using System.Numerics;

namespace TS2SMDTools.SMD
{
    /// <summary>
    /// Represents a vertex in 3D space, with normals, uvs and bone weights.
    /// </summary>
    public class Vertex
    {
        public Vector3 Position = Vector3.Zero;
        public Vector3 Normal = Vector3.Zero;
        public Vector2 UV = Vector2.Zero;
        public List<VertexWeight> Weights;
        public Vertex(Vector3 position, Vector3 normal, Vector2 uv)
        {
            Position = position;
            Normal = normal;
            UV = uv;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Position.GetHashCode();
                hash = hash * 23 + Normal.GetHashCode();
                hash = hash * 23 + UV.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex);
        }

        public bool Equals(Vertex obj)
        {
            return (Position == obj.Position && Normal == obj.Normal && UV == obj.UV);
        }
    }
}
