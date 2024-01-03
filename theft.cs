using System.Diagnostics.CodeAnalysis;

namespace algorytm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graf g = new Graf(4);
            g.dodajPołączenia(0, 1, 2, 3);
            g.dodajPołączenia(1, 2);
            Console.WriteLine("Nie istnieją krawędzie:");
            for (int i = 0; i < 4; i++)
                for (int j = i + 1; j < 4; j++)
                    if (!g.sprawdźKrawędź(i, j))
                        Console.WriteLine("{0} z {1}", i, j);
            Console.ReadKey();
        }
    }

    // algorytm prima kruskala
    // konstruktor oparty na krawedzi
    // metoda sprawdz zwraca integera przyjmuje za parametr krawedz
    // jezeli lewy wierzcholek jest to ++ jezeli prawy wierzcholek jest to ++
    // metoda dodaj
    // finalna wersja to na samym koncu jeden graf
    

    class Graf
    {
        private List <Wierzchołek> wierzchołki = new List<Wierzchołek>();
        public Graf(int ile)
        {
            while (ile-- > 0)
                wierzchołki.Add(new Wierzchołek());
        }
        public void dodajPołączenia(int id, params int[] połączenia)
        {
            foreach (int krawędź in połączenia)
                wierzchołki[id].dodajKrawędź(krawędź);
        }
        public bool sprawdźKrawędź(int start, int koniec)
        {
            if (start > koniec)
                return sprawdźKrawędź(koniec, start);
            return wierzchołki[start].sprawdźPołączenie(koniec);
        }
    }


    class Wierzchołek
    {
        private List<int> połączenia = new List<int>();
        public bool sprawdźPołączenie(int cel)
        {
            return połączenia.IndexOf(cel) != -1;
        }
        public bool dodajKrawędź(int cel)
        {
            if (sprawdźPołączenie(cel))
            {
                return false;
            }
            else
            {
                połączenia.Add(cel);
                return true;
            }
        }
    }



}
