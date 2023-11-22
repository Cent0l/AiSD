using System.IO.Pipes;
using System.Security;
using System.Xml.Linq;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        string napis = "";
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
            
           B(w1);
           MessageBox.Show(napis);

           napis = "";
           odwiedzone.Clear();


        }
        void A(Wezel w)
        {
            MessageBox.Show(w.wartosc.ToString());
            for (int i = 0; i < w.sasiedzi.Count; i++)
            {
                A(w.sasiedzi[i]);
            }

        }
        List<Wezel> odwiedzone = new();
        void B(Wezel w)
        { 
            odwiedzone.Add(w);
            napis += w.wartosc.ToString();
            foreach (var sasiedzi in w.sasiedzi)
            {
                if(!odwiedzone.Contains(sasiedzi))
                    B(sasiedzi);
            }
        }
    }
    public class Wezell
    {

        public int wartosc;
        public List<Wezell> dzieci = new List<Wezell>();
        public Wezell(int n)
        {
            this.wartosc = n;
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
        public class Wezel3
    {

            public int wartosc;
            public List<Wezel3> rodzic = new();
            public List<Wezel3> lewe = new();
            public List<Wezel3> prawe = new();
            public Wezel3(int n)
            {
            this.wartosc = n;
            }
            public void Addl(Wezel3 w)
        {
            if(w==this)
            {
                return;
            }

        }



    }
}

