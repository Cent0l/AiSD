namespace dsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            String strdef = tb_1.Text;
            int[] tab = fromstring(strdef);
            int[] bubble = bubblesort(tab);
            int[] ins = insertsort(tab);
            lbl_1.Text = tostring(ins);

        }
        int[] bubblesort(int[] tab)
        {
            int temp = tab[1];
            int change = 0;
            do
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
            while (change > 0);
            return tab;
        }
        int[] insertsort(int[] tab)
        {
            int n = tab.Length;
            for (int i = 1; i < n; i++)
            {
                int temp = tab[i];
                int j = i - 1;
                while (j >= 0 && tab[j] > temp)
                {
                    tab[j + 1] = tab[j];
                    j = j - 1;
                }
                tab[j + 1] = temp;
            }
            return tab;
        }

        int[] fromstring(String napis)
        {
            var liczbyS = napis.Trim().Split(' ');//var domysla sie ze to tablica stringow a to wynika z prawej strony
            int[] liczby = new int[liczbyS.Length];
            for (int i = 0; i < liczbyS.Length; i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;
        }
        String tostring(int[] tab)
        {
            String ret = "";
            for (int i = 0; i < tab.Length; i++)
            {
                ret = ret + tab[i] + " ";
            }
            return ret;
        }
        

        private void tb_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_1_Click(object sender, EventArgs e)
        {

        }
    }
}
