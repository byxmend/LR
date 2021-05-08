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
    char date[20];
    struct node* pNext;
    struct node* pPrev;
} Node;

typedef struct informationAboutSchedule
{
    Node* head;
    Node* tail;
    Node* top;
} InformationAboutSchedule; 

void pushBack(InformationAboutSchedule* schedules, Node* node)
{
    node->pNext = NULL;
    node->pPrev = NULL;
    Node* currant = (Node*)malloc(sizeof(Node));

    currant->flightNumber = node->flightNumber;
    currant->typeOfPlane = node->typeOfPlane;
    strcpy(currant->startLocation, node->startLocation);
    strcpy(currant->finishLocation, node->finishLocation);
    strcpy(currant->place, node->place);
    strcpy(currant->time, node->time);
    strcpy(currant->date, node->date);

    currant->pNext = NULL;
    currant->pPrev = NULL;

    if (schedules->head == NULL)
    {
        schedules->head = currant;
        schedules->top = currant;
        schedules->tail = currant;
    }
    else
    {
        currant->pPrev = schedules->top;
        schedules->top->pNext = currant;
        schedules->top = currant;
        schedules->tail = currant;
    }
}

void printElementOfList(InformationAboutSchedule schedules, int counter)
{
    Node* p = schedules.head;

    for (int i = 0; i < counter; i++)
    {
        p = p->pNext;
    }

    printf("\n1. Flight number: %d", p->flightNumber);
    printf("\n2. Type of plane: %d", p->typeOfPlane);
    printf("\n3. Start location: %s", p->startLocation);
    printf("\n4. Finish location: %s", p->finishLocation);
    printf("\n5. Place: %s", p->place);
    printf("\n6. Time: %s", p->time);
    printf("\n7. Date: %s", p->date);
}

// flightNumber
void findByFlightNumber(InformationAboutSchedule schedules, int numb)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (p->flightNumber == numb)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// typeOfPlane
void findByTypeOfPlane(InformationAboutSchedule schedules, int numb)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (p->typeOfPlane == numb)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// startLocation
void findByStartLocation(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->startLocation) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// finishLocation
void findByFinishLocation(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->finishLocation) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// place
void findByPlace(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->place) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// time
void findByTime(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->time) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

// date
void findByDate(InformationAboutSchedule schedules, char* str)
{
    Node* p = schedules.head;
    int counter = 0;

    while (p != NULL)
    {
        if (strcmp(str, p->date) == 0)
        {
            printElementOfList(schedules, counter);
        }

        p = p->pNext;
        counter++;
    }
}

void menu()
{
    printf("\n1 - Find (flightNumber)\n");
    printf("2 - Find (typeOfPlane)\n");
    printf("3 - Find (startLocation)\n");
    printf("4 - Find (finishLocation)\n");
    printf("5 - Find (place)\n");
    printf("6 - Find (time)\n");
    printf("7 - Find (day)\n");
    printf("8 - Find the nearest flight\n");
    printf("9 - Book a ticket\n");
    printf("10 - Hand over your ticket\n");
    printf("11 - Number of available seats\n");
    // printf("12 - Print ticket\n");
    printf("Other - exit\n");
}

int main()
{
    char buffer[N]; // strings from the file are stored here
    char str[200];
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
        fgets(str, 200, filePrint);

        char* s = strtok_s(str, ",", &next);
        
        Node currant = { 0, 0, "", "", "", "", "", NULL, NULL };
        
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
                strcat(currant.date, s);
                break;
            }

            count++;
        } while (s = strtok_s(0, ",", &next));

        count = 0;

        pushBack(&schedules, &currant);
    }

    // findByFlightNumber(schedules, 1);
    // findByTypeOfPlane(schedules, 200);
    // findByStartLocation(schedules, "London");
    // findByFinishLocation(schedules, "Warsaw");
    // findByPlace(schedules, "Prague");
    // findByTime(schedules, "20:45");
    //  TODO: strcat(\n\n\n\n\n\n\n\n\n)
    // findByDate(schedules, "05.06\n");

    return 0;
}