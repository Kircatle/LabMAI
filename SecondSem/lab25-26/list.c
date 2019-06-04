#include <stdio.h>
#include <stdbool.h>
int max_size;
typedef struct 
{
    int keyint;
    int num;
}t_data;
typedef struct
{
    t_data key;
    int next_index;
    int prev_index;
    int last_index;
    int first_index;
    int size;

} list;
int list_create(list* l) //Объявление списка
{
    for (int i = 0; i < max_size; i++)
        { 
            l[i].key.num=0;
            l[i].key.keyint=i;
        }
    l->size=0;
    l->last_index=l->first_index=0;
}
int list_update(list *l, int size)  //обновление длины списка
{
    int c=0;
    for (int i = 0; i < size; i++)
    {
        c++;
        if (i==0)
        {
            l[i].next_index=i+1;
            l[i].prev_index=-1;
            l->first_index=i;
        }
        else if (i==size-1)
        {
            l[i].next_index=i+1;
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
int list_fetch(list* l, int i) // Итератор, дающий значение по индексу
{
    return l[i].key.num;
}
void list_store(list* l, int i, int t, int key) // Итератор, присваивающий значение по индексу
{
    l[i].key.num=t;
    l[i].key.keyint=key;
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
bool list_delete_elem(list* l, int i) //Удаление элемента из списка
{
    if (i>list_size(l))
    {
        printf("\nЭлемента с таким индексном не существует!\n");
        return false;
    }
    for (i; i<list_size(l); i++)
        list_store(l,i,list_fetch(l,list_next_elem(l,i)), i);
    list_store(l, list_size(l)-1, 0, 0);
    list_update(l, list_size(l)-1);
    return true;
}
void list_print(list* l) //Печать списка
{
    printf("\n");
    for (int i = 0; i < list_size(l); i++)
    {
        printf(" %d ", list_fetch(l,i));
    }
    printf("\n");

}
void list_destroy(list *l) //очистить список
{
    for (int i=0; i<max_size; i++)
        list_store(l, i, 0,0);
    l->size=0;
}

void elem_sort(list* l, int newElement) //вставка элемента в правильном порядке
{
    int location=list_size(l)-1;
    while(location > list_first_elem(l) && list_fetch(l, list_prev_elem(l, location))> newElement)
    {
        list_store(l, location, list_fetch(l, list_prev_elem(l, location)), location);
        location=list_prev_elem(l, location);
    }
    list_store(l, location, newElement, location);
}
void list_good_insert(list* l, int newElement) //вставка элемента
{
    list_update(l, list_size(l)+1);
    list_store(l,list_size(l)-1, newElement, list_size(l)-1);
    elem_sort(l, newElement);
}
void print_menu()
{
    printf("\n1.Вставить элемент в список с соблюдением порядка. \n2.Удалить элемент из списка\n3.Печать списка.\n4.Длина списка.\n5.Очистить список.\nВыберите действие: ");
}