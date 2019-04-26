#include <stdio.h>
#include <stdlib.h>
typedef struct tree
{
    int key;
    struct tree* left;
    struct tree* right;
    struct tree* parent;
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
    
node* search_graph(node* tree,int key)
{
    if ((tree == NULL) || (tree->key==key))
        return tree;
    if (key<tree->key)
        return search_graph(tree->left, key);
    else
        return search_graph(tree->right, key); 
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
node* min_graph(node *tree)
{
    node *min = tree;
    while (min -> left != NULL)
        min = min -> left;
    return min;
}
node *succ(node *root)
{
    node *p = root, *l = NULL;
// Если есть правое поддерево, то ищем минимальный элемент в этом поддереве
    if (p -> right != NULL)
        return min_graph(p -> right);
/* Правое дерево пусто, идем по родителям до тех пор,
пока не найдем родителя, для которого наше поддерево левое */
    l = p -> parent;
    while ((l != NULL) && (p == l -> right))
    {
        p = l;
        l = l -> parent;
    }
    return l;
}
node *delete(node *root, int key)
{
// Поиск удаляемого узла по ключу
    node *p = root, *l = NULL, *m = NULL;
    l = search_graph(root, key);
// 1 случай
    if ((l -> left == NULL) && (l -> right == NULL))
    {
        m = l -> parent;
        if (l == m -> right) m -> right == NULL;
        else m -> left == NULL;
        free(l);
    }
// 2 случай, 1 вариант - поддерево справа
    if ((l -> left == NULL) && (l -> right != NULL))
    {
        m = l -> parent;
        if (l == m -> right) m -> right == l -> right;
        else m -> left == l -> right;
        free(l);
    }
// 2 случай, 2 вариант - поддерево слева
    if ((l -> left != NULL) && (l -> right == NULL))
    {
        m = l -> parent;
        if (l == m -> right) m -> right == l -> left;
        else m -> left == l -> left;
        free(l);
    }
// 3 случай
    if ((l -> left != NULL) && (l -> right != NULL))
    {
        m = succ(l);
        l -> key = m -> key;
        if (m -> right == NULL)
            m -> parent -> left = NULL;
        else m -> parent -> left = m -> right;
        free(m);
    }
    return root;
}
void postorder(node *root, int *arr, int i)
{
    if (root == NULL)
        return;
    postorder(root -> left, arr, i++);
    postorder(root -> right, arr, i++);
    if (root -> key)
        arr[i]=1;
    else
        arr[i]=0;
    
}
int main()
{
    int arr[100];
    for (int i=0; i<100; i++)
        arr[i]=0;
    node* tree;
    node* lal;
    create_tree(&tree, 8);
    add_graph(&tree, 5);
    add_graph(&tree, 2);
    add_graph(&tree, 1);
    add_graph(&tree, 6);
    add_graph(&tree, 9);
    add_graph(&tree, 11);
    add_graph(&tree, 7);
    tree_print(tree, 1);
    postorder(tree,arr, 0);
    lal=succ(tree->right);
    for (int i=0; i<100; i++)
        printf(" %d ", arr[i]);
    printf("\n%d", lal->key);

}