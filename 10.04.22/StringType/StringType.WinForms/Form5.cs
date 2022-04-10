using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringType.WinForms
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private string GetBaseText()
        {
            return textBox1.Text;
        }

        private string GetFromChange()
        {
            return textBox2.Text;
        }

        private string GetToChange()
        {
            return textBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReplaceText(GetBaseText(), GetFromChange(), GetToChange());
        }

        private void ReplaceText(string changedString, string from, string to)
        {
            label5.Text = changedString.Replace(from, to);

            label5.Visible = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
        }
    }
}
