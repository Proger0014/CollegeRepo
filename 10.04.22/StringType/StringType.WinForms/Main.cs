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
    public partial class Main : Form
    {
        private Form1 form1;
        private Form2 form2;
        private Form3 form3;
        private Form4 form4;
        private Form5 form5;

        public Main()
        {
            InitializeComponent();
            FormClosing += Main_FormClosing;
        }

        private void buttonCreateForm1_Click(object sender, EventArgs e)
        {
            form1 = (Form1)Application.OpenForms["Form1"];

            if (form1 is null)
            {
                form1 = new Form1(GetPersons());
                form1.Show();
                //form1.ShowDialog(); // Это не дает взаимодействовать с главной формой
            }
            else
            {
                form1.Activate();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form1 != null)
            {
                form1.Close();
            }
            if (form2 != null)
            {
                form2.Close();
            }
            if (form3 != null)
            {
                form3.Close();
            }
            if (form4 != null)
            {
                form4.Close();
            }
            if (form5 != null)
            {
                form5.Close();
            }
        }

        private List<Person> GetPersons()
        {
            return new List<Person>()
            {
                { new Person("Иванов", "896045678") },
                { new Person("Петров", "896545678") },
                { new Person("Сидоров", "891255511") },
                { new Person("Путилов", "890855511") },
                { new Person("Минин", "890322511") }
            };
        }

        private void buttonCreateForm2_Click(object sender, EventArgs e)
        {
            form2 = (Form2)Application.OpenForms["Form2"];

            if (form2 is null)
            {
                form2 = new Form2();
                form2.Show();
                //form1.ShowDialog(); // Это не дает взаимодействовать с главной формой
            }
            else
            {
                form2.Activate();
            }
        }

        private void buttonCreateForm3_Click(object sender, EventArgs e)
        {
            form3 = (Form3)Application.OpenForms["Form3"];

            if (form3 is null)
            {
                form3 = new Form3();
                form3.Show();
                //form1.ShowDialog(); // Это не дает взаимодействовать с главной формой
            }
            else
            {
                form3.Activate();
            }
        }

        private void buttonCreateForm4_Click(object sender, EventArgs e)
        {
            form4 = (Form4)Application.OpenForms["Form4"];

            if (form4 is null)
            {
                form4 = new Form4();
                form4.Show();
                //form1.ShowDialog(); // Это не дает взаимодействовать с главной формой
            }
            else
            {
                form4.Activate();
            }
        }

        private void buttonCreateForm5_Click(object sender, EventArgs e)
        {
            form5 = (Form5)Application.OpenForms["Form5"];

            if (form5 is null)
            {
                form5 = new Form5();
                form5.Show();
                //form1.ShowDialog(); // Это не дает взаимодействовать с главной формой
            }
            else
            {
                form5.Activate();
            }
        }
    }
}
