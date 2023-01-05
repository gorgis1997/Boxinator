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

namespace Boxinator_V2
{
    public partial class FormMenu : Form {
        private readonly home _home = new home();
        private readonly dboard _dashboard = new dboard();
        private readonly newProject _newProject = new newProject();
        private readonly openProject _openProject = new openProject();

        public FormMenu()
        {
            InitializeComponent();
            addUserControl(_home);
        }

        private void addUserControl(UserControl userControl)
        {
            panelMainWindow.Controls.Clear();
            panelMainWindow.Controls.Add(userControl);
            userControl.BringToFront();
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
    }
}
