#include <stdio.h>
const int maxn = 9;
int main()
{
    int max=-2147483648,n,i=1,j=1,l,array[maxn][maxn];
    printf("Введите ранг матрицы: ");
    while (scanf("%d",&n)!=EOF)
    {  
        if (n<=8&&n>0)
        {
            printf("\nВведите матрицу\n");
            for (i=1; i<=n; i++)
                for (j=1;j<=n;j++)
                    scanf("%d", &array[i][j]);
             printf("\nВы ввели: \n");
            for (int i=1; i<=n; i++)
            {
                printf("\n");
                for (int j=1; j<=n; j++)
                    printf("%4d ",array[i][j] );
            }
            printf("\n"); 
            printf("\nРезультат:\n");
            for (i=1; i<=n; i++)
                for (j=1;j<=n;j++)
                    if (i==j)
                    {
                        for (l=i; l<=n; l++)
                            if (array[l][j]>max)
                                max = array[l][j];
                    }            
            for (i=1; i<=n; i++)
                for (j=1;j<=n;j++)
                    if (i==j)
                    {
                        for(l=i; l>=1; l--)
                            array[l][j]=array[l][j]*max;
                    }
            for (i=1; i<=n; i++)
                for (j=1;j<=n;j++)
                    if (j==1)
                    {
                        printf("\n%4d ", array[i][j]);
                    }
                    else 
                    {
                        printf("%4d ", array[i][j]);
                    }
            
            printf("\n");
        } 
        else printf("\nНесоответствует требованиям\n");
        max = -2147483648;
        printf("\nВведите ранг матрицы: ");
    }   
    printf("EOF\n");
}