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
        }

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

        private void ProjectName_TextChanged(object sender, EventArgs e) { }

        private void changeInputMode() {
            // Enable video input if video radio button is checked
            // Enable folder input if image radio button is checked
            if (rb_video.Checked) {
                tb_videopath.Enabled = true;
                btn_select_video.Enabled = true;
                tb_folderpath.Enabled = false;
                btn_select_folder.Enabled = false;
            }
            else {
                tb_videopath.Enabled = false;
                btn_select_video.Enabled = false;
                tb_folderpath.Enabled = true;
                btn_select_folder.Enabled = true;
            }
        }

        private void rb_video_CheckedChanged(object sender, EventArgs e) {
            changeInputMode();
        }

        private void rb_images_CheckedChanged(object sender, EventArgs e) {
            changeInputMode();
        }

        private void btn_select_folder_Click(object sender, EventArgs e) {
            // Open folder browser dialog
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                tb_folderpath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_submit_new_project_Click(object sender, EventArgs e) {
            // Check if all fields are filled
            if (tb_projectName.Text == "" && (tb_videopath.Text == "" || tb_folderpath.Text == "")) {
                MessageBox.Show(Resources.Please_fill_in_all_fields);
            }
            else {
                // Check if video or image input is selected
                if (rb_video.Checked) {
                    // Check if video file exists
                    if (System.IO.File.Exists(tb_videopath.Text)) {
                        // TODO: Create new project
                    }
                    else {
                        MessageBox.Show(Resources.Video_file_does_not_exist);
                    }
                }
                else {
                    // Check if folder exists
                    if (System.IO.Directory.Exists(tb_folderpath.Text)) {
                        // TODO: Create new project
                    }
                    else {
                        MessageBox.Show(Resources.Folder_does_not_exist);
                    }
                }
            }
        }
    }
}
