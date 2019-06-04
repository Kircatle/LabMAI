#include <stdio.h>
#include <stdbool.h>
int max_size;
typedef struct
{
    char num;
    int next_index;
    int prev_index;
    int last_index;
    int first_index;
    int size;

} list;
int list_create(list* l) //Объявление списка
{
    for (int i = 0; i < max_size; i++)
        l[i].num=0;
    l->size=0;
    l->last_index=l->first_index=0;
}
int list_update(list *l, int size)  //обновление длины списка и связей
{
    int c=0;
    for (int i = 0; i < size; i++)
    {
        c++;
        if (size==1)
        {
            l[i].next_index=l[i].prev_index=i;
            l->first_index=i;
            l->last_index=i;
        }
        else if (i==0)
        {
            l[i].next_index=i+1;
            l[i].prev_index=size-1;
            l->first_index=i;
        }
        else if (i==size-1)
        {
            l[i].next_index=l->first_index;
            l[i].prev_index=i-1;
            l->last_index=i;
        }
        else
        {
            l[i].next_index=i+1;
            l[i].prev_index=i-1;
        }
    }
    l->size=c;
}
int list_next_elem(list* l, int i) //Итератор следующего элемента
{
    i=l[i].next_index;
    return i;
}
int list_prev_elem(list* l, int i) // Итератор предыдущего элемента
{
    i=l[i].prev_index;
    return i;
}
char list_fetch(list* l, int i) // Итератор, дающий значение по индексу
{
    return l[i].num;
}
void list_store(list* l, int i, char t) // Итератор, присваивающий значение по индексу
{
    l[i].num=t;
}
int list_first_elem(list* l) // Итератор, возвращающий первый элемент
{
    return l->first_index;
}
int list_last_elem(list* l) // Итератор, возвращающий последний элемент
{
    return l->last_index;
}
int list_size(list* l) //Итератор, возвращающий длину списка
{
    return l->size;
}
bool list_empty(list* l) //Итератор, проверяющий на пустоту список 
{
    if (l->size==0)
        return true;
    return false;
}
bool list_insert_elem(list *l, int i, char t) //вставка элемента в любую часть списка
{
    if (list_size(l)==max_size)
    {
        printf("\nПривышен максимальный размер списка!\n");
        return false;
    } 
    if (i>list_size(l))
    {
        printf("\nЭлемента с таким индексном не существует!\n");
        return false;
    }
    list_update(l, list_size(l)+1);
    if (i==0)
        list_store(l,list_size(l)-1, t);
    else
    {
            int c=i-1;
            for (int p=list_size(l)-1; p>=i; p--)
                list_store(l, p, list_fetch(l, list_prev_elem(l,p)));
            list_store(l,c,t);
    }
    return true;   
}
bool list_delete_elem(list* l, int i) //Удаление элемента из списка
{
    if (i>list_size(l))
    {
        printf("\nЭлемента с таким индексном не существует!\n");
        return false;
    }
    for (i; i<list_size(l); i++)
        list_store(l,i,list_fetch(l,list_next_elem(l,i)));
    list_store(l, list_size(l)-1, 0);
    list_update(l, list_size(l)-1);
    return true;
}
void list_print(list* l) //Печать списка
{
    printf("\n");
    for (int i = 0; i < list_size(l); i++)
    {
        printf(" %c ", list_fetch(l,i));
    }
    printf("\n");

}
bool list_delete_k_elem(list *l, int k)
{
    if (k==list_size(l))
        return false;
    else
        for (k; k>0; k--)
            list_delete_elem(l, list_last_elem(l));
    return true;
    
}
void list_destroy(list *l) //очистить список
{
    for (int i=0; i<max_size; i++)
        list_store(l, i, 0);
    l->size=0;
}
void print_menu()
{
    printf("\n1.Вставить элемент в конец списка \n2.Вставка элемента перед определенным элементом.\n3.Удаление элемента из списка.\n4.Удалить последние k элементов.\n5.Печать списка.\n6.Длина списка.\n7.Очистить список.\n\nВыберите действие: ");
}
void main()
{
    printf("Введите максимальный размер кольцевого двусвязного списка: ");
    scanf("%d", &max_size);
    list l[max_size];
    int act, position,k;
    char elem;
    list_create(l);
    print_menu();
    while(scanf("%d", &act)!=EOF)
    {
        switch(act)
        {
            case 1:
                    printf("\nЭлемент: ");
                    scanf("%c", &elem);
                    list_insert_elem(l, 0, elem);
            break;
            case 2:
                    printf("\nВыберите преред каким элементов вставить нужный(от 1): ");
                    scanf("%d", &position);
                    printf("\nЭлемент: ");
                    scanf("%c", &elem);
                    list_insert_elem(l, position, elem);
            break;
            case 3:
                printf("\nВыберите на какой позици удалить элемент(от 1): ");
                scanf("%d", &position);
                list_delete_elem(l, position-1);
            break;
            case 4:
                printf("\nk:");
                scanf("%d", &k);
                
            break;
            case 5:
                list_print(l);
            break;
            case 6:
                printf("\n%d\n",list_size(l));
            break;
            case 7:
                list_destroy(l);
            break;

        }
          print_menu();
    }
    printf("\n");
   
    
}
