#include <stdio.h>
#include <stdlib.h>
int main()
{
  int condition, count;
  int c;
  condition = 0;
  count = 0;
  c == ' ';
  printf("Enter the identifiers\n");
  while (condition != 3)
    {
      c = getchar();
      switch(condition)
	{
	case 0:
	  if (c == EOF) {condition = 3;}
	  else if (c == ' ' || c == ',' || c == '\n' || c == '\t')  {condition = 0;}
	  else if ( !((c<='Z' && c>='A')||(c<='z' && c>='a')||(c=='_')) ) {condition = 2;}
	  else if ( (c<='Z' && c>='A') || ( c<='z'&& c>='a') || ( c== '_')) {condition = 1;}
	  else {condition = 0;}
	  break;
	case 1:
	  if (c == EOF) {count++; condition = 3;}
	   else if ((c<='Z' && c>='A')||(c<='z' && c>='a')||(c=='_')||((c>='0')&&(c<='9'))) {condition = 1;}
	   else if (c == ' ' || c == ',' || c == '\n' || c == '\t')  {count++; condition = 0;}
	   else {condition = 2;}
	  break;
	case 2:
	  if (c == EOF) {condition = 3;}
	   else if  (c == ' ' || c == ',' || c == '\n' || c == '\t') { condition = 0;}
	    else {condition = 2;}
	  break;
	}
      
    }
  printf("\nCorrect identifiers: %d\n", count);
}
