#include <stdio.h>
#include <stdlib.h>
typedef struct tree
{
    int key;
    struct tree* left;
    struct tree* right;
}node;
void create_tree(node **tree, int key)
{
    node *tmp = malloc(sizeof(node));
    tmp -> key = key;
    tmp -> left = NULL;
    tmp -> right = NULL;
    *tree = tmp;
}
void add_graph(node **tree, int key)
{
    node *tree2 = *tree;
    node *tree3 = NULL;
    node *tmp = malloc(sizeof(node));
    while (tree2 != NULL)
    {
        tree3 = tree2;
        if (key < tree2 -> key)
            tree2 = tree2 -> left;
        else
            tree2 = tree2 -> right;
    }
    tmp -> key = key;
    tmp -> left = NULL;
    tmp -> right = NULL;
    if (key < tree3 -> key)
        tree3 -> left = tmp;
    else
        tree3 -> right = tmp;
}
void tree_print(node *tree, int gap)
{
    if (tree == NULL)
        return;
    tree_print(tree -> right, gap+1);
    for (int i = 0; i < gap; ++i)
        printf(" ");
    printf("%d\n",tree -> key );
    tree_print(tree -> left, gap+1);
}
void inorder_count(node* root, int* count)
{
 if (root)
 {
    inorder_count(root->left, &*count);
    if (root->left)
    {
        (*count)++;
    }
    else
    {   
        (*count)++;

    }
    if (root->right)
    {    
        (*count)++;

    }
    else
    {    
        (*count)++;

    }    
    inorder_count(root->right, &*count);
 } 
}
void inorder_array(node* root, int* array, int* i)
{
 if (root)
 {
    inorder_array(root->left, array, &*i);
    if (root->left)
    {
        array[*i]=1;
        (*i)++;
    }
    else
    {   
        array[*i]=0;
        (*i)++;
    }
    if (root->right)
    {    
        array[*i]=1;
        (*i)++;
    }
    else
    {    
        array[*i]=0;
        (*i)++;
    }     inorder_array(root->right, array, &*i);
 } 
}
void *delete(node **root, int value)
{
    node *l = *root;
    while (l -> key != value)
    {

        if (value < l -> key)
            l = l -> left;
        else l = l -> right;
    }
    if (l -> left == NULL && l -> right == NULL)
    {
        node *root2 = *root;
        node *root3 = *root;
        while (1)
        {
            if (root2 -> left != NULL)
                if (root2 -> left -> key == value)
                    break;
            if (root2 -> right != NULL)
                if (root2 -> right -> key == value)
                    break;
            if (value < root2 -> key)
                root2 = root2 -> left;
            else root2 = root2 -> right;
            root3 = root2;
        }
        if (l == root3 -> right)
            root3 -> right = NULL;
        else root3 -> left = NULL;
        free(l);

    }
    if (l -> left == NULL && l -> right != NULL)
    {
        node *root2 = *root;
        node *root3 = *root;
        while (1)
        {
            if (root2 -> left != NULL)
                if (root2 -> left -> key == value)
                    break;
            if (root2 -> right != NULL)
                if (root2 -> right -> key == value)
                    break;
            if (value < root2 -> key)
                root2 = root2 -> left;
                    else root2 = root2 -> right;
                    root3 = root2;

        }
        if (l == root3 -> right) 
            root3 -> right = l -> right;
        else root3 -> left = l -> right;
        free(l);
    }

    if (l -> left != NULL && l -> right == NULL)
    {
        node *root2 = *root;
        node *root3 = *root;
        while (1)
        {
            if (root2 -> left != NULL)
                if (root2 -> left -> key == value)
                        break;
            if (root2 -> right != NULL)
                if (root2 -> right -> key == value)
                    break;
            if (value < root2 -> key)
                root2 = root2 -> left;
            else 
                root2 = root2 -> right;
            root3 = root2;
        }
        if (l == root3 -> right) 
            root3 -> right = l -> left;
        else 
            root3 -> left = l -> left;
        free(l);
    }
    if (l -> left != NULL && l -> right !=NULL)
    {
        node *root2 = l;
        while (1)
        {
            if (root2 -> right == NULL)
            {
                root2 = root2 -> left;
                while (root2 -> right != NULL)
                    root2 = root2 -> right;
            }
            if (root2 -> right != NULL)
            {    
                root2 = root2 -> right;
                while (root2 -> left != NULL)
                    root2 = root2 -> left;
            }
            break;
        }
        node *root3 = *root;
        node *root4 = *root;
        while (1)
        {
            if (root3 -> left != NULL)
                if (root3 -> left -> key == root2 -> key)
                    break;
            if (root3 -> right != NULL)
                if (root3 -> right -> key == root2 -> key)
                    break;
            if (value < root3 -> key)
                root3 = root3 -> left;
            else root3 = root3 -> right;
            root4 = root3;
        }
        l -> key = root2 -> key;
        if (root4 -> left -> key == root2 -> key)
        {
            if (root4 -> left -> left != NULL)
                root4 -> left = root4 -> left -> right;
            else if (root4 -> left -> right != NULL)
                root4 -> left = root4 -> left -> right;
            else 
                root4 -> left = NULL;
        }
        else 
        {
            if (root4 -> left -> right != NULL)
                root4 -> left = root4 -> left -> right;
            else if (root4 -> right -> right != NULL)
                root4 -> right = root4 -> right -> right;
            else root4 -> right = NULL;
        }
        free(root2);
    }
}
void print_menu()
{
    printf("\n1. Добавить узел.\n2. Напечатать дерево.\n3. Удалить узел.\n4. Проверить на самоподобие.\nВыберите действие: ");
}
void menu()
{
    int i, count, gap=0, act, graph,c,c2 ;
    node* tree;
    int* array=NULL;
    print_menu();
    while(scanf("%d", &act)!=EOF)
    {
        switch(act)
        {
        case 1:
            printf("\n");
            scanf("%d", &graph);
            if (tree==NULL)
                create_tree(&tree, graph);
            else
                add_graph(&tree, graph);
            print_menu();
            break;
        case 2:
            printf("\n");
            tree_print(tree, gap);
            print_menu();
            break;
        case 3:
            printf("\n");
            scanf("%d", &graph);
            delete(&tree, graph);
            print_menu();
            break;
        case 4:
            count=0; c=0; c2=0, i=0;
            printf("\n");
            inorder_count(tree, &count);
            array=(int*)realloc(array ,count*sizeof(int));
            inorder_array(tree, array, &i);
            c=count-1; c2=count;
            if (!tree->left || !tree->right)
            {
                printf("Дерево не самоподобное\n");
                free(array);
                print_menu();
                break;
            }
            else
            {
                for(int l = 0; l < count; l++)
                {
                    if (array[c]-array[l]==0)
                        c2--;
                    c--;
                }
                if (c2==0)
                    printf("Дерево самоподобное\n");
                else 
                    printf("Дерево не самоподобное\n");
                print_menu();
                free(array);
                printf("\n");
            }
            break;
        default:
            printf("\nПожалуйста, выберите один из представленных пунктов меню!\n");
            break;
        }
    }
}
int main()
{    
   menu();
}