﻿using System;
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
        
        public void AddBox(PercentageRectangle box) {
            _boxes.Add(box);
        }
        
        public void DeleteBox(int id) {
            foreach (var box in _boxes) {
                if (box.Id != id) continue;
                _boxes.Remove(box);
                break;
            }
        }
        
        public void MoveBox(int id, float x, float y) {
            foreach (var box in _boxes) {
                if (box.Id != id) continue;
                box.X = x;
                box.Y = y;
                break;
            }
        }
    }
}