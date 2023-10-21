int[] Selectsort(int[] tab)
        {
            int min = tab[0];
            int temp = 0;
            int ind = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                min = tab[i];
                ind = i;
                for (int j = i;  j < tab.Length; j++)
                {
                    if(tab[j] < min)
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
