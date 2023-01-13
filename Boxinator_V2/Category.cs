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

public class Category
{
    public class CategoryData
    {
        public string Category { get; set; }
    }
    public void Cat()
    {
        Logger.Log("entered CAT");
        List<CategoryData> categoryList = new List<CategoryData>();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 1;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;
            // Read and process the file
            string json = File.ReadAllText(filePath);
            // Deserialize the JSON data to a list of CategoryData objects
            categoryList = JsonConvert.DeserializeObject<List<CategoryData>>(json);
        }
        foreach (var item in categoryList)
        {
            Logger.Log(item.Category); // Prints each category
        }
        /*
         * Now we can get all data from JSON FILE so next step is to
         * take all data and write into:
         * this.comboBox1.Items.AddRange(new object[] {"Car", "Pedestrian"});
         *  Button2 SelectFile category
         *  ComboBox1 Category URL/dropdown
         * _projectCat
         * tb_categorypath_TextChanged
         * 
         */
    }
}