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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private string GetText()
        {
            var text = textBox1.Text;

            return text;
        }

        private void ChangeTextUpper(string text)
        {
            label2.Text = text.ToUpper();
        }

        private void ChangeTextLower(string text)
        {
            label3.Text = text.ToLower();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = GetText();

            ChangeTextUpper(text);

            label2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = GetText();

            ChangeTextLower(text);

            label3.Visible = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }
    }
}
