using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {

            var d = new DrzewoBinarne(5);
            d.Add(4);
            d.Add(4);
            d.Add(8);
            d.Add(7);
            d.Add(9);
            d.Add(5);
            d.Add(6);
                        
        }

        void A(Węzeł w)
        {
            MessageBox.Show(w.wartość.ToString());
            for (int i = 0; i < w.dzieci.Count; i++)
            {
                A(w.dzieci[i]);
            }
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
           
            List<Wezel4> wezly = new List<Wezel4>();
            List<Krawedz> krawedz = new List<Krawedz>();
            var w0 = new Wezel4(0);
            var w1 = new Wezel4(1);
            var w2 = new Wezel4(2);
            var w3 = new Wezel4(3);
            var w4 = new Wezel4(4);
            var w5 = new Wezel4(5);
            var w6 = new Wezel4(6);
            var w7 = new Wezel4(7);
            var k1 = new Krawedz(w4, w6, 1);
            var k2 = new Krawedz(w4, w5, 2);
            var k3 = new Krawedz(w2, w7, 3);
            var k4 = new Krawedz(w0, w6, 3);
            var k5 = new Krawedz(w2, w4, 4);
            var k6 = new Krawedz(w0, w1, 5);
            var k7 = new Krawedz(w2, w6, 5);
            var k8 = new Krawedz(w1, w5, 6);
            var k9 = new Krawedz(w5, w6, 6);
            var k10 = new Krawedz(w1, w7, 7);
            var k11 = new Krawedz(w1, w4, 8);
            var k12 = new Krawedz(w3, w6, 8);
            var k13 = new Krawedz(w0, w3, 9);
            var k14 = new Krawedz(w1, w2, 9);
            var k15 = new Krawedz(w2, w3, 9);
            var k16 = new Krawedz(w6, w7, 9);
            {
                wezly.Add(w0);
                wezly.Add(w1);
                wezly.Add(w2);
                wezly.Add(w3);
                wezly.Add(w4);
                wezly.Add(w5);
                wezly.Add(w6);
                wezly.Add(w7);
            }

            {
                krawedz.Add(k1);
                krawedz.Add(k2);
                krawedz.Add(k3);
                krawedz.Add(k4);
                krawedz.Add(k5);
                krawedz.Add(k6);
                krawedz.Add(k7);
                krawedz.Add(k8);
                krawedz.Add(k9);
                krawedz.Add(k10);
                krawedz.Add(k11);
                krawedz.Add(k12);
                krawedz.Add(k13);
                krawedz.Add(k14);
                krawedz.Add(k15);
                krawedz.Add(k16);
            }
            var graf1 = new Graf(wezly,krawedz);

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
    public Wezel3 lewe;//lewe dziecko
    public Wezel3 prawe;//prawe dziecko
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
        if (a < this.wartosc)
        {
            this.lewe = dziecko;
        }
        else
        {
            this.prawe = dziecko;
        }
    }
    public int GetLiczbaDzieci()
    {
        int wynik = 0;
        if (this.lewe != null)
        {
            wynik++;
        }
        if (this.prawe != null)
        {
            wynik++;
        }
    return wynik;
    }
    public override string ToString()
    {
        return this.wartosc.ToString();
    }

    /*
    public Wezel3 Znajdz(int liczba)
    {
        var obecny = this;

        while (obecny != null)
        {
            if (liczba == obecny.wartosc)
            {
                return obecny;
            }
            else if (liczba < obecny.wartosc)
            {
                obecny = obecny.lewe;
            }
            else
            {
                obecny = obecny.prawe;
            }
        }

        return null; // Zwróć null, jeśli liczba nie została znaleziona w drzewie.
    }
    public Wezel3 ZnajdzMin(Wezel3 w)
    {
        while (w.lewe != null)
        {
            w = w.lewe;
        }
        return w;
    }

    public Wezel3 ZnajdzMax(Wezel3 w)
    {
        while (w.prawe != null)
        {
            w = w.prawe;
        }
        return w;
    }
    public Wezel3 Nastepny(Wezel3 w)
    {
        if (w == null)
        {
            return null; // Jeśli węzeł jest null, to nie ma następnika
        }

        // a) Jest prawym dzieckiem - znajdź minimum na prawym poddrzewie
        if (w.prawe != null)
        {
            return ZnajdzMin(w.prawe);
        }

        // b) Nie ma dziecka prawego - idź do góry, aż znajdziesz się jako lewe dziecko
        while (w.rodzic != null && w == w.rodzic.prawe)
        {
            w = w.rodzic;
        }

        // c) Nie mogę iść w górę lub wychodzę jako ciągle prawe dziecko (brak następnika)
        return w.rodzic;
    }
    */
}

class DrzewoBinarne
{
    public Wezel3 korzen;
    public int LiczbaWezlow;
    public DrzewoBinarne(int liczba)
    {
        this.korzen = new Wezel3(liczba);
        this.LiczbaWezlow = 1;
    }

    public void Add(int a)
    {
        Wezel3 rodzic = this.ZnajdzRodzica(a);
        rodzic.Add(a);
    }

    public Wezel3 ZnajdzRodzica(int a)
    {
        var w = this.korzen;

        while (true)
        {
            if (a < w.wartosc)
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
    public Wezel3 Znajdz(int liczba)
    {
        var obecny = this.korzen;

        while (true)
        {
            if (liczba == obecny.wartosc)
                return obecny;
            if (liczba < obecny.wartosc)
            {
                if (obecny.lewe == null)
                    return null;
                else
                    obecny = obecny.lewe;
            }
            else
            {
                if (obecny.prawe == null)
                    return null;
                else
                    obecny = obecny.prawe;
            }

        }
    }

    public Wezel3 ZnajdzMin(Wezel3 w)
    {
        while (w.lewe != null)
            w = w.lewe;
        return w;
    }

    public Wezel3 ZnajdzMax(Wezel3 w)
    {
        while (w.prawe != null)
            w = w.prawe;
        return w;
    }
    public Wezel3 Nastepny(Wezel3 w)
    {
        if (w.prawe != null)
        {
            return this.ZnajdzMin(w.prawe);
        }

        while (w.rodzic != null)
        {
            if (w.rodzic.lewe == w)
            {
                return w.rodzic;
            }
            w = w.rodzic;

        }
        return null;
    }
    public Wezel3 Usun(Wezel3 w)
    {
        switch(w.GetLiczbaDzieci())
        {
            case 0:
                w = this.UsunGdy0Dzieci(w);
                    break;
            case 1:
                w = this.UsunGdy1Dzieci(w);
                    break;
            case 3:
                w = this.UsunGdy2Dzieci(w);
                    break;
        }
        return w;
    }

    private Wezel3 UsunGdy2Dzieci(Wezel3 w)
    {
        var zamiennik = this.Nastepny(w);
        if(zamiennik.GetLiczbaDzieci()==0)
        {
            zamiennik = this.UsunGdy0Dzieci(zamiennik);
        } 
        else
        {
            zamiennik = this.UsunGdy1Dzieci(zamiennik);
        }
        if(w.rodzic!=null)
        {
            if (w.rodzic.lewe==w)
            {
                w.rodzic.lewe = zamiennik;
            }
            else
            {
                w.rodzic.prawe = zamiennik;
            }
        }
        zamiennik.rodzic = w.rodzic;
        w.rodzic = null;
        //dalej opisz jak przepiac lewe na zamiennik i prawe na zamiennik, sprawdz czy jest to lewe czy prawe i sie z tym baw
        return w; //xd

    }

    private Wezel3 UsunGdy1Dzieci(Wezel3 w)
    {
        Wezel3 dziecko = null;
        if(w.lewe!=null)
        {
            dziecko = w.lewe;
            w.lewe = null;
        }
        else
        {
            dziecko = w.prawe;
            w.prawe = null;
        }
        dziecko.rodzic = w.rodzic;
        if(w.rodzic==null)
        {
            this.korzen = null;
            return w;
        }
        if(w.rodzic.lewe==w)
        {
            w.rodzic.lewe = dziecko;
        }
        else
        {
            w.rodzic.prawe = dziecko;
        }
        w.rodzic = null;
        return w;
    }

    private Wezel3 UsunGdy0Dzieci(Wezel3 w)
    {
        if (w.rodzic == null);
        {
            this.korzen = null;
            return w;
        }
        if(w.rodzic.lewe==w)
        {
            w.rodzic.lewe = null;
        }
        else
        {
            w.rodzic.prawe = null;
        }
        w.rodzic = null;
        return w;

    }
}
public class Wezel4
{
    int wartosc;
    public Wezel4(int wartosc)
    {
        this.wartosc = wartosc;
    }
    public override string ToString()
    {
        return this.wartosc.ToString();
    }
}
public class Krawedz
{
    int waga;
    public Wezel4 poczatek;
    public Wezel4 koniec;
    public Krawedz(Wezel4 w1,Wezel4 w2,int waga)
    {
        this.poczatek = w1;
        this.koniec = w2;
        this.waga = waga;
    }
}
public class Graf
{
 List<Wezel4>wezly=new List<Wezel4>();
 List<Krawedz>krawedz=new List<Krawedz>();
 public Graf(List<Wezel4> wezly, List<Krawedz> krawedz)
    {
        this.wezly = wezly;
        this.krawedz = krawedz;
    }
}
