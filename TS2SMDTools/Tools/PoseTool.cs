using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS2SMDTools.SMD;
using TS2SMDTools.Scenegraph;
using System.Numerics;

namespace TS2SMDTools.Tools
{
    public static class PoseTool
    {
        public static StudioModel TransferStartingPose(StudioModel targetModel, cAnimResourceDataBlock animationResource)
        {
            var resultModel = new StudioModel();
            resultModel.Type = StudioModel.ModelType.Sequence;
            foreach(var joint in targetModel.Nodes)
            {
                var newJoint = new Node(joint.ID, joint.Name, joint.ParentID);
                newJoint.Position = joint.Position;
                newJoint.ParentID = joint.ParentID;
                var rotationOffset = ReorderRotation(animationResource.GetBoneRotationDeltaAtTimeCode(0, joint.Name));
                newJoint.Rotation = joint.Rotation + rotationOffset;
                resultModel.AddNode(newJoint);
                if (rotationOffset != Vector3.Zero)
                {
                    Console.WriteLine(newJoint.Name + " rotated by " + rotationOffset.ToString());
                }
            }

            return resultModel;

            Vector3 ReorderRotation(Vector3 rotation)
            {
                var newVec = new Vector3(-rotation.X, -rotation.Y, rotation.Z);
                newVec *= 0.6f;
                return newVec;
            }
        }
    }
}
