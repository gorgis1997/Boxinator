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
    List<string> categoryList = new List<string>();
    private string _categoryPath;
    public List<string> GetCategories()
    {
        return categoryList;
    }
    public Category(string categoryPath)
    {
        string[] lines = File.ReadAllLines(categoryPath);
        foreach (var line in lines)
        {
            categoryList.Add(line);
            
        }

        this._categoryPath = categoryPath;
    }

    public string CatName()
    {
        _categoryPath = _categoryPath.Replace("\\", "/");
        int lastSlash = _categoryPath.LastIndexOf("/");
        int beforeFtype = _categoryPath.LastIndexOf(".");
        _categoryPath = _categoryPath.Substring(lastSlash + 1, beforeFtype - lastSlash - 1);
        return _categoryPath;
    }
}