using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Boxinator_V2;
using Boxinator_V2.Usercontrol;

public class Category
{
    public class CategoryData
    {
        public string Category { get; set; }
    }
    public void Cat(string categoryPath, System.Windows.Forms.ComboBox comboBox, System.Windows.Forms.Label categoryLabel)
    {
        categoryPath = categoryPath.Replace("\\", "/");
        List<CategoryData> categoryList = new List<CategoryData>();
        string json = File.ReadAllText(categoryPath);
        // Deserialize the JSON data to a list of CategoryData objects
        categoryList = JsonConvert.DeserializeObject<List<CategoryData>>(json);
        foreach (var item in categoryList)
        {
            comboBox.Items.AddRange(new Object[] {item.Category});
        }

        int lastSlash = categoryPath.LastIndexOf("/");
        int beforeJSON = categoryPath.LastIndexOf(".");
        categoryLabel.Text = categoryPath.Substring(lastSlash + 1, beforeJSON - lastSlash - 1);
    }
}