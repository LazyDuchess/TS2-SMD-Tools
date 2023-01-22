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
using TS2SMDTools.Tools;

namespace TS2SMDTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTargetBaseMeshBrowse_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxTargetBaseMesh);
        }

        void BrowseSMDFile(TextBox textBox)
        {
            openFileDialogSMD.FileName = textBox.Text;
            var openDialog = openFileDialogSMD.ShowDialog();
            if (openDialog != DialogResult.OK)
                return;
            textBox.Text = openFileDialogSMD.FileName;
        }

        private void btnGenerateMorphMesh_Click(object sender, EventArgs e)
        {
            var targetBaseModelPath = textBoxTargetBaseMesh.Text;
            var refBaseModelPath = textBoxRefBaseMesh.Text;
            var refMorphModelPath = textBoxRefMorphMesh.Text;

            if (!File.Exists(targetBaseModelPath))
            {
                MessageBox.Show("Can't find Target Model!");
                return;
            }

            if (!File.Exists(refBaseModelPath))
            {
                MessageBox.Show("Can't find Reference Base Model!");
                return;
            }

            if (!File.Exists(refMorphModelPath))
            {
                MessageBox.Show("Can't find Reference Morph Model!");
                return;
            }

            var targetBaseModel = new StudioModel(targetBaseModelPath);
            var refBaseModel = new StudioModel(refBaseModelPath);
            var refMorphModel = new StudioModel(refMorphModelPath);
            AutoMorph.GenerateMorphForTarget(targetBaseModel, refBaseModel, refMorphModel, (float)numericUpDownInterpolationDistance.Value, (float)numericUpDownMaxInfluenceDistance.Value);
            var outputFileName = Path.GetFileNameWithoutExtension(textBoxTargetBaseMesh.Text);
            outputFileName += "-morph.smd";
            saveFileDialogSMD.FileName = outputFileName;
            var dialog = saveFileDialogSMD.ShowDialog();
            if (dialog != DialogResult.OK)
                return;
            var outputFileStream = new FileStream(saveFileDialogSMD.FileName, FileMode.Create);
            targetBaseModel.Write(outputFileStream);
            outputFileStream.Dispose();

            MessageBox.Show("Model exported successfully!");
        }

        private void btnRefBaseMeshBrowse_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxRefBaseMesh);
        }

        private void btnRefMorphMeshBrowse_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxRefMorphMesh);
        }

        private void btnBrowseNormalTargetMesh_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxNormalTargetMesh);
        }

        private void btnBrowseNormalRefMesh_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxNormalRefMesh);
        }

        private void btnFixNormals_Click(object sender, EventArgs e)
        {
            var targetModelPath = textBoxNormalTargetMesh.Text;
            var refModelPath = textBoxNormalRefMesh.Text;

            if (!File.Exists(targetModelPath))
            {
                MessageBox.Show("Can't find Target Model!");
                return;
            }

            if (!File.Exists(refModelPath))
            {
                MessageBox.Show("Can't find Reference Model!");
                return;
            }

            var targetModel = new StudioModel(targetModelPath);
            var refModel = new StudioModel(refModelPath);
            AutoNormals.FixNormalsForTarget(targetModel, refModel, (float)numericUpDownNormalDistance.Value, (float)numericUpDownNormalFacing.Value, checkBoxTestNormalFacing.Checked);
            var outputFileName = Path.GetFileNameWithoutExtension(textBoxNormalTargetMesh.Text);
            outputFileName += ".smd";
            saveFileDialogSMD.FileName = outputFileName;
            var dialog = saveFileDialogSMD.ShowDialog();
            if (dialog != DialogResult.OK)
                return;
            var outputFileStream = new FileStream(saveFileDialogSMD.FileName, FileMode.Create);
            targetModel.Write(outputFileStream);
            outputFileStream.Dispose();

            MessageBox.Show("Model exported successfully!");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDisplay();
        }

        void RefreshDisplay()
        {
            labelNormalFacing.Enabled = checkBoxTestNormalFacing.Checked;
            numericUpDownNormalFacing.Enabled = checkBoxTestNormalFacing.Checked;
        }

        private void checkBoxTestNormalFacing_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDisplay();
        }

        private void btnSkinTargetMeshBrowse_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxSkinTargetMesh);
        }

        private void btnSkinRefMeshBrowse_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxSkinRefMesh);
        }

        private void btnAutoSkin_Click(object sender, EventArgs e)
        {
            var targetModelPath = textBoxSkinTargetMesh.Text;
            var refModelPath = textBoxSkinRefMesh.Text;

            if (!File.Exists(targetModelPath))
            {
                MessageBox.Show("Can't find Target Model!");
                return;
            }

            if (!File.Exists(refModelPath))
            {
                MessageBox.Show("Can't find Reference Model!");
                return;
            }

            var targetModel = new StudioModel(targetModelPath);
            var refModel = new StudioModel(refModelPath);
            AutoSkin.GenerateSkinForTarget(targetModel, refModel);
            var outputFileName = Path.GetFileNameWithoutExtension(textBoxSkinTargetMesh.Text);
            outputFileName += ".smd";
            saveFileDialogSMD.FileName = outputFileName;
            var dialog = saveFileDialogSMD.ShowDialog();
            if (dialog != DialogResult.OK)
                return;
            var outputFileStream = new FileStream(saveFileDialogSMD.FileName, FileMode.Create);
            targetModel.Write(outputFileStream);
            outputFileStream.Dispose();

            MessageBox.Show("Model exported successfully!");
        }

        private void btnBrowseReExportMesh_Click(object sender, EventArgs e)
        {
            BrowseSMDFile(textBoxReExportMesh);
        }

        private void btnReExport_Click(object sender, EventArgs e)
        {
            var targetModelPath = textBoxReExportMesh.Text;

            if (!File.Exists(targetModelPath))
            {
                MessageBox.Show("Can't find Model!");
                return;
            }

            var targetModel = new StudioModel(targetModelPath);
            var outputFileName = Path.GetFileNameWithoutExtension(textBoxReExportMesh.Text);
            outputFileName += ".smd";
            saveFileDialogSMD.FileName = outputFileName;
            var dialog = saveFileDialogSMD.ShowDialog();
            if (dialog != DialogResult.OK)
                return;
            var outputFileStream = new FileStream(saveFileDialogSMD.FileName, FileMode.Create);
            targetModel.Write(outputFileStream);
            outputFileStream.Dispose();

            MessageBox.Show("Model exported successfully!");
        }
    }
}
