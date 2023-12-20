namespace ISI3__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void A(Wezel w)
        {
            MessageBox.Show(w.wartosc.ToString());
            foreach (var dziecko in w.dzieci)
            {
                A(dziecko);
            }
        }
        List<Wezel2> odwiedzone = new();
        void A(Wezel2 w)
        {
            MessageBox.Show(w.wartosc.ToString());
            odwiedzone.Add(w);
            foreach(var sasiad in w.sasiedzi)
            {
                if(!odwiedzone.Contains(sasiad))
               A(sasiad);
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            int liczbaN = (int)nudLiczbaN.Value;

            long wynik = Fib2(liczbaN);
            // int[] tab = { 5, 7, 2, 4, 1 };
            //int[] wynik2 = bubbleSort(tab);
            //for(int i =0;i<tab.Length;i++)
            //{
            //  MessageBox.Show(wynik2[i].ToString());
            // }
            int[] tab = Convert(tbnapis.Text);
            bubbleSort(tab);
            lblposortowane.Text = wysw(tab);
            


            //MessageBox.Show(wynik2.ToString());
        }

        int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }

        long Fib2(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            long[] wyrazy = new long[n];

            wyrazy[0] = 0;
            wyrazy[1] = 1;
            for(int i = 2; i< wyrazy.Length;i++)
            {
                wyrazy[i] = wyrazy[i - 1] + wyrazy[i - 2];
            }
            return wyrazy[n - 1] + wyrazy[n - 2];

        }

        int[] bubbleSort(int[] tab)
        {
            int zamiana = 0;
            int pom = tab[0];
            do
            {
                zamiana = 0;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        pom = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = pom;
                        zamiana++;
                    }

                }

            } while (zamiana != 0);
            return tab;
        }

        int[] selectSort(int[] tab)
        {
            int minIndex;
            int pom;
            for(int i =0;i<tab.Length-1;i++)
            {
                minIndex = i;
                pom = tab[i];
                for(int j =i+1;j<tab.Length;j++)
                {
                    if (tab[j] < tab[minIndex])
                    {
                        minIndex = j;
                    }
                }
                tab[i] = tab[minIndex];
                tab[minIndex] = pom;
            }
            return tab;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // '5 8 1' > '5' '8' '1'
        int[] Convert(String napis)
        {
            var liczbyS = napis.Trim().Split(' ');
            int[] liczby = new int[liczbyS.Length];
            for(int i =0;i<liczbyS.Length;i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;

        }

        String wysw(int[]tab)
        {
            String wyraz = "";
            for(int i =0;i<tab.Length;i++)
            {
                wyraz += tab[i].ToString();
                wyraz += ' ';
            }
            return wyraz;

        }

        private void btnSS_Click(object sender, EventArgs e)
        {
            int[] tab = Convert(tbnapis.Text);
            selectSort(tab);
            lblposortowane.Text = wysw(tab);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel(1);
            var w2 = new Wezel(2);
            var w3 = new Wezel(3);
            var w4 = new Wezel(4);
            var w5 = new Wezel(5);
            var w6 = new Wezel(7);
            w1.dzieci.Add(w2);
            w1.dzieci.Add(w6);
            w1.dzieci.Add(w3);
            w2.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            A(w1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel2(5);
            var w2 = new Wezel2(1);
            var w3 = new Wezel2(3);
            var w4 = new Wezel2(8);
            var w5 = new Wezel2(4);
            var w6 = new Wezel2(2);
            w1.Add(w2);
            w2.Add(w3);
            w2.Add(w4);
        }
    }




    public class Wezel
    {
        public int wartosc;
        public List<Wezel>dzieci=new List<Wezel>();
        public Wezel(int liczba)
        {
            this.wartosc = liczba;
        }

    }

    public class Wezel2
    {
        public int wartosc;
        public List<Wezel2> sasiedzi = new List<Wezel2>();
        public Wezel2(int liczba)
        {
            this.wartosc = liczba;
        }
        public override string ToString()
        {
            return this.wartosc.ToString();
        }

        public void Add(Wezel2 w)
        {
            w.sasiedzi.Add(this);
            this.sasiedzi.Add(w);
        }

    }

    public class Graf
    {
        public List<Wezel5> listaWezlow=new List<Wezel5>();
        public List<Wezel5> listaKrawedzi=new List<Wezel5>();
    }

    public class Wezel5
    {
        public int wartosc;
        public List<Wezel5> ListaKrawedzi = new List<Wezel5>();
    }
    public class Krawedz
    {
        public int waga;
        public Wezel5 poczatek;
        public Wezel5 koniec;
    }
    public class Węzeł4
    {
        public int wartosc;
        public Węzeł4 rodzic;
        public Węzeł4 dziecko_prawe;
        public Węzeł4 dziecko_lewe;

        public Węzeł4(int liczba)
        {
            this.wartosc = liczba;
        }

        public override string ToString()
        {
            return this.wartosc.ToString();
        }

        internal void Add(int liczba)
        {
            var dziecko = new Węzeł4(liczba);
            dziecko.rodzic = this;
            if (dziecko.wartosc >= this.wartosc)
            {
                this.dziecko_prawe = dziecko;
            }
            else
            {
                this.dziecko_lewe = dziecko;
            }

        }
        public int GetLiczbaDzieci()
        {
            int wynik = 0;
            if(this.dziecko_lewe!=null)
            {
                wynik++;
            }
            if(this.dziecko_prawe!=null)
            {
                ++wynik;
            }
            return wynik;
        }
    }

    public class DrzewoBinarne
    {
        public Węzeł4 korzeń;
        public int liczbaWęzłów;
        public DrzewoBinarne(int liczba)
        {
            this.korzeń = new Węzeł4(liczba);
            this.liczbaWęzłów = 1;
        }
        public void Add(int liczba)
        {
            Węzeł4 rodzic = this.ZnajdzRodzica(liczba);
            rodzic.Add(liczba);
        }

        private Węzeł4 ZnajdzRodzica(int liczba)
        {
            var w = this.korzeń;
            while (true)
            {
                if (liczba >= w.wartosc)
                {
                    if (w.dziecko_prawe == null)
                    {
                        return w;
                    }
                    w = w.dziecko_prawe;
                }
                if (liczba < w.wartosc)
                {
                    if (w.dziecko_lewe == null)
                    {
                        return w;
                    }
                    w = w.dziecko_lewe;
                }
            }
        }
        public Węzeł4 znajdz(int liczba)
        {
            var w = this.korzeń;
            if (w == null)
            {
                return null;
            }
            while (w != null)
            {
                if (liczba == w.wartosc)
                {
                    return w;
                }
                else if (liczba < w.wartosc)
                {
                    w = w.dziecko_lewe;
                }
                else
                {
                    w = w.dziecko_prawe;
                }
            }
            return null;
        }
        public void WyswietlDrzewo(Węzeł4 wezel)
        {
            if (wezel != null)
            {
                WyswietlDrzewo(wezel.dziecko_lewe);
                MessageBox.Show(wezel.wartosc.ToString());
                WyswietlDrzewo(wezel.dziecko_prawe);
            }
        }

        private void WyswietlInOrder(Węzeł4 węzeł)
        {
            if (węzeł != null)
            {
                WyswietlInOrder(węzeł.dziecko_lewe);
                Console.WriteLine(węzeł.wartosc + " ");
                WyswietlInOrder(węzeł.dziecko_prawe);
            }
        }
        public Węzeł4 znajdzMin(Węzeł4 w)
        {
            //var w = węzeł;
            while (w.dziecko_lewe != null)
            {
                w = w.dziecko_lewe;
            }
            return w;

        }
        public Węzeł4 znajdzMax(Węzeł4 w)
        {
            //var w = węzeł;
            while (w.dziecko_prawe != null)
            {
                w = w.dziecko_prawe;
            }
            return w;
        }
        // poprzednik to zamiana prawego z lewym i min z max
        public Węzeł4 Następnik(Węzeł4 w)
        {
            if (w == null)
            {
                return null;
            }
            if (w.dziecko_prawe != null)
            {
                return this.znajdzMin(w.dziecko_prawe);
            }
            while(w.rodzic!=null)
            {
                if(w.rodzic.dziecko_lewe == w)
                {
                    return w.rodzic;
                }
                w = w.rodzic;
            }
            
            return null;
        }

        public Węzeł4 UsunGdy0Dzieci(Węzeł4 w)
        {
            if(w.rodzic==null)
            {
                this.korzeń = null;
                return w;
            }
            if(w.rodzic.dziecko_lewe==w)
            {
                w.rodzic.dziecko_lewe = null;
            }
            else
            {
                w.rodzic.dziecko_prawe = null;
            }
            w.rodzic = null;
            return w;
        }

        public Węzeł4 UsunGdy1Dziecko(Węzeł4 w)
        {
            Węzeł4 dziecko = null;
            if(w.dziecko_lewe!=null)
            {
                dziecko = w.dziecko_lewe;
                w.dziecko_lewe = null;
            }
            else
            {
                dziecko = w.dziecko_prawe;
                w.dziecko_prawe = null;
            }
            if(w.rodzic!=null)
            {
                if(w.rodzic.dziecko_lewe==w)
                {
                    w.rodzic.dziecko_lewe = dziecko;
                }
                else
                {
                    w.rodzic.dziecko_prawe = dziecko;
                }
            }
            dziecko.rodzic = w.rodzic;
            w.rodzic = null;
            return w;
        }

        public Węzeł4 UsunGdy2Dzieci(Węzeł4 w)
        {
            var zamiennik = this.Następnik(w);
            zamiennik = this.Usun(zamiennik);
            if(w.rodzic!=null)
            {
                if(w.rodzic.dziecko_lewe==w)
                {
                    w.rodzic.dziecko_lewe = zamiennik;
                }
                else
                {
                    w.rodzic.dziecko_prawe = zamiennik;
                }
            }
            zamiennik.rodzic = w.rodzic;
            w.rodzic = null;
            // zrobic
            return w;
        }

        public Węzeł4 Usun(Węzeł4 w)
        {
            switch(w.GetLiczbaDzieci())
            {
                case 0:
                    w=this.UsunGdy0Dzieci(w);
                    break;
                case 1:
                    w=this.UsunGdy1Dziecko(w);
                    break;
                case 2:
                    w=this.UsunGdy2Dzieci(w);
                    break;
            }
            return w;
        }

        

        public void Usun2(Węzeł4 w)
        {
            if (w.dziecko_lewe == null && w.dziecko_prawe == null)
            {
                if (w.wartosc < w.rodzic.wartosc)
                {
                    w.rodzic.dziecko_lewe = null;
                    w.rodzic = null;
                    //return w;
                }
                else
                {
                    w.rodzic.dziecko_prawe = null;
                    w.rodzic = null;
                    //return w;
                }
            }
            else if (w.dziecko_lewe != null && w.dziecko_prawe == null)
            {
                if (w == w.rodzic.dziecko_lewe)
                {
                    w.rodzic.dziecko_lewe = w.dziecko_lewe;
                }
                else
                {
                    w.rodzic.dziecko_prawe = w.dziecko_lewe;
                }
                w.dziecko_lewe.rodzic = w.rodzic;
                w.rodzic = null;
                w.dziecko_lewe = null;
            }
            else if (w.dziecko_lewe == null && w.dziecko_prawe != null)
            {
                if (w == w.rodzic.dziecko_lewe)
                {
                    w.rodzic.dziecko_lewe = w.dziecko_prawe;
                }
                else
                {
                    w.rodzic.dziecko_prawe = w.dziecko_prawe;
                }
                w.dziecko_prawe.rodzic = w.rodzic;
                w.rodzic = null;
                w.dziecko_prawe = null;
            }
            else
            {
                Węzeł4 wezel = Następnik(w);
                int temp = w.wartosc;
                w.wartosc = wezel.wartosc;
                wezel.wartosc = temp;
                Usun2(wezel);

            }

        }
    }
}
