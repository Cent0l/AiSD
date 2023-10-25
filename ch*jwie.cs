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
            String str1 = "5 4 3 7 2";
            int[] tab = fromstrign(str1);
            tb_2.Text = str1;
            int[] ret = Selectsort(tab);
            String str2 = tostring(ret);
            tb_1.Text = str2;
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
        int[] fromstrign(String napis)
        {
            var liczbyS = napis.Trim().Split(' ');
            int[] liczby=new int[liczbyS.Length];
            for(int i=0;i<liczbyS.Length; i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;
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

        private void tb_1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
