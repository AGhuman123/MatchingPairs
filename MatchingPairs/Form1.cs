using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MatchingPairs
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        int count = 0;

        private Stopwatch stopWatch;

        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!","N","N",",",",","K","K",
             "b","b","v","v","w","w","z","z"
        };

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.Enabled = false;
                iconLabel.Visible = false;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                    iconLabel.ForeColor = iconLabel.BackColor;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();

            Form2 myForm2 = new Form2();
            myForm2.Visible = false;
        }

        private void label_Click(object sender, EventArgs e)
        {
            count++;
            
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;
            scoreCounter.Text = count.ToString();
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    clickedLabel.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                winner();
                
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
            }
            
        }

    private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void winner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconlabel = control as Label;
                if (iconlabel != null)
                {
                    if (iconlabel.ForeColor == iconlabel.BackColor)
                        return;
                }
            }
            timer2.Stop();
            MessageBox.Show("You matched all pairs" + timer2.GetLifetimeService());
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DigiClockTextBox.Text =
        stopWatch.Elapsed.Hours.ToString("00") + ":" +
        stopWatch.Elapsed.Minutes.ToString("00") + ":" +
        stopWatch.Elapsed.Seconds.ToString("00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconlabel = control as Label;
                iconlabel.Enabled = true;
                iconlabel.Visible = true;
            }
                stopWatch = new Stopwatch();
            timer2.Enabled = true;
            stopWatch.Start();
        }
    }
}
