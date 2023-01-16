using System;
using System.Windows.Forms;

namespace Boxinator_V2.Usercontrol {
    public partial class openProject : Form {
        public openProject() {
            InitializeComponent();
        }
        
        public string imagePath { get; set; }
        public string boxinatorPath { get; set; }
        

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }


        // BOXINATOR FORMAT
        private void btnBoxinator_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e) {
            // Open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Project files (*.boxinator)|*.boxinator";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            
            // Show dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                boxinatorPath = openFileDialog.FileName;
                textBox1.Text = boxinatorPath;
            }
        }

        private void btn_select_folder_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                tb_folderpath.Text = folderBrowserDialog1.SelectedPath;
                imagePath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            // check if variables are filled in
            if (tb_folderpath.Text != "" && boxinatorPath != "") {
                imagePath = tb_folderpath.Text;
                DialogResult = DialogResult.OK;
            } else {
                MessageBox.Show("Please select a folder and a boxinator file");
            }
        }

        private void tb_folderpath_TextChanged(object sender, EventArgs e) {
            imagePath = tb_folderpath.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            boxinatorPath = textBox1.Text;
        }
    }
}