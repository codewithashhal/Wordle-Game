using System;
using System.Drawing;
using System.Windows.Forms;

namespace wordle
{
    public partial class Form2 : Form
    {
        Label[,] manualgrid = new Label[6, 5];
        int currentrow = 0;
        int currentcol = 0;
        string anokha = "";
        private WordleBank w1;
        private Calculation calc;
        private WordValidator v1;
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            w1 = new WordleBank();
            anokha = w1.GetRandomWord();
            calc = new Calculation(anokha);
            v1 = new WordValidator(anokha);

            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is Label lbl)
                {
                    int row = tableLayoutPanel1.GetRow(lbl);
                    int col = tableLayoutPanel1.GetColumn(lbl);
                    manualgrid[row, col] = lbl;
                    manualgrid[row, col].Text = "";
                    lbl.BackColor = Color.DarkSlateGray;
                    lbl.ForeColor = Color.White;
                    lbl.Font = new Font("Arial", 16, FontStyle.Bold);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BorderStyle = BorderStyle.Fixed3D;
                }
            }

        }
        public void LetterButton_Click(object sender, EventArgs e)
        {
            if (currentcol > 4) { return; }
            else
            {
                Button btn = (Button)sender;
                manualgrid[currentrow, currentcol].Text = btn.Text;
                currentcol++;
            }

        }
        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (currentcol > 0)
            {
                currentcol--;
                manualgrid[currentrow, currentcol].Text = "";

            }
        }

        private void Enterbutton_Click(object sender, EventArgs e)
        {
            string answer = "";
            string[] result = new string[5];
            for (int i = 0; i < 5; i++)
            {
                answer += manualgrid[currentrow, i].Text;
            }
            if (!v1.Validate(answer))
            {
                MessageBox.Show("INVALID INPUT!");
                return;
            }
            result = calc.Calculate(answer);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == "Green")
                {
                    manualgrid[currentrow, i].BackColor = Color.ForestGreen;
                }
                else if (result[i] == "Yellow")
                {
                    manualgrid[currentrow, i].BackColor = Color.Gold;
                }
                else
                {
                    manualgrid[currentrow, i].BackColor = Color.DimGray;
                }
            }

            currentrow++;
            currentcol = 0;
            if (calc.CheckVictory(result))
            {
                MessageBox.Show("Yeahhhhhh aap jeet gye 🎉 ( ◠‿◠ ) \n\n The word was " + anokha);
                this.Close();
            }
            if (currentrow > 5 && !calc.CheckVictory(result))
            {
                MessageBox.Show("Koi baat nhi aap se nhi ho paaya ❌ (༎ຶ︵༎ຶ) \n\n The word was " + anokha);
                this.Close();
            }





        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}