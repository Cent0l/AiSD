namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        String napis = "";

        public Form1()
        {

            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            var w = new Wezel(5);
            var w2 = new Wezel(3);
            var w3 = new Wezel(1);
            var w4 = new Wezel(2);
            var w5 = new Wezel(6);
            var w6 = new Wezel(4);
            w.dzieci.Add(w2);
            w.dzieci.Add(w3);
            w.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);
            A(w);
            MessageBox.Show(napis);



        }

        void A(Wezel w)
        {
          
            for(int i = 0; i < w.dzieci.Count; i++)
            {

                A(w.dzieci[i]);
            }
            napis += " " + w.wartosci.ToString();
        }

    }

    class Wezel
    {

        public int wartosci;

        public List<Wezel> dzieci = new List<Wezel>();


        public Wezel(int liczba)
        {

            this.wartosci = liczba;

        }
    }
}
