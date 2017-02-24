using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Score_Calculator
{
    public partial class Form1 : Form

    {
        //List of scores
        List<int> scores = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calculate();

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void calculate()//calculate and display results
        {
            if (dataValidation(txtScore))
            {
                scores.Add(Convert.ToInt16(txtScore.Text));
            }
        }
        private bool dataValidation(TextBox t)
        {
            string name = "Score";

            return (IsPresent(t, name) && IsNumber(t, name) && IsInRange(t, name, 0, 100));

        }
        public bool IsPresent(TextBox textBox, string name) //is there data in the text box?
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        public bool IsNumber(TextBox textBox, string name) //is the data numeric?
        {
            decimal numdec = 0m;
            if (Decimal.TryParse(textBox.Text, out numdec))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        public bool IsInRange(TextBox textBox, string name, decimal min, decimal max) //is the number in the right range?
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min.ToString() + " and " + max.ToString() + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        
        

    }
}
