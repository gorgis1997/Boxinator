using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.IO;

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
            
            //pictureBox1.Paint -= PicturePaint;
            pictureBox1.MouseDown -= pictureBox1_MouseDown;
            pictureBox1.MouseMove -= pictureBox1_MouseMove;
            pictureBox1.MouseUp -= pictureBox1_MouseUp;
        }

        private Project _project;
        // Create a new Timer object
        private Timer _timer;
        List<int> _keyframes = new List<int>();
        
        public void dboard_Load(string catPath, string path, string projectName, bool modeVideo) {
            Logger.Log("CATPATH: "+ catPath + "\n" + "Dashboard loading " + "\n" + "Path: " + path + "\n" + "Project Name: " + projectName + "\n" + "Mode: " + (modeVideo? "Video" : "Image"));
            if (modeVideo) {
                var converterDialog = new ConverterDialogForm(path);
                var result = converterDialog.ShowDialog();
                if (result == DialogResult.Cancel) {
                    // Do something
                    return;
                }
                path = converterDialog.Output();
            }
            label1.Text = "Dashboard - " + projectName;
            //comboBox1.Items.AddRange();
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

            _timer = new Timer();
            _timer.Interval = 33;
            _timer.Tick += TimerEventProcessor;
            _keyframes = new List<int>();
            EnableControls();
        }

        private void EnableControls() {
            btnPlayerLeft.Enabled = true;
            btnPlayerRight.Enabled = true;
            btnPlayerPlay.Enabled = true;
            frameTextBox.Enabled = true;
            trackBar1.Enabled = true;
            cbKeyframe.Enabled = true;
            cbSelectionMode.Enabled = true;
            btnPreviousKeyframe.Enabled = true;
            btnNextKeyframe.Enabled = true;
            //pictureBox1.Paint += PicturePaint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
        }

        private void DisableControls() {
            //pictureBox1.Paint -= PicturePaint;
            pictureBox1.MouseDown -= pictureBox1_MouseDown;
            pictureBox1.MouseMove -= pictureBox1_MouseMove;
            pictureBox1.MouseUp -= pictureBox1_MouseUp;
            cbKeyframe.Enabled = false;
            cbSelectionMode.Enabled = false;
            btnPreviousKeyframe.Enabled = false;
            btnNextKeyframe.Enabled = false;
            frameTextBox.Enabled = false;
        }
        private Size _originalSize;

        
        public void AddCategory(string name) {
            comboBox1.Items.Add(name);
        }
        
        public void RemoveCategory(string name) {
            comboBox1.Items.Remove(name);
        }
        
        public void loadCategories(Category category)
        {
            var list = category.GetCategories();
            comboBox1.Items.AddRange(list.ToArray());
            // If there are cats, select the first one
            if (list.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            categoryLabel.Text = category.CatName();
        }
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
            pictureBox1.Invalidate();
            _selectedBox = PercentageRectangle.Empty;
            _highlightedBox = PercentageRectangle.Empty;
            // Set keyframe checkbox if keyframe
            cbKeyframe.Checked = _keyframes.Contains(index);
            trackBar1.Value = index;
            frameTextBox.Text = (index).ToString();
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
            /*
            int value = 0;
            if (int.TryParse(frameTextBox.Text, out value)) {
                if (value >= 0 && value <= trackBar1.Maximum) {
                    trackBar1.Value = value;
                    SetImage(value);
                }
            }
            */
        }
        
        private List<PercentageRectangle> _boxes = new List<PercentageRectangle>();
        private PercentageRectangle _selectedBox = PercentageRectangle.Empty;
        private PercentageRectangle _highlightedBox = PercentageRectangle.Empty;
        private Point _startPoint;
        private bool _leftMouseButtonDown;
        private int _nextId;
        private bool _movingBox;

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
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(rectangle.X, rectangle.Y, 50, 20));
                e.Graphics.DrawString(box.CategoryTag + "_" +box.Id.ToString(), new Font("Arial", 10), Brushes.Red, new PointF(rectangle.X, rectangle.Y));

            }

            // Draw selected box
            e.Graphics.DrawRectangle(Pens.Green, _selectedBox.GetRectangle(pictureBox1.Size));
            
            if(cbSelectionMode.Checked) {
                using (var brush = new SolidBrush(Color.FromArgb(50, Color.Red))) {
                    e.Graphics.FillRectangle(brush, _highlightedBox.GetRectangle(pictureBox1.Size));
                    e.Graphics.FillRectangle(brush, _selectedBox.GetRectangle(pictureBox1.Size));
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            Logger.LogDebug("pictureBox1_MouseDown event triggered");
            if (e.Button != MouseButtons.Left) return;
            
            _leftMouseButtonDown = true;
            _startPoint = e.Location;
            if (cbSelectionMode.Checked) {
                if (_highlightedBox != PercentageRectangle.Empty)
                    _selectedBox = _highlightedBox;
            }
            else {
                _selectedBox = new PercentageRectangle((float)e.X / pictureBox1.Width, (float)e.Y / pictureBox1.Height, 0, 0, _nextId++, comboBox1.SelectedItem.ToString());
            }
            
            pictureBox1.Invalidate();
            Logger.LogDebug("Mouse down at " + e.Location.ToString());
            Logger.LogDebug("Current box: " + _selectedBox.ToString());
            Logger.LogDebug("Started dragging");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            Logger.LogDebug("pictureBox1_MouseUp event triggered");
            if (e.Button != MouseButtons.Left) return;

            if (cbSelectionMode.Checked) {
                UnlockAll();
                if (_selectedBox != PercentageRectangle.Empty && _movingBox) {
                    _movingBox = false;
                    _project.PermeateMovedBox(trackBar1.Value, _selectedBox.Id, _selectedBox.X, _selectedBox.Y, _selectedBox.Width, _selectedBox.Height);
                    pictureBox1.Invalidate();
                }
            }
            else {
                if (_leftMouseButtonDown) {
                    _selectedBox.Width = (float)(e.X - _startPoint.X) / pictureBox1.Width;
                    _selectedBox.Height = (float)(e.Y - _startPoint.Y) / pictureBox1.Height;
                    if (_selectedBox.Width < 0) {
                        _selectedBox.Width = -_selectedBox.Width;
                        _selectedBox.X = (float)e.X / pictureBox1.Width;
                    }

                    if (_selectedBox.Height < 0) {
                        _selectedBox.Height = -_selectedBox.Height;
                        _selectedBox.Y = (float)e.Y / pictureBox1.Height;
                    }
                    Logger.LogDebug("Current box before adding to list: " + _selectedBox.ToString());
                    
                    // If box has minimum size, add it to list
                    if (_selectedBox.Width > 0.01 && _selectedBox.Height > 0.01) {
                        _project.PermeateNewBox(trackBar1.Value, _selectedBox.Copy());
                        Logger.Log("Added box " + _selectedBox.ToString() + " to list, total boxes: " + _boxes.Count);
                    }
                    else {
                        Logger.LogDebug("Box too small, not added to list");
                    }
                }
                Logger.LogDebug("Boxes: " + _boxes.Count.ToString());
                _selectedBox = PercentageRectangle.Empty;
            }
            // If keyframe, run interpolation
            if (_keyframes.Contains(trackBar1.Value)) {
                Interpolate(trackBar1.Value);
            }
            _leftMouseButtonDown = false;
            Logger.LogDebug("pictureBox1_MouseUp event finished execution");
        }

    

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (_boxes == null) return;
            
            Logger.LogDebug("pictureBox1_MouseMove event triggered");
            if (cbSelectionMode.Checked) {
                HighlightBox(e.Location);
                ResizeBox(e);
            }
            else {
                if (!_leftMouseButtonDown) return;
                pictureBox1.Cursor = Cursors.Cross;
                _selectedBox.Width = (float)(e.X - _startPoint.X) / pictureBox1.Width;
                _selectedBox.Height = (float)(e.Y - _startPoint.Y) / pictureBox1.Height;
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

        private void HighlightBox(Point e) {
            _highlightedBox = PercentageRectangle.Empty;
            foreach (var box in _boxes) {
                if (!box.GetRectangle(pictureBox1.Size).Contains(e)) continue;
                _highlightedBox = box;
                break;
            }
        }
        
        public void DeleteSelected() {
            Logger.LogDebug("Delete event triggered");
            Logger.LogDebug("Selected box: " + _selectedBox.ToString());
            Logger.LogDebug("Is dragging: " + _leftMouseButtonDown.ToString());
            if (_selectedBox == PercentageRectangle.Empty || _leftMouseButtonDown) return;

            //_boxes.RemoveAll(x => x.Id == _selectedBox.Id);
            Logger.LogDebug("Deleting box " + _selectedBox.ToString());
            _project.PermeateDeleteBox(trackBar1.Value, _selectedBox.Id);
            
            if (_selectedBox == _highlightedBox) _highlightedBox = PercentageRectangle.Empty;
            _selectedBox = PercentageRectangle.Empty;
            pictureBox1.Invalidate();
        }

        private bool _lockLeft = false;
        private bool _lockRight = false;
        private bool _lockTop = false;
        private bool _lockBottom = false;
        
        private void UnlockAll() {
            _lockLeft = false;
            _lockRight = false;
            _lockTop = false;
            _lockBottom = false;
        }
        const int resizeDist = 8;
        private void ResizeLeft(MouseEventArgs e, Rectangle rect) {
            if (_leftMouseButtonDown) {
                _lockLeft = true;
                _movingBox = true;
                if (Math.Abs(e.Y - rect.Top) > resizeDist && Math.Abs(e.Y - rect.Bottom) > resizeDist)
                {
                    var newX = (float)e.X / pictureBox1.Width;
                    _selectedBox.Width += _selectedBox.X - newX;
                    _selectedBox.X = newX;
                }
            }
        }
        private float _prevMouseX = 0;
        private float _threshold = 0.0001f;
        private void ResizeRight(MouseEventArgs e, Rectangle rect) {
            if (_leftMouseButtonDown) {
                _lockRight = true;
                _movingBox = true;
                if (Math.Abs(e.Y - rect.Top) > resizeDist && Math.Abs(e.Y - rect.Bottom) > resizeDist)
                {
                    var mouseX = (float)e.X / pictureBox1.Width;
                    if (Math.Abs(mouseX - _prevMouseX) > _threshold)
                    {
                        var newWidth = mouseX - _selectedBox.X;
                        _selectedBox.Width = newWidth;
                        _prevMouseX = mouseX;
                    }
                }
            }
        }

        private void ResizeTop(MouseEventArgs e, Rectangle rect) {
            if (_leftMouseButtonDown)
            {
                _lockTop = true;
                _movingBox = true;
                if (Math.Abs(e.X - rect.Left) > resizeDist && Math.Abs(e.X - rect.Right) > resizeDist)
                {
                    var newY = (float)e.Y / pictureBox1.Height;
                    _selectedBox.Height += _selectedBox.Y - newY;
                    _selectedBox.Y = newY;
                }
            }
        }

        private float _prevMouseY = 0;
        private void ResizeBottom(MouseEventArgs e, Rectangle rect) {
            if (_leftMouseButtonDown) {
                _lockBottom = true;
                _movingBox = true;
                if (Math.Abs(e.X - rect.Left) > resizeDist && Math.Abs(e.X - rect.Right) > resizeDist)
                {
                    var mouseY = (float)e.Y / pictureBox1.Height;
                    if (Math.Abs(mouseY - _prevMouseY) > _threshold)
                    {
                        var newHeight = mouseY - _selectedBox.Y;
                        _selectedBox.Height = newHeight;
                        _prevMouseY = mouseY;
                    }
                }
            }
        }
        private void ResizeBox(MouseEventArgs e) {
            var rect = _highlightedBox.GetRectangle(pictureBox1.Size);

            var cursor = Cursors.Default;

            if (Math.Abs(e.X - rect.X) <= resizeDist || _lockLeft)
            {
                cursor = Cursors.SizeWE;
                ResizeLeft(e, rect);
            }
            else if (Math.Abs(e.X - rect.Right) <= resizeDist || _lockRight)
            {
                cursor = Cursors.SizeWE;
                ResizeRight(e, rect);
            }
            else if (Math.Abs(e.Y - rect.Top) <= resizeDist || _lockTop)
            {
                cursor = Cursors.SizeNS;
                ResizeTop(e, rect);
            }
            else if (Math.Abs(e.Y - rect.Bottom) <= resizeDist || _lockBottom)
            {
                cursor = Cursors.SizeNS;
                ResizeBottom(e, rect);
            }
            else if (rect.Contains(e.Location))
            {
                cursor = Cursors.SizeAll;
                if (_leftMouseButtonDown)
                {
                    _movingBox = true;
                    var offsetX = e.X - _startPoint.X;
                    var offsetY = e.Y - _startPoint.Y;
                    _selectedBox.X += offsetX / (float)pictureBox1.Width;
                    _selectedBox.Y += offsetY / (float)pictureBox1.Height;
                    _startPoint = e.Location;
                }
            }
            pictureBox1.Cursor = cursor;
            pictureBox1.Invalidate();
        }
        
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
            SetImage(trackBar1.Value);
            trackBar1.Value += 1;
        }

        private bool _playing = false;
        private void Play(object sender, EventArgs e) {
            if (_playing) {
                _playing = false;
                _timer.Stop();
                btnPlayerPlay.Image = Properties.Resources.playButtonColor;
                EnableControls();
            }
            else {
                _playing = true;
                btnPlayerPlay.Image = Properties.Resources.stopButton;
                _timer.Start();
                DisableControls();
            }
        }


        private void cbKeyframe_CheckedChanged(object sender, EventArgs e) {
            // If the user has checked the keyframe checkbox, add the current frame to the keyframes list
            if (cbKeyframe.Checked) {
                _keyframes.Add(trackBar1.Value);
                _keyframes.Sort();
                Interpolate(trackBar1.Value);
            }
            else {
                // If the user has unchecked the keyframe checkbox, remove the current frame from the keyframes list
                _keyframes.Remove(trackBar1.Value);
            }
            
        }

        private void PerformInterpolation(int start, int end) {
            var boxesPrev = _project.GetBoxes(start);
            var boxesCurrent = _project.GetBoxes(end);
            var framesBetween = end - start - 1;
                
            foreach (var box in boxesPrev) {
                var boxCurrent = boxesCurrent.FirstOrDefault(b => b.Id == box.Id);
                if (boxCurrent == null) continue;
                var deltaX = (boxCurrent.X - box.X) / framesBetween;
                var deltaY = (boxCurrent.Y - box.Y) / framesBetween;
                var deltaWidth = (boxCurrent.Width - box.Width) / framesBetween;
                var deltaHeight = (boxCurrent.Height - box.Height) / framesBetween;
                for (var i = 1; i <= framesBetween; i++) {
                    var frame = start + i;
                    var interpolatedBox = new PercentageRectangle(box.X + deltaX * i, box.Y + deltaY * i, box.Width + deltaWidth * i, box.Height + deltaHeight * i, box.Id, box.CategoryTag);
                    _project.SetBoxAtFrame(frame, interpolatedBox);
                }
            }
        }
        private void Interpolate(int currentKeyframe) {
            if (_keyframes.Count <= 1) return;
    
            var indexKeyframe = _keyframes.IndexOf(currentKeyframe);
            if (indexKeyframe > 0) {
                var prevKeyframe = _keyframes[indexKeyframe - 1];
                PerformInterpolation(prevKeyframe, currentKeyframe);
            }
            if (indexKeyframe < _keyframes.Count - 1) {
                var nextKeyframe = _keyframes[indexKeyframe + 1];
                PerformInterpolation(currentKeyframe, nextKeyframe);
            }
        }

        private void btnPreviousKeyframe_Click(object sender, EventArgs e) {
            var prevKeyframe = _keyframes.Where(k => k < trackBar1.Value).OrderByDescending(k => k).FirstOrDefault();
            SetImage(prevKeyframe);
        }

        private void btnNextKeyframe_Click(object sender, EventArgs e) {
            var nextKeyframe = _keyframes.Where(k => k > trackBar1.Value).OrderBy(k => k).FirstOrDefault();
            if (nextKeyframe != 0) {
                SetImage(nextKeyframe);
            }
        }
    }
}
