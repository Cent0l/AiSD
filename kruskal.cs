namespace kruskal2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Wezel4
        {
            public int wartosc;
            public List<Krawedz> listaKrawedzi;

            public Wezel4(int wartosc, List<Krawedz> listaKrawedzi)
            {
                this.wartosc = wartosc;
                this.listaKrawedzi = listaKrawedzi;
            }
        }

        public class Krawedz
        {
            public int waga;
            public Wezel4 poczatek;
            public Wezel4 koniec;

            public Krawedz(int waga, Wezel4 poczatek, Wezel4 koniec)
            {
                this.waga = waga;
                this.poczatek = poczatek;
                this.koniec = koniec;
            }
        }

        class Graf
        {
            public List<Wezel4> listaWezlow = new List<Wezel4>();
            public List<Krawedz> listaKrawedzi = new List<Krawedz>();

            public Graf(Krawedz k)
            {
                listaKrawedzi.Add(k);
            }

            public int Sprawdz(Krawedz k)
            {
                int wynik = 0;
                if (!this.listaWezlow.Contains(k.poczatek))
                {
                    wynik++;
                    listaWezlow.Add(k.poczatek);
                }
                if (!this.listaWezlow.Contains(k.koniec))
                {
                    wynik++;
                    listaWezlow.Add(k.koniec);
                }
                return wynik;
            }

            public Graf AlgKruskala()
            {
                var krawedzie = this.listaKrawedzi.OrderBy(k => k.waga);
                var grafy = new List<Graf>();
                Graf czyPonownie = null;

                foreach (var k in krawedzie)
                {
                    if (grafy.Count == 0)
                    {
                        grafy.Add(new Graf(k));
                        continue;
                    }

                    for (int i = 0; i < grafy.Count; i++)
                    {
                        var g = grafy[i];
                        var ileNowychWezlow = g.Sprawdz(k);

                        if (ileNowychWezlow == 0)
                        {
                            break;
                        }
                        else if (ileNowychWezlow == 1)
                        {
                            if (czyPonownie == null)
                            {
                                g.Add(k);
                                czyPonownie = g;
                            }
                            else
                            {
                                czyPonownie.Join(g);
                                grafy.RemoveAt(i);
                                break;
                            }
                        }
                        else
                        {
                            grafy.Add(new Graf(k));
                            break;
                        }
                    }
                }

                return grafy[0];
            }

            public void Add(Krawedz k)
            {
                if (!listaKrawedzi.Contains(k))
                {
                    listaKrawedzi.Add(k);
                }
            }

            private void Join(Graf g)
            {
                foreach (Wezel4 w in g.listaWezlow)
                {
                    this.Add(w.listaKrawedzi[0]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wezel4 w1 = new Wezel4(1, new List<Krawedz>());
            Wezel4 w2 = new Wezel4(2, new List<Krawedz>());
            Wezel4 w3 = new Wezel4(3, new List<Krawedz>());

            Krawedz k1 = new Krawedz(1, w1, w2);
            Krawedz k2 = new Krawedz(2, w2, w3);
            Krawedz k3 = new Krawedz(3, w1, w3);

            Graf mojGraf = new Graf(k1);
            mojGraf.Add(k2);
            mojGraf.Add(k3);

            Graf minimalneDrzewo = mojGraf.AlgKruskala();

            MessageBox.Show("Minimalne drzewo o wadze: " + minimalneDrzewo.listaKrawedzi.Sum(k => k.waga));
        }
    }
}
