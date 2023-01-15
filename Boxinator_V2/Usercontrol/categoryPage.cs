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
            listView1.Name = "listView1";
            listView1.View = View.List;
            listView1.FullRowSelect = true;
            panel2.Controls.Add(listView1);
        }

        public void loadTags(Category category)
        {
            var list = category.GetCategories();
            foreach (var item in list)
            {
                listView1.Items.Add(new ListViewItem(item));
                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                
            }
            else
            {
                
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void tb_projectName_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
