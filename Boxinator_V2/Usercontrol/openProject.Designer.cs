using System.ComponentModel;

namespace Boxinator_V2.Usercontrol {
    partial class openProject {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_folderpath = new System.Windows.Forms.TextBox();
            this.btn_select_folder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openProjectLabel = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(17, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 44);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tb_folderpath);
            this.panel2.Controls.Add(this.btn_select_folder);
            this.panel2.Location = new System.Drawing.Point(17, 73);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(502, 124);
            this.panel2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Boxinator project file";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(8, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 22);
            this.textBox1.TabIndex = 24;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(399, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 22);
            this.button1.TabIndex = 23;
            this.button1.Text = "Select folder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Folder of images";
            // 
            // tb_folderpath
            // 
            this.tb_folderpath.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_folderpath.BackColor = System.Drawing.Color.White;
            this.tb_folderpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_folderpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tb_folderpath.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tb_folderpath.Location = new System.Drawing.Point(8, 94);
            this.tb_folderpath.Name = "tb_folderpath";
            this.tb_folderpath.Size = new System.Drawing.Size(385, 22);
            this.tb_folderpath.TabIndex = 21;
            this.tb_folderpath.TextChanged += new System.EventHandler(this.tb_folderpath_TextChanged);
            // 
            // btn_select_folder
            // 
            this.btn_select_folder.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select_folder.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.btn_select_folder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_select_folder.FlatAppearance.BorderSize = 0;
            this.btn_select_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_select_folder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_select_folder.Location = new System.Drawing.Point(399, 94);
            this.btn_select_folder.Name = "btn_select_folder";
            this.btn_select_folder.Size = new System.Drawing.Size(95, 22);
            this.btn_select_folder.TabIndex = 20;
            this.btn_select_folder.Text = "Select folder";
            this.btn_select_folder.UseVisualStyleBackColor = false;
            this.btn_select_folder.Click += new System.EventHandler(this.btn_select_folder_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (7)))), ((int) (((byte) (14)))), ((int) (((byte) (21)))));
            this.panel1.Controls.Add(this.openProjectLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 57);
            this.panel1.TabIndex = 15;
            // 
            // openProjectLabel
            // 
            this.openProjectLabel.AutoSize = true;
            this.openProjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.openProjectLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.openProjectLabel.Location = new System.Drawing.Point(17, 19);
            this.openProjectLabel.Name = "openProjectLabel";
            this.openProjectLabel.Size = new System.Drawing.Size(137, 18);
            this.openProjectLabel.TabIndex = 0;
            this.openProjectLabel.Text = "Opening project..";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnOpen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpen.Location = new System.Drawing.Point(385, 203);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(134, 44);
            this.btnOpen.TabIndex = 18;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (7)))), ((int) (((byte) (14)))), ((int) (((byte) (21)))));
            this.ClientSize = new System.Drawing.Size(542, 259);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "openProject";
            this.Text = "saveProjectt";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_folderpath;
        private System.Windows.Forms.Button btn_select_folder;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label openProjectLabel;

        #endregion
    }
}