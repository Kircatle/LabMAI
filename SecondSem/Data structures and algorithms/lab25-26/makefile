# makefile 1
CC=cc # имя компилятора 
LD=cc # имя редактора связей
LDFLAGS = -o # флаги для редактора связей
CCFLAGS = -c # флаги для компилятора
lab25_26: main.o list.o
	$(LD) $(LDFLAGS) lab25_26 main.o list.o
main.o: main.c list.h
	$(CC) $(CCFLAGS) main.c
list.o: list.c
	$(CC) $(CCFLAGS) list.c