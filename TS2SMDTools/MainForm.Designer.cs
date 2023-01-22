
namespace TS2SMDTools
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageAutoMorphs = new System.Windows.Forms.TabPage();
            this.tabPageFixNormals = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialogSMD = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSMD = new System.Windows.Forms.SaveFileDialog();
            this.textBoxTargetBaseMesh = new System.Windows.Forms.TextBox();
            this.textBoxRefBaseMesh = new System.Windows.Forms.TextBox();
            this.textBoxRefMorphMesh = new System.Windows.Forms.TextBox();
            this.btnTargetBaseMeshBrowse = new System.Windows.Forms.Button();
            this.btnRefBaseMeshBrowse = new System.Windows.Forms.Button();
            this.btnRefMorphMeshBrowse = new System.Windows.Forms.Button();
            this.btnGenerateMorphMesh = new System.Windows.Forms.Button();
            this.numericUpDownInterpolationDistance = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowseNormalRefMesh = new System.Windows.Forms.Button();
            this.btnBrowseNormalTargetMesh = new System.Windows.Forms.Button();
            this.textBoxNormalRefMesh = new System.Windows.Forms.TextBox();
            this.textBoxNormalTargetMesh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFixNormals = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownNormalDistance = new System.Windows.Forms.NumericUpDown();
            this.labelNormalFacing = new System.Windows.Forms.Label();
            this.numericUpDownNormalFacing = new System.Windows.Forms.NumericUpDown();
            this.checkBoxTestNormalFacing = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownMaxInfluenceDistance = new System.Windows.Forms.NumericUpDown();
            this.tabPageAutoSkin = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSkinRefMeshBrowse = new System.Windows.Forms.Button();
            this.btnSkinTargetMeshBrowse = new System.Windows.Forms.Button();
            this.textBoxSkinRefMesh = new System.Windows.Forms.TextBox();
            this.textBoxSkinTargetMesh = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAutoSkin = new System.Windows.Forms.Button();
            this.tabPageExport = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBrowseReExportMesh = new System.Windows.Forms.Button();
            this.textBoxReExportMesh = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnReExport = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageAutoMorphs.SuspendLayout();
            this.tabPageFixNormals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormalDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormalFacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxInfluenceDistance)).BeginInit();
            this.tabPageAutoSkin.SuspendLayout();
            this.tabPageExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageAutoMorphs);
            this.tabControlMain.Controls.Add(this.tabPageFixNormals);
            this.tabControlMain.Controls.Add(this.tabPageAutoSkin);
            this.tabControlMain.Controls.Add(this.tabPageExport);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(559, 413);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageAutoMorphs
            // 
            this.tabPageAutoMorphs.Controls.Add(this.label10);
            this.tabPageAutoMorphs.Controls.Add(this.numericUpDownMaxInfluenceDistance);
            this.tabPageAutoMorphs.Controls.Add(this.label5);
            this.tabPageAutoMorphs.Controls.Add(this.numericUpDownInterpolationDistance);
            this.tabPageAutoMorphs.Controls.Add(this.label4);
            this.tabPageAutoMorphs.Controls.Add(this.btnGenerateMorphMesh);
            this.tabPageAutoMorphs.Controls.Add(this.btnRefMorphMeshBrowse);
            this.tabPageAutoMorphs.Controls.Add(this.btnRefBaseMeshBrowse);
            this.tabPageAutoMorphs.Controls.Add(this.btnTargetBaseMeshBrowse);
            this.tabPageAutoMorphs.Controls.Add(this.textBoxRefMorphMesh);
            this.tabPageAutoMorphs.Controls.Add(this.textBoxRefBaseMesh);
            this.tabPageAutoMorphs.Controls.Add(this.textBoxTargetBaseMesh);
            this.tabPageAutoMorphs.Controls.Add(this.label3);
            this.tabPageAutoMorphs.Controls.Add(this.label2);
            this.tabPageAutoMorphs.Controls.Add(this.label1);
            this.tabPageAutoMorphs.Location = new System.Drawing.Point(4, 22);
            this.tabPageAutoMorphs.Name = "tabPageAutoMorphs";
            this.tabPageAutoMorphs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAutoMorphs.Size = new System.Drawing.Size(551, 387);
            this.tabPageAutoMorphs.TabIndex = 0;
            this.tabPageAutoMorphs.Text = "Auto Morphs";
            this.tabPageAutoMorphs.UseVisualStyleBackColor = true;
            // 
            // tabPageFixNormals
            // 
            this.tabPageFixNormals.Controls.Add(this.checkBoxTestNormalFacing);
            this.tabPageFixNormals.Controls.Add(this.labelNormalFacing);
            this.tabPageFixNormals.Controls.Add(this.numericUpDownNormalFacing);
            this.tabPageFixNormals.Controls.Add(this.label9);
            this.tabPageFixNormals.Controls.Add(this.numericUpDownNormalDistance);
            this.tabPageFixNormals.Controls.Add(this.btnFixNormals);
            this.tabPageFixNormals.Controls.Add(this.btnBrowseNormalRefMesh);
            this.tabPageFixNormals.Controls.Add(this.btnBrowseNormalTargetMesh);
            this.tabPageFixNormals.Controls.Add(this.textBoxNormalRefMesh);
            this.tabPageFixNormals.Controls.Add(this.textBoxNormalTargetMesh);
            this.tabPageFixNormals.Controls.Add(this.label7);
            this.tabPageFixNormals.Controls.Add(this.label8);
            this.tabPageFixNormals.Controls.Add(this.label6);
            this.tabPageFixNormals.Location = new System.Drawing.Point(4, 22);
            this.tabPageFixNormals.Name = "tabPageFixNormals";
            this.tabPageFixNormals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFixNormals.Size = new System.Drawing.Size(551, 387);
            this.tabPageFixNormals.TabIndex = 1;
            this.tabPageFixNormals.Text = "Fix Normals";
            this.tabPageFixNormals.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target Base Mesh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference Base Mesh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reference Morph Mesh:";
            // 
            // openFileDialogSMD
            // 
            this.openFileDialogSMD.FileName = "openFileDialog1";
            this.openFileDialogSMD.Filter = "SMD Files|*.smd|All files|*.*";
            // 
            // saveFileDialogSMD
            // 
            this.saveFileDialogSMD.Filter = "SMD Files|*.smd|All files|*.*";
            // 
            // textBoxTargetBaseMesh
            // 
            this.textBoxTargetBaseMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetBaseMesh.Location = new System.Drawing.Point(134, 94);
            this.textBoxTargetBaseMesh.Name = "textBoxTargetBaseMesh";
            this.textBoxTargetBaseMesh.Size = new System.Drawing.Size(326, 20);
            this.textBoxTargetBaseMesh.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxTargetBaseMesh, "Target mesh that will receive the new morph.");
            // 
            // textBoxRefBaseMesh
            // 
            this.textBoxRefBaseMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRefBaseMesh.Location = new System.Drawing.Point(134, 172);
            this.textBoxRefBaseMesh.Name = "textBoxRefBaseMesh";
            this.textBoxRefBaseMesh.Size = new System.Drawing.Size(326, 20);
            this.textBoxRefBaseMesh.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBoxRefBaseMesh, "Reference mesh with no morphs.");
            // 
            // textBoxRefMorphMesh
            // 
            this.textBoxRefMorphMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRefMorphMesh.Location = new System.Drawing.Point(134, 198);
            this.textBoxRefMorphMesh.Name = "textBoxRefMorphMesh";
            this.textBoxRefMorphMesh.Size = new System.Drawing.Size(326, 20);
            this.textBoxRefMorphMesh.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBoxRefMorphMesh, "Morphed reference mesh to transfer to target mesh.");
            // 
            // btnTargetBaseMeshBrowse
            // 
            this.btnTargetBaseMeshBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetBaseMeshBrowse.Location = new System.Drawing.Point(466, 92);
            this.btnTargetBaseMeshBrowse.Name = "btnTargetBaseMeshBrowse";
            this.btnTargetBaseMeshBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnTargetBaseMeshBrowse.TabIndex = 6;
            this.btnTargetBaseMeshBrowse.Text = "Browse";
            this.btnTargetBaseMeshBrowse.UseVisualStyleBackColor = true;
            this.btnTargetBaseMeshBrowse.Click += new System.EventHandler(this.btnTargetBaseMeshBrowse_Click);
            // 
            // btnRefBaseMeshBrowse
            // 
            this.btnRefBaseMeshBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefBaseMeshBrowse.Location = new System.Drawing.Point(466, 169);
            this.btnRefBaseMeshBrowse.Name = "btnRefBaseMeshBrowse";
            this.btnRefBaseMeshBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnRefBaseMeshBrowse.TabIndex = 7;
            this.btnRefBaseMeshBrowse.Text = "Browse";
            this.btnRefBaseMeshBrowse.UseVisualStyleBackColor = true;
            this.btnRefBaseMeshBrowse.Click += new System.EventHandler(this.btnRefBaseMeshBrowse_Click);
            // 
            // btnRefMorphMeshBrowse
            // 
            this.btnRefMorphMeshBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefMorphMeshBrowse.Location = new System.Drawing.Point(466, 198);
            this.btnRefMorphMeshBrowse.Name = "btnRefMorphMeshBrowse";
            this.btnRefMorphMeshBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnRefMorphMeshBrowse.TabIndex = 8;
            this.btnRefMorphMeshBrowse.Text = "Browse";
            this.btnRefMorphMeshBrowse.UseVisualStyleBackColor = true;
            this.btnRefMorphMeshBrowse.Click += new System.EventHandler(this.btnRefMorphMeshBrowse_Click);
            // 
            // btnGenerateMorphMesh
            // 
            this.btnGenerateMorphMesh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateMorphMesh.Location = new System.Drawing.Point(3, 338);
            this.btnGenerateMorphMesh.Name = "btnGenerateMorphMesh";
            this.btnGenerateMorphMesh.Size = new System.Drawing.Size(545, 46);
            this.btnGenerateMorphMesh.TabIndex = 9;
            this.btnGenerateMorphMesh.Text = "Generate Morph Mesh";
            this.btnGenerateMorphMesh.UseVisualStyleBackColor = true;
            this.btnGenerateMorphMesh.Click += new System.EventHandler(this.btnGenerateMorphMesh_Click);
            // 
            // numericUpDownInterpolationDistance
            // 
            this.numericUpDownInterpolationDistance.DecimalPlaces = 2;
            this.numericUpDownInterpolationDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownInterpolationDistance.Location = new System.Drawing.Point(134, 254);
            this.numericUpDownInterpolationDistance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownInterpolationDistance.Name = "numericUpDownInterpolationDistance";
            this.numericUpDownInterpolationDistance.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownInterpolationDistance.TabIndex = 11;
            this.toolTip1.SetToolTip(this.numericUpDownInterpolationDistance, "Lowering this value will potentially make morphs less smooth and more pronounced." +
        "");
            this.numericUpDownInterpolationDistance.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Interpolation Distance:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(539, 86);
            this.label4.TabIndex = 10;
            this.label4.Text = "Automatically generates a morph for a base mesh, based on a reference mesh.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(545, 86);
            this.label6.TabIndex = 11;
            this.label6.Text = "Matches normals to those of a reference mesh where appropriate, fixes seams and s" +
    "hading issues.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBrowseNormalRefMesh
            // 
            this.btnBrowseNormalRefMesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseNormalRefMesh.Location = new System.Drawing.Point(470, 147);
            this.btnBrowseNormalRefMesh.Name = "btnBrowseNormalRefMesh";
            this.btnBrowseNormalRefMesh.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseNormalRefMesh.TabIndex = 17;
            this.btnBrowseNormalRefMesh.Text = "Browse";
            this.btnBrowseNormalRefMesh.UseVisualStyleBackColor = true;
            this.btnBrowseNormalRefMesh.Click += new System.EventHandler(this.btnBrowseNormalRefMesh_Click);
            // 
            // btnBrowseNormalTargetMesh
            // 
            this.btnBrowseNormalTargetMesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseNormalTargetMesh.Location = new System.Drawing.Point(470, 90);
            this.btnBrowseNormalTargetMesh.Name = "btnBrowseNormalTargetMesh";
            this.btnBrowseNormalTargetMesh.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseNormalTargetMesh.TabIndex = 16;
            this.btnBrowseNormalTargetMesh.Text = "Browse";
            this.btnBrowseNormalTargetMesh.UseVisualStyleBackColor = true;
            this.btnBrowseNormalTargetMesh.Click += new System.EventHandler(this.btnBrowseNormalTargetMesh_Click);
            // 
            // textBoxNormalRefMesh
            // 
            this.textBoxNormalRefMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNormalRefMesh.Location = new System.Drawing.Point(101, 149);
            this.textBoxNormalRefMesh.Name = "textBoxNormalRefMesh";
            this.textBoxNormalRefMesh.Size = new System.Drawing.Size(360, 20);
            this.textBoxNormalRefMesh.TabIndex = 15;
            this.toolTip1.SetToolTip(this.textBoxNormalRefMesh, "Reference mesh normals will be taken from.");
            // 
            // textBoxNormalTargetMesh
            // 
            this.textBoxNormalTargetMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNormalTargetMesh.Location = new System.Drawing.Point(101, 92);
            this.textBoxNormalTargetMesh.Name = "textBoxNormalTargetMesh";
            this.textBoxNormalTargetMesh.Size = new System.Drawing.Size(360, 20);
            this.textBoxNormalTargetMesh.TabIndex = 14;
            this.toolTip1.SetToolTip(this.textBoxNormalTargetMesh, "Target mesh that will receive the new normals.");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Reference Mesh:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Target Mesh:";
            // 
            // btnFixNormals
            // 
            this.btnFixNormals.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFixNormals.Location = new System.Drawing.Point(3, 338);
            this.btnFixNormals.Name = "btnFixNormals";
            this.btnFixNormals.Size = new System.Drawing.Size(545, 46);
            this.btnFixNormals.TabIndex = 18;
            this.btnFixNormals.Text = "Fix Normals";
            this.btnFixNormals.UseVisualStyleBackColor = true;
            this.btnFixNormals.Click += new System.EventHandler(this.btnFixNormals_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Maximum Distance:";
            // 
            // numericUpDownNormalDistance
            // 
            this.numericUpDownNormalDistance.DecimalPlaces = 4;
            this.numericUpDownNormalDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownNormalDistance.Location = new System.Drawing.Point(134, 228);
            this.numericUpDownNormalDistance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNormalDistance.Name = "numericUpDownNormalDistance";
            this.numericUpDownNormalDistance.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNormalDistance.TabIndex = 19;
            this.toolTip1.SetToolTip(this.numericUpDownNormalDistance, "Maximum distance between vertices to transfer normals from one to the other.");
            this.numericUpDownNormalDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // labelNormalFacing
            // 
            this.labelNormalFacing.AutoSize = true;
            this.labelNormalFacing.Location = new System.Drawing.Point(6, 265);
            this.labelNormalFacing.Name = "labelNormalFacing";
            this.labelNormalFacing.Size = new System.Drawing.Size(122, 13);
            this.labelNormalFacing.TabIndex = 22;
            this.labelNormalFacing.Text = "Minimum Normal Facing:";
            // 
            // numericUpDownNormalFacing
            // 
            this.numericUpDownNormalFacing.DecimalPlaces = 2;
            this.numericUpDownNormalFacing.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownNormalFacing.Location = new System.Drawing.Point(134, 263);
            this.numericUpDownNormalFacing.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNormalFacing.Name = "numericUpDownNormalFacing";
            this.numericUpDownNormalFacing.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNormalFacing.TabIndex = 21;
            this.numericUpDownNormalFacing.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // checkBoxTestNormalFacing
            // 
            this.checkBoxTestNormalFacing.AutoSize = true;
            this.checkBoxTestNormalFacing.Location = new System.Drawing.Point(272, 264);
            this.checkBoxTestNormalFacing.Name = "checkBoxTestNormalFacing";
            this.checkBoxTestNormalFacing.Size = new System.Drawing.Size(128, 17);
            this.checkBoxTestNormalFacing.TabIndex = 23;
            this.checkBoxTestNormalFacing.Text = "Check Normal Facing";
            this.toolTip1.SetToolTip(this.checkBoxTestNormalFacing, "Checks that vertices are facing roughly the same direction. Enable if you\'re gett" +
        "ing incorrect shading in areas.");
            this.checkBoxTestNormalFacing.UseVisualStyleBackColor = true;
            this.checkBoxTestNormalFacing.CheckedChanged += new System.EventHandler(this.checkBoxTestNormalFacing_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Max Influence Distance:";
            // 
            // numericUpDownMaxInfluenceDistance
            // 
            this.numericUpDownMaxInfluenceDistance.DecimalPlaces = 4;
            this.numericUpDownMaxInfluenceDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownMaxInfluenceDistance.Location = new System.Drawing.Point(134, 280);
            this.numericUpDownMaxInfluenceDistance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMaxInfluenceDistance.Name = "numericUpDownMaxInfluenceDistance";
            this.numericUpDownMaxInfluenceDistance.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMaxInfluenceDistance.TabIndex = 13;
            this.toolTip1.SetToolTip(this.numericUpDownMaxInfluenceDistance, "Distance at which vertices take 100% influence. Fixes gaps.");
            this.numericUpDownMaxInfluenceDistance.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // tabPageAutoSkin
            // 
            this.tabPageAutoSkin.Controls.Add(this.btnAutoSkin);
            this.tabPageAutoSkin.Controls.Add(this.btnSkinRefMeshBrowse);
            this.tabPageAutoSkin.Controls.Add(this.btnSkinTargetMeshBrowse);
            this.tabPageAutoSkin.Controls.Add(this.textBoxSkinRefMesh);
            this.tabPageAutoSkin.Controls.Add(this.textBoxSkinTargetMesh);
            this.tabPageAutoSkin.Controls.Add(this.label12);
            this.tabPageAutoSkin.Controls.Add(this.label13);
            this.tabPageAutoSkin.Controls.Add(this.label11);
            this.tabPageAutoSkin.Location = new System.Drawing.Point(4, 22);
            this.tabPageAutoSkin.Name = "tabPageAutoSkin";
            this.tabPageAutoSkin.Size = new System.Drawing.Size(551, 387);
            this.tabPageAutoSkin.TabIndex = 2;
            this.tabPageAutoSkin.Text = "Auto Skin";
            this.tabPageAutoSkin.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(551, 127);
            this.label11.TabIndex = 11;
            this.label11.Text = "Copies all bones from the reference mesh to the target mesh and automatically tra" +
    "nsfers bone weights.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSkinRefMeshBrowse
            // 
            this.btnSkinRefMeshBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkinRefMeshBrowse.Location = new System.Drawing.Point(467, 187);
            this.btnSkinRefMeshBrowse.Name = "btnSkinRefMeshBrowse";
            this.btnSkinRefMeshBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSkinRefMeshBrowse.TabIndex = 23;
            this.btnSkinRefMeshBrowse.Text = "Browse";
            this.btnSkinRefMeshBrowse.UseVisualStyleBackColor = true;
            this.btnSkinRefMeshBrowse.Click += new System.EventHandler(this.btnSkinRefMeshBrowse_Click);
            // 
            // btnSkinTargetMeshBrowse
            // 
            this.btnSkinTargetMeshBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkinTargetMeshBrowse.Location = new System.Drawing.Point(467, 130);
            this.btnSkinTargetMeshBrowse.Name = "btnSkinTargetMeshBrowse";
            this.btnSkinTargetMeshBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSkinTargetMeshBrowse.TabIndex = 22;
            this.btnSkinTargetMeshBrowse.Text = "Browse";
            this.btnSkinTargetMeshBrowse.UseVisualStyleBackColor = true;
            this.btnSkinTargetMeshBrowse.Click += new System.EventHandler(this.btnSkinTargetMeshBrowse_Click);
            // 
            // textBoxSkinRefMesh
            // 
            this.textBoxSkinRefMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSkinRefMesh.Location = new System.Drawing.Point(98, 189);
            this.textBoxSkinRefMesh.Name = "textBoxSkinRefMesh";
            this.textBoxSkinRefMesh.Size = new System.Drawing.Size(360, 20);
            this.textBoxSkinRefMesh.TabIndex = 21;
            this.toolTip1.SetToolTip(this.textBoxSkinRefMesh, "Reference mesh bones and weights will be taken from.");
            // 
            // textBoxSkinTargetMesh
            // 
            this.textBoxSkinTargetMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSkinTargetMesh.Location = new System.Drawing.Point(98, 132);
            this.textBoxSkinTargetMesh.Name = "textBoxSkinTargetMesh";
            this.textBoxSkinTargetMesh.Size = new System.Drawing.Size(360, 20);
            this.textBoxSkinTargetMesh.TabIndex = 20;
            this.toolTip1.SetToolTip(this.textBoxSkinTargetMesh, "Target mesh that will receive the new bone weights.");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Reference Mesh:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Target Mesh:";
            // 
            // btnAutoSkin
            // 
            this.btnAutoSkin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAutoSkin.Location = new System.Drawing.Point(0, 341);
            this.btnAutoSkin.Name = "btnAutoSkin";
            this.btnAutoSkin.Size = new System.Drawing.Size(551, 46);
            this.btnAutoSkin.TabIndex = 24;
            this.btnAutoSkin.Text = "Generate Skinned Mesh";
            this.btnAutoSkin.UseVisualStyleBackColor = true;
            this.btnAutoSkin.Click += new System.EventHandler(this.btnAutoSkin_Click);
            // 
            // tabPageExport
            // 
            this.tabPageExport.Controls.Add(this.btnReExport);
            this.tabPageExport.Controls.Add(this.btnBrowseReExportMesh);
            this.tabPageExport.Controls.Add(this.textBoxReExportMesh);
            this.tabPageExport.Controls.Add(this.label15);
            this.tabPageExport.Controls.Add(this.label14);
            this.tabPageExport.Location = new System.Drawing.Point(4, 22);
            this.tabPageExport.Name = "tabPageExport";
            this.tabPageExport.Size = new System.Drawing.Size(551, 387);
            this.tabPageExport.TabIndex = 3;
            this.tabPageExport.Text = "Re-Export";
            this.tabPageExport.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(551, 86);
            this.label14.TabIndex = 11;
            this.label14.Text = "Re-Exports an SMD without any changes. Makes SMDs exported via SimPE compatible w" +
    "ith the Blender Source Tools.";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBrowseReExportMesh
            // 
            this.btnBrowseReExportMesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseReExportMesh.Location = new System.Drawing.Point(473, 163);
            this.btnBrowseReExportMesh.Name = "btnBrowseReExportMesh";
            this.btnBrowseReExportMesh.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseReExportMesh.TabIndex = 14;
            this.btnBrowseReExportMesh.Text = "Browse";
            this.btnBrowseReExportMesh.UseVisualStyleBackColor = true;
            this.btnBrowseReExportMesh.Click += new System.EventHandler(this.btnBrowseReExportMesh_Click);
            // 
            // textBoxReExportMesh
            // 
            this.textBoxReExportMesh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReExportMesh.Location = new System.Drawing.Point(45, 165);
            this.textBoxReExportMesh.Name = "textBoxReExportMesh";
            this.textBoxReExportMesh.Size = new System.Drawing.Size(422, 20);
            this.textBoxReExportMesh.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textBoxReExportMesh, "Target mesh that will receive the new morph.");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Mesh:";
            // 
            // btnReExport
            // 
            this.btnReExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReExport.Location = new System.Drawing.Point(0, 341);
            this.btnReExport.Name = "btnReExport";
            this.btnReExport.Size = new System.Drawing.Size(551, 46);
            this.btnReExport.TabIndex = 19;
            this.btnReExport.Text = "Export";
            this.btnReExport.UseVisualStyleBackColor = true;
            this.btnReExport.Click += new System.EventHandler(this.btnReExport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 437);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "SMD Tools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAutoMorphs.ResumeLayout(false);
            this.tabPageAutoMorphs.PerformLayout();
            this.tabPageFixNormals.ResumeLayout(false);
            this.tabPageFixNormals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormalDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormalFacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxInfluenceDistance)).EndInit();
            this.tabPageAutoSkin.ResumeLayout(false);
            this.tabPageAutoSkin.PerformLayout();
            this.tabPageExport.ResumeLayout(false);
            this.tabPageExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageAutoMorphs;
        private System.Windows.Forms.TabPage tabPageFixNormals;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialogSMD;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSMD;
        private System.Windows.Forms.Button btnGenerateMorphMesh;
        private System.Windows.Forms.Button btnRefMorphMeshBrowse;
        private System.Windows.Forms.Button btnRefBaseMeshBrowse;
        private System.Windows.Forms.Button btnTargetBaseMeshBrowse;
        private System.Windows.Forms.TextBox textBoxRefMorphMesh;
        private System.Windows.Forms.TextBox textBoxRefBaseMesh;
        private System.Windows.Forms.TextBox textBoxTargetBaseMesh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownInterpolationDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownNormalDistance;
        private System.Windows.Forms.Button btnFixNormals;
        private System.Windows.Forms.Button btnBrowseNormalRefMesh;
        private System.Windows.Forms.Button btnBrowseNormalTargetMesh;
        private System.Windows.Forms.TextBox textBoxNormalRefMesh;
        private System.Windows.Forms.TextBox textBoxNormalTargetMesh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxTestNormalFacing;
        private System.Windows.Forms.Label labelNormalFacing;
        private System.Windows.Forms.NumericUpDown numericUpDownNormalFacing;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxInfluenceDistance;
        private System.Windows.Forms.TabPage tabPageAutoSkin;
        private System.Windows.Forms.Button btnAutoSkin;
        private System.Windows.Forms.Button btnSkinRefMeshBrowse;
        private System.Windows.Forms.Button btnSkinTargetMeshBrowse;
        private System.Windows.Forms.TextBox textBoxSkinRefMesh;
        private System.Windows.Forms.TextBox textBoxSkinTargetMesh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPageExport;
        private System.Windows.Forms.Button btnReExport;
        private System.Windows.Forms.Button btnBrowseReExportMesh;
        private System.Windows.Forms.TextBox textBoxReExportMesh;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}