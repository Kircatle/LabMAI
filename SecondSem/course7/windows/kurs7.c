#include <stdio.h>
#include <stdlib.h>
double zero=0; 
int count_all_elem(FILE *input)  // Количество элементов в матрице
{
   fseek(input, 0L, SEEK_SET);
   double sym;
   int i=0;
   while(fscanf(input,"%lf", &sym)!=EOF)
        i++;
    return i;
}
int count_line(FILE *input) //Количество строк в матрице
{
    fseek(input, 0L, SEEK_SET);
    int ch, count=0;
    while ( (ch=fgetc(input)) != EOF )
        if ( ch == '\n' )
            ++count;
    return count+1;
}
int count_column(FILE *input) //Количество столбцов в матрице
{
    fseek(input, 0L, SEEK_SET);   
    return count_all_elem(input)/count_line(input);
}
void matrix_to_vector(double *matrix, FILE *input) //перевод матрицу в векторное представление
{
    for (int i=0; i<302; i++)
        matrix[i]=0;
    int column=count_column(input);
    fseek(input, 0L, SEEK_SET);
    int num_elem_in_string=1, i=1, num_string=1;
    double sym;
    while(fscanf(input,"%lf", &sym)!=EOF)
    {
        if (num_elem_in_string>=column)
        {
            if (sym!=0)
            {
                matrix[i]=num_elem_in_string;
                matrix[i+1]=sym;
                i+=2;
                num_elem_in_string=1;
            }
            else 
                num_elem_in_string=1;  
        }
        else if (num_elem_in_string==1)
        {
            if (sym!=0)
            {
                matrix[i]=0;
                matrix[i+1]=num_string;
                matrix[i+2]=num_elem_in_string;
                matrix[i+3]=sym;
                i+=4;
                num_elem_in_string++; 
                num_string++;
            }
            else 
            {
                matrix[i]=0;
                matrix[i+1]=num_string;
                i+=2;
                num_elem_in_string++;
                num_string++;                    
            }
        }
        else if (num_elem_in_string!=1)
        {
            if (sym!=0)
            { 
                matrix[i]=num_elem_in_string;
                matrix[i+1]=sym;
                i+=2;
                num_elem_in_string++;
            }
            else
                num_elem_in_string++;
        } 
    }
}
int size(double *matrix, FILE *input) // размер матрицы, записанной в векторе
{
    int size_matrix=1;
    while (matrix[size_matrix]!=0 || matrix[size_matrix+1]!=0)
        size_matrix++;
    return size_matrix+2;
}
void print_matrix(double *matrix, FILE *input) //Печать матрицы в обычном виде, пользуясь данными только из векторного представления
{
    int size_matrix=size(matrix, input);
    int max_line=1, i=1, max_column=1, res=0;
    for (int i=1; i<size_matrix; i++) 
        if (matrix[i]==0 && matrix[i+1]>max_line)
            max_line=matrix[i+1];
     for (int i=1; i<size_matrix; i+=2) 
        if (matrix[i]>max_column)
            max_column=matrix[i];
    for (int f=1; f<=max_line; f++)
    {
        printf("\n");
        do
        {
            i+=2;
            if (matrix[i]-matrix[i-2]==1) 
            {
                printf(" %4.1lf ", matrix[i+1]);
            }
            else if (matrix[i]-matrix[i-2]>1)
            {
                double count=matrix[i]-matrix[i-2];
                for(int k=1; k<count; k++)
                    printf(" %4.1lf ", zero);
                printf(" %4.1lf ", matrix[i+1]);
            }
            else if (matrix[i]==0 && matrix[i-2]!=max_column)
            {
                res=max_column-matrix[i-2]+1;
                for(int o=1; o<res; o++)
                    printf(" %4.1lf ", zero);
            } 
        }
        while (matrix[i]!=0);
    }
    printf("\n");
}
void print_array(double *matrix, FILE *input) //Печать матрицы в векторном представлении
{
    int size_matrix=size(matrix, input);
    printf("\n");
    for (int l=1; l<size_matrix; l++)
        printf("%4.1lf ", matrix[l]);
        printf("\n");
}
void vector_trans(double *matrix, FILE *input) //нахождение строк с наибольшим числом элементов относительно вектора. 
{
    double summ[100];
    int count[100];
    for(int i = 0; i < 100; i++)
    {
        count[i]=0;
        summ[i]=0;
    }
    int size_matrix=size(matrix, input), max_line=1;
    for (int i=1; i<size_matrix; i++) 
        if (matrix[i]==0 && matrix[i+1]>max_line)
            max_line=matrix[i+1];
    int l=1,string=0;
    for(int a = 1; a < max_line+1; a++)
    {
        string++; 
        do
        {
        
            l+=2;
            if (matrix[l]!=0)
            {
                count[string]++;
                summ[string]+=matrix[l+1];
            }
        }
        while (matrix[l]!=0);
    }
      int max=0;
    for(int i = 1; i < 100; i++)
        if (count[i]>max)
            max=count[i];
    for(int i = 1; i < 100; i++)
        if (count[i]==max && max!=0)
            printf("\nНомер строки: %d; Сумма элементов: %4.1lf", i, summ[i]);
        else if (max==0)
            {
                printf("\nОшибка: Нулевая матрица!");
                break;
            }
        printf("\n"); 
}
void matrix_trans(FILE *input) //нахождение строк с наибольшим числом элементов относительно матрицы
{
     double sym, summ[100];
    int count[100];
    for(int i = 0; i < 100; i++)
    {
        count[i]=0;
        summ[i]=0;
    }
    int max=0, k=0, line = 1, column=count_column(input);
    fseek(input, 0L, SEEK_SET);
    while(fscanf(input,"%lf", &sym)!=EOF)
    {
        k++;
        if (k>column)
        {
            k=1;
            line++;
        }
        if (sym!=0) 
        {
            count[line]++;
            summ[line]+=sym;
        }
    }
    for(int i = 1; i < 100; i++)
        if (count[i]>max)
            max=count[i];
    for(int i = 1; i < 100; i++)
        if (count[i]==max && max!=0)
            printf("\nНомер строки: %d; Сумма элементов: %4.1lf", i, summ[i]);
        else if (max==0)
            {
                printf("\nОшибка: Нулевая матрица!");
                break;
            }
        printf("\n"); 
}
void print_menu()
{
    printf("\n 1. Вывести матрицу в векторном представлении. \n 2. Вывести матрицу, используя векторное представление. \n 3. Нахождение строк с наибольшим числом элементов, используя векторное представление. \n 4. Нахождение строк с наибольшим числом элементов, используя обычное представление\n 5. Выйти из программы. \n Выберите действие: ");  
}
void action_menu(FILE *input)
{
    double matrix[320];
    matrix_to_vector(matrix, input);
    print_menu();
    int act;
    while(scanf("%d", &act)!=EOF)
    {
        switch (act)
        {
            case 1:
                print_array(matrix, input);
                break;
            case 2:
                print_matrix(matrix, input);
                break;
            case 3:
                vector_trans(matrix, input);
                break;
            case 4:
                matrix_trans(input);
                break;
            case 5:
                exit(0);
                break;
            default:
                printf("\nПожалуйста, выберите один из представленных пунктов меню!\n");
                break;
        }
        printf("\n Выберите действие:");
    }
}
int main(int argc, char* *argv)
{
    FILE *input=fopen(argv[1], "r");
    action_menu(input);  
    fclose(input);
}
