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
            
            var w1 = new Wezel(1);//dodawanie wezla
            var w2 = new Wezel(2);
            var w3 = new Wezel(3);
            var w4 = new Wezel(4);
            var w5 = new Wezel(5);
            var w6 = new Wezel(6);
            
            w1.Add(w2);
            w1.Add(w3);
            w2.Add(w4);
            w2.Add(w5);
            w4.Add(w6);
            w3.Add(w6);
            A(w1);
            MessageBox.Show(napis);
            napis = " ";


        }
        void A(Wezel w)
        {
            if (!napis.Contains(w.wartosc.ToString()))
                napis += " " + w.wartosc.ToString();
            for (int i = 0; i < w.sasiedzi.Count; i++)
            {
                A(w.sasiedzi[i]);          }

        }
    }

    public class Wezel
    {

        public int wartosc;
        public List<Wezel> sasiedzi = new List<Wezel>();
        public Wezel(int n)
        {
            this.wartosc = n;
        }
        public void Add(Wezel w)
        {
            if (w == this)
                return;
            if (!this.sasiedzi.Contains(w))
                this.sasiedzi.Add(w);
            if (!w.sasiedzi.Contains(this))
                w.sasiedzi.Add(this);
            

        }
    }
}
