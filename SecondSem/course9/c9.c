#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define COMPARE(a, b) ((a > b) - (a < b))
typedef struct 
{
    int keyint;
    char keychar;
}t_intchar_key;

typedef struct 
{
    char verse[100];
} t_input;

typedef struct 
{
    t_intchar_key key;
    int index;
} t_table;
void destroy_table(t_table *table)
{
    for (int i = 0; i < 12; i++)
    {
        table[i].key.keychar=0;
        table[i].key.keyint=0;
        table[i].index=0;
    }
    
}
void destroy_input(t_input *input)
{
    for (int i = 0; i < 12; i++)
        input[i].verse[0]=0;
}
void enter(FILE * f, t_table *table, t_input *input, int *count_lines)
{
    fseek(f, 0L, SEEK_SET);
    while (fscanf(f, "%d %c %s", &table[*count_lines].key.keyint, &table[*count_lines].key.keychar, input[*count_lines].verse) != EOF)
    {
        table[*count_lines].index = *count_lines;
        ++(*count_lines);
    }
}
int shell_sort(int n, t_table *table)
{
    int i, j, step;
    int tmp, tmp2;
    char tmp1;
    for (step = n / 2; step > 0; step /= 2)
        for (i = step; i < n; i++)
        {
            tmp = table[i].key.keyint;
            tmp1 = table[i].key.keychar;
            tmp2= table[i].index;
            for (j = i; j >= step; j -= step)
            {
                if (tmp < table[j - step].key.keyint)
                    table[j] = table[j - step];
                else if (tmp == table[j - step].key.keyint && tmp1 < table[j - step].key.keychar)
                    table[j] = table[j - step];
                else
                    break;
            }
            table[j].key.keyint = tmp;
            table[j].key.keychar = tmp1;
            table[j].index=tmp2;
        }
    return 1;
}
int compare_keys(const t_intchar_key *key1, const t_intchar_key *key2)
{
  int cmp;
  if ((cmp = COMPARE(key1->keyint, key2->keyint)) != 0)
    return cmp;
  if ((cmp = COMPARE(key1->keychar, key2->keychar)) != 0)
    return cmp;
  return 0;
}
int binarysearch(int a, char c, const t_table *table, int n)
{
    int low = 0, high = n - 1;
    const t_intchar_key key = { a, c };

    while (low <= high)
    {
        int middle = (low + high) / 2;
        int cmp = compare_keys(&key, &table[middle].key);
        if (cmp < 0)
            high = middle - 1;
        else if (cmp > 0)
            low = middle + 1;
        else 
            return middle;
    }
    return -1;
}
void swap_table(t_table *x, t_table *y)
{
    t_table z = *x;
    *x = *y;
    *y = z;
}
void reverse_table(t_table *table, int count_lines)
{
    for (int i = 0; i < count_lines / 2; ++i)
        swap_table(&table[i], &table[count_lines - i - 1]);
}
void random_keys(t_table *table, int count_lines)
{
    for (int i = 0; i < count_lines; ++i)
    {
        int rand_key = rand() % count_lines;
        swap_table(&table[i], &table[rand_key]);
    }
}
void print_table(int count_lines, t_table *table, t_input *input)
{
    printf("\n|  key  | Verse\n");
    printf("----------------------------------------------------------------------\n");
    for (int i = 0; i < count_lines; i++)
        {
            printf("|  %d %c  |%s\n", table[i].key.keyint, table[i].key.keychar, input[table[i].index].verse);
            printf("----------------------------------------------------------------------\n");
        }
    printf("\n");
}
void print_menu()
{
    printf("1.Обновить таблицу.\n2.Отсортировать таблицу.\n3.Поиск по ключу.\n4.Реверс таблицы.\n5.Случайные ключи.\n6.Печать таблицы.\n7.Выход.\nВыберите действие: ");
}
void main()
{
    t_table table[12];
    t_input input[12];
    int bi, count_lines=0, act, a,cs;
    char filename[15],c;
    printf("Введите название файла с таблицей: ");
    scanf("%s", filename);
    FILE* f=fopen(filename, "rb");
    count_lines=0;
    enter(f, table, input, &count_lines);
    print_menu();
    while (scanf("%d", &act)!=EOF)
    {
        printf("\n");
        switch (act)
        {
        case 1:
            fclose(f);
            count_lines=0; cs=0; bi=0;
            printf("\nВведите название нового файла:");
            scanf("%s", filename);
            f=fopen(filename, "rb");
            enter(f,table,input,&count_lines);
            print_menu();
            break;
        case 2:
            cs=shell_sort(count_lines, table);
            print_menu();
            break;
        case 3:
            printf("\n");
            printf("Введите ключ: ");
            scanf("%d", &a);
            scanf("%c", &c);
            bi=binarysearch(a,c, table, count_lines);
            if (cs!=1)
                printf("\nСначала отсортеруйте таблицу\n");
            else if (bi==-1)
                printf("\nТакого элемента не существует!\n");
            else
                printf("|  %d %c  |%s\n", table[bi].key.keyint, table[bi].key.keychar, input[table[bi].index].verse);
            print_menu();
            break;
        case 4:
            reverse_table(table, count_lines);
            print_menu();
            break;
        case 5:
            random_keys(table, count_lines);
            print_menu();
            break;
        case 6:
            print_table(count_lines, table, input);
            print_menu();
            break;
        case 7:
            exit(0);
            break;
        default:
            printf("\nПожалуйста, выберите одно из доступных действий!\n");
            print_menu();
            break;
        }
    }
    fclose(f);
}
