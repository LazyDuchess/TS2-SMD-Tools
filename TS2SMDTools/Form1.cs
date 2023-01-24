using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TS2SMDTools.SMD;
using TS2SMDTools.Scenegraph;

namespace TS2SMDTools
{
    public partial class Form1 : Form
    {
        StudioModel currentModel;
        cAnimResourceDataBlock currentAnim;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "SMD Files (*.smd)|*.smd";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            var model = new StudioModel();
            var stream = new FileStream(fileDialog.FileName, FileMode.Open);
            model.Read(stream);
            stream.Dispose();
            currentModel = model;
            var boneString = "Bones:" + Environment.NewLine;
            foreach(var element in model.Nodes)
            {
                boneString += "ID: " + element.ID.ToString() + ", " + element.Name + ", Parent: " + element.ParentID.ToString() + Environment.NewLine;
            }
            MessageBox.Show(boneString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "SMD Files (*.smd)|*.smd";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            var stream = new FileStream(fileDialog.FileName, FileMode.Create);
            currentModel.Write(stream);
            stream.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "ANIM Files (*.5an)|*.5an|All files (*.*)|*.*";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            var stream = new FileStream(fileDialog.FileName, FileMode.Open);
            var anim = new RCOLFile(stream);
            currentAnim = anim.dataBlocks[0] as cAnimResourceDataBlock;
            MessageBox.Show(anim.dataBlocks[0].GetType().ToString());
            stream.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var animationStringBuilder = new StringBuilder("Length: ");
            animationStringBuilder.Append(currentAnim.AnimationLength.ToString());
            MessageBox.Show(animationStringBuilder.ToString());
        }
    }
}
