#include <stdio.h>
#include <ctype.h>
#define vow (1u<<('a'-'a')|1u<<('e'-'a')|1u<<('i'-'a')|1u<<('o'-'a')|1u<<('u'-'a')|1u<<('y'- 'a'))
#define gap (1u<<(31))
unsigned int char_to_set(char c)
{
	c = tolower(c);
	if ((c < 'a' || c > 'z') && c != ',' && c != '\t' && c != ' ' && c != '\n')
	{
		return 0;
	}
	else if (c >= 'a' && c <= 'z')
	{
		return 1u << (c - 'a');
	}
	else
	{
		return(1u << (31));
	}
}
unsigned int letters_gap(unsigned int slovo1)
{
	if ((slovo1&gap) == 0)
		return slovo1;
	else
	return 0;
}

unsigned int letters_ncon(unsigned int slovo1)
{
	unsigned int slovo2;
	slovo2 = slovo1&vow;
	return slovo2;
}

unsigned int letters_ngap(unsigned int slovo1)
{
	slovo1 = slovo1 & (~gap);
	return slovo1;
}

unsigned int letters_check(unsigned int slovo1)
{
	unsigned int sym;
	int con = 0;
	for (int i = 'a'; i <= 'z'; i++)
	{
		sym = (1u << (i - 'a'));
		if ((sym&slovo1)>0) con++;
	}

	return con;
}			

int main()
{
	int c, count = 0;
	unsigned int letters_set = 0;
	printf("Words:\n");
	while ((c = getchar()) != EOF)
	{
	
		letters_set = letters_set | char_to_set(c);
		if (letters_gap(letters_set) == 0)
		{
			letters_set = letters_ngap(letters_set);
			letters_set = letters_ncon(letters_set);
			if (letters_check(letters_set) == 1)
			{
				count++;
			}
			letters_set = 0;
		}
	}
	if (letters_gap(letters_set) !=0)
	{	
		letters_set = letters_ngap(letters_set);
			letters_set = letters_ncon(letters_set);
			if (letters_check(letters_set) == 1)
			{
				count++;
			}
	}
	printf("\ncount = %d\n", count);
}