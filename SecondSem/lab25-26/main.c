#include <stdio.h>
#include <stdbool.h>
#include "list.h"
int main()
{
    printf("Введите максимальный размер линейного списка: ");
    scanf("%d", &max_size);
    list l[max_size];
    int act, elem, position;
    list_create(l);
    print_menu();
    while(scanf("%d", &act)!=EOF)
    {
        switch(act)
        {
            case 1:
                printf("\nЭлемент: ");
                scanf("%d", &elem);
                list_good_insert(l, elem);
            break;
            case 2:
                printf("\nВыберите на какой позици удалить элемент(от 1): ");
                scanf("%d", &position);
                list_delete_elem(l, position-1);
            break;
            case 3:
                list_print(l);
            break;
            case 4:
                printf("\n%d\n",list_size(l));
            break;
            case 5:
                 list_destroy(l);
            break;
        }
          print_menu();
    }
    printf("\n");
   
    
}