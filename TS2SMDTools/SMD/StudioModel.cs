using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TS2SMDTools.SMD
{
    /// <summary>
    /// Represents an SMD 3D mesh.
    /// </summary>
    public class StudioModel
    {
        public enum ModelType
        {
            Reference,
            Sequence
        }
        static CultureInfo s_Culture = CultureInfo.InvariantCulture;

        public ModelType Type = ModelType.Reference;
        public List<Node> Nodes = new List<Node>();
        public Dictionary<int, Node> NodesByID = new Dictionary<int, Node>();
        public List<Triangle> Triangles = new List<Triangle>();
        enum SMDBlock
        {
            None,
            Nodes,
            Skeleton,
            Triangles
        }

        public StudioModel()
        {

        }

        /// <summary>
        /// Reads an SMD from a file.
        /// </summary>
        /// <param name="file">SMD File.</param>
        public StudioModel(string file)
        {
            var fileStream = new FileStream(file, FileMode.Open);
            Read(fileStream);
            fileStream.Dispose();
        }

        /// <summary>
        /// Splits a string using spaces and quotations.
        /// </summary>
        /// <param name="str">String to split.</param>
        /// <returns>List of split strings.</returns>
        List<string> SplitString(string str)
        {
            var stringList = new List<string>();
            var startIndex = 0;
            var insideQuotes = false;
            var stringLength = str.Length;
            for(var i=0;i<stringLength;i++)
            {
                if(startIndex == -1)
                {
                    if (str[i] != ' ')
                        startIndex = i;
                    else
                        continue;
                }
                if (str[i] == ' ')
                {
                    if (insideQuotes == false)
                    {
                        var finalString = str.Substring(startIndex, (i - startIndex));
                        startIndex = -1;
                        stringList.Add(finalString);
                    }
                }
                else if (str[i] == '"')
                {
                    if (!insideQuotes)
                    {
                        startIndex = i + 1;
                        insideQuotes = true;
                    }
                    else
                    {
                        var finalString = str.Substring(startIndex, (i - startIndex));
                        startIndex = -1;
                        insideQuotes = false;
                        stringList.Add(finalString);
                    }
                }
            }
            if (startIndex != -1)
            {
                var finalString = str.Substring(startIndex, (stringLength - startIndex));
                startIndex = -1;
                stringList.Add(finalString);
            }
            return stringList;
        }

        /// <summary>
        /// Adds a new node to the model.
        /// </summary>
        /// <param name="node">Node to add.</param>
        public void AddNode(Node node)
        {
            Nodes.Add(node);
            NodesByID[node.ID] = node;
        }

        /// <summary>
        /// Removes all nodes from the model.
        /// </summary>
        public void ClearNodes()
        {
            Nodes.Clear();
            NodesByID.Clear();
        }

        /// <summary>
        /// Clears all bone weights from every vertex in the model.
        /// </summary>
        public void ClearWeights()
        {
            foreach(var element in Triangles)
            {
                element.Vertices[0].Weights.Clear();
                element.Vertices[1].Weights.Clear();
                element.Vertices[2].Weights.Clear();
            }
        }

        /// <summary>
        /// Retrieves a node by its ID.
        /// </summary>
        /// <param name="id">ID of the Node to retrieve.</param>
        /// <returns>Retrieved node.</returns>
        Node GetNodeByID(int id)
        {
            if (NodesByID.TryGetValue(id, out Node node))
                return node;
            return null;
        }

        /// <summary>
        /// Writes the SMD file into a stream.
        /// </summary>
        /// <param name="stream">Stream to write to.</param>
        public void Write(Stream stream)
        {
            var writer = new StreamWriter(stream);
            writer.WriteLine("version 1");
            writer.WriteLine("nodes");
            foreach(var element in Nodes)
            {
                writer.WriteLine(element.ID.ToString() + " " + '"' + element.Name + '"' + " " + element.ParentID);
            }
            writer.WriteLine("end");
            writer.WriteLine("skeleton");
            writer.WriteLine("time 0");
            foreach (var element in Nodes)
            {
                writer.WriteLine(element.ID.ToString() + " " + Utils.FloatString(element.Position.X) + " " + Utils.FloatString(element.Position.Y) + " " + Utils.FloatString(element.Position.Z) + " " + Utils.FloatString(element.Rotation.X) + " " + Utils.FloatString(element.Rotation.Y) + " " + Utils.FloatString(element.Rotation.Z));
            }
            writer.WriteLine("end");
            if (Type == ModelType.Reference)
            {
                writer.WriteLine("triangles");
                foreach (var element in Triangles)
                {
                    writer.WriteLine("map.bmp");
                    writer.WriteLine(GetVertexString(element.Vertices[0]));
                    writer.WriteLine(GetVertexString(element.Vertices[1]));
                    writer.WriteLine(GetVertexString(element.Vertices[2]));
                }
                writer.WriteLine("end");
            }
            writer.Dispose();

            string GetVertexString(Vertex vertex)
            {
                var str = new StringBuilder("0 ");
                str.Append(Utils.FloatString(vertex.Position.X));
                str.Append(" ");
                str.Append(Utils.FloatString(vertex.Position.Y));
                str.Append(" ");
                str.Append(Utils.FloatString(vertex.Position.Z));
                str.Append(" ");
                str.Append(Utils.FloatString(vertex.Normal.X));
                str.Append(" ");
                str.Append(Utils.FloatString(vertex.Normal.Y));
                str.Append(" ");
                str.Append(Utils.FloatString(vertex.Normal.Z));
                str.Append(" ");
                str.Append(Utils.FloatString(vertex.UV.X));
                str.Append(" ");
                str.Append(Utils.FloatString(vertex.UV.Y));
                str.Append(" ");
                str.Append(vertex.Weights.Count.ToString());
                foreach(var element in vertex.Weights)
                {
                    str.Append(" ");
                    str.Append(element.NodeID.ToString());
                    str.Append(" ");
                    str.Append(Utils.FloatString(element.Weight));
                }
                return str.ToString();
            }
        }

        /// <summary>
        /// Reads an SMD from a stream.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        public void Read(Stream stream)
        {
            var reader = new StreamReader(stream);
            var currentBlock = SMDBlock.None;
            while(reader.Peek() != -1)
            {
                var line = reader.ReadLine().Trim();
                if (line == "end")
                {
                    currentBlock = SMDBlock.None;
                    continue;
                }
                switch (currentBlock)
                {
                    case SMDBlock.Triangles:
                        ProcessTriangles();
                        break;
                    case SMDBlock.Skeleton:
                        ProcessSkeleton(line);
                        break;
                    case SMDBlock.None:
                        ProcessNone(line);
                        break;
                    case SMDBlock.Nodes:
                        ProcessNodes(line);
                        break;
                }
                
            }

            void ProcessTriangles()
            {
                var vertex1Line = reader.ReadLine();
                var vertex2Line = reader.ReadLine();
                var vertex3Line = reader.ReadLine();

                var vertex1 = ProcessVertex(vertex1Line);
                var vertex2 = ProcessVertex(vertex2Line);
                var vertex3 = ProcessVertex(vertex3Line);

                var triangle = new Triangle(vertex1, vertex2, vertex3);
                Triangles.Add(triangle);
            }

            Vertex ProcessVertex(string line)
            {
                var lineSplit = SplitString(line);

                var positionX = float.Parse(lineSplit[1], s_Culture);
                var positionY = float.Parse(lineSplit[2], s_Culture);
                var positionZ = float.Parse(lineSplit[3], s_Culture);

                var normalX = float.Parse(lineSplit[4], s_Culture);
                var normalY = float.Parse(lineSplit[5], s_Culture);
                var normalZ = float.Parse(lineSplit[6], s_Culture);

                var u = float.Parse(lineSplit[7], s_Culture);
                var v = float.Parse(lineSplit[8], s_Culture);

                var weightAmount = int.Parse(lineSplit[9]);

                var weights = new List<VertexWeight>();
                var currentChar = 0;
                for(var i=0;i<weightAmount;i++)
                {
                    var nodeID = int.Parse(lineSplit[10 + currentChar]);
                    currentChar++;
                    var nodeWeight = float.Parse(lineSplit[10 + currentChar]);
                    currentChar++;
                    var weight = new VertexWeight(nodeID, nodeWeight);
                    weights.Add(weight);
                }
                var vertex = new Vertex(new Vector3(positionX, positionY, positionZ), new Vector3(normalX, normalY, normalZ), new Vector2(u, v));
                vertex.Weights = weights;
                return vertex;
            }

            void ProcessSkeleton(string line)
            {
                var lineSplit = SplitString(line);
                if (lineSplit[0] == "time")
                    return;
                var nodeID = int.Parse(lineSplit[0]);
                var node = GetNodeByID(nodeID);
                if (node == null)
                    return;

                var positionX = float.Parse(lineSplit[1], s_Culture);
                var positionY = float.Parse(lineSplit[2], s_Culture);
                var positionZ = float.Parse(lineSplit[3], s_Culture);

                var rotationX = float.Parse(lineSplit[4], s_Culture);
                var rotationY = float.Parse(lineSplit[5], s_Culture);
                var rotationZ = float.Parse(lineSplit[6], s_Culture);

                node.Position = new Vector3(positionX, positionY, positionZ);
                node.Rotation = new Vector3(rotationX, rotationY, rotationZ);
            }

            void ProcessNodes(string line)
            {
                var lineSplit = SplitString(line);
                var nodeID = int.Parse(lineSplit[0]);
                var nodeName = lineSplit[1];
                var nodeParentID = int.Parse(lineSplit[2]);
                var node = new Node(nodeID, nodeName, nodeParentID);
                AddNode(node);
            }

            void ProcessNone(string line)
            {
                switch (line)
                {
                    case "triangles":
                        currentBlock = SMDBlock.Triangles;
                        break;
                    case "skeleton":
                        currentBlock = SMDBlock.Skeleton;
                        break;
                    case "nodes":
                        currentBlock = SMDBlock.Nodes;
                        break;
                    default:
                        currentBlock = SMDBlock.None;
                        break;
                }
            }
            reader.Dispose();
        }
    }
}
