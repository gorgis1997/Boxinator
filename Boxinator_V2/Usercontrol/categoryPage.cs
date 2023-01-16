using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Accord;
using Point = System.Drawing.Point;

namespace Boxinator_V2.Usercontrol
{
    public partial class categoryPage : UserControl
    {
        private ListView listView1 = new ListView();
        
        public categoryPage()
        {
            InitializeComponent();
            listView1.Location = new Point(10, 10);
            listView1.Size = new Size(200, 200);
            listView1.Dock = DockStyle.Fill;
            listView1.Name = "listView1";
            listView1.View = View.List;
            listView1.FullRowSelect = true;
            panel2.Controls.Add(listView1);
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }
        
        // Add clicking on an item in the listview and put the value of that item into textbox1
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].Text;
            }
        }

        public void loadTags(Category category)
        {
            var list = category.GetCategories();
            foreach (var item in list)
            {
                listView1.Items.Add(item);
            }
        }

        public string AddCategory() {
            string category = textBox1.Text;
            listView1.Items.Add(category);
            return category;
        }

        public string RemoveCategory() {
            string category = textBox1.Text;
            // Remove item from listview with value matching category
            try {
                listView1.Items.Remove(listView1.Items.Cast<ListViewItem>().First(i => i.Text == category));

            }
            catch (Exception e) {
                //MessageBox.Show("Category not found");
            }
            return category;
        }
    }
}
