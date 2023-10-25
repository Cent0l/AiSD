namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            String strdef = tb_input.Text;
            int[] tab = fromstring(strdef);
            int[] ret = Selectsort(tab);
            int[] ret2 = Bubblesort(tab);
            int[] ret3 = Insertsort(tab);
            String str1 = tostring(ret);
            String str2 = tostring(ret2);
            String str3 = tostring(ret3);
            lbl_1.Text = str1;
            lbl_2.Text = str2;
            lbl_3.Text = str3;
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
        int[] fromstring(String napis)
        {
            var liczbyS = napis.Trim().Split(' ');//var domysla sie ze to tablica stringow a to wynika z prawej strony
            int[] liczby=new int[liczbyS.Length];
            for(int i=0;i<liczbyS.Length; i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;
        }
        int[] Bubblesort(int[] tab)
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
        int[] Selectsort(int[] tab)
        {
            int min = tab[0];
            int temp = 0;
            int ind = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                min = tab[i];
                ind = i;
                for (int j = i; j < tab.Length; j++)
                {
                    if (tab[j] < min)
                    {
                        min = tab[j];
                        ind = j;

                    }

                }
                temp = tab[i];
                tab[i] = min;
                tab[ind] = temp;
            }
            return tab;
        }

        int[] Insertsort(int[] tab)
        {
            int min = tab[0];
            int temp = 0;
            int ind = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                min = tab[i];
                ind = i;
                for (int j = i; j < tab.Length; j++)
                {
                    if (tab[j] < min)
                    {
                        temp = tab[i];
                        tab[i] = min;
                        tab[ind] = temp;

                    }

                }
                
            }
            return tab;
        }
        private void tb_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_1_Click(object sender, EventArgs e)
        {

        }
    }
}
