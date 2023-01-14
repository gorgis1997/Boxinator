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
            Logger.LogDebug("Dashboard loaded");
            Logger.LogDebug("picturebox width: " + pictureBox1.Width.ToString() + "x" + pictureBox1.Height.ToString());
            Logger.LogDebug("picturebox location: " + pictureBox1.Location.X.ToString() + "x" + pictureBox1.Location.Y.ToString());
            pictureBox1.Image = (Bitmap) Properties.Resources.ResourceManager.GetObject("BOXINATOR_v3");
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
        private Size _originalSize;

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            float zoom = Math.Min((float)pictureBox1.Width / _originalSize.Width, (float)pictureBox1.Height / _originalSize.Height);
            pictureBox1.ClientSize = new Size((int)(_originalSize.Width * zoom), (int)(_originalSize.Height * zoom));
            pictureBox1.Location = new Point((panel2.Width - pictureBox1.Width) / 2, (panel2.Height - pictureBox1.Height) / 2);
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
        private PercentageRectangle _selectedBox = new PercentageRectangle(0, 0, 0, 0);
        private PercentageRectangle _highlightedBox = new PercentageRectangle(0, 0, 0, 0);
        private Point startPoint;
        private bool _isMouseDown = false;

        private void PicturePaint(object sender, PaintEventArgs e) {
            if (_boxes == null) return;
            
            #if DEBUG
            Logger.Log("Drawing boxes: " + _boxes.Count.ToString() + "\n" + "Current box: " + _selectedBox.ToString());
            foreach (var box in _boxes) {
                Logger.Log(box.ToString());
            }
            #endif
            
            // Draw all boxes in list
            foreach (var box in _boxes)
            {
                var rectangle = box.GetRectangle(pictureBox1.Size);
                e.Graphics.DrawRectangle(Pens.Red, rectangle);
            }

            // Draw selected box
            e.Graphics.DrawRectangle(Pens.Green, _selectedBox.GetRectangle(pictureBox1.Size));
            
            // Fill highlighted box
            if (_highlightedBox != null) {
                using (var brush = new SolidBrush(Color.FromArgb(50, Color.Red))) {
                    e.Graphics.FillRectangle(brush, _highlightedBox.GetRectangle(pictureBox1.Size));
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            Logger.LogDebug("pictureBox1_MouseDown event triggered");
            if (e.Button != MouseButtons.Left) return;
            if (cbSelectionMode.Checked) {
                _selectedBox = _boxes.FirstOrDefault(box => box.GetRectangle(pictureBox1.Size).Contains(e.Location));
            }
            else {
                startPoint = e.Location;
                _selectedBox = new PercentageRectangle((float)e.X / pictureBox1.Width, (float)e.Y / pictureBox1.Height, 0, 0);
                _isMouseDown = true;
                pictureBox1.Invalidate();
            }

            Logger.LogDebug("Mouse down at " + e.Location.ToString());
            Logger.LogDebug("Current box: " + _selectedBox.ToString());
            Logger.LogDebug("Started dragging");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            Logger.LogDebug("pictureBox1_MouseUp event triggered");
            if (_isMouseDown) {
                _selectedBox.Width = (float)(e.X - startPoint.X) / pictureBox1.Width;
                _selectedBox.Height = (float)(e.Y - startPoint.Y) / pictureBox1.Height;
                if (_selectedBox.Width < 0) {
                    _selectedBox.Width = -_selectedBox.Width;
                    _selectedBox.X = (float)e.X / pictureBox1.Width;
                }

                if (_selectedBox.Height < 0) {
                    _selectedBox.Height = -_selectedBox.Height;
                    _selectedBox.Y = (float)e.Y / pictureBox1.Height;
                }
                Logger.LogDebug("Current box before adding to list: " + _selectedBox.ToString());
                _boxes.Add(_selectedBox);
                _project.PermeateNewBox(trackBar1.Value, _selectedBox);
                Logger.Log("Added box " + _selectedBox.ToString() + " to list, total boxes: " + _boxes.Count);
            }
            _isMouseDown = false;
            Logger.LogDebug("Boxes: " + _boxes.Count.ToString());
            _selectedBox = new PercentageRectangle(0, 0, 0, 0);
            Logger.LogDebug("pictureBox1_MouseUp event finished execution");
        }

    

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (_boxes == null) return;
            Logger.LogDebug("pictureBox1_MouseMove event triggered");
            if (cbSelectionMode.Checked) {
                // Check if the mouse is over any of the boxes
                _highlightedBox = _boxes.FirstOrDefault(box => box.GetRectangle(pictureBox1.Size).Contains(e.Location));
                pictureBox1.Invalidate();
            }
            else {
                if (!_isMouseDown) return;
                _selectedBox.Width = (float)(e.X - startPoint.X) / pictureBox1.Width;
                _selectedBox.Height = (float)(e.Y - startPoint.Y) / pictureBox1.Height;
                if (_selectedBox.Width < 0) {
                    _selectedBox.Width = -_selectedBox.Width;
                    _selectedBox.X = (float)e.X / pictureBox1.Width;
                }
                if (_selectedBox.Height < 0) {
                    _selectedBox.Height = -_selectedBox.Height;
                    _selectedBox.Y = (float)e.Y / pictureBox1.Height;
                }
                Logger.LogDebug("Current box: " + _selectedBox.ToString());
                pictureBox1.Invalidate();
                Logger.LogDebug("pictureBox1 invalidated");
            }

            Logger.LogDebug("Mouse move at " + e.Location.ToString());
            Logger.LogDebug("pictureBox1_MouseMove event finished execution");
        }
    }
}
