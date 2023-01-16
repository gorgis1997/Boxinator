using Boxinator_V2.Usercontrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boxinator_V2.Properties;
using Newtonsoft.Json;

namespace Boxinator_V2
{
    public partial class FormMenu : Form {
        private readonly home _home = new home();
        private readonly dboard _dashboard = new dboard();
        private readonly newProject _newProject = new newProject();
        private readonly openProject _openProject = new openProject();
        private readonly categoryPage _categoryPage = new categoryPage();

        private Button _submitButton;
        private Button _addCategoryButton;
        private Button _removeCategoryButton;

        public FormMenu()
        {
            //Category categ = new Category();
            //categ.Cat(); //TEMP
            InitializeComponent();
            CreateSubmitButton();
            CreateCatButtons();
            _home.Dock = DockStyle.Fill;
            _categoryPage.Dock = DockStyle.Fill;
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
            _submitButton.ForeColor = Color.White;
        }

        private void CreateCatButtons() {
            _addCategoryButton = new Button();
            _removeCategoryButton = new Button();
            
            _addCategoryButton.Text = @"Add";
            _removeCategoryButton.Text = @"Remove";
            
            _addCategoryButton.Size = new Size(150, 60);
            _removeCategoryButton.Size = new Size(150, 60);
            
            _addCategoryButton.Location = new Point(10, Size.Height - 50 - _addCategoryButton.Size.Height);
            _removeCategoryButton.Location = new Point(20 + _addCategoryButton.Size.Width, Size.Height - 50 - _removeCategoryButton.Size.Height);
            
            _addCategoryButton.Visible = false;
            _removeCategoryButton.Visible = false;
            
            _addCategoryButton.Enabled = false;
            _removeCategoryButton.Enabled = false;
            
            _addCategoryButton.Click += AddCategory;
            _removeCategoryButton.Click += RemoveCategory;
            
        }
        
        private void AddCategory(object sender, EventArgs e) {
            var cat = _categoryPage.AddCategory();
            _dashboard.AddCategory(cat);
        }
        
        private void RemoveCategory(object sender, EventArgs e) {
            var cat = _categoryPage.RemoveCategory();
            _dashboard.RemoveCategory(cat);
        }

        private void SubmitNewProject(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(_newProject.ProjectName) || string.IsNullOrEmpty(_newProject.ProjectPath)) {
                MessageBox.Show("Fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!System.IO.File.Exists(_newProject.ProjectCat))
            {
                MessageBox.Show("You have to submit a valid category file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Video mode
            else if (_newProject.ProjectModeIsVideo) {
                // Check path if video file exists
                if (!System.IO.File.Exists(_newProject.ProjectPath)) {
                    MessageBox.Show("Video file does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    Category category = new Category(_newProject.ProjectCat);
                    _dashboard.dboard_Load(_newProject.ProjectCat, _newProject.ProjectPath, _newProject.ProjectName, _newProject.ProjectModeIsVideo);
                    _dashboard.loadCategories(category);
                    _categoryPage.loadTags(category);
                    addUserControl(_dashboard);
                    highlightButton(dashboardButton);
                }
            }
            else {
                // Check that the folder exists
                if (!System.IO.Directory.Exists(_newProject.ProjectPath)) {
                    MessageBox.Show("Folder does not exist", "Error mdfkr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Category category = new Category(_newProject.ProjectCat);
                    _dashboard.dboard_Load(_newProject.ProjectCat, _newProject.ProjectPath, _newProject.ProjectName, _newProject.ProjectModeIsVideo);
                    _dashboard.loadCategories(category);
                    _categoryPage.loadTags(category);
                    addUserControl(_dashboard);
                    highlightButton(dashboardButton);
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

            if (userControl == _categoryPage) {
                panelMainWindow.Controls.Add(_addCategoryButton);
                panelMainWindow.Controls.Add(_removeCategoryButton);
                _addCategoryButton.Visible = true;
                _removeCategoryButton.Visible = true;
                _addCategoryButton.Enabled = true;
                _removeCategoryButton.Enabled = true;
                _addCategoryButton.BringToFront();
                _removeCategoryButton.BringToFront();
            }
            else {
                _addCategoryButton.Visible = false;
                _removeCategoryButton.Visible = false;
                _addCategoryButton.Enabled = false;
                _removeCategoryButton.Enabled = false;
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
            var openDia = new openProject();
            if (openDia.ShowDialog() == DialogResult.OK) {
                string imagePath = openDia.imagePath;
                string boxPath = openDia.boxinatorPath;
                
                _dashboard.LoadProjectBoxinator(boxPath, imagePath);
            }
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

        private void categoryButton_Click(object sender, EventArgs e)
        {
            highlightButton(categoryButton);
            addUserControl(_categoryPage);
        }

        private void saveButton_Click(object sender, EventArgs e) {
            // Pop up a save dialog
            var saveDia = new saveProject();
            var result = saveDia.ShowDialog();
            if (result == DialogResult.Cancel) {
                return;
            }
            else if (result == DialogResult.OK) {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Boxinator Project|*.boxinator";
                saveFileDialog1.Title = "Save a Boxinator Project";
                saveFileDialog1.ShowDialog();
            
                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "") {
                    var data = _dashboard.SaveProjectBoxinator();
                    //string json = JsonConvert.SerializeObject(data);
                    using (StreamWriter save = new StreamWriter(saveFileDialog1.FileName, false))
                    {
                        save.Write(data);
                    }
                }
            }
            highlightButton(dashboardButton);
            addUserControl(_dashboard);
        }
    }
}
