using System.Collections.Generic;
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
            // Check if index is within range
            if (index < 0 || index >= images.Length) {
                Bitmap error = (Bitmap) Properties.Resources.ResourceManager.GetObject("BOXINATOR_v3");
                return error;
            }
            return images[index].Get();
        }
        
        public List<PercentageRectangle> GetBoxes(int index) {
            // Check if index is within range
            if (index < 0 || index >= images.Length) {
                return new List<PercentageRectangle>();
            }
            return images[index].GetBoxes();
        }


        public int GetImageCount() {
            return images.Length;
        }
        
        public void AddNewBox(int index, PercentageRectangle box) {
            // Check if index is within range
            if (index < 0 || index >= images.Length) {
                return;
            }
            images[index].AddBox(box);
        }
        
        public void PermeateNewBox(int index, PercentageRectangle box) {
            // Loop through all images and add the box to them
            // Start from index to end of images
            for (int i = index; i < images.Length; i++) {
                images[i].AddBox(box.Copy());
            }
        }
        
        public void PermeateDeleteBox(int index, int id) {
            // Loop through all images and delete the box from them
            // Start from index to end of images
            for (int i = index; i < images.Length; i++) {
                images[i].DeleteBox(id);
            }
        }
        
        public void PermeateMovedBox(int index, int id, float x, float y, float width, float height) {
            // Loop through all images and move the box in them
            // Start from index to end of images
            for (int i = index; i < images.Length; i++) {
                images[i].MoveBox(id, x, y, width, height);
            }
        }

        public object GetBoxAtFrame(int currentKeyframe, int i) {
            return images[currentKeyframe].GetBoxes()[i];
        }
        
        public void SetBoxAtFrame(int currentKeyframe, PercentageRectangle box) {
            images[currentKeyframe].MoveBox(box.Id, box.X, box.Y, box.Width, box.Height);
        }
        
    }
}