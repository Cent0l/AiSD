namespace WinFormsApp1
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
        private void button1_Click(object sender, EventArgs e)
        {
            int a = 2137;
            int b = 4412563;
            MessageBox.Show(AddingUnderKreska(a, b).ToString());
            MessageBox.Show((a + b).ToString());
        }
        private void btnSortowanie_Click(object sender, EventArgs e)
        {
            int[] tab = new int[]  { 7, 2, 5, 4, 1 };
            String tabs = tostring(tab);
            //Bubblesort(tab);
            int[] bubul = Bubblesortint(tab);
            String bubuls = tostring(bubul);
            //MessageBox.Show(tabs);
            //MessageBox.Show(bubuls);
            lbl2.Text = tabs;
            lbl1.Text = bubuls;

        }
        String tostring(int[] tab)
        {
            String ret = "";
            for(int i=0;i<tab.Length;i++)
            {
                ret=ret+tab[i]+" ";
            }
            return ret;
        }
        int[] Selectsort(int[] tab)
        {
            int min = tab[0];
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j=0;j<tab.Length;j++)
                {
                    

                }
            }

        }
        void Bubblesort(int[] tab)
        {
            int temp = tab[1];
            int change = 1;
            while (change > 0)
            {
                change = 0;
                for (int i = 1; i < tab.Length; i++)
                {
                    if (tab[i] < tab[i - 1])
                    {
                        temp = tab[i];
                        tab[i] = tab[i - 1];
                        tab[i - 1] = temp;
                        change++;
                    }
                }   
            }
            
        }
        int[] Bubblesortint(int[] tab)
        {
            int temp = tab[1];
            int change = 1;
            while (change > 0)
            {
                change = 0;
                for (int i = 1; i < tab.Length; i++)
                {
                    if (tab[i] < tab[i - 1])
                    {
                        temp = tab[i];
                        tab[i] = tab[i - 1];
                        tab[i - 1] = temp;
                        change++;
                    }
                }
            }
            return tab;
        }

        int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
        long Fib2(int n)
        {
            if (n == 0 || n == 1)
                return n;

            long[] wyrazy = new long[n + 1];
            wyrazy[1] = 1;
            for (int i = 2; i < wyrazy.Length; i++)
            {

                wyrazy[i] = wyrazy[i - 1] + wyrazy[i - 2];
            }
            return wyrazy[n];

        }

        int AddingUnderKreska(int a, int b)
        {
            int[] A = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] B = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] wynik = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int ret = 0;
            for (int i = 0; a > 0; i++)
            {
                A[i] = a % 10;
                a = a / 10;
            }
            for (int i = 0; b > 0; i++)
            {
                B[i] = b % 10;
                b = b / 10;
            }
            for (int i = 0; i < 10; i++)
            {
                wynik[i] = wynik[i] + A[i] + B[i];
                if (wynik[i] > 10)
                {
                    wynik[i] = wynik[i] % 10;
                    wynik[i + 1] = wynik[i + 1] + 1;
                }
            }
            int pot = 1;
            for (int i = 0; i < 10; i++)
            {
                ret = ret + wynik[i] * pot;
                pot = pot * 10;
            }
            return ret;

        }
        private void nudLiczbaN_ValueChanged(object sender, EventArgs e)
        {

        }
        private void lbl1_Click(object sender, EventArgs e)
        {
            
        }
        private void lbl2_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }
    }
}
