using System;
using System.Threading;
using System.Windows.Forms;
using Boxinator_V2.Usercontrol;

namespace Boxinator_V2 {
    public partial class ConverterDialogForm : Form {
        public ConverterDialogForm(string path) {
            InitializeComponent();
            _path = path;
            if (CreateFolder()) {
                ConvertVideo();
            }
        }
        
        private readonly string _path;
        private string _output;

        private string _fileName;
        private string _fileExt;
        private string _fileDir;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        // Getter for path
        public string Output() {
            return _output;
        }

        private async void ConvertVideo() {
            VideoConverter converter = new VideoConverter();
            //Category category = new Category();
            //newProject proj = new newProject();
            var progress = new Progress<int>(p => progressBar1.Value = p);
            var status = new Progress<string>(s => lblProgress.Text = s);
            var timeReaming = new Progress<string>(t => label2.Text = t);
            //category.Cat(proj.comboBox1.Text);
            try {
                await converter.ConvertAsync(_path, _output, progress, _cancellationTokenSource.Token, status, timeReaming);
            }
            catch (OperationCanceledException) {
                MessageBox.Show(@"Operation was stopped");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                _cancellationTokenSource.Dispose();
            }
            DialogResult = DialogResult.OK;
        }
        
        private bool CreateFolder() {
            _fileName = System.IO.Path.GetFileName(_path);
            _fileExt = System.IO.Path.GetExtension(_path);
            _fileDir = System.IO.Path.GetDirectoryName(_path);
            string newFileName = _fileName.Replace(_fileExt, "");
            
            if (System.IO.Directory.Exists(_fileDir + "\\" + newFileName)) {
                int i = 1;
                while (System.IO.Directory.Exists(_fileDir + "\\" + newFileName + " (" + i + ")")) {
                    i++;
                }
                newFileName = newFileName + " (" + i + ")";
            }
            // Create folder for converted files
            try {
                System.IO.Directory.CreateDirectory(_fileDir + "\\" + newFileName);
                _output = _fileDir + "\\" + newFileName;
            }
            catch (Exception e) {
                MessageBox.Show(@"Error creating directory: " + e.Message);
                return false;
            }
            return true;
        }

        private void btnStop_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _cancellationTokenSource.Cancel();
            btnStop.Text = @"Stopping...";
            btnStop.Enabled = false;
            Close();
        }
    }
}