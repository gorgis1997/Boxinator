using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Boxinator_V2 {
    public class Image {
        private string _imagePath;
        private List<PercentageRectangle> _boxes;
        
        public Image(string imagePath) {
            _imagePath = imagePath;
            _boxes = new List<PercentageRectangle>();
        }

        public Bitmap Get() {
            Bitmap image;
            try {
                image = new Bitmap(_imagePath);
            }
            catch (Exception e) {
                MessageBox.Show("Image not found: " + _imagePath);
                image = Bitmap.FromHicon(SystemIcons.Error.Handle);
            }
            return image;
        }
        
        public List<PercentageRectangle> GetBoxes() {
            return _boxes;
        }
    }
}