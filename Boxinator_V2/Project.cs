using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Boxinator_V2 {
    public class Project {
        private string _name;
        private string _workPath;
        private Image[] images;
        
        public Project(string name, string path) {
            _name = name;
            _workPath = path;
        }

        public void InitializeImages() {
            // Get every jpg/png image in _workPath
            var imagePaths = Directory.EnumerateFiles(_workPath, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png"));
            
            images = new Image[imagePaths.Count()];
            int i = 0;
            foreach (var imagePath in imagePaths) {
                images[i] = new Image(imagePath);
                i++;
            }
        }
        
        public Bitmap GetImage(int index) {
            //Bitmap image = new Bitmap(images[index].Get());
            return images[index].Get();
        }
        
        public int GetImageCount() {
            return images.Length;
        }
    }
}