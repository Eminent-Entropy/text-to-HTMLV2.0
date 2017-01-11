using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Text_to_html_v2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool gen = false;

        private void button1_Click(object sender, EventArgs e)//save
        {
            string path = textBox3.Text;
            string name = textBox4.Text + ".html";
            string Fpath = Path.Combine(path, name);

            if (gen == true && Directory.Exists(path) && File.Exists(Fpath) == false)
            {
                File.Create(Fpath).Close();      
                File.WriteAllText(Fpath, textBox2.Text);
            }
            else if (gen == true && Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
                File.Create(Fpath).Close();
                File.WriteAllText(Fpath, textBox2.Text);
            }
            else  if (File.Exists(Fpath))
            {
                MessageBox.Show("This file already exists");
            }
            else if (gen == false)
            {
                MessageBox.Show("Please click generate first");
            }
        }

        private void button2_Click(object sender, EventArgs e)//generate
        {
            string title = textBox1.Text;
            string bodyT = textBox2.Text;
            string html;

            html = "<html> <head> <title> " + title + " </title>" + "</head>" + Environment.NewLine + "<body> <pre>" + Environment.NewLine + bodyT + Environment.NewLine + "</pre> </body> </html>";
            textBox2.Text = html;
            gen = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            gen = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            gen = false;
        }
    }
}
