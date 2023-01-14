using Boxinator_V2.Usercontrol;
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

namespace Boxinator_V2
{
    public partial class FormMenu : Form {
        private readonly home _home = new home();
        private readonly dboard _dashboard = new dboard();
        private readonly newProject _newProject = new newProject();
        private readonly openProject _openProject = new openProject();
        
        private Button _submitButton;

        public FormMenu()
        {
            InitializeComponent();
            CreateSubmitButton();
            _home.Dock = DockStyle.Fill;
            _dashboard.Dock = DockStyle.Fill;
            _newProject.Dock = DockStyle.Fill;
            _openProject.Dock = DockStyle.Fill;
            addUserControl(_home);
            
            this.KeyPreview = true;
        }

        private void CreateSubmitButton() {
            _submitButton = new Button();
            _submitButton.Text = Resources.Submit;
            _submitButton.Size = new Size(150, 60);
            _submitButton.Location = new Point(10, Size.Height - 50 - _submitButton.Size.Height);
            _submitButton.Visible = false;
            _submitButton.Enabled = false;
            _submitButton.Click += SubmitNewProject;
        }

        private void SubmitNewProject(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(_newProject.ProjectName) || string.IsNullOrEmpty(_newProject.ProjectPath)) {
                MessageBox.Show("FILL OUT THE FIELDS YO", "Error mdfkr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Video mode
            else if (_newProject.ProjectModeIsVideo) {
                // Check path if video file exists
                if (!System.IO.File.Exists(_newProject.ProjectPath)) {
                    MessageBox.Show("Video file does not exist", "Error mdfkr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    _dashboard.dboard_Load(_newProject.ProjectPath, _newProject.ProjectName, _newProject.ProjectModeIsVideo);
                    addUserControl(_dashboard);
                }
            }
            else {
                // Check that the folder exists
                if (!System.IO.Directory.Exists(_newProject.ProjectPath)) {
                    MessageBox.Show("Folder does not exist", "Error mdfkr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    _dashboard.dboard_Load(_newProject.ProjectPath, _newProject.ProjectName, _newProject.ProjectModeIsVideo);
                    addUserControl(_dashboard);
                }
            }
        }
        
        private void addUserControl(UserControl userControl)
        {
            panelMainWindow.Controls.Clear();
            panelMainWindow.Controls.Add(userControl);
            if (userControl == _newProject) {
                panelMainWindow.Controls.Add(_submitButton);
                _submitButton.Visible = true;
                _submitButton.Enabled = true;
                _submitButton.BringToFront();
            }
            else {
                _submitButton.Visible = false;
                _submitButton.Enabled = false;
            }
        }

        private void highlightButton(Button button)
        {
            Button[] buttons = { dashboardButton, newButton, openButton, saveButton, categoryButton, docsButton };
            foreach (Button b in buttons) {
                b.BackColor = b == button ? Color.FromArgb(127, 92, 255) : Color.FromArgb(7, 14, 21);
            }
        }
        

        private void Logotype_Click(object sender, EventArgs e)
        {
            highlightButton(null);
            addUserControl(_home);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            highlightButton(openButton);
            addUserControl(_openProject);
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            highlightButton(dashboardButton);
            addUserControl(_dashboard);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            highlightButton(newButton);
            addUserControl(_newProject);
        }

        private void FormKeyDown(object sender, KeyEventArgs e) {
            // If key is delete
            if (e.KeyCode == Keys.Delete) {
                _dashboard.DeleteSelected();
            }
        }
    }
}
