using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TS2SMDTools.Scenegraph
{
    #region cAnimResource
    public class cAnimResourceDataBlock : DataBlock
    {
        public ushort AnimationLength;
        public List<AnimObject> AnimObjects = new List<AnimObject>();
    }
    public enum TransformTypes
    {
        Unknown,
        Rotation,
        Translation
    }
    public class AnimFlags
    {
        public uint ItemCount;
        public uint Unknown1;
        public uint Type1;
        public uint Type2;
        public uint Time;
        public uint Time2;
        //public uint RawValue;
        public TransformTypes TransformType
        {
            get
            {
                if (Type1 == 12)
                    return TransformTypes.Rotation;
                else if (Type2 == 2)
                    return TransformTypes.Translation;
                return TransformTypes.Unknown;
            }
        }

        public AnimFlags(uint flags)
        {
            // This stinks
            ItemCount = (flags & 0b_11100000000000000000000000000000) >> 29;
            Unknown1 = (flags & 0b_00011111000000000000000000000000) >> 24;
            Type1 = (flags & 0b_00000000111100000000000000000000) >> 20;
            Type2 = (flags & 0b_00000000000011110000000000000000) >> 16;
            Time2 = flags & 0b_00000000000000001111111111111111;
            Time = flags & 0b_00000000000000000111111111111111;
            //RawValue = flags;
        }
    }
    public class AnimJoint
    {
        public uint BoneHash;
        public AnimFlags Flags;
        public string Name;
        public List<MovementData> Data = new List<MovementData>();
        public AnimFrameHolder FrameHolder = new AnimFrameHolder();

        public override string ToString()
        {
            return Name;
        }
    }
    public class AnimObject
    {
        public string Name;
        public uint Count;
        public List<AnimJoint> Joints = new List<AnimJoint>();

        public override string ToString()
        {
            return Name;
        }
    }
    public class MovementData
    {
        public uint Raw;
        public uint Dum;
        public uint Count;
        public uint Type;
        public int Size;
        public bool Locked;
        public int TimeCode;
        public Vector3 Movement = Vector3.Zero;

        public MovementData(uint raw, uint dum, uint count, uint type, int size, bool locked)
        {
            Raw = raw;
            Dum = dum;
            Count = count;
            Type = type;
            Size = size;
            Locked = locked;
        }
        public MovementData()
        {

        }
    }
    public enum TranslationAxis
    {
        X,
        Y,
        Z
    }
    public class AnimFrameHolder
    {
        public List<AnimFrame> Frames = new List<AnimFrame>();
    }
    public class AnimFrame
    {
        public uint TimeCode;
        public int Raw;

        public TranslationAxis Axis;
        public float TranslationValue;
        public Vector3 Movement = Vector3.Zero;

        public AnimFrame(uint timeCode, int raw, TranslationAxis axis, float translationValue)
        {
            TimeCode = timeCode;
            Raw = raw;
            Axis = axis;
            TranslationValue = translationValue;
        }
    }
    public class cAnimResourceStream : IDataBlockStream
    {
        public DataBlock Read(IoBuffer reader, RCOLFile owner)
        {
            var dataBlock = new cAnimResourceDataBlock();
            //0xFB00791E
            var blockID = reader.ReadUInt32();
            //6
            var version = reader.ReadUInt32();
            var cSG = reader.ReadVariableLengthPascalString();
            var cSGResource = RCOLFile.streams["cSGResource"].Read(reader, owner);

            var dataLength = reader.ReadUInt32();
            dataBlock.AnimationLength = reader.ReadUInt16();
            var count1 = reader.ReadUInt16();
            var count2 = reader.ReadUInt16();
            var objectModifierLength = reader.ReadByte();
            var animationVersion = reader.ReadByte();
            var animationType = reader.ReadByte();
            var unknown = reader.ReadByte();
            var locomotionType = reader.ReadByte();
            var objectNameLength = reader.ReadByte();

            //Filler
            reader.Skip(16);

            var radiansInitialDirection = reader.ReadFloat();
            var unknownFloat = reader.ReadFloat();
            var unknownFloat2 = reader.ReadFloat();
            //Usually 0 or 0.5
            var unknownFloat3 = reader.ReadFloat();
            var unknownFloat4 = reader.ReadFloat();
            var unknownFloat5 = reader.ReadFloat();
            var radiansFinalDirection = reader.ReadFloat();
            var skeletonScale = reader.ReadFloat();
            var skeletonHeight = reader.ReadFloat();

            var start = (int)reader.Stream.Position;

            var objectName = reader.ReadNullTerminatedString();
            var objectModifier = reader.ReadNullTerminatedString();

            Align((int)reader.Stream.Position - start);

            // P1 Object
            for (var i = 0; i < count1; i++)
            {
                var animObject = new AnimObject();
                reader.Skip(8);
                var unknownp1 = reader.ReadUInt16();
                animObject.Count = reader.ReadUInt16();
                var p5count = reader.ReadUInt16();
                var nameLength = reader.ReadUInt16();
                reader.Skip(12);
                dataBlock.AnimObjects.Add(animObject);
            }

            start = (int)reader.Stream.Position;

            for (var i = 0; i < count1; i++)
            {
                dataBlock.AnimObjects[i].Name = reader.ReadNullTerminatedString();
            }

            Align((int)reader.Stream.Position - start);

            // P2 Assignment
            for (var i = 0; i < count1; i++)
            {
                for (var j = 0; j < dataBlock.AnimObjects[i].Count; j++)
                {
                    var joint = new AnimJoint();
                    reader.Skip(8);
                    joint.BoneHash = reader.ReadUInt32();
                    reader.Skip(4);
                    joint.Flags = new AnimFlags(reader.ReadUInt32());
                    reader.Skip(4);
                    dataBlock.AnimObjects[i].Joints.Add(joint);
                }
            }

            start = (int)reader.Stream.Position;
            for (var i = 0; i < count1; i++)
            {
                for (var j = 0; j < dataBlock.AnimObjects[i].Count; j++)
                {
                    dataBlock.AnimObjects[i].Joints[j].Name = reader.ReadNullTerminatedString();
                }
            }
            Align((int)reader.Stream.Position - start);

            // P3 Movements

            for (var i = 0; i < count1; i++)
            {
                for (var j = 0; j < dataBlock.AnimObjects[i].Count; j++)
                {
                    for (var k = 0; k < dataBlock.AnimObjects[i].Joints[j].Flags.ItemCount; k++)
                    {
                        var unk1 = reader.ReadUInt32();
                        reader.Skip(4);
                        var dum = unk1 >> 0x10;
                        var count = unk1 & 0xFFFF;
                        var locked = ((unk1 >> 0x12) & 1) == 1;
                        var addonType = dum & 3;
                        int size;
                        if (addonType == 0)
                            size = 1;
                        else if (addonType == 1)
                            size = 3;
                        else
                            size = 4;

                        dataBlock.AnimObjects[i].Joints[j].Data.Add(new MovementData(unk1, dum, count, addonType, size, locked));
                    }
                }
            }

            for (var i = 0; i < count1; i++)
            {
                for (var j = 0; j < dataBlock.AnimObjects[i].Count; j++)
                {
                    
                    for (var n = 0; n < dataBlock.AnimObjects[i].Joints[j].Flags.ItemCount; n++)
                    {
                        var data = dataBlock.AnimObjects[i].Joints[j].Data[n];
                        var loopCount = dataBlock.AnimObjects[i].Joints[j].Data[n].Count;
                        var size = dataBlock.AnimObjects[i].Joints[j].Data[n].Size;
                        var transformType = dataBlock.AnimObjects[i].Joints[j].Flags.TransformType;
                        var frame = new AnimFrame(0, 0, TranslationAxis.X, 0f);

                        if (loopCount == 1 && size == 3)
                        {
                            var xValue = UncompressFloat(reader.ReadInt16(), transformType);
                            var yValue = UncompressFloat(reader.ReadInt16(), transformType);
                            var zValue = UncompressFloat(reader.ReadInt16(), transformType);
                            frame.Movement = new Vector3(xValue, yValue, zValue);
                            dataBlock.AnimObjects[i].Joints[j].FrameHolder.Frames.Add(frame);
                        }
                        else
                        {
                            for(var l=0;l<loopCount;l++)
                            {
                                frame = new AnimFrame(0, 0, TranslationAxis.X, 0f);
                                if (size == 1)
                                {
                                    var param = UncompressFloat(reader.ReadInt16(), transformType);
                                    frame.TranslationValue = param;
                                    dataBlock.AnimObjects[i].Joints[j].FrameHolder.Frames.Add(frame);
                                }
                                else if (size == 3)
                                {
                                    var u1 = reader.ReadUInt16();
                                    var u2 = reader.ReadInt16();
                                    reader.Skip(2);
                                    var timeCode = u1 & 0x7FFF;
                                    data.TimeCode = timeCode;
                                    if (l == 0)
                                        data.Movement.X = UncompressFloat(u2, transformType);
                                    if (l == 1)
                                        data.Movement.Y = UncompressFloat(u2, transformType);
                                    if (l == 2)
                                        data.Movement.Z = UncompressFloat(u2, transformType);
                                    frame.Movement = data.Movement;
                                    frame.TimeCode = (uint)timeCode;
                                }
                                else if (size == 4)
                                {
                                    var u1 = reader.ReadUInt16();

                                    data.TimeCode = u1 & 0x7FFF;
                                    data.Movement.X = UncompressFloat(reader.ReadInt16(), transformType);
                                    data.Movement.Y = UncompressFloat(reader.ReadInt16(), transformType);
                                    data.Movement.Z = UncompressFloat(reader.ReadInt16(), transformType);
                                    frame.Movement = data.Movement;
                                    frame.TimeCode = (uint)data.TimeCode;
                                }
                                dataBlock.AnimObjects[i].Joints[j].FrameHolder.Frames.Add(frame);
                            }
                        }
                        //dataBlock.AnimObjects[i].Joints[j].FrameHolder.Frames.Add(frame);
                        /*
                        var timeCode = reader.ReadUInt16();
                        var value = reader.ReadInt16();
                        reader.Skip(2);
                        var translationValue = UncompressFloat(value, dataBlock.AnimObjects[i].Joints[j].Flags.TransformType);

                        AnimFrame frame = new AnimFrame(timeCode, value, TranslationAxis.X, translationValue);
                        switch (n)
                        {
                            case 0:
                                frame.Axis = TranslationAxis.X;
                                break;
                            case 1:
                                frame.Axis = TranslationAxis.Y;
                                break;
                            case 2:
                                frame.Axis = TranslationAxis.Z;
                                break;
                        }
                        dataBlock.AnimObjects[i].Joints[j].FrameHolder.Frames.Add(frame);*/
                    }
                }
            }

            //Part 5
            for (var i = 0; i < count1; i++)
            {
                for (var j = 0; j < dataBlock.AnimObjects[i].Count; j++)
                {

                }
            }

            return dataBlock;

            float UncompressFloat(int value, TransformTypes transformType)
            {
                return (float)value;
                if (transformType == TransformTypes.Rotation)
                    return (float)Math.Round(value * 0.01562500, 6);
                else if (transformType == TransformTypes.Translation)
                    return (float)Math.Round(value * 0.000976562, 6);
                return value;
            }
            /*
            float UncompressFloat(short value, TransformTypes transformType)
            {
                if (transformType == TransformTypes.Rotation)
                    return (float)Math.Round(value * 0.01562500, 6);
                else if (transformType == TransformTypes.Translation)
                    return (float)Math.Round(value * 0.000976562, 6);
                return value;
            }*/

            void Align(int amount)
            {
                var add = 0;
                if (amount % 2 == 0)
                    add = amount % 4;
                else
                {
                    add = amount % 2;
                    if ((add + amount) % 4 == 0)
                        add += 2;
                }

                reader.Skip(add);
            }

        }
    }
    #endregion
}
