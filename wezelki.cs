namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        String napis = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel(5);//dodawanie wezla
            var w2 = new Wezel(3);
            var w3 = new Wezel(1);
            var w4 = new Wezel(2);
            var w5 = new Wezel(6);
            var w6 = new Wezel(4);
            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);
            A(w1);
            MessageBox.Show(napis);
           

        }
        void A(Wezel w)
        {
            napis += " " + w.wartosc.ToString();
            for (int i=0;i<w.dzieci.Count;i++)
            {
                A(w.dzieci[i]);

            }
            
        }
    }
    
    public class Wezel
    {

        public int wartosc;
        public List<Wezel> dzieci = new List<Wezel>();
        public Wezel(int n)
        {
            this.wartosc = n;
        }
    }
}
