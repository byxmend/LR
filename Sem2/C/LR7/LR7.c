#define _CRT_SECURE_NO_WARNINGS

#include<stdio.h>
#include<math.h>
#include<stdlib.h>
#include<string.h>
#include<malloc.h>

#define N 20

typedef struct node
{
	int flightNumber;
	int typeOfPlane; // number of seats
	char startLocation[20];
	char finishLocation[20];
	char place[20];
	char time[20];
	char day[20];
	struct node* pNext;
	struct node* pPrev;
} Node;

typedef struct informationAboutSchedule
{
	Node* head;
	Node* tail;
	Node* top;
} InformationAboutSchedule; 



void pushBack(InformationAboutContributors* users, Node* node) {
	node->pNext = NULL;
	node->pPrev = NULL;
	Node* currant = (Node*)malloc(sizeof(Node));

	currant->accountNumber = node->accountNumber;
	currant->currentDepositAmount = node->currentDepositAmount;
	strcpy(currant->lastOperationWithAcoount, node->lastOperationWithAcoount);
	strcpy(currant->passportData, node->passportData);
	strcpy(currant->typeOfCapitalization, node->typeOfCapitalization);
	strcpy(currant->typeOfContribution, node->typeOfContribution);

	currant->pNext = NULL;
	currant->pPrev = NULL;

	if (users->head == NULL) {
		users->head = currant;
		users->top = currant;
	}
	else
	{
		currant->pPrev = users->top;
		users->top->pNext = currant;
		users->top = currant;
	}
}



int main()
{
	// int counter = 0;
	char buffer[N]; // strings from the file are stored here
	char str[20];
	char* next = 0;
	int count = 0;

	InformationAboutSchedule schedules = { NULL, NULL, NULL };

	FILE* filePrint;
	FILE* fileWrite;

	// open filePrint
	int errOpenFilePrint = fopen_s(&filePrint, "filePrint.txt", "r");

	if (errOpenFilePrint != 0)
	{
		exit(1);
	}

	// open fileWrite
	int errOpenFileWrite = fopen_s(&fileWrite, "fileWrite.txt", "w");

	if (errOpenFileWrite != 0)
	{
		exit(1);
	}

	// Fill the list from filePrint

	while (!feof(filePrint))
	{
		fgets(str, 20, filePrint);

		char* s = strtok_s(str, ",", &next);
		
		Node currant = { 0, 0, "", "", "", "", "", NULL };
		
		do {
			switch (count)
			{
			case 0:
				currant.flightNumber = atoi(s);
				break;
			case 1:
				currant.typeOfPlane = atoi(s);
				break;
			case 2:
				strcat(currant.startLocation, s);
				break;
			case 3:
				strcat(currant.finishLocation, s);
				break;
			case 4:
				strcat(currant.place, s);
				break;
			case 5:
				strcat(currant.time, s);
				break;
			case 6:
				strcat(currant.day, s);
				break;
			}

			count++;
		} while (s = strtok_s(0, ",", &next));

		count = 0;

		pushBack(&schedules, &currant);
	}


}