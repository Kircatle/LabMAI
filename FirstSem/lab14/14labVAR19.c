#include <stdio.h>
const int maxn = 8;
int main()
{
    int n,i=1,j=1,l=1,k=1,array[maxn][maxn];
    printf("Введите ранг матрицы: ");
    while (scanf("%d",&n)!=EOF)
    {  
        if (n<=7&&n>0)
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
                    printf("%3d ",array[i][j] );
            }
            printf("\n");                  
            printf("Результат:");
            for (i=1; i<=n; i++)
                for (j=1;j<=n;j++)
                    if (i==j)
                    {
                        if (i==1) 
                            printf(" %d ", array[i][j]);
                        else if (i%2==0)
                        {
                            for (l=1; l<=i; l++)
                                printf(" %d ", array[l][j]); 

                            for (k=j-1; k>=1; k--)
                                printf(" %d ", array[i][k]); 
                        }
                        else if (i%2!=0)
                        {
                            for (k=1; k<=j; k++)
                                printf(" %d ", array[i][k]);
                            for (l=i-1; l>=1; l--)
                                printf(" %d ", array[l][j]);
                        }
                    }
            printf("\n");
        } 
        else printf("\nНесоответствует требованиям\n");
        printf("\nВведите ранг матрицы ");
    }   
    printf("EOF\n");
}
