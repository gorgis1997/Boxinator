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
        
        private Project _project;

        public void dboard_Load(string path, string projectName, bool modeVideo) {
            Logger.Log("Dashboard loading " + "\n" + "Path: " + path + "\n" + "Project Name: " + projectName + "\n" + "Mode: " + (modeVideo? "Video" : "Image"));
            if (modeVideo) {
                var converterDialog = new ConverterDialogForm(path);
                var result = converterDialog.ShowDialog();
                if (result == DialogResult.Cancel) {
                    // Do something
                    return;
                }
                path = converterDialog.Output();
            }
            _project = new Project(projectName, path);
            _project.InitializeImages();
            
            pictureBox1.Size = panel2.Size;
            pictureBox1.Location = new Point(0, 0);
            
            trackBar1.Maximum = _project.GetImageCount();
            trackBar1.TickFrequency = trackBar1.Maximum / 10;
            frameLabel.Text = "/ " + trackBar1.Maximum.ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            Logger.Log("Dashboard loaded");
            SetImage(0);
        }
        private float _zoom = 1f;
        private Size _originalSize;

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            float zoom = Math.Min((float)pictureBox1.Width / _originalSize.Width, (float)pictureBox1.Height / _originalSize.Height);
            pictureBox1.ClientSize = new Size((int)(_originalSize.Width * zoom), (int)(_originalSize.Height * zoom));
        }
        private void SetImage(int index) {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = _project.GetImage(index);
            _originalSize = pictureBox1.Image.Size;
            _boxes = _project.GetBoxes(index);
            Logger.Log("Image set to " + index.ToString());
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
        
        private List<PercentageRectangle> _boxes = new List<PercentageRectangle>();
        private PercentageRectangle currentBox = new PercentageRectangle(0, 0, 0, 0);
        private Point startPoint;
        private bool isDragging = false;

        private void PicturePaint(object sender, PaintEventArgs e) {
            if (_boxes == null) return;
            
            #if DEBUG
            Logger.Log("Drawing boxes: " + _boxes.Count.ToString() + "\n" + "Current box: " + currentBox.ToString());
            foreach (var box in _boxes) {
                Logger.Log(box.ToString());
            }
            #endif
            
            if (_boxes != null) {
                // Draw all boxes
                foreach (var box in _boxes) {
                    var rectangle = box.GetRectangle(pictureBox1.Size);
                    e.Graphics.DrawRectangle(Pens.Red, rectangle);
                }
            }
            e.Graphics.DrawRectangle(Pens.Green, currentBox.GetRectangle(pictureBox1.Size));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            startPoint = e.Location;
            currentBox = new PercentageRectangle((float)e.X / pictureBox1.Width, (float)e.Y / pictureBox1.Height, 0, 0);
            isDragging = true;
            pictureBox1.Invalidate();
            
            Logger.LogDebug("Mouse down at " + e.Location.ToString());
            Logger.LogDebug("Current box: " + currentBox.ToString());
            Logger.LogDebug("Started dragging");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            if (isDragging) {
                currentBox.Width = Math.Abs((float)e.X - startPoint.X) / pictureBox1.Width;
                currentBox.Height = Math.Abs((float)e.Y - startPoint.Y) / pictureBox1.Height;
                _boxes.Add(currentBox);
            }
            isDragging = false;
            currentBox = new PercentageRectangle(0, 0, 0, 0);
            Logger.LogDebug("Boxes: " + _boxes.Count.ToString());
            Logger.Log("Added box " + currentBox.ToString());
        }
    

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (!isDragging) return;
            currentBox.Width = Math.Abs((float)e.X - startPoint.X) / pictureBox1.Width;
            currentBox.Height = Math.Abs((float)e.Y - startPoint.Y) / pictureBox1.Height;
            pictureBox1.Invalidate();
            Logger.LogDebug("Mouse move at " + e.Location.ToString());
        }

        private void panel2_SizeChanged(object sender, EventArgs e) {
            float zoom = Math.Min((float)pictureBox1.Width / _originalSize.Width, (float)pictureBox1.Height / _originalSize.Height);
            pictureBox1.ClientSize = new Size((int)(_originalSize.Width * zoom), (int)(_originalSize.Height * zoom));
            pictureBox1.Location = new Point((panel2.Width - pictureBox1.Width) / 2, (panel2.Height - pictureBox1.Height) / 2);
        }
    }
}
