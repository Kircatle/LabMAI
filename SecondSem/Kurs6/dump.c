#include <stdio.h>
#include <string.h>
#include <errno.h>
#include "pass.h"
void warning()
{
    printf("Предупреждение: неккоректный ввод, могут возникнуть проблемы в выполнении работы программы\n");
}
void war(int argc)
{
     if (argc!=3) 
    {
        warning();
    }
}
int readpass(pass *p,FILE *input)
{
    return fscanf(input,"%s%s%d%f%s%s%s%s", p->name, p->initials, &p->num_cloth, &p->weight_cloth, p->point, p->time, p->trans, p->childs)!=EOF;
} 

int main(int argc, char* argv[])
{
    war(argc);
    pass p;
    FILE *input;
    FILE *output;
    output = fopen(argv[2], "wb");
    input = fopen(argv[1], "r");
    while(readpass(&p, input))
        fwrite(&p,sizeof(p),1,output);
    fclose(input);
    fclose(output);
}

