using StringType.WinForms.Models;
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
    public partial class Form1 : Form
    {
        private readonly List<Person> _persons;

        public Form1(List<Person> persons)
        {
            InitializeComponent();

            _persons = persons;
        }

        private string GetTextFromTextBox()
        {
            string s = textBox1.Text;
            textBox1.Clear();

            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var phone = GetTextFromTextBox();

            foreach (var person in _persons)
            {
                if (person.Phone.StartsWith(phone))
                {
                    listBox1.Items.Add(person.FirstName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var phone = GetTextFromTextBox();

            foreach (var person in _persons)
            {
                if (person.Phone.EndsWith(phone))
                {
                    listBox1.Items.Add(person.FirstName);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var phone = GetTextFromTextBox();

            foreach (var person in _persons)
            {
                if (person.Phone.Contains(phone))
                {
                    listBox1.Items.Add(person.FirstName);
                }
            }
        }
    }
}
