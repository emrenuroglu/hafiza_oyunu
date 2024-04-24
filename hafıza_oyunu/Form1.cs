namespace hafıza_oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> list = new List<string>()
            {
                "q","w","e","r","t","y","u","ı","o","p","ğ","ü","a","s","d","f","g","h","j","k",
                "q","w","e","r","t","y","u","ı","o","p","ğ","ü","a","s","d","f","g","h","j","k",
            };
        Random rnd = new Random();
        int sure = 4;
        int skor1;
        int skor2;
        int siralama = 1;
        Button buton1, buton2;

        private void Form1_Load(object sender, EventArgs e)
        {
            Button btn;
            timer1.Start();
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    btn = (Button)c;
                    int en = rnd.Next(list.Count);
                    btn.Text = list[en];
                    btn.ForeColor = Color.Black;
                    list.RemoveAt(en);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            if (sure == 0)
            {
                timer1.Stop();
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        item.ForeColor = item.BackColor;
                    }
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            buton1.ForeColor = buton1.BackColor;
            buton2.ForeColor = buton2.BackColor;
            buton1 = null;
            buton2 = null;
        }

        private void buton_ayarlari(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (buton1 == null)
            {
                buton1 = btn;
                buton1.ForeColor = Color.Yellow;
                return;
            }
            buton2 = btn;
            buton2.ForeColor = Color.Yellow;

            if (buton1.Text == buton2.Text)
            {
                buton1.ForeColor = Color.Yellow;
                buton2.ForeColor = Color.Yellow;
                buton1 = null;
                buton2 = null;
                if (siralama == 1)
                {
                    skor1 += 10;
                    label3.Text = skor1.ToString();
                    if (skor1 == 110)
                    {
                        MessageBox.Show("OYUNCU 1 KAZANDI");
                    }
                }
                else
                {
                    skor2 += 10;
                    label4.Text = skor2.ToString();
                    if (skor2 == 110)
                    {
                        MessageBox.Show("OYUN");
                    }
                }
            }
            else
            {
                timer2.Start();
                if (siralama == 1)
                {
                    siralama = 0;

                }
                else
                {
                    siralama = 1;
                }
            }
        }
    }
}