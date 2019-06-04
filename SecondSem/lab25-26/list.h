#ifndef _list_h_
#define _list_h_
#include <stdio.h>
#include <stdbool.h>
int max_size; //максимальный размер спикска
typedef struct
{
    int num; //значение элемента
    int next_index; //следующий индекс
    int prev_index; //предыдущий интекс
    int last_index; //индекс последнего элемента
    int first_index; //индекс первого элемента
    int size; //длина списка

} list;

int list_create(list* l);  //Объявление списка
int list_update(list *l, int size);  //обновление длины списка
int list_next_elem(list* l, int i); //Итератор следующего элемента
int list_prev_elem(list* l, int i); // Итератор предыдущего элемента
int list_fetch(list* l, int i); // Итератор, дающий значение по индексу
void list_store(list* l, int i, int t); // Итератор, присваивающий значение по индексу
int list_first_elem(list* l); // Итератор, возвращающий первый элемент
int list_last_elem(list* l); // Итератор, возвращающий последний элемент
int list_size(list* l); //Итератор, возвращающий длину списка
bool list_empty(list* l); //Итератор, проверяющий на пустоту список 
bool list_delete_elem(list* l, int i); //Удаление элемента из списка
void list_print(list* l); //Печать списка
void list_destroy(list *l); //очистить список
void elem_sort(list* l, int newElement); // кидает полученный элемент на нужное место(сортировка вставками)
void list_good_insert(list* mass, int newElement); //Вставка элемента в список в правильном порядке
void print_menu(); // печать меню
#endif