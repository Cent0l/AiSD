using System.Numerics;

namespace AiSD_Zaj_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int LiczbaN = (int)nudLiczbaN.Value;
            long wynik = Fib2(LiczbaN);
            MessageBox.Show(wynik.ToString());
            
          
       
        }
        int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
        long Fib2(int n)
        {
            if ( n == 0 || n==1 )
                return n;

            long[] wyrazy = new long[n+1];
            wyrazy[1] = 1;
            for (int i=2;i<wyrazy.Length;i++)
            {
                
                wyrazy[i] = wyrazy[i-1]+wyrazy[i-2];
            }
            return wyrazy[n];
        }
        private void nudLiczbaN_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}