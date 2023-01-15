using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boxinator_V2.Properties;

namespace Boxinator_V2.Usercontrol {
    public partial class newProject : UserControl {
        public newProject() {
            InitializeComponent();
            _projectModeIsVideo = rb_video.Checked;
            _projectPath = "";
            _projectName = "";
            _projectCat = "";

            rb_video.CheckedChanged += ChangeInputMode;
            rb_images.CheckedChanged += ChangeInputMode;
        }

        private string _projectName;
        private string _projectPath;
        private string _projectCat;
        private bool _projectModeIsVideo;
        
        public string ProjectName => _projectName;
        public string ProjectPath => _projectPath;
        public string ProjectCat => _projectCat;
        public bool ProjectModeIsVideo => _projectModeIsVideo;
      
        
        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() {
                InitialDirectory = @"C:\",
                Title = "Chose video file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "mp4",
                Filter = "mp4 files (*.mp4)|*.mp4",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                tb_videopath.Text = openFileDialog1.FileName;
            }
        }
        
        private void button2_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() {
                InitialDirectory = @"C:\",
                Title = "Chose category file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                catTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void ProjectName_TextChanged(object sender, EventArgs e) {
            _projectName = tb_projectName.Text;
        }
        private void tb_videopath_TextChanged(object sender, EventArgs e) {
            _projectPath = tb_videopath.Text;
        }
        private void tb_categorypath_TextChanged(object sender, EventArgs e)
        {
            _projectCat = catTextBox.Text;
        }
        private void tb_folderpath_TextChanged(object sender, EventArgs e) {
            _projectPath = tb_folderpath.Text;
        }

        private void ChangeInputMode(object sender, EventArgs e) {
            // Enable video input if video radio button is checked
            // Enable folder input if image radio button is checked
            if (rb_video.Checked) {
                _projectModeIsVideo = true;
                tb_videopath.Enabled = true;
                btn_select_video.Enabled = true;
                tb_folderpath.Enabled = false;
                btn_select_folder.Enabled = false;
            }
            else {
                _projectModeIsVideo = false;
                tb_videopath.Enabled = false;
                btn_select_video.Enabled = false;
                tb_folderpath.Enabled = true;
                btn_select_folder.Enabled = true;
            }
        }
        
        private void btn_select_folder_Click(object sender, EventArgs e) {
            // Open folder browser dialog
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                tb_folderpath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
