using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringType.WinForms
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var students = GetStudentsName();
            var textOrder = GetTextOrder(students);
            SetTextOrder(textOrder);
        }

        private List<string> GetStudentsName()
        {
            List<string> students = new List<string>();

            var namesList = textBox1.Text.Split(' ');

            foreach (var name in namesList)
            {
                students.Add(name);
            }

            return students;
        }

        private string GetTextOrder(List<string> studentsName)
        {
            string studentsNameOneString = String.Join(", ", studentsName);
            studentsNameOneString = Regex.Replace(studentsNameOneString, @"\r?\n", ", ");
            string order = "За отличные успехи в учебе почетной грамотой награждаются студенты: ";

            return String.Concat(order, ' ', studentsNameOneString, '.');
        }

        private void SetTextOrder(string order)
        {
            label3.Text = order;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Введите учеников...";

            textBox1.GotFocus += RemoveText;
            textBox1.LostFocus += AddText;
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите учеников...")
            {
                textBox1.Text = "";
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Введите учеников...";
            }
        }
    }
}
