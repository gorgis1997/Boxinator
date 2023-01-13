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
    public void Cat(string categoryPath)
    {
        Logger.Log("PATH1 WITH PARAMETER: ");
        Logger.Log(categoryPath);
        categoryPath = categoryPath.Replace("\\", "/");
        Logger.Log("NEW PATH2 WITH PARAMETER: ");
        Logger.Log(categoryPath);
        List<CategoryData> categoryList = new List<CategoryData>();
        string json = File.ReadAllText(categoryPath);
        // Deserialize the JSON data to a list of CategoryData objects
        categoryList = JsonConvert.DeserializeObject<List<CategoryData>>(json);
        foreach (var item in categoryList)
        {
            Logger.Log(item.Category); // Prints each category
        }

        newProject proj = new newProject();
        proj.comboBox1.Text = "eopfgke";
        //this.comboBox1.Items.AddRange(new object[] {"Car", "Pedestrian", "Traffic Light", "Etc"});

        /*
         * Now we can get all data from JSON FILE so next step is to
         * take all data and write into:
         * this.comboBox1.Items.AddRange(new object[] {"Car", "Pedestrian"});
         *  Button2 SelectFile category
         *  ComboBox1 Category URL/dropdown
         * _projectCat
         * tb_categorypath_TextChanged
         *
         *  Category categ = new Category();
            categ.Cat("eofkeopf");
         */
    }
}