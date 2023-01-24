using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace TS2SMDTools.Scenegraph
{
    //http://simswiki.info/wiki.php?title=E519C933
    public class cMaterialDefinitionDataBlock : DataBlock
    {
        public string MaterialType;
        public string MaterialDescription;
        public Dictionary<string, string> properties = new Dictionary<string, string>();
        public List<string> textures = new List<string>();
    }

    public class cMaterialDefinitionStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new cMaterialDefinitionDataBlock();
            thisData.BlockName = "cMaterialDefinition";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();

            var csgRef = reader.ReadVariableLengthPascalString();
            var csg = RCOLFile.streams[csgRef].Read(reader, owner);

            thisData.MaterialDescription = reader.ReadVariableLengthPascalString();
            thisData.MaterialType = reader.ReadVariableLengthPascalString();

            var propCount = reader.ReadUInt32();
            for (var i = 0; i < propCount; i++)
            {
                var propName = reader.ReadVariableLengthPascalString();
                var propValue = reader.ReadVariableLengthPascalString();
                thisData.properties[propName] = propValue;
            }
            if (thisData.BlockVersion > 8)
            {
                var textureCount = reader.ReadUInt32();
                for (var i = 0; i < textureCount; i++)
                {
                    thisData.textures.Add(reader.ReadVariableLengthPascalString());
                }
            }
            return thisData;
        }
    }

    public class cGeometryNodeDataBlock : DataBlock
    {
        public string targetName = "";
    }
    public class cGeometryNodeStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new cGeometryNodeDataBlock();
            thisData.BlockName = "cGeometryNode";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            var graphNode = reader.ReadVariableLengthPascalString();
            var graphNodeDataBlock = RCOLFile.streams[graphNode].Read(reader, owner);
            var csG = reader.ReadVariableLengthPascalString();
            var csgDataBlock = RCOLFile.streams[csG].Read(reader, owner);
            thisData.targetName = csgDataBlock.BlockName.Substring(0, csgDataBlock.BlockName.Length - 4) + "gmdc";
            if (thisData.BlockVersion == 11)
            {
                var forcedRelocation = reader.ReadUInt16(); //2=yes, 512=no - GMND Redirects to geometry
            }
            if (thisData.BlockVersion == 11 || thisData.BlockVersion == 12)
            {
                var assistedGeometry = reader.ReadUInt16(); //1=yes, 256=no - GMND Contains geometry
                var unknownByte = reader.ReadByte();
            }
            var count = reader.ReadUInt32();
            for (var i = 0; i < count; i++)
            {
                var blockID = reader.ReadVariableLengthPascalString();
                if (!RCOLFile.streams.ContainsKey(blockID))
                {
                    return thisData;
                }
                var blocked = RCOLFile.streams[blockID].Read(reader, owner);
            }
            return thisData;
        }
    }
    public class cShapeDataBlock : DataBlock
    {
        public string GMNDFileName;
        public Dictionary<string, string> groupMaterials = new Dictionary<string, string>();
    }
    public class cShapeStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new cShapeDataBlock();
            thisData.BlockName = "cShape";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            var csg = reader.ReadVariableLengthPascalString();
            var csgBlock = RCOLFile.streams["cSGResource"].Read(reader, owner);
            var cReferent = reader.ReadVariableLengthPascalString();
            var referentBlockID = reader.ReadUInt32();
            var referentVersion = reader.ReadUInt32();
            var objGraph = reader.ReadVariableLengthPascalString();
            var objGraphDataBlock = RCOLFile.streams[objGraph].Read(reader, owner);
            if (thisData.BlockVersion > 6)
            {
                var lodCount = reader.ReadUInt32();
                for (var i = 0; i < lodCount; i++)
                {
                    var lodValue = reader.ReadUInt32();
                }
            }
            if (thisData.BlockVersion == 7 || thisData.BlockVersion == 6)
            {
                var lodCount2 = reader.ReadUInt32();
                for (var i = 0; i < lodCount2; i++)
                {
                    var lodType = reader.ReadUInt32();
                    var enabled = reader.ReadByte();
                    var useAGMNDEmbeddedSubmesh = reader.ReadByte();
                    var headerLinkIndex = reader.ReadUInt32();
                }
            }



            if (thisData.BlockVersion == 8)
            {
                var lodCount3 = reader.ReadUInt32();
                for (var i = 0; i < lodCount3; i++)
                {
                    var lodType2 = reader.ReadUInt32();
                }
            }
            var enabled2 = reader.ReadByte();
            var gmndFilename = reader.ReadVariableLengthPascalString();
            thisData.GMNDFileName = gmndFilename;
            var matCount = reader.ReadUInt32();
            for (var i = 0; i < matCount; i++)
            {
                var group = reader.ReadVariableLengthPascalString();
                var materialDefinition = reader.ReadVariableLengthPascalString();
                thisData.groupMaterials[group] = materialDefinition;
                reader.Skip(9);
            }
            return thisData;
        }
    }

    public class cTransformDataBlock : DataBlock
    {
        public ReferenceDataBlock cObjectGraphNode;
    }
    public class cTransformNodeStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new cTransformDataBlock();
            thisData.BlockName = "cTransformNode";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();

            var compositionName = reader.ReadVariableLengthPascalString();
            var compID = reader.ReadUInt32();
            var compVers = reader.ReadUInt32();

            var objGraphName = reader.ReadVariableLengthPascalString();
            thisData.cObjectGraphNode = RCOLFile.streams["cObjectGraphNode"].Read(reader, owner) as ReferenceDataBlock;

            var count = reader.ReadUInt32();
            for (var i = 0; i < count; i++)
            {
                var enabled = reader.ReadByte();
                var dependsOnChildNode = reader.ReadByte();
                var childNodeIndex = reader.ReadUInt32();
            }

            var xTransform = reader.ReadFloat();
            var yTransform = reader.ReadFloat();
            var zTransform = reader.ReadFloat();

            var xQuat = reader.ReadFloat();
            var yQuat = reader.ReadFloat();
            var zQuat = reader.ReadFloat();
            var wQuat = reader.ReadFloat();

            var assignedSubset = reader.ReadInt32(); //[as an int] [7fffffff - enumerated to "No Assignment"]
            return thisData;
        }
    }
    public class cShapeRefDataBlock : ReferenceDataBlock
    {
        public List<uint> links = new List<uint>();
        public cTransformDataBlock cTransformNode;
    }
    public class ReferenceDataBlock : DataBlock
    {
        public List<string> references = new List<string>();
    }
    public class cShapeRefNodeStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new cShapeRefDataBlock();
            thisData.BlockName = "cShapeRefNode";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            var renderableNodeString = reader.ReadVariableLengthPascalString();
            var renderableRCOLID = reader.ReadUInt32();
            var renderableVersion = reader.ReadUInt32();
            var boundedNodeString = reader.ReadVariableLengthPascalString();
            var boundedRCOLID = reader.ReadUInt32();
            var boundedVersion = reader.ReadUInt32();
            var transformNodeName = reader.ReadVariableLengthPascalString();
            thisData.cTransformNode = RCOLFile.streams["cTransformNode"].Read(reader, owner) as cTransformDataBlock;
            var unknown1 = reader.ReadUInt16();
            var unknown2 = reader.ReadUInt32();
            var practical = reader.ReadVariableLengthPascalString();
            var unknown1a = reader.ReadUInt32();
            var unknown2a = reader.ReadByte();
            var shapeLinkCount = reader.ReadUInt32();
            for (var i = 0; i < shapeLinkCount; i++)
            {
                var shapeEnabled = reader.ReadByte();
                var shapeDependant = reader.ReadByte();
                var shapeFileLinkIndex = reader.ReadUInt32();
                thisData.links.Add(shapeFileLinkIndex);
            }
            var unknown1b = reader.ReadUInt32(); //Always 0 or 16
            var count = reader.ReadUInt32();
            for (var i = 0; i < count; i++)
            {
                var unknown1c = reader.ReadUInt32();
            }
            if (thisData.BlockVersion == 21)
            {
                for (var i = 0; i < count; i++)
                {
                    var blendName = reader.ReadVariableLengthPascalString();
                }
            }
            var count2 = reader.ReadUInt32();
            for (var i = 0; i < count2; i++)
            {
                var unknown1d = reader.ReadByte();
            }
            var unknown1e = reader.ReadUInt32();
            return thisData;
        }
    }

    public class cDataListExtensionStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new DataBlock();
            thisData.BlockName = "cDataListExtension";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            var exten = reader.ReadVariableLengthPascalString();
            var classID = reader.ReadUInt32();
            var version = reader.ReadUInt32();
            Recursive(reader, thisData, version);
            return thisData;
        }
        void Recursive(IoBuffer reader, DataBlock block, uint version)
        {
            var extensionType = reader.ReadByte();
            var varname2 = reader.ReadVariableLengthPascalString();
            /*if (extensionType < 0x07)
            {*/
            switch (extensionType)
            {
                case 2:
                    //Uint32

                    reader.ReadUInt32();
                    break;
                case 3:
                    //Float
                    reader.ReadFloat();
                    break;
                case 5:
                    //Transform
                    var xTrans = reader.ReadFloat();
                    var yTrans = reader.ReadFloat();
                    var zTrans = reader.ReadFloat();
                    break;
                case 6:
                    //String
                    //var stringKey = reader.ReadVariableLengthPascalString();
                    var stringValue = reader.ReadVariableLengthPascalString();
                    break;
                case 7:
                    //Array
                    /*
                    Debug.Log("Reading array");
                    Recursive(reader, block, version);*/
                    //var varname = reader.ReadVariableLengthPascalString();
                    /*
                    var varname = reader.ReadVariableLengthPascalString();
                    Debug.Log(varname);*/
                    var extensionCount = reader.ReadUInt32();
                    for (var i = 0; i < extensionCount; i++)
                    {
                        Recursive(reader, block, version);
                    }
                    break;
                case 8:
                    //Quaternion
                    var quatX = reader.ReadFloat();
                    var quatY = reader.ReadFloat();
                    var quatZ = reader.ReadFloat();
                    var quatW = reader.ReadFloat();
                    break;
                case 9:
                    //Arbitrary data
                    var dataLength = reader.ReadUInt32();
                    reader.ReadBytes(dataLength);
                    break;
            }

            /*
            var siz = 16;
            if ((extensionType != 0x03) || (block.BlockVersion == 4))
                siz += 15;
            if ((extensionType <= 0x03) && (version == 3))
            {
                if (block.BlockVersion == 5)
                    siz = 31;
                else
                    siz = 15;
            }
            if ((extensionType <= 0x03) && block.BlockVersion == 4)
                siz = 31;
            if (extensionType == 6) //This a string
            {
                var strengKey = reader.ReadVariableLengthPascalString();
                var strengValue = reader.ReadVariableLengthPascalString();
            }
            else
            {
                Debug.Log("Final size: " + siz.ToString());
                var allData = reader.ReadBytes(siz);
            }*/
            /*
        }
        else
        {
            var varname = reader.ReadVariableLengthPascalString();
            Debug.Log(varname);
            var extensionCount = reader.ReadUInt32();
            for(var i=0;i<extensionCount;i++)
            {
                Recursive(reader, block, version);
            }
        }*/
        }
    }

    public class cObjectGraphNodeStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new ReferenceDataBlock();
            thisData.BlockName = "cObjectGraphNode";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            var numberOfExtensions = reader.ReadUInt32();
            for (var i = 0; i < numberOfExtensions; i++)
            {
                var enabled = reader.ReadByte();
                var dependsOnAnotherRCOL = reader.ReadByte();
                var indexofcDataListExtension = reader.ReadUInt32();
                /*
                if (dependsOnAnotherRCOL != (byte)0)
                    Debug.Log("DEPENDS ON ANOTHER!");*/
            }
            if (thisData.BlockVersion == 4)
            {
                var fileName = reader.ReadVariableLengthPascalString();
                thisData.references.Add(fileName);
            }
            return thisData;
        }
    }

    public class cCompositionTreeNodeStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new DataBlock();
            thisData.BlockName = "cCompositionTreeNode";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            return thisData;
        }
    }

    public class cResourceNodeDataBlock : DataBlock
    {
        public DataBlock cSGResource;
    }

    public class cResourceNodeStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new cResourceNodeDataBlock();
            thisData.BlockName = "cResourceNode";
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            var typecode = reader.ReadByte();
            if (typecode == 1)
            {
                var cSG = reader.ReadVariableLengthPascalString();
                thisData.cSGResource = RCOLFile.streams["cSGResource"].Read(reader, owner);
                cSG = reader.ReadVariableLengthPascalString();
                RCOLFile.streams["cCompositionTreeNode"].Read(reader, owner);
                cSG = reader.ReadVariableLengthPascalString();
                RCOLFile.streams["cObjectGraphNode"].Read(reader, owner);

                var chainCount = reader.ReadUInt32();
                for (var i = 0; i < chainCount; i++)
                {
                    var chainEnabled = reader.ReadByte();
                    var chainDependent = reader.ReadByte();
                    var chainLocation = reader.ReadUInt32();
                }

                var isASubnodeCRES = reader.ReadByte();
                var purposeType = reader.ReadUInt32();
            }
            else if (typecode == 0)
            {
                var oGraph = reader.ReadVariableLengthPascalString();
                RCOLFile.streams["cObjectGraphNode"].Read(reader, owner);

                var enabled = reader.ReadByte();
                var isSubnode = reader.ReadByte();
                var objectBlockLink = reader.ReadUInt32();
                var blockObjectCount = reader.ReadUInt32();
            }
            return thisData;
        }
    }
    public class DataBlock
    {
        public string BlockName;
        public uint BlockRCOLID;
        public uint BlockVersion;
    }
    public interface IDataBlockStream
    {
        DataBlock Read(IoBuffer reader, RCOLFile owner);
    }
    #region cSGResource
    public class cSGResourceStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var thisData = new DataBlock();
            thisData.BlockRCOLID = reader.ReadUInt32();
            thisData.BlockVersion = reader.ReadUInt32();
            //Parsing the filename into the block name instead of cSGResource cause we already know it's a cSGResource... will change if this happens not to be the case
            thisData.BlockName = reader.ReadVariableLengthPascalString();
            return thisData;
        }
    }
    #endregion
    public enum ReferenceType { TGIR, TGI };
    public class RCOLFile
    {
        public ReferenceType referenceType = ReferenceType.TGIR;
        public List<int> references = new List<int>();
        public bool imposter = false;
        public static List<uint> RCOLTypeIDs = new List<uint>()
        {
            0xAC4F8687,
            0x7BA3838C,
            0x49596978,
            0xE519C933,
            0xFC6EB1F7,
            0x1C4A276C
        };
        public static Dictionary<string, IDataBlockStream> streams = new Dictionary<string, IDataBlockStream>()
        {
            { "cSGResource", new cSGResourceStream() },
            { "cCompositionTreeNode", new cCompositionTreeNodeStream() },
            { "cObjectGraphNode", new cObjectGraphNodeStream() },
            { "cResourceNode", new cResourceNodeStream() },
            { "cDataListExtension", new cDataListExtensionStream() },
            { "cShapeRefNode", new cShapeRefNodeStream() },
            { "cTransformNode", new cTransformNodeStream() },
            { "cShape", new cShapeStream() },
            { "cGeometryNode", new cGeometryNodeStream() },
            { "cMaterialDefinition", new cMaterialDefinitionStream() },
            { "cAnimResourceConst", new cAnimResourceStream() }
        };
        public List<DataBlock> dataBlocks = new List<DataBlock>();
        private IoBuffer reader;
        
        public static string GetGMNDName(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var io = IoBuffer.FromStream(stream, ByteOrder.LITTLE_ENDIAN);
            var vMark = io.ReadUInt32();
            if (vMark != 0xFFFF0001)
            {
                io.Seek(SeekOrigin.Begin, 0);
            }
            var fileLinks = io.ReadUInt32();
            var skipCount = 16;
            if (vMark != 0xFFFF0001)
                skipCount = 12;
            io.Skip(fileLinks * skipCount);
            var items = io.ReadUInt32();
            io.Skip(4 * items);
            var blockName = io.ReadVariableLengthPascalString();
            //var boop = RCOLFile.streams[blockName].Read(bytes, io, null);
            //var cSG = io.ReadVariableLengthPascalString();
            var eBlockRCOLID = io.ReadUInt32();
            var eBlockVersion = io.ReadUInt32();
            blockName = io.ReadVariableLengthPascalString();
            RCOLFile.streams[blockName].Read(io, null);
            var cesg = io.ReadVariableLengthPascalString();
            eBlockRCOLID = io.ReadUInt32();
            eBlockVersion = io.ReadUInt32();
            var retName = io.ReadVariableLengthPascalString();
            io.Dispose();
            stream.Dispose();
            return retName;
        }
        public static string GetCRESName(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var io = IoBuffer.FromStream(stream, ByteOrder.LITTLE_ENDIAN);
            var vMark = io.ReadUInt32();
            if (vMark != 0xFFFF0001)
            {
                io.Seek(SeekOrigin.Begin, 0);
            }
            var fileLinks = io.ReadUInt32();
            var skipCount = 16;
            if (vMark != 0xFFFF0001)
                skipCount = 12;
            io.Skip(fileLinks * skipCount);
            var items = io.ReadUInt32();
            io.Skip(4 * items);
            var blockName = io.ReadVariableLengthPascalString();
            var BlockRCOLID = io.ReadUInt32();
            var BlockVersion = io.ReadUInt32();
            io.Skip(1);

            var cesg = io.ReadVariableLengthPascalString();
            var datte = streams[cesg].Read(io, null);
            //Debug.Log(datte.BlockName);
            io.Dispose();
            stream.Dispose();
            return datte.BlockName;
        }
        public static string GetName(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var io = IoBuffer.FromStream(stream, ByteOrder.LITTLE_ENDIAN);
            var vMark = io.ReadUInt32();
            if (vMark != 0xFFFF0001)
            {
                io.Seek(SeekOrigin.Begin, 0);
            }
            var fileLinks = io.ReadUInt32();
            var skipCount = 16;
            if (vMark != 0xFFFF0001)
                skipCount = 12;
            io.Skip(fileLinks * skipCount);
            if (io.Stream.Position >= io.Stream.Length)
                return "";
            var items = io.ReadUInt32();
            io.Skip(4 * items);
            var blockName = io.ReadVariableLengthPascalString();
            var BlockRCOLID = io.ReadUInt32();
            var BlockVersion = io.ReadUInt32();
            var cSG = io.ReadVariableLengthPascalString();
            BlockRCOLID = io.ReadUInt32();
            BlockVersion = io.ReadUInt32();
            var retName = io.ReadVariableLengthPascalString();
            io.Dispose();
            stream.Dispose();
            //Debug.Log(retName);
            return retName;
            /*
            var dataBlock = streams[blockName].Read(bytes, reader);
            dataBlocks.Add(dataBlock);*/
            /*
            for (var i = 0; i < fileLinks; i++)
            {
                var groupID = reader.ReadUInt32();
                var instanceID = reader.ReadUInt32();
                uint resourceID = 0x0;
                if (vMark == 0xFFFF0001)
                    resourceID = reader.ReadUInt32();
                var typeID = reader.ReadUInt32();
            }*/
        }
        public RCOLFile(Stream stream)
        {
            reader = IoBuffer.FromStream(stream, ByteOrder.LITTLE_ENDIAN);
            var vMark = reader.ReadUInt32();
            if (vMark != 0xFFFF0001)
            {
                referenceType = ReferenceType.TGI;
                reader.Seek(SeekOrigin.Begin, 0);
            }
            var fileLinks = reader.ReadUInt32();
            for (var i = 0; i < fileLinks; i++)
            {
                var groupID = reader.ReadUInt32();
                var instanceID = reader.ReadUInt32();
                uint instanceHigh = 0x0;
                if (referenceType == ReferenceType.TGIR)
                    instanceHigh = reader.ReadUInt32();
                var typeID = reader.ReadUInt32();
            }
            var items = reader.ReadUInt32();
            for (var i = 0; i < items; i++)
            {
                var rcolID = reader.ReadUInt32();
            }
            for (var i = 0; i < items; i++)
            {
                var blockName = reader.ReadVariableLengthPascalString();
                var dataBlock = streams[blockName].Read(reader, this);
                dataBlocks.Add(dataBlock);
                //Read data blocks
            }
            reader.Dispose();
            stream.Dispose();
        }
    }
}