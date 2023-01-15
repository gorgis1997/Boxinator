using System.ComponentModel;
using System.Windows.Forms;

namespace Boxinator_V2.Usercontrol
{
    partial class dboard
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dboard));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.frameLabel = new System.Windows.Forms.Label();
            this.frameTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNextKeyframe = new System.Windows.Forms.Button();
            this.btnPreviousKeyframe = new System.Windows.Forms.Button();
            this.cbKeyframe = new System.Windows.Forms.CheckBox();
            this.cbSelectionMode = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnPlayerLeft = new System.Windows.Forms.Button();
            this.btnPlayerRight = new System.Windows.Forms.Button();
            this.btnPlayerPlay = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(373, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(94, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.categoryLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.categoryLabel.Location = new System.Drawing.Point(473, 19);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Padding = new System.Windows.Forms.Padding(4);
            this.categoryLabel.Size = new System.Drawing.Size(63, 21);
            this.categoryLabel.TabIndex = 3;
            this.categoryLabel.Text = "Traffic_v2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (7)))), ((int) (((byte) (14)))), ((int) (((byte) (21)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.categoryLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 57);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard - no project loaded";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel2.Location = new System.Drawing.Point(20, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 402);
            this.panel2.TabIndex = 7;
            this.panel2.Resize += new System.EventHandler(this.WindowResized);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(207, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PicturePaint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.25197F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 481);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(856, 45);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.panel3.Controls.Add(this.frameLabel);
            this.panel3.Controls.Add(this.frameTextBox);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(114, 39);
            this.panel3.TabIndex = 0;
            // 
            // frameLabel
            // 
            this.frameLabel.AutoSize = true;
            this.frameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.frameLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.frameLabel.Location = new System.Drawing.Point(56, 11);
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(20, 15);
            this.frameLabel.TabIndex = 1;
            this.frameLabel.Text = "/ 0";
            // 
            // frameTextBox
            // 
            this.frameTextBox.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.frameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frameTextBox.Enabled = false;
            this.frameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.frameTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.frameTextBox.Location = new System.Drawing.Point(13, 9);
            this.frameTextBox.Name = "frameTextBox";
            this.frameTextBox.Size = new System.Drawing.Size(40, 21);
            this.frameTextBox.TabIndex = 0;
            this.frameTextBox.Text = "0";
            this.frameTextBox.TextChanged += new System.EventHandler(this.ManualFrameChange);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.panel4.Controls.Add(this.btnNextKeyframe);
            this.panel4.Controls.Add(this.btnPreviousKeyframe);
            this.panel4.Controls.Add(this.cbKeyframe);
            this.panel4.Controls.Add(this.cbSelectionMode);
            this.panel4.Location = new System.Drawing.Point(123, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 39);
            this.panel4.TabIndex = 1;
            // 
            // btnNextKeyframe
            // 
            this.btnNextKeyframe.Enabled = false;
            this.btnNextKeyframe.Location = new System.Drawing.Point(308, 5);
            this.btnNextKeyframe.Name = "btnNextKeyframe";
            this.btnNextKeyframe.Size = new System.Drawing.Size(94, 28);
            this.btnNextKeyframe.TabIndex = 3;
            this.btnNextKeyframe.Text = "Next Key";
            this.btnNextKeyframe.UseVisualStyleBackColor = true;
            // 
            // btnPreviousKeyframe
            // 
            this.btnPreviousKeyframe.Enabled = false;
            this.btnPreviousKeyframe.Location = new System.Drawing.Point(208, 5);
            this.btnPreviousKeyframe.Name = "btnPreviousKeyframe";
            this.btnPreviousKeyframe.Size = new System.Drawing.Size(94, 28);
            this.btnPreviousKeyframe.TabIndex = 2;
            this.btnPreviousKeyframe.Text = "Previous Key";
            this.btnPreviousKeyframe.UseVisualStyleBackColor = true;
            // 
            // cbKeyframe
            // 
            this.cbKeyframe.Enabled = false;
            this.cbKeyframe.Location = new System.Drawing.Point(120, 8);
            this.cbKeyframe.Name = "cbKeyframe";
            this.cbKeyframe.Size = new System.Drawing.Size(82, 24);
            this.cbKeyframe.TabIndex = 1;
            this.cbKeyframe.Text = "Keyframe";
            this.cbKeyframe.UseVisualStyleBackColor = true;
            this.cbKeyframe.CheckedChanged += new System.EventHandler(this.cbKeyframe_CheckedChanged);
            // 
            // cbSelectionMode
            // 
            this.cbSelectionMode.Enabled = false;
            this.cbSelectionMode.Location = new System.Drawing.Point(7, 8);
            this.cbSelectionMode.Name = "cbSelectionMode";
            this.cbSelectionMode.Size = new System.Drawing.Size(104, 24);
            this.cbSelectionMode.TabIndex = 0;
            this.cbSelectionMode.Text = "Selection Mode";
            this.cbSelectionMode.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.25197F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 532);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(856, 45);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.panel5.Controls.Add(this.btnPlayerLeft);
            this.panel5.Controls.Add(this.btnPlayerRight);
            this.panel5.Controls.Add(this.btnPlayerPlay);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(114, 39);
            this.panel5.TabIndex = 0;
            // 
            // btnPlayerLeft
            // 
            this.btnPlayerLeft.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.btnPlayerLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayerLeft.Enabled = false;
            this.btnPlayerLeft.FlatAppearance.BorderSize = 0;
            this.btnPlayerLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (18)))), ((int) (((byte) (33)))), ((int) (((byte) (49)))));
            this.btnPlayerLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerLeft.Image = ((System.Drawing.Image) (resources.GetObject("btnPlayerLeft.Image")));
            this.btnPlayerLeft.Location = new System.Drawing.Point(14, 3);
            this.btnPlayerLeft.Name = "btnPlayerLeft";
            this.btnPlayerLeft.Size = new System.Drawing.Size(25, 33);
            this.btnPlayerLeft.TabIndex = 2;
            this.btnPlayerLeft.UseVisualStyleBackColor = false;
            // 
            // btnPlayerRight
            // 
            this.btnPlayerRight.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.btnPlayerRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayerRight.Enabled = false;
            this.btnPlayerRight.FlatAppearance.BorderSize = 0;
            this.btnPlayerRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (18)))), ((int) (((byte) (33)))), ((int) (((byte) (49)))));
            this.btnPlayerRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerRight.Image = ((System.Drawing.Image) (resources.GetObject("btnPlayerRight.Image")));
            this.btnPlayerRight.Location = new System.Drawing.Point(74, 3);
            this.btnPlayerRight.Name = "btnPlayerRight";
            this.btnPlayerRight.Size = new System.Drawing.Size(25, 33);
            this.btnPlayerRight.TabIndex = 1;
            this.btnPlayerRight.UseVisualStyleBackColor = false;
            // 
            // btnPlayerPlay
            // 
            this.btnPlayerPlay.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.btnPlayerPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayerPlay.Enabled = false;
            this.btnPlayerPlay.FlatAppearance.BorderSize = 0;
            this.btnPlayerPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (18)))), ((int) (((byte) (33)))), ((int) (((byte) (49)))));
            this.btnPlayerPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerPlay.Image = ((System.Drawing.Image) (resources.GetObject("btnPlayerPlay.Image")));
            this.btnPlayerPlay.Location = new System.Drawing.Point(34, 3);
            this.btnPlayerPlay.Name = "btnPlayerPlay";
            this.btnPlayerPlay.Size = new System.Drawing.Size(46, 33);
            this.btnPlayerPlay.TabIndex = 0;
            this.btnPlayerPlay.UseVisualStyleBackColor = false;
            this.btnPlayerPlay.Click += new System.EventHandler(this.Play);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.panel6.Controls.Add(this.trackBar1);
            this.panel6.Location = new System.Drawing.Point(123, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(730, 39);
            this.panel6.TabIndex = 1;
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(730, 39);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // dboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (18)))), ((int) (((byte) (33)))), ((int) (((byte) (49)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "dboard";
            this.Size = new System.Drawing.Size(898, 584);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.trackBar1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox cbKeyframe;
        private System.Windows.Forms.Button btnPreviousKeyframe;
        private System.Windows.Forms.Button btnNextKeyframe;

        private System.Windows.Forms.CheckBox cbSelectionMode;

        #endregion

        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1; // Project name
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox frameTextBox;
        private System.Windows.Forms.Label frameLabel;
        private System.Windows.Forms.Button btnPlayerPlay;
        private System.Windows.Forms.Button btnPlayerLeft;
        private System.Windows.Forms.Button btnPlayerRight;
    }
}
