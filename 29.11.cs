using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            /*
            var w1 = new Węzeł(5);
            var w2 = new Węzeł(3);
            var w3 = new Węzeł(1);
            var w4 = new Węzeł(2);
            var w5 = new Węzeł(6);
            var w6 = new Węzeł(4);
            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);

            var p1 = new Węzeł2(1);
            var p2 = new Węzeł2(2);
            var p3 = new Węzeł2(3);
            var p4 = new Węzeł2(4);
            var p5 = new Węzeł2(5);
            var p6 = new Węzeł2(6);

            p1.Add(p2);
            p1.Add(p3);
            p2.Add(p4);
            p2.Add(p5);
            p3.Add(p6);
            p4.Add(p6);
            napis = "";
            odwiedzone.Clear();
            //B(p1);
            //MessageBox.Show(napis);

         */
            var d = new DrzewoBinarne(5);
            d.Add(4);
            d.Add(4);
            d.Add(8);
            d.Add(7);
            d.Add(9);
            d.Add(5);
            d.Add(6);

            
            MessageBox.Show(d.ToString());
        }

        void A(Węzeł w)
        {
            MessageBox.Show(w.wartość.ToString());
            for (int i = 0; i < w.dzieci.Count; i++)
            {
                A(w.dzieci[i]);
            }
        }

        // DFS GRAF z cyklami
        string napis = "";
        List<Węzeł2> odwiedzone = new();

        void B(Węzeł2 w)
        {
            odwiedzone.Add(w);
            napis += w.wartość.ToString();
            foreach (var sąsiad in w.sąsiad)
            {
                if (!odwiedzone.Contains(sąsiad))
                {
                    B(sąsiad);
                }
            }
        }
        /*
        // BFS dla kazdego GRAFu: 5,2,1,4,8,3
        void C(Wezel3 start)
        {
            Queue<Wezel3> queue = new Queue<Wezel3>();
            HashSet<Wezel3> visited = new HashSet<Wezel3>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                Wezel3 current = queue.Dequeue();
                napis += current.ToString() + Environment.NewLine; // Dodaj wynik do napisu

                foreach (Wezel3 child in current.lewedziecko.Concat(current.prawedziecko))
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }
        }
        */
    }
}
public class Węzeł
{
    public int wartość;
    public List<Węzeł> dzieci = new List<Węzeł>();
    public Węzeł(int liczba)
    {
        this.wartość = liczba;
    }
}
public class Węzeł2
{
    public int wartość;
    public List<Węzeł2> sąsiad = new List<Węzeł2>();

    public Węzeł2(int liczba)
    {
        this.wartość = liczba;
    }
    public void Add(Węzeł2 s)
    {
        if (s == this)
        {
            return;
        }
        if (!this.sąsiad.Contains(s))
        {
            this.sąsiad.Add(s);
            s.sąsiad.Add(this);
        }
        if (!s.sąsiad.Contains(this))
        {
            s.sąsiad.Add(this);
        }
    }
}
public class Wezel3
{
    public int wartosc;
    public Wezel3 lewe;
    public Wezel3 prawe;
    public Wezel3 rodzic;

    public Wezel3(int wartosc)
    {
        this.wartosc = wartosc;
        this.prawe = null;
        this.lewe = null;
    }

    internal void Add(int a)
    {
        var dziecko = new Wezel3(a);
        dziecko.rodzic = this;
        if(a<this.wartosc)
        {
            this.lewe = dziecko;
        }
        else
        {
            this.prawe = dziecko;
        }
    }
    public override string ToString()
    {
        return this.wartosc.ToString();
    }
}
class DrzewoBinarne
{
    public Wezel3 korzen;
    public int LiczbaWezlow;
    public DrzewoBinarne(int liczba)
    {
        this.korzen= new Wezel3(liczba);
        this.LiczbaWezlow = 1;
    }

   public void Add(int a)
    {
        Wezel3 rodzic = this.ZnajdzRodzica(a);
        rodzic.Add(a);
    }

    private Wezel3 ZnajdzRodzica(int a)
    {
        var w = this.korzen;

        while(true)
        {
            if(a<w.wartosc)
            {
                if (w.lewe == null)
                {
                    return w;
                }
                else
                {
                    w = w.lewe;
                }
            }
            else
            {
                if (w.prawe == null)
                {
                    return w;
                }
                else
                {
                    w = w.prawe;
                }
            }
        }
    }

}
wezel3 znajdz(liczba)
   // podajesz i ma znalezc pierwsza znaleziona;
   // jak natrafi to ma zwrocic wezel z wartoscia a jak nie null
wezel3 znajdzmin(wezel3 w)
 //minimum idz do prawej od podanego wezla
    wezel3 znajdzmax(wezel3 w)
 //minimum idz do prawej od podanego wezla
wezel3 nastepny(wezel3 w)
    a) jest prawe dziecko(cos jak sortowanie)
    znajdz min na prawym dziecku
    b)nie ma dziecka prawego
    idz do gory tak dlugo az wyjdziesz jako lewe dziecko
    c)nie moge isc do gory lub wychodze jako ciagle prawe dziecko
