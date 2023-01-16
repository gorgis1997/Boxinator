using System;
using System.Windows.Forms;

namespace Boxinator_V2.Usercontrol {
    public partial class saveProject : Form {
        public saveProject() {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }


        // BOXINATOR FORMAT
        private void btnBoxinator_Click(object sender, EventArgs e) {
            
            DialogResult = DialogResult.OK;
        }
    }
}