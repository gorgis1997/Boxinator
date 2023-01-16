using System.Drawing;

namespace Boxinator_V2 {
    public class PercentageRectangle {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        
        public Size ImageSize {get;set;}
        
        public int Id {get;set;}
        
        public string CategoryTag {get;set;}
        
        public static readonly PercentageRectangle Empty = new PercentageRectangle(0,0,0,0, -1, "");
        
        public PercentageRectangle(float x, float y, float width, float height, int id, string categoryTag) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Id = id;
            CategoryTag = categoryTag;
        }

        public Rectangle GetRectangle(Size imageSize) {
            return new Rectangle((int)(X * imageSize.Width), (int)(Y * imageSize.Height),
                (int)(Width * imageSize.Width), (int)(Height * imageSize.Height));
        }
        
        public Rectangle ToRectangle(Size imageSize)
        {
            return new Rectangle((int)(X * imageSize.Width), (int)(Y * imageSize.Height), (int)(Width * imageSize.Width), (int)(Height * imageSize.Height));
        }
        
        // ToString
        public override string ToString() {
            return string.Format("X: {0}, Y: {1}, Width: {2}, Height: {3}, ID: {4}, Category: {5}", (object)X, (object)Y, (object)Width, (object)Height, (object)Id, (object)CategoryTag);
        }
        
        // Copy
        public PercentageRectangle Copy() {
            return new PercentageRectangle(X, Y, Width, Height, Id, CategoryTag);
        }
    }
}