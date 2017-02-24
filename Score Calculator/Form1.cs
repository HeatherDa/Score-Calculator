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
            string output="";
            List<int> sortedScores = new List<int>();
            sortedScores = scores;
            scores.Sort();
            foreach (int num in scores)
            {
                output = output + num + "\n";
            }
            MessageBox.Show(output);
        }

        private void btnClear_Click(object sender, EventArgs e)//clear all values
        {
            txtAverage.Clear();
            txtCount.Clear();
            txtHigh.Clear();
            txtLow.Clear();
            txtMedian.Clear();
            txtQ1.Clear();
            txtQ2.Clear();
            txtScore.Clear();
            txtTotal.Clear();
            scores.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)//close the program
        {
            this.Close();
        }
        private void calculate()//calculate and display results
        {
            if (dataValidation(txtScore))//if data validation returns true
            {
                scores.Add(Convert.ToInt16(txtScore.Text));
                decimal average = 0;//average score
                decimal count = 0;//total scores
                decimal total = 0;//total of scores
                foreach (Int16 score in scores)
                {
                    total = +score;
                    count++;
                }
                average = total / count;


            }
        }
        private bool dataValidation(TextBox t)//data validation
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
            Int16 numdec = 0;
            if (Int16.TryParse(textBox.Text, out numdec))
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
