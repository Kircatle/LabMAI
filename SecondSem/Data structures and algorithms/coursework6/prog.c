#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "pass.h"
int table(int argc, char* argv[])   //Проверяет наличие аргумента "-f", который отвечает за отображение таблицы.
{
    for (int n = 1; n<argc; n++) 
    {
        if (strcmp(argv[n], "-f")==0)
            return 1;
    }
    return 0;
}
int work(int argc, char* argv[]) // Проверяет наличие аргумента "-p", который отвечает за выполнение задания.
{
    for (int n = 1; n<argc; n++) 
    {
        if (strcmp(argv[n], "-p")==0)
            return 1;
    }
    return 0;
}
int medium(char* argv) // ноходит среднее арифметическое общего кол-ва вещей.
{
    pass p;
    FILE *input;
    input=fopen(argv, "rb");
    int medium = 0;
    int n=0;
    while (fread(&p, sizeof(p), 1, input) == 1)
    {
        medium+=p.num_cloth;
        n++;
    }
    fclose(input);
    return medium=medium/n;
}
void printtable(int argc, char* *argv) //печатает таблицу, если найден аргумент "-f"
{
    if (table(argc, argv)==1)
    {
        pass p;
        FILE *input;
        input=fopen(argv[1], "rb");
        int k=0;
        while (k<76)
            {
                k++;
                printf("-");
            }
        printf("\n| \tИмя\t |Вещи|   Вес   |\tточка\t |время| Пересадки |  Дети |\n");
        int l = 1;
        while (l<77)
        {
            l++;
            printf("-");
        }
        while (fread(&p, sizeof(p), 1, input) == 1)
        { 
            printf("\n|%12s %3s|%3d |%3.3f\t| %14s |%5s|\t%3s|\t%3s|\n", p.name, p.initials, p.num_cloth, p.weight_cloth, p.point, p.time, p.trans, p.childs);
            int s = 1;
            while (s<77)
            {
                s++;
                printf("-");
            }
        }
        printf("\n");
        fclose(input); 
    }
}
void printwork(int argc, char* *argv) //Выполняет задание, если найден аргумент -p и корректно задан параметр p.
{
    if (work(argc, argv)==1)
    {
        printf("\n");
        pass p;
        FILE *input;
        int count;
        input=fopen(argv[1], "rb");
        count=atoi(argv[3]);
        while (fread(&p, sizeof(p), 1, input) == 1)
        {
            if (p.num_cloth-count>=medium(argv[1]))
            printf("%s %s\n", p.name, p.initials);
        }
        fclose(input);
    }
}
void main(int argc, char* argv[])
{
    printtable(argc, argv);
    printwork(argc, argv);
}