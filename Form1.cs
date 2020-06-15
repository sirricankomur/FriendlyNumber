using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriendlyNumber
{
    public partial class Form1 : Form
    {
        TextBox textBoxNumberX;
        TextBox textBoxNumberY;
        ListBox listBoxX;
        ListBox listBoxY;
        TextBox textBoxSumOfPrimeFactorsX;
        TextBox textBoxSumOfPrimeFactorsY;

        int numberOfElementsInListBoxX;
        int numberOfElementsInListBoxY;
        int numberX;
        int numberY;
        int sumOfNumberX;
        int sumOfNumberY;

        public Form1()
        {
            InitializeComponent();
        }

        private void formFriendlyNumber_Load(object sender, EventArgs e)
        {
            this.Text = "Friendly Number";
            ShowLoginScreen();
            ShowResultScreen();
        }

        private void btnIsFriend_Click(object sender, EventArgs e)
        {            
            //Has anything been entered in the textboxes?
            if (textBoxNumberX.Text != "" && textBoxNumberY.Text != "")
            {             
                if (numberOfElementsInListBoxX > 0 && numberOfElementsInListBoxY > 0)
                {
                    listBoxX.Items.Clear();
                    listBoxY.Items.Clear();
                }
               
                numberX = Convert.ToInt32(textBoxNumberX.Text);
                numberY = Convert.ToInt32(textBoxNumberY.Text);

                ShowResults();
                IsFriendlyNumbers();
               
                numberOfElementsInListBoxX = listBoxX.Items.Count;
                numberOfElementsInListBoxY = listBoxY.Items.Count;
                sumOfNumberX = 0;
                sumOfNumberY = 0;
            }           
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowLoginScreen()
        {
            AddLabelTextBoxX();
            AddLabelTextBoxY();
            AddTextBoxNumberX();
            AddTextBoxNumberY();
            AddIsFriendButton();
            AddExitButton();
        }

        private void ShowResultScreen()
        {
            AddLabelListBoxX();
            AddLabelListBoxY();
            AddListBoxX();
            AddListBoxY();
            AddLabelTotals();
            AddTextBoxSumOfPrimeFactorsX();
            AddTextBoxSumOfPrimeFactorsY();
        }

        private void AddLabelTextBoxX()
        {
            Label label = new Label();
            label.Name = "lblTextBoxX";
            label.Text = "X";
            label.Size = new Size(15, 15);
            label.Location = new Point(30, 50);

            this.Controls.Add(label);
        }

        private void AddLabelTextBoxY()
        {
            Label label = new Label();
            label.Name = "lblTextBoxY";
            label.Text = "Y";
            label.Size = new Size(15, 15);
            label.Location = new Point(30, 80);

            this.Controls.Add(label);
        }

        private void AddTextBoxNumberX()
        {
            textBoxNumberX = new TextBox();
            textBoxNumberX.Name = "tbxNumberX";
            textBoxNumberX.Size = new Size(220, 30);
            textBoxNumberX.Location = new Point(50, 47);

            this.Controls.Add(textBoxNumberX);
        }

        private void AddTextBoxNumberY()
        {
            textBoxNumberY = new TextBox();
            textBoxNumberY.Name = "tbxNumberY";
            textBoxNumberY.Size = new Size(220, 30);
            textBoxNumberY.Location = new Point(50, 77);

            this.Controls.Add(textBoxNumberY);
        }

        private void AddIsFriendButton()
        {
            Button button = new Button();
            button.Name = "btnIsFriend";
            button.Text = "Is Friendly?";
            button.Size = new Size(100, 30);
            button.Location = new Point(50, 120);

            this.Controls.Add(button);
            button.Click += new EventHandler(btnIsFriend_Click);
        }

        private void AddExitButton()
        {
            Button button = new Button();
            button.Name = "btnExit";
            button.Text = "Exit";
            button.Size = new Size(100, 30);
            button.Location = new Point(170, 120);

            this.Controls.Add(button);
            button.Click += new EventHandler(btnEnd_Click);
        }

        private void AddLabelListBoxX()
        {
            Label label = new Label();
            label.Name = "lblListBoxX";
            label.Text = "X";
            label.Size = new Size(15, 15);
            label.Location = new Point(393, 31);

            this.Controls.Add(label);
        }

        private void AddLabelListBoxY()
        {
            Label label = new Label();
            label.Name = "lblListBoxY";
            label.Text = "Y";
            label.Size = new Size(15, 15);
            label.Location = new Point(568, 31);

            this.Controls.Add(label);
        }

        private void AddLabelTotals()
        {
            Label label = new Label();
            label.Name = "lblTotals";
            label.Text = "Totals: ";
            label.Size = new Size(60, 15);
            label.Location = new Point(260, 349);

            this.Controls.Add(label);
        }

        private void AddListBoxX()
        {
            listBoxX = new ListBox();
            listBoxX.Name = "lbxX";
            listBoxX.Size = new Size(150, 300);
            listBoxX.Location = new Point(325, 47);
            FindPositiveDivisorsOfPrimeNumberX(listBoxX);

            this.Controls.Add(listBoxX);
        }

        private void AddListBoxY()
        {
            listBoxY = new ListBox();
            listBoxY.Name = "lbxY";
            listBoxY.Size = new Size(150, 300);
            listBoxY.Location = new Point(500, 47);
            FindPositiveDivisorsOfPrimeNumberY(listBoxY);

            this.Controls.Add(listBoxY);
        }

        private void AddTextBoxSumOfPrimeFactorsX()
        {
            textBoxSumOfPrimeFactorsX = new TextBox();
            textBoxSumOfPrimeFactorsX.Name = "tbxSumOfPrimeFactorsX";
            textBoxSumOfPrimeFactorsX.Size = new Size(150, 15);
            textBoxSumOfPrimeFactorsX.Location = new Point(325, 345);

            this.Controls.Add(textBoxSumOfPrimeFactorsX);
        }

        private void AddTextBoxSumOfPrimeFactorsY()
        {
            textBoxSumOfPrimeFactorsY = new TextBox();
            textBoxSumOfPrimeFactorsY.Name = "tbxSumOfPrimeFactorsY";
            textBoxSumOfPrimeFactorsY.Size = new Size(150, 15);
            textBoxSumOfPrimeFactorsY.Location = new Point(500, 345);

            this.Controls.Add(textBoxSumOfPrimeFactorsY);
        }

        private void FindPositiveDivisorsOfPrimeNumberX(ListBox listBox)
        {
            //Counting up to the numberX.
            for (int i = 1; i < numberX; i++)
            {
                //Add i to the ListBox if it divides the numberX completely.
                if (numberX % i == 0)
                {
                    listBox.Items.Add(i);
                }
            }
        }

        private void FindPositiveDivisorsOfPrimeNumberY(ListBox listBox)
        {
            //Counting up to the numberY.
            for (int i = 1; i < numberY; i++)
            {
                //Add i to the ListBox if it divides the numberY completely.
                if (numberY % i == 0)
                {
                    listBox.Items.Add(i);
                }
            }
        }

        private void SumPositiveDivisorsOfPrimeNumberX()
        {
            //Counting up to the numberX.
            for (int i = 1; i < numberX; i++)
            {
                //Add i to the sumOfNumberX if it divides the numberX completely.
                if (numberX % i == 0)
                {
                    sumOfNumberX += i;
                }
            }
            textBoxSumOfPrimeFactorsX.Text = sumOfNumberX.ToString();
        }

        private void SumPositiveDivisorsOfPrimeNumberY()
        {
            //Counting up to the numberY.
            for (int i = 1; i < numberY; i++)
            {
                //Add i to the sumOfNumberY if it divides the numberY completely.
                if (numberY % i == 0)
                {
                    sumOfNumberY += i;
                }
            }
            textBoxSumOfPrimeFactorsY.Text = sumOfNumberY.ToString();
        }

        private void ShowResults()
        {
            FindPositiveDivisorsOfPrimeNumberX(listBoxX);
            FindPositiveDivisorsOfPrimeNumberY(listBoxY);

            SumPositiveDivisorsOfPrimeNumberX();
            textBoxSumOfPrimeFactorsX.Text = sumOfNumberX.ToString();

            SumPositiveDivisorsOfPrimeNumberY();
            textBoxSumOfPrimeFactorsY.Text = sumOfNumberY.ToString();
        }

        private void IsFriendlyNumbers()
        {
            //If the sum of the positive divisors of the numberY equals the numberX and the sum of the positive divisors of the numberX is the numberY, the Friendly Number.
            if (numberX == sumOfNumberY && numberY == sumOfNumberX && numberX != numberY)
            {
                MessageBox.Show("These are Friendly Number.");
            }
            else
            {
                MessageBox.Show("These are not Friendly Number!");
            }

        }
    }
}
