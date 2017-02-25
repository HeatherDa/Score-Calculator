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
        List<int> sortedScores = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calculate();
            txtScore.Clear();//make space for next score
            txtScore.Focus();//ready for next score

        }

        private void btnDisplay_Click(object sender, EventArgs e)//shows sorted data
        {
            string output="";
            foreach (int num in sortedScores)
            {
                output = output + num + "\n";
            }
            MessageBox.Show(output);
        }
        private void btnUScores_Click(object sender, EventArgs e)//shows unsorted data
        {
            string output = "";
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
            txtScore.Clear();
            txtTotal.Clear();
            txtPrevScore.Clear();
            scores.Clear();
            sortedScores.Clear();
            txtScore.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)//close the program
        {
            this.Close();
        }
        private void calculate()//calculate and display results
        {
            try
            {
                if (dataValidation(txtScore))//if data validation returns true
                {
                    scores.Add(Convert.ToInt16(txtScore.Text));
                    sortedScores.Add(Convert.ToInt16(txtScore.Text));
                    sortedScores.Sort();//sort scores and make sure variable is updated

                    decimal total = 0;//total of scores
                    foreach (Int16 score in scores)
                    {
                        total = total + score;//could maybe do without loop...
                    }
                    txtTotal.Text = Convert.ToString(total);//get and set total value of scores
                    txtCount.Text = Convert.ToString(scores.Count());//get and set count of scores
                    txtAverage.Text = Convert.ToString(total/scores.Count());//calculate and set Average score
                    txtLow.Text = Convert.ToString(scores.Min());//calcultate and set Low score
                    txtHigh.Text = Convert.ToString(scores.Max());//calculate and set High score
                    calcMedian(); //set median

                    txtPrevScore.Text = txtScore.Text; //so that user can see which number they just entered
                }
            }catch(FormatException)
            {
                MessageBox.Show("There is a format exception.", "Exceptions");
            }
            catch (Exception)
            {
                MessageBox.Show("There is some kind of exception.", "Exception");
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
        
        private void calcMedian()//calculate median
        {
            int count = scores.Count();
            decimal median = 0m;
            int indexMedian = 0;
            int index1 = 0;
            int index2 = 0;

            if ((count % 2 != 0)&&(scores.Count!=1))//ie if it's odd
            {
                indexMedian = (count + 1) / 2;
                indexMedian = indexMedian - 1;//adjusting for index starting at 0
                median = sortedScores[indexMedian];
            }
            else if (scores.Count == 1) { txtAverage.Text = "NA";  median=scores[0]; }//median is the only score available if there is only one score, Average is not applicable to a single score
            else if (scores.Count ==2) { median = (Convert.ToDecimal(txtAverage.Text)); }//median is the same as the average if there are only two scores.
            else//if it's even
            {
                indexMedian = count / 2;
                indexMedian = indexMedian - 1;//adjusting for index starting at 0
                index1 = sortedScores[indexMedian];
                index2 = sortedScores[indexMedian+1];
                decimal indexes = index1 + index2;
                median = indexes / 2; //average of the two middle numbers
            }

            Math.Round(median,2);
            txtMedian.Text = Convert.ToString(median);//set median text box with calculated value


        }
       
    }
}
