#include <stdio.h>
#include "pass.h"
void war(int argc)
{
     if (argc!=3) 
        printf("Предупреждение: неккоректный ввод, могут возникнуть проблемы в выполнении работы программы\n");
    else
        printf("Конвертация прошла успещно.\n");
}
void binary(char* *argv)
{
    pass p;
    FILE *input;
    FILE *output;
    output = fopen(argv[2], "wb");
    input = fopen(argv[1], "r");
    while(fscanf(input,"%s %s %d %f %s %s %s %s", p.name, p.initials, &p.num_cloth, &p.weight_cloth, p.point, p.time, p.trans, p.childs)!=EOF)
        fwrite(&p,sizeof(p),1,output);
    fclose(input);
    fclose(output);
}
int main(int argc, char* argv[])
{
    war(argc);
    binary(argv);
}

