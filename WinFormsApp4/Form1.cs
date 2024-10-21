using System.Diagnostics;
namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        Gracz g = new Gracz();

        int gracz = 0;
        int przeciwnik = 0;
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        void restartGame()
        {
            List<Button> buttonList = tableLayoutPanel1.Controls.OfType<Button>().ToList();
            foreach (Button button in buttonList)
            {
                button.Text = String.Empty;
            }
            g.Reset();
            label2.Text = "aktywny gracz: " + g.GetP();
            turnCount = 0;
            label4.Text = "Gracz: " + gracz.ToString();
            label6.Text = "Przeciwnik: " + przeciwnik.ToString();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text != "")
            {
                return;
            }
            else if (b.Text == "")
            {
                b.Text = g.GetP(); // Changed 'button' to 'b'
                g.SwitchP();
                label2.Text = "aktywny gracz: " + g.GetP();
                turnCount++;
                label1.Text = "Liczba ruchów: " + turnCount.ToString();
                checkResult();
            }
        }
        public void LoadGame(object sender, EventArgs e)
        {
            restartGame();
        }

        public void checkResult()
        {
            List<Button> buttonList = tableLayoutPanel1.Controls.OfType<Button>().ToList();
            int empty = 0;
            foreach (Button button in buttonList)
            {
                if (button.Text == String.Empty)
                {
                    empty++;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (buttonList[i * 5].Text == buttonList[i * 5 + 1].Text && buttonList[i * 5 + 1].Text == buttonList[i * 5 + 2].Text && buttonList[i * 5].Text != String.Empty)
                {
                    if (buttonList[i * 5].Text == "X")
                    {
                        przeciwnik++;
                        label6.Text = "Przeciwnik: " + przeciwnik.ToString();
                        MessageBox.Show("Przeciwnik wygrał!");
                        restartGame();
                    }
                    else
                    {
                        gracz++;
                        label4.Text = "Gracz: " + gracz.ToString();
                        MessageBox.Show("Gracz wygrał!");
                        restartGame();
                    }
                }
                if (buttonList[i].Text == buttonList[i + 5].Text && buttonList[i + 5].Text == buttonList[i + 5].Text && buttonList[i].Text != String.Empty)
                {
                    if (buttonList[i].Text == "X")
                    {
                        przeciwnik++;
                        label6.Text = "Przeciwnik: " + przeciwnik.ToString();
                        MessageBox.Show("Przeciwnik wygrał!");
                        restartGame();
                    }
                    else
                    {
                        gracz++;
                        label4.Text = "Gracz: " + gracz.ToString();
                        MessageBox.Show("Gracz wygrał!");
                        restartGame();
                    }
                }
            }

        }
    }
}