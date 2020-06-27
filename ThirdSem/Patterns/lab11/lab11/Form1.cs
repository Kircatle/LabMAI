using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace lab11
{
    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
            i = 0;
        }
        private TreeNode Node(string text)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Text == text)
                    return node;
            }
            return default;
        }
        private bool NodeExist(string text)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Text == text)
                    return true;
            }
            return false;
        }
       

        private void Button1_Click(object sender, EventArgs e)
        {
            i++;
            string city = cityBox.Text;
            string s = sqrBox.Text;
            string count = cBox.Text;
            string age = aBox.Text;
            string comment = commentBox.Text;
            string name = nameBox.Text;
            string info = $"Класс: {city}\nАнглийский: {s}\nМатематика: {count}\nРусский: {age}\n{comment}";
            if (NodeExist(city))
            {
                var node = new TreeNode(name);
                node.Tag = info;
                Node(city).Nodes.Add(node);
            }
            else
            {
                treeView1.Nodes.Add(new TreeNode(city));
                var node = new TreeNode(name);
                node.Tag = info;
                Node(city).Nodes.Add(node);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = treeView1.SelectedNode.Tag.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
