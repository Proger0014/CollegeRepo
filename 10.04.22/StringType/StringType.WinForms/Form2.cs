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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeNameHello(textBox1.Text);
        }

        private void ChangeNameHello(string personName)
        {
            label2.Text = "Добрый день, " + personName + "!";
            label2.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
