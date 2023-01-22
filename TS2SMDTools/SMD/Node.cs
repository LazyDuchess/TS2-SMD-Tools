using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TS2SMDTools.SMD
{
    /// <summary>
    /// Represents a node, or bone, in 3D space.
    /// </summary>
    public class Node
    {
        public int ID = 0;
        public string Name = "";
        public int ParentID = -1;
        public Vector3 Position = Vector3.Zero;
        public Vector3 Rotation = Vector3.Zero;
        public Node(int id, string name, int parentID)
        {
            ID = id;
            Name = name;
            ParentID = parentID;
        }
    }
}
