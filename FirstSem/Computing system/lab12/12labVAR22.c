#include <stdio.h>
#include <stdlib.h>
int main(void) 
{
	int num, size, numS, ldight, nnum, discharges,n;
	num = 0;
	while (num != EOF) 
	{
		printf("Number: ");
		scanf("%d", &num);
		if (num == 0) {printf("EOF\n");exit(1);}
		numS = num;
		size = 0; nnum = 0; 
		while (numS != 0) 
		{
			numS = numS/10;
			size++;
		}
		for (int i = 1; i<=size; i++)
		{
			n = i;
			ldight = num%10;
			num = num/10;
			discharges = 1;
			if (ldight%2 != 0)
			{		
				while  (n>1)
				{
					discharges*=10;
					n--;
				}
			nnum = nnum+discharges*ldight;
			}	
			else 
			{
				i--;
				size--;
			}
		}	
		printf("Answer: %d\n\n", nnum);
	}
}