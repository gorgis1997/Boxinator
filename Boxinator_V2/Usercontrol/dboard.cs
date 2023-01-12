using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boxinator_V2.Usercontrol
{
    public partial class dboard : UserControl
    {
        public dboard()
        {
            InitializeComponent();
        }
        
        private Project project;
        public void dboard_Load(string path, string projectName, bool modeVideo) {
            if (modeVideo) {
                var converterDialog = new ConverterDialogForm(path);
                var result = converterDialog.ShowDialog();
                if (result == DialogResult.Cancel) {
                    // Do something
                    return;
                }
                path = converterDialog.Output();
                converterDialog.Close();
            }
            project = new Project(projectName, path);
            project.InitializeImages();
            pictureBox1.Size = panel2.Size;
            pictureBox1.Location = new Point(0, 0);
            trackBar1.Maximum = project.GetImageCount();
            trackBar1.TickFrequency = trackBar1.Maximum / 10;
            frameLabel.Text = "/ " + trackBar1.Maximum.ToString();
            SetImage(0);
        }

        private void SetImage(int index) {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = project.GetImage(index);
        }
        


        private void WindowResized(object sender, EventArgs e) {
            pictureBox1.Size = panel2.Size;
            pictureBox1.Location = new Point(0, 0);
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            frameTextBox.Text = trackBar1.Value.ToString();
            SetImage(trackBar1.Value);
        }

        private void ManualFrameChange(object sender, EventArgs e) {
            int value = 0;
            if (int.TryParse(frameTextBox.Text, out value)) {
                if (value >= 0 && value <= trackBar1.Maximum) {
                    trackBar1.Value = value;
                    SetImage(value);
                }
            }
        }
    }
}
