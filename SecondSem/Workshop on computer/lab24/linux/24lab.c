#include <string.h>
#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#define is_operator(c) (c == '+' || c == '-' || c == '/' || c == '*' || c == '^')
#define is_ident(c) ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z'))
struct stack_item_string  // функции для стека строк
{
     char data[40];
     struct stack_item_string* prev;
};
typedef struct
{
    struct stack_item_string* top;
    int size;
}stack_string;
void create_stack_string(stack_string *s) // присвоить начальные значения
{
    s->size=0;
    s->top=0;
}
bool empty_stack_string(stack_string* s) // проверка на пустоту
{
    return s->top==0;
}
int size_stack_string(stack_string* s) // размер стека
{
    return s->size;
}
bool push_in_stack_string(stack_string* s, char* data) // занос нового элемента в стек
{
    struct stack_item_string* tmp = malloc(sizeof(struct stack_item_string));
    if(!tmp)
        return false;
    strcpy(tmp->data,data);
    tmp->prev=s->top;
    s->top=tmp;
    s->size++;
    return true;
}
bool pop_from_stack_string(stack_string* s) // изъятие первого элемента из стека
{
    if (!s->size)
        return false;
    struct stack_item_string* tmp = s->top;
    s->top=s->top->prev;
    s->size--;
    free(tmp);
    return true;
}
char* top_stack_string(stack_string* s) // первый элемент
{
    if(s->top)
        return s->top->data;
}

void destroy_stack_string(stack_string* s) // удалить стек
{
    while(s->top)
    {
        struct stack_item_string* tmp=s->top;
        s->top=s->top->prev;
        free(tmp);
    }
    s->top=0;
    s->size=0;
}
void reverse_stack_string(stack_string *s) // отразить стек
{
    stack_string tmp1;
    stack_string tmp2;
    create_stack_string(&tmp1);
    create_stack_string(&tmp2);
    while (!empty_stack_string(s))
    {
        push_in_stack_string(&tmp1, top_stack_string(s));
        pop_from_stack_string(s);
    }
    while (!empty_stack_string(&tmp1))
    {
        push_in_stack_string(&tmp2, top_stack_string(&tmp1));
        pop_from_stack_string(&tmp1);
    }
    while (!empty_stack_string(&tmp2))
    {
        push_in_stack_string(s, top_stack_string(&tmp2));
        pop_from_stack_string(&tmp2);
    }
    destroy_stack_string(&tmp1);
    destroy_stack_string(&tmp2);
}
int priority(const char c) // Приоритеты операторов
{
    switch(c)
    {
        case '^':
        return 4;

        case '*':
        case '/':
        return 3;

        case '+':
        case '-':
        return 2;
    }
    return 0;
}

bool op_left_assoc(const char c)
{
    switch(c)
    {
        // лево-ассоциативные операторы
        case '*':
        case '/':
        case '+':
        case '-':
        return true;
        // право-ассоциативные операторы
        case '^':
        return false;
    }
    return false;
}
bool infix_to_postfix_algorithm(const char *input, char *output, int size_input)
{
    const char *strpos = input, *strend = input + strlen(input);
    char c, stack[size_input], sc, *outpos = output;
    unsigned int sl = 0;
    while(strpos < strend)
    {
        c = *strpos;
        if(c != ' ')
        {
            // Если токен является числом (идентификатором), то добавить его в очередь вывода.
            if(is_ident(c))
            {
                *outpos = c; ++outpos;
            }
            // Если токен оператор op1, то:
            else if(is_operator(c))
            {
                *outpos=' '; ++outpos;
                while(sl > 0)
                {
                    sc = stack[sl - 1];
                    // Пока на вершине стека присутствует токен оператор op2,
                    // а также оператор op1 лево-ассоциативный и его приоритет меньше или такой же чем у оператора op2,
                    // или оператор op1 право-ассоциативный и его приоритет меньше чем у оператора op2
                    if(is_operator(sc) &&
                        ((op_left_assoc(c) && (priority(c) <= priority(sc))) ||
                           (!op_left_assoc(c) && (priority(c) < priority(sc)))))
                    {
                        // Переложить оператор op2 из стека в очередь вывода.
                        *outpos=' '; ++outpos;
                        *outpos = sc; ++outpos;
                        sl--;
                    }
                    else
                    {
                        break;
                    }
                }
                // положить в стек оператор op1
                *outpos=' '; ++outpos;
                stack[sl] = c;
                ++sl;
            }
            // Если токен - левая круглая скобка, то положить его в стек.
            else if(c == '(')
            {
                stack[sl] = c;
                ++sl;
            }
            // Если токен - правая круглая скобка:
            else if(c == ')')
            {
                bool pe = false;
                // До появления на вершине стека токена "левая круглая скобка"
                // перекладывать операторы из стека в очередь вывода.
                while(sl > 0)
                {
                    sc = stack[sl - 1];
                    if(sc == '(')
                    {
                        pe = true;
                        break;
                    }
                    else
                    {
                        *outpos=' '; ++outpos;
                        *outpos = sc; ++outpos;

                        sl--;
                    }
                }
                // Если стек кончится до нахождения токена левая круглая скобка, то была пропущена скобка.
                if(!pe)
                {
                    printf("Error: parentheses mismatched\n");
                    return false;
                }
                // выкидываем токен "левая круглая скобка" из стека (не добавляем в очередь вывода).
                sl--;
                // Если на вершине стека токен - функция, положить его в очередь вывода.
            }
            else
            {
                printf("Unknown token %c\n", c);
                return false; // Unknown token
            }
        }
        ++strpos;
    }
    // Когда не осталось токенов на входе:
    // Если в стеке остались токены:
    while(sl > 0)
    {
        sc = stack[sl - 1];
        if(sc == '(' || sc == ')')
        {
            printf("Error: parentheses mismatched\n");
            return false;
        }
        *outpos = sc; ++outpos;
        --sl;
    }

    *outpos = 0; // Добавляем завершающий ноль к строке
    return true;
}
char posfix_stack_string(stack_string *s) //перенос постфиксной записи в стек c конца в начало (<-)
{
    int size_input=1, i=0;
    char *input = malloc(size_input), c, tmp[40];
    tmp[0]=0;
    printf("\n Введие арифметическое выражение: ");
    while ((c=getchar()) != EOF) 
    {
        size_input++;
        input = realloc(input, size_input);
        sprintf(input, "%s%c", input, c);

    }
    printf("\n\nВы ввели: %s", input);
    char *output=malloc(size_input*2);
    infix_to_postfix_algorithm(input, output, size_input);
    while (output[i]!='\0') // прочитываем постфиксную строку
    {
        if (is_ident(output[i]))  // если это цифра то добавляем её в временную строковую переменную
        {
            sprintf(tmp, "%s%c", tmp, output[i]);
        }
        else if (is_operator(output[i])) 
        {
            if (atoi(tmp)!=0) // если в строке число то кладем его в стек и очищаем переменную
                push_in_stack_string(&*s, tmp);
            tmp[0]=0;
            sprintf(tmp, "%s%c", tmp, output[i]); // кладем оператор в строку и кидаем в стек, а затем очищаем
            push_in_stack_string(&*s, tmp);
            tmp[0]=0;
        }
        else if (output[i]=' ' && atoi(tmp)!=0) // если разделитель и в строке число кидаем число в стек и очищаем переменную
        {
            push_in_stack_string(&*s, tmp);
            tmp[0]=0;
        }
        i++; 
    }
}
typedef struct tree //функции для дерева
{
    char key[40];
    struct tree* left;
    struct tree* right;
}node;
struct stack_item_node  // функции для стека из узлов
{
    node* data;
    struct stack_item_node* prev;
};
typedef struct
{
    struct stack_item_node* top;
    int size;
}stack_node;
void create_stack_node(stack_node *s) // присвоить начальные значения
{
    s->size=0;
    s->top=NULL;
}
bool empty_stack_node(stack_node *s) // проверка на пустоту
{
    return s->top==NULL;
}
int size_stack_node(stack_node *s) // размер стека
{
    return s->size;
}
bool push_in_stack_node(stack_node* s, node *data) // занос нового элемента в стек
{
    struct stack_item_node* tmp = malloc(sizeof(struct stack_item_node));
    if(!tmp)
        return false;
    tmp->data=data;
    tmp->prev=s->top;
    s->top=tmp;
    s->size++;
    return true;
}
bool pop_from_stack_node(stack_node* s) // изъятие первого элемента из стека
{
    if (!s->size)
        return false;
    struct stack_item_node* tmp = s->top;
    s->top=s->top->prev;
    s->size--;
    free(tmp);
    return true;
}
node* top_stack_node(stack_node *s) // первый элемент
{
    if(s->top)
        return s->top->data;
    else 
        return NULL;
}
void destroy_stack_node(stack_node* s) // удалить стек
{
    while(s->top)
    {
        struct stack_item_node* tmp=s->top;
        s->top=s->top->prev;
        free(tmp);
    }
    s->top=NULL;
    s->size=0;
}
node* string_to_node(char *s) //преобразование строки в ноду с ключом в виде этой строки
{
    node* tmp=(node*)malloc(sizeof(node));
    strcpy(tmp->key, s);
    tmp->left=NULL;
    tmp->right=NULL;
    return tmp;
}
node* string_to_tree(stack_string *input) //преобразование стека строк в дерево
{
    stack_node tree;
    node* tmp=(node*)malloc(sizeof(node));
    create_stack_node(&tree);
    while (!empty_stack_string(input))
    {
        if (atoi(top_stack_string(input))!=0)
            push_in_stack_node(&tree, string_to_node(top_stack_string(input)));
        else 
        {
            tmp=string_to_node(top_stack_string(input));
            tmp->right=top_stack_node(&tree);
            pop_from_stack_node(&tree);
            tmp->left=top_stack_node(&tree);
            pop_from_stack_node(&tree);
            push_in_stack_node(&tree, tmp);
        }
        pop_from_stack_string(input);
    }
    tmp=top_stack_node(&tree);
    destroy_stack_node(&tree);
    return tmp;
}
void tree_print(node* tree, int lrc) //печать дерева
{
        static int level = 0;
        int i;

        level++;
        if (tree){
                tree_print(tree->right, 2);
                for (i = 0; i<level; i++) printf("  ");
                if(lrc == 1) printf("\\_%s\n", tree->key);
                else if (lrc == 2) printf("__%s\n", tree->key);
                else printf("_%s\n", tree->key);
                tree_print(tree->left, 1);
        }
        level--;
}

void remove_div_one(node* tree) //удаление в дереве деление на 1
{
    if (tree) 
    {
        remove_div_one(tree->left);
        remove_div_one(tree->right);
        if (strcmp(tree->key, "/")==0 && strcmp(tree->right->key, "1")==0)
        {
            free(tree->right);
            *tree=*tree->left;
        }
    }
}
int pr_int(char c) //порядок действий
{
        switch(c)
        {
                case '-': case '+': return 1;
                case '*': case '/': case '^': return 2;
        }
}

void print_infix(node* tree, int priority_node) //распечатка инфиксной записи из дерева
{
        if(priority_node == 2) 
            printf("(");
        if(tree->left) 
        {
                if(!tree->left->left && !tree->left->right)
                    print_infix(tree->left, 1);
                else 
                    print_infix(tree->left, pr_int(tree->key[0]));
        }
        printf("%s", tree->key);
        if(tree->right) 
        {
                if(!tree->right->left && !tree->right->right)
                    print_infix(tree->right, 1);
                else 
                    print_infix(tree->right, pr_int(tree->key[0]));
        }
        if(priority_node == 2) 
            printf(")");
}
int main()
{
    stack_string input;
    node* tree = (node*)malloc(sizeof(node));
    create_stack_string(&input);
    posfix_stack_string(&input);
    reverse_stack_string(&input);
    tree=string_to_tree(&input);
    destroy_stack_string(&input);
    printf("\nПредставление в дереве:\n");
    tree_print(tree, 0);
    remove_div_one(tree);
    printf("\nДерево после преобразований: \n");
    tree_print(tree, 0);
    printf("\nВыражение после преобразований: \n");
    print_infix(tree, 1);
    printf("\n");
}