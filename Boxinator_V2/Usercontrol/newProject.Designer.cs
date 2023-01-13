namespace Boxinator_V2.Usercontrol
{
    partial class newProject
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tb_projectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_select_video = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_videopath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_folderpath = new System.Windows.Forms.TextBox();
            this.btn_select_folder = new System.Windows.Forms.Button();
            this.rb_video = new System.Windows.Forms.RadioButton();
            this.rb_images = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (7)))), ((int) (((byte) (14)))), ((int) (((byte) (21)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 57);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create new project";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Open file";
            // 
            // tb_projectName
            // 
            this.tb_projectName.AcceptsReturn = true;
            this.tb_projectName.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_projectName.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.tb_projectName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tb_projectName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tb_projectName.Location = new System.Drawing.Point(30, 105);
            this.tb_projectName.Name = "tb_projectName";
            this.tb_projectName.Size = new System.Drawing.Size(524, 22);
            this.tb_projectName.TabIndex = 8;
            this.tb_projectName.TextChanged += new System.EventHandler(this.ProjectName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(30, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Project name";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {"Traffic_V2", "Other_v1", "Etc"});
            this.comboBox1.Location = new System.Drawing.Point(31, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(420, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.TextChanged += new System.EventHandler(this.tb_categorypath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(31, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Category";
            // 
            // btn_select_video
            // 
            this.btn_select_video.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select_video.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.btn_select_video.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_select_video.FlatAppearance.BorderSize = 0;
            this.btn_select_video.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select_video.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_select_video.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_select_video.Location = new System.Drawing.Point(456, 263);
            this.btn_select_video.Name = "btn_select_video";
            this.btn_select_video.Size = new System.Drawing.Size(95, 30);
            this.btn_select_video.TabIndex = 12;
            this.btn_select_video.Text = "Select File";
            this.btn_select_video.UseVisualStyleBackColor = false;
            this.btn_select_video.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(32, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Videofile";
            // 
            // tb_videopath
            // 
            this.tb_videopath.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_videopath.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.tb_videopath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_videopath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tb_videopath.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tb_videopath.Location = new System.Drawing.Point(30, 263);
            this.tb_videopath.Name = "tb_videopath";
            this.tb_videopath.Size = new System.Drawing.Size(419, 22);
            this.tb_videopath.TabIndex = 13;
            this.tb_videopath.TextChanged += new System.EventHandler(this.tb_videopath_TextChanged);
            // 
            // button2 - Category
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(457, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 24);
            this.button2.TabIndex = 15;
            this.button2.Text = "Select File";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(30, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Folder of images";
            // 
            // tb_folderpath
            // 
            this.tb_folderpath.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_folderpath.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (12)))), ((int) (((byte) (22)))), ((int) (((byte) (31)))));
            this.tb_folderpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_folderpath.Enabled = false;
            this.tb_folderpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tb_folderpath.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tb_folderpath.Location = new System.Drawing.Point(29, 328);
            this.tb_folderpath.Name = "tb_folderpath";
            this.tb_folderpath.Size = new System.Drawing.Size(419, 22);
            this.tb_folderpath.TabIndex = 18;
            this.tb_folderpath.TextChanged += new System.EventHandler(this.tb_folderpath_TextChanged);
            // 
            // btn_select_folder
            // 
            this.btn_select_folder.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select_folder.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))), ((int) (((byte) (92)))), ((int) (((byte) (255)))));
            this.btn_select_folder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_select_folder.Enabled = false;
            this.btn_select_folder.FlatAppearance.BorderSize = 0;
            this.btn_select_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_select_folder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_select_folder.Location = new System.Drawing.Point(455, 328);
            this.btn_select_folder.Name = "btn_select_folder";
            this.btn_select_folder.Size = new System.Drawing.Size(95, 30);
            this.btn_select_folder.TabIndex = 17;
            this.btn_select_folder.Text = "Select folder";
            this.btn_select_folder.UseVisualStyleBackColor = false;
            this.btn_select_folder.Click += new System.EventHandler(this.btn_select_folder_Click);
            // 
            // rb_video
            // 
            this.rb_video.Checked = true;
            this.rb_video.Location = new System.Drawing.Point(29, 204);
            this.rb_video.Name = "rb_video";
            this.rb_video.Size = new System.Drawing.Size(104, 24);
            this.rb_video.TabIndex = 20;
            this.rb_video.TabStop = true;
            this.rb_video.Text = "Video mode";
            this.rb_video.UseVisualStyleBackColor = true;
            // 
            // rb_images
            // 
            this.rb_images.Location = new System.Drawing.Point(139, 204);
            this.rb_images.Name = "rb_images";
            this.rb_images.Size = new System.Drawing.Size(104, 24);
            this.rb_images.TabIndex = 21;
            this.rb_images.Text = "Image mode";
            this.rb_images.UseVisualStyleBackColor = true;
            // 
            // newProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (18)))), ((int) (((byte) (33)))), ((int) (((byte) (49)))));
            this.Controls.Add(this.rb_images);
            this.Controls.Add(this.rb_video);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_folderpath);
            this.Controls.Add(this.btn_select_folder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_videopath);
            this.Controls.Add(this.btn_select_video);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_projectName);
            this.Controls.Add(this.panel1);
            this.Name = "newProject";
            this.Size = new System.Drawing.Size(587, 474);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RadioButton rb_video;
        private System.Windows.Forms.RadioButton rb_images;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_folderpath;
        private System.Windows.Forms.Button btn_select_folder;

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tb_projectName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox1; // category url text
        private System.Windows.Forms.Button button2; // category button
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_select_video;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_videopath;
    }
}
