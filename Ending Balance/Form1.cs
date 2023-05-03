using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ending_Balance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Declare a constant for the interest rate
            const decimal INTEREST_RATE = 0.005m;

            // Declare variable to hold the balance
            decimal balance;

            // Decalre a variable to hold the number of months
            int months;

            // Variable used in counting the number of months
            int count = 1;

            // Get the starting balance
            if (decimal.TryParse(startingBalTextBox.Text, out balance)) 
            {
                // Get the number of months
                if (int.TryParse(monthsTextBox.Text, out months))
                {
                    // Calculate the ending balance
                    while (count <= months)
                    {
                        // Add this month's interest to the balance
                        balance = balance + (INTEREST_RATE * balance);
                        count = count + 1;
                    }

                    // Display the ending balance
                    endingBalanceLabel.Text = balance.ToString();
                }
                else 
                {
                    // Display an error message for the months
                    MessageBox.Show("Inavalid value for the starting balance, try again.");
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the text boxes
            startingBalTextBox.Clear();
            monthsTextBox.Clear();

            // Reset the focus
            startingBalTextBox.Focus();
            monthsTextBox.Focus();
            endingBalanceLabel.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
