﻿using System;
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
        }

        private Project _project;
        // Create a new Timer object
        private Timer _timer;

            

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

            _timer = new Timer();
            _timer.Interval = 33;
            _timer.Tick += new EventHandler(TimerEventProcessor);
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
            pictureBox1.Invalidate();
            _selectedBox = PercentageRectangle.Empty;
            _highlightedBox = PercentageRectangle.Empty;
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
        private bool _leftMouseButtonDown = false;
        private int _nextId = 0;
        private bool _movingBox = false;

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
                _selectedBox = new PercentageRectangle((float)e.X / pictureBox1.Width, (float)e.Y / pictureBox1.Height, 0, 0, _nextId++);
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
                    
                    //_boxes.Add(_selectedBox.Copy());
                    _project.PermeateNewBox(trackBar1.Value, _selectedBox.Copy());
                    Logger.Log("Added box " + _selectedBox.ToString() + " to list, total boxes: " + _boxes.Count);
                }
                Logger.LogDebug("Boxes: " + _boxes.Count.ToString());
                _selectedBox = PercentageRectangle.Empty;
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
        const int resizeDist = 6;
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

        private void Play(object sender, EventArgs e) {
            _timer.Start();
        }
    }
}
